namespace SeminarHub.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using Microsoft.AspNetCore.Authorization;

    using SeminarHub.Data.Models;
    using Models;
    using Data;
    using Extensions;
    using static Data.ValidationConstants;


    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext dbContext;
        public SeminarController(SeminarHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Visualizing all current seminars through "All seminars" button
        [HttpGet]
        public async Task<IActionResult> All()
        {
            //Gathering all the current Seminars
            ICollection<AllModel> allModels = await this.dbContext.Seminars
                .AsNoTracking()
                .Where(s => s.IsDeleted == false)
                .Select(s => new AllModel()
            {
                Id = s.Id,
                Topic = s.Topic,
                Lecturer = s.Lecturer,
                Organizer = s.Organizer.UserName,
                Category = s.Category.Name,
                DateAndTime = s.DateAndTime.ToString(DateFormat),
            }).ToListAsync();

            return View(allModels);
        }

        //Adding a Seminar through "Announce new" button
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //Creating an empty model with available categories
            AddModel addModel = new AddModel()
            {
                Categories = await GetCategories() 
            };

            return View(addModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddModel addModel)
        {
            DateTime dateAndTime;

            //Checking for invalid date formatting
            if (!DateTime.TryParseExact(addModel.DateAndTime, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateAndTime))
            {
                ModelState.AddModelError(nameof(addModel.DateAndTime), $"Invalid date! Format must be {DateFormat}!");
            }

            //Checking for invalid category id in model
            if (!await this.dbContext.Categories.AnyAsync(c => c.Id == addModel.CategoryId))
            {
                return BadRequest();
            }

            //Check for eventual errors in modelState
            if (!ModelState.IsValid)
            {
                List<string> errorMessages = new List<string>();
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        errorMessages.Add(error.ErrorMessage);
                    }
                }

                addModel.Categories = await GetCategories();
                return View(addModel);
            }

            Data.Models.Seminar seminar = new Data.Models.Seminar()
            {
                Topic = addModel.Topic,
                Lecturer = addModel.Lecturer,
                Details = addModel.Details,
                OrganizerId = User.GetUserId(),
                CategoryId = addModel.CategoryId,
                Duration = addModel.Duration,
                DateAndTime = dateAndTime
            };

            //Adding Seminar to Db
            await this.dbContext.Seminars.AddAsync(seminar);
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        //Editing Seminar only if current User is it's organizer
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //Searching the Seminar that the User wants to edit
            Data.Models.Seminar? searchedSeminar = await dbContext.Seminars
                .AsNoTracking()
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            //Seminar is not found
            if (searchedSeminar == null)
            {
                return BadRequest();
            }

            //If the User tries to edit a Seminar, which is not his
            if (searchedSeminar.OrganizerId != User.GetUserId())
            {
                return Unauthorized();
            }


            //Filling the edit form and returning it to the view
            EditModel? seminarToEdit = await this.dbContext.Seminars
                .Where(s => s.Id == id)
                .AsNoTracking().Select(s => new EditModel()
            {
                Id = s.Id,
                Topic = s.Topic,
                Lecturer = s.Lecturer,
                Details = s.Details,
                DateAndTime = s.DateAndTime.ToString(DateFormat),
                Duration = s.Duration,
                CategoryId = s.CategoryId
            }).FirstOrDefaultAsync();

            //Checking for null
            if (seminarToEdit == null)
            {
                return BadRequest();
            }

            seminarToEdit.Categories = await GetCategories();
            return View(seminarToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditModel seminarToEdit)
        {
            //Null Validation
            if (seminarToEdit == null)
            {
                return BadRequest();
            }

            DateTime dateAndTime;

            //Checking for invalid date formatting
            if (!DateTime.TryParseExact(seminarToEdit.DateAndTime, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateAndTime))
            {
                ModelState.AddModelError(nameof(seminarToEdit.DateAndTime), $"Invalid date! Format must be {DateFormat}!");
            }

            if (!ModelState.IsValid)
            {
                //This is used to show the error messages of the modelState
                List<string> errorMessages = new List<string>();
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        errorMessages.Add(error.ErrorMessage);
                    }
                }

                seminarToEdit.Categories = await GetCategories();
                return View(seminarToEdit);
            }

            Data.Models.Seminar? seminar =
                await this.dbContext.Seminars.Where(s => s.Id == seminarToEdit.Id)
                    .FirstOrDefaultAsync();

            //Null validating and editing the Seminar with new data
            if (seminar == null)
            {
                return BadRequest();
            }


            seminar.Topic = seminarToEdit.Topic;
            seminar.Lecturer = seminarToEdit.Lecturer;
            seminar.Duration = seminarToEdit.Duration;
            seminar.DateAndTime = dateAndTime;
            seminar.Details = seminarToEdit.Details;
            seminar.CategoryId = seminarToEdit.CategoryId;

            await this.dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        //User adding a Seminar to his collection via "Subscribe" button 
        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            //Checking if there is no seminar with given id
            if (!await this.dbContext.Seminars.AnyAsync(s => s.Id == id))
            {
                return BadRequest();
            }

            //Checking if User is trying to join second time Seminar
            if (await this.dbContext.SeminarsParticipants
                    .AnyAsync(sp => sp.SeminarId == id && sp.ParticipantId == User.GetUserId()))
            {
                return RedirectToAction(nameof(All));
            }

            SeminarParticipant sp = new SeminarParticipant()
            {
                SeminarId = id,
                ParticipantId = User.GetUserId(),
            };

            //Successfully adding a Seminar to User's collection
            await this.dbContext.SeminarsParticipants.AddAsync(sp);
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }

        //Visualizing all the joined Seminars of current User's collection
        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            //Collecting only seminars that current User is subscribed to and converting them to view models
            ICollection<JoinedModel> joinedModels = await this.dbContext.SeminarsParticipants
                .AsNoTracking()
                .Where(sp => sp.ParticipantId == User.GetUserId() && sp.Seminar.IsDeleted == false )
                .Select(sp => new JoinedModel()
                {
                    Id = sp.SeminarId,
                    Organizer = sp.ParticipantId,
                    Topic = sp.Seminar.Topic,
                    Lecturer = sp.Seminar.Lecturer,
                    DateAndTime = sp.Seminar.DateAndTime.ToString(DateFormat)
                }).ToListAsync();

            return View(joinedModels);
        }

        //User leaving joined Seminar through the "Unsubscribe" button
        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            //Checking if there is no Seminar with given id
            if (!await this.dbContext.SeminarsParticipants
                    .AnyAsync(sp => sp.SeminarId == id  && sp.ParticipantId == User.GetUserId()))
            {
                return BadRequest();
            }

            SeminarParticipant? sp = await this.dbContext.SeminarsParticipants
                .Where(sp => sp.SeminarId == id && sp.ParticipantId == User.GetUserId()).FirstOrDefaultAsync();

            //Null validation
            if (sp == null)
            {
                return BadRequest();
            }

            //Removing the Seminar from current User's collection
            this.dbContext.SeminarsParticipants.Remove(sp);
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }

        //Asking the User if he wants to delete Seminar he is the organizer of 
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //Searching the Seminar that the User wants to delete
            var seminar = await dbContext.Seminars
                .AsNoTracking()
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            //Seminar is not found
            if (seminar == null)
            {
                return BadRequest();
            }

            //If the User tries to delete a Seminar, which is not his
            if (seminar.OrganizerId != User.GetUserId())
            {
                return Unauthorized();
            }

            DeleteModel deleteModel = new DeleteModel()
            {
                Id = seminar.Id,
                Topic = seminar.Topic,
                DateAndTime = seminar.DateAndTime.ToString(DateFormat),
            };

            return View(deleteModel);
        }

        //Confirming the deletion of Seminar
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //Searching the Seminar that the User wants to delete
            var seminar = await dbContext.Seminars
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            //Seminar is not found
            if (seminar == null)
            {
                return BadRequest();
            }

            //If the User tries to delete a Seminar, which is not his
            if (seminar.OrganizerId != User.GetUserId())
            {
                return Unauthorized();
            }

            //Not actually deleting a record but raising IsDeleted flag
            seminar.IsDeleted = true;
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        //Showing detailed data and options for a Seminar through "Details" button
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            DetailsModel? detailsModel = await this.dbContext.Seminars.Where(s => s.Id == id)
                .AsNoTracking()
                .Select(s => new DetailsModel()
            {
                Id = s.Id,
                Topic = s.Topic,
                Lecturer = s.Lecturer,
                DateAndTime = s.DateAndTime.ToString(DateFormat),
                Duration = s.Duration,
                Details = s.Details,
                Organizer = s.Organizer.UserName,
                Category = s.Category.Name
            }).FirstOrDefaultAsync();

            if (detailsModel == null)
            {
                return BadRequest();
            }

            return View(detailsModel);
        }
        
        //Gets all the available categories in the Db
        public async Task<ICollection<CategoryViewModel>> GetCategories()
        {
            ICollection<CategoryViewModel> categories = await this.dbContext.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToListAsync();

            return categories;
        }
    }
}
