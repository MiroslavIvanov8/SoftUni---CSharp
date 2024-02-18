namespace SeminarHub.Data
{
    public static class ValidationConstants
    {
        public const string DateFormat = "dd.MM.yyyy HH:mm";
        public static class Seminar
        {
            public const int SeminarTopicMaxLength = 100;
            public const int SeminarTopicMinLength = 3;

            
            public const int LecturerNameMaxLength = 60;
            public const int LecturerNameMinLength = 5;

            public const int DetailsMaxLength = 500;
            public const int DetailsMinLength = 10;

            public const int DurationMinLength = 30;
            public const int DurationMaxLength = 180;
        }

        public static class Category
        {
            public const int CategoryNameMaxLength = 50;
            public const int CategoryNameMinLength = 3;
        }
    }
}
