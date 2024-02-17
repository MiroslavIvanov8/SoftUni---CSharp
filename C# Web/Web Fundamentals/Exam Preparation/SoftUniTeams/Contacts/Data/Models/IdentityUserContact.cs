namespace Contacts.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    public class IdentityUserContact
    {
        [ForeignKey(nameof(IdentityUser))] 
        public string IdentityUserId { get; set; } = null!;
        public IdentityUser IdentityUser { get; set; } = null!;


        [ForeignKey(nameof(Contact))]
        public int ContactId { get; set; }
        public Contact Contact { get; set; } = null!;


    }
}