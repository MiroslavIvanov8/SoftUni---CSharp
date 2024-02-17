namespace Contacts.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Extensions;
    using Contracts;
    using Models;
    

    [Authorize]
    public class ContactsController : Controller
    {
        private readonly IContactsService contactsService;

        public ContactsController(IContactsService contactService)
        {
            this.contactsService = contactService;
        }

        //Visualizing all the current contacts as a home
        [HttpGet]
        public async Task<IActionResult> All()
        {
            ICollection<ContactViewModel> viewModels = await contactsService.GetAllAsync();

            return View(viewModels);
        }

        //Adding a contact to the app through "Add a contact" button
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ContactViewModel viewModel = await this.contactsService.AddContactViewModelAsync();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactViewModel viewModel)
        {
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
                
                return View(viewModel);
            }

            await this.contactsService.AddContactAsync(User.GetUserId(),viewModel);

            return RedirectToAction("All" ,"Contacts");
        }

        //Editing an existing model and loading its previous data
        [HttpGet]
        public async Task<IActionResult> Edit(int contactId)
        {
            ContactViewModel viewModel = await this.contactsService.GetEditBookModelAsync(contactId);

            if (viewModel == null)
            {
                return BadRequest();
            }

            if (viewModel.Creator != User.GetUserId())
            {
                return Unauthorized();
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactViewModel viewModel)
        {
            viewModel.Creator = User.GetUserId();

            if (viewModel == null)
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

                return View(viewModel);
            }

            await this.contactsService.EditBookAsync(viewModel);

            return RedirectToAction("All");
        }

        //Adding a contact to current user's team via "Add to team" button
        [HttpPost]
        public async Task<IActionResult> AddToTeam(int contactId)
        {
            string currentUserId = User.GetUserId();

            await this.contactsService.AddContactToTeamAsync(contactId, currentUserId);
            
            return RedirectToAction("All");
        }

        //Visualizing all contacts in the current user's team through "My Team" button
        [HttpGet]
        public async Task<IActionResult> Team()
        {
            return View(await this.contactsService.GetMyTeamAsync(User.GetUserId()));
        }

        //Removing a contact from the current user's team through "Remove from team" button
        [HttpPost]
        public async Task<IActionResult> RemoveFromTeam(int contactId)
        {
            await this.contactsService.RemoveFromTeamAsync(User.GetUserId(), contactId);

            return RedirectToAction("Team");
        }
    }
}
