namespace Contacts.Data
{
    public static class DataConstants
    {
        public static class InputUser
        {
            public const int InputUserNameMaxLength = 50;
            public const int InputUserNameMinLength = 5;
        }

        public static class Contact
        {
            public const int ContactFirstNameMaxLength = 50;
            public const int ContactFirstNameMinLength = 2;

            public const int ContactLastNameMaxLength = 50;
            public const int ContactLastNameMinLength = 5;

            public const int ContactEmailMaxLength = 60;
            public const int ContactEmailMinLength = 10;

            public const int ContactPhoneNumberMaxLength = 13;
            public const int ContactPhoneNumberMinLength = 10;
        }

        public static class RegexConstants
        {
            public const string WebSiteRegex = @"^www\.[a-zA-Z0-9-]+\.[bB][gG]$";

            public const string PhoneNumberRegex = @"^(?:\+359|0)[ -]?\d{3}[ -]?\d{2}[ -]?\d{2}[ -]?\d{2}$";
        }
    }
}
