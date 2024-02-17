namespace Contacts.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Contact;
    public class Contact
    {
        public Contact()
        {
            this.ApplicationUsersContacts = new HashSet<IdentityUserContact>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ContactFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(ContactLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(ContactEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(ContactPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;
        
        public string? Address { get; set; }

        [Required]
        public string CreatorId { get; set; } = null!;

        [Required]
        public IdentityUser Creator { get; set; } = null!;


        [Required]
        public string Website { get; set; } = null!;
        
        public ICollection<IdentityUserContact> ApplicationUsersContacts { get; set; }
        

    }
}
