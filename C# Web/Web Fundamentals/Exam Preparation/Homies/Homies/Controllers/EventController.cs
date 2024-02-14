

using DataConstants = Homies.Data.DataConstants;

namespace Homies.Controllers
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Globalization;
    using System.Runtime.Serialization;

    using Homies.Data.Models;
    using Models.Event;
    using Data;
    using Extensions;
    using DataConstants = Homies.Data.DataConstants;
    


    [Authorize]
    public class EventController : Controller
    {
        private readonly HomiesDbContext dbContext;


        public EventController(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ICollection<EventViewModel> viewModels = await this.dbContext
                .Events
                .Select(e => new EventViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Type = e.Type.Name,
                    Organiser = e.Organizer.UserName,
                    Start = e.Start.ToString(DataConstants.DateTimeFormat),
                })
                .ToListAsync();

            return View(viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            EventFormModel formModel = new EventFormModel()
            {
                Types = await GetTypes()
            };

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormModel formModel)
        {
            string currentUserId = User.GetUserId();

            if (formModel == null)
            {
                return BadRequest();
            }

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
            }

            Event model = new Event()
            {
                Name = formModel.Name,
                Description = formModel.Description,
                OrganizerId = currentUserId,
                CreatedOn = DateTime.Now,
                Start = DateTime.Parse(formModel.Start),
                End = DateTime.Parse(formModel.End),
                TypeId = formModel.TypeId,
                EventsParticipants = new List<EventParticipant>()
            };

            await this.dbContext.Events.AddAsync(model);
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Event? model = await this.dbContext.Events
                .Include(@event => @event.Organizer)
                .Include(@event => @event.Type)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (model == null)
            {
                ModelState.AddModelError("","Invalid event Id.");
                RedirectToAction("All", "Event");
            }

            EventDetailModel detailModel = new EventDetailModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Start = model.Start,
                End = model.End,
                Organiser = model.Organizer.UserName,
                CreatedOn = model.CreatedOn,
                Type = model.Type.Name,
            };

            return View(detailModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Event? model = await this.dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);

            if (model == null)
            {
                ModelState.AddModelError("","Invalid event Id.");
                return View();
            }

            EventFormModel formModel = new EventFormModel()
            {
                Id = id,
                Name = model.Name,
                Description = model.Description,
                Start = model.Start.ToString(DataConstants.DateTimeFormat),
                End = model.End.ToString(DataConstants.DateTimeFormat),
                Types = await GetTypes()
            };

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventFormModel formModel)
        {
            if (formModel == null)
            {
                ModelState.AddModelError("","Unsuccessful data binding.");
                return BadRequest();
            }

            //Dates Validation
            DateTime startDate;
            DateTime endDate;

            if (!DateTime.TryParseExact(formModel.Start, DataConstants.DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
            {
                ModelState.AddModelError(nameof(formModel.Start), $"Invalid date! Format must be {DataConstants.DateTimeFormat}!");
            }
            if (!DateTime.TryParseExact(formModel.End, DataConstants.DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
            {
                ModelState.AddModelError(nameof(formModel.End), $"Invalid date! Format must be {DataConstants.DateTimeFormat}!");
            }

            if (!ModelState.IsValid)
            {
                //This is used to show the error messages of the ModelState
                List<string> errorMessages = new List<string>();
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        errorMessages.Add(error.ErrorMessage);
                    }
                }

                formModel.Types = await GetTypes();
                return View(formModel);
            }

            Event? editModel = await this.dbContext.Events.FirstOrDefaultAsync(e => e.Id == formModel.Id);

            if (editModel == null)
            {
                return BadRequest();
            }

            editModel.Name = formModel.Name;
            editModel.Description = formModel.Description;
            editModel.Start = startDate;
            editModel.End = endDate;
            editModel.Id = formModel.Id;

            await this.dbContext.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            string currentUserId = User.GetUserId();

            Event? eventModel = await this.dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);

            if (eventModel == null)
            {
                return RedirectToAction("All", "Event");
            }

            if (await this.dbContext.EventsParticipants.AnyAsync(e => e.EventId == eventModel.Id && e.HelperId == currentUserId))
            {
                return RedirectToAction("All", "Event");
            }

            eventModel.EventsParticipants.Add(new EventParticipant()
            {
                HelperId = currentUserId,
                EventId = id
            });
            
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction("Joined", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string currentUserId = User.GetUserId();

            ICollection<EventViewModel> viewModels = await this.dbContext.Events
                .Where(e => e.EventsParticipants.Any(p => p.HelperId == currentUserId))
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString(DataConstants.DateTimeFormat),
                    Type = e.Type.Name,
                }).ToListAsync();

            return View(viewModels);
        }

        
        public async Task<IActionResult> Leave(int id)
        {
            string currentUserId = User.GetUserId();

            if (!await this.dbContext.Events.AnyAsync(e => e.Id == id))
            {
                ModelState.AddModelError("", "Invalid event Id.");
                return RedirectToAction("Joined", "Event");
            }

            EventParticipant? participant =
                await this.dbContext.EventsParticipants
                    .FirstOrDefaultAsync(e => e.EventId == id && e.HelperId == currentUserId);

            if (participant == null)
            {
                ModelState.AddModelError("", "Wrong event Id or User Id.");
                return RedirectToAction("Joined", "Event");
            }
            
            this.dbContext.EventsParticipants.Remove(participant);
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Event");

        }
        
        public async Task<IActionResult> Delete(int id)
        {
            // if there is no event with given id
            if (!await this.dbContext.Events.AnyAsync(e => e.Id == id))
            {
                return BadRequest();
            }

            Event? modelToDelete = await this.dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);

            // null check
            if(modelToDelete == null)
            {
                return BadRequest();
            }

            string currentUserId = User.GetUserId();
            // if the user is not the creator of the given event
            if (currentUserId != modelToDelete.OrganizerId)
            {
                return Unauthorized();
            }

            var eventParticipants = await dbContext.EventsParticipants
                .Where(ep => ep.EventId == id)
                .ToListAsync();

            if (eventParticipants != null && eventParticipants.Any())
            {
                dbContext.EventsParticipants.RemoveRange(eventParticipants);
            }
            
            this.dbContext.Events.Remove(modelToDelete);
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction("All");
        }

        private async Task<ICollection<EventTypeModel>> GetTypes()
        {
            return await dbContext.Types
                .Select(t => new EventTypeModel()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }
    }
}
    
    
