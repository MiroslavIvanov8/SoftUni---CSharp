using Contacts.Models;

namespace Contacts.Contracts
{
    public interface IContactsService
    {
        Task<ICollection<ContactViewModel>> GetAllAsync();
        Task<ContactViewModel> AddContactViewModelAsync();
        Task AddContactAsync(string creatorId, ContactViewModel viewmodel);
        Task<ContactViewModel> GetEditBookModelAsync(int contactId);
        Task EditBookAsync(ContactViewModel viewModel);

        Task<bool> AddContactToTeamAsync(int contactId, string userId);
        Task<ICollection<ContactViewModel>> GetMyTeamAsync(string userId);
        Task RemoveFromTeamAsync(string userId, int contactId);
    }
}
