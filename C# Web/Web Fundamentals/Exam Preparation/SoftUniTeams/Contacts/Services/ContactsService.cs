namespace Contacts.Services
{
    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Data;
    using Models;
    using Contacts.Data.Models;
    using Contact = Data.Models.Contact;

    public class ContactsService : IContactsService
    {
        private readonly ContactsDbContext dbContext;

        public ContactsService(ContactsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ICollection<ContactViewModel>> GetAllAsync()
        {
            ICollection<ContactViewModel> viewModels = await this.dbContext
                .Contacts.Select(c => new ContactViewModel()
                {
                    ContactId = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Creator = c.Creator.UserName,
                    Address = c.Address,
                    Website = c.Website,
                })
                .ToListAsync();
            return viewModels;
        }

        public async Task<ContactViewModel> AddContactViewModelAsync()
        {
            ContactViewModel viewModel = new ContactViewModel();

            return viewModel;
        }

        public async Task AddContactAsync(string creatorId, ContactViewModel viewmodel)
        {
            //checking if there is a valid user with given creatorId
            if (await this.dbContext.Users.AnyAsync(u => u.Id == creatorId))
            {
                Contact model = new Contact()
                {
                    FirstName = viewmodel.FirstName,
                    LastName = viewmodel.LastName,
                    Email = viewmodel.Email,
                    PhoneNumber = viewmodel.PhoneNumber,
                    CreatorId = creatorId,
                    Website = viewmodel.Website,
                    Address = viewmodel.Address,
                };

                await this.dbContext.Contacts.AddAsync(model);
                await this.dbContext.SaveChangesAsync();
            }
            
        }

        public async Task<ContactViewModel> GetEditBookModelAsync(int contactId)
        { 
            // checking if there is a contact with given id
            if (await this.dbContext.Contacts.AnyAsync(c => c.Id == contactId))
            {
                ContactViewModel? viewModel = await this.dbContext
                    .Contacts
                    .Where(c => c.Id == contactId)
                    .Select(c => new ContactViewModel()
                    {
                        ContactId = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Email = c.Email,
                        PhoneNumber = c.PhoneNumber,
                        Address = c.Address,
                        Creator = c.Creator.Id,
                        Website = c.Website,
                    }).FirstOrDefaultAsync();

                return viewModel;
            }

            return null;
        }

        public async Task EditBookAsync(ContactViewModel viewModel)
        {
            if (await this.dbContext.Contacts.AnyAsync(c => c.Id == viewModel.ContactId))
            {
                Contact? model = await this.dbContext.Contacts.FindAsync(viewModel.ContactId);

                model.FirstName = viewModel.FirstName;
                model.LastName = viewModel.LastName;
                model.Email = viewModel.Email;
                model.PhoneNumber = viewModel.PhoneNumber;
                model.Address = viewModel.Address;
                model.Website = viewModel.Website;

                await this.dbContext.SaveChangesAsync();
            }

        }

        public async Task<bool> AddContactToTeamAsync(int contactId , string userId)
        {
            //Checking if user is trying to add second time a contact to his team
            if (await this.dbContext.IdentityUsersContacts.AnyAsync(c =>
                    c.ContactId == contactId && c.IdentityUserId == userId))
            {
                return false;
            }

            // checking if there is a contact with given id
            if (await this.dbContext.Contacts.AnyAsync(c => c.Id == contactId))
            {
                
                IdentityUserContact uc = new IdentityUserContact()
                {
                    IdentityUserId = userId,
                    ContactId = contactId
                };

                await this.dbContext.IdentityUsersContacts.AddAsync(uc);
                await this.dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<ICollection<ContactViewModel>> GetMyTeamAsync(string userId)
        {
            ICollection<ContactViewModel> viewModels = await this.dbContext
                .IdentityUsersContacts
                .Where(uc => uc.IdentityUserId == userId)
                .Select(uc => new ContactViewModel()
                {
                    ContactId = uc.ContactId,
                    FirstName = uc.Contact.FirstName,
                    LastName = uc.Contact.LastName,
                    Email = uc.Contact.Email,
                    PhoneNumber = uc.Contact.PhoneNumber,
                    Address = uc.Contact.Address,
                    Website = uc.Contact.Website,
                })
                .ToListAsync();

            return viewModels;
        }

        public async Task RemoveFromTeamAsync(string userId, int contactId)
        {
            IdentityUserContact? uc = await this.dbContext.IdentityUsersContacts
                .FirstOrDefaultAsync(uc => uc.IdentityUserId == userId && uc.ContactId == contactId);
            if (uc != null)
            {
                this.dbContext.IdentityUsersContacts.Remove(uc);
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
