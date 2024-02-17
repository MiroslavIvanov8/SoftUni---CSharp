namespace Contacts.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Contact;
    using static Data.DataConstants.RegexConstants;
    public class ContactViewModel
    {
        public int ContactId { get; set; }

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
        [RegularExpression(PhoneNumberRegex)]
        public string PhoneNumber { get; set; } = null!;

        public string? Address { get; set; }
        
        public string? Creator { get; set; } 

        [Required]
        [RegularExpression(WebSiteRegex)]
        public string Website { get; set; } = null!;

    }
}
