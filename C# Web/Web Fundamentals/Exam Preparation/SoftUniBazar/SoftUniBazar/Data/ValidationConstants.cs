namespace SoftUniBazar.Data
{
    public static class ValidationConstants
    {
        public const string DateFormat = "yyyy-MM-dd H:mm";
        public static class Ad
        {
            public const int AdNameMaxLength = 25;
            public const int AdNameMinLength = 5;

            public const int AdDescriptionMaxLength = 250;
            public const int AdDescriptionMinLength = 15;
        }

        public static class Category
        {
            public const int CategoryNameMaxLength = 15;
            public const int CategoryNameMinLength = 3;
        }
    }
}
