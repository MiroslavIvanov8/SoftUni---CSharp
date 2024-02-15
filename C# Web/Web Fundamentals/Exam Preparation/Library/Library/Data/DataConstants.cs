namespace Library.Data
{
    public class DataConstants
    {
        public static class Book
        {
            public const int BookTitleMaxLength = 50;
            public const int BookTitleMinLength = 10;

            public const int BookAuthorMaxLength = 50;
            public const int BookAuthorMinLength = 5;

            public const int BookDescriptionMaxLength = 5000;
            public const int BookDescriptionMinLength = 5;

            public const double BookMaxRating = 10.00;
            public const double BookMinRating = 0.00;

        }

        public static class Category
        {
            public const int CategoryNameMaxLength = 50;
            public const int CategoryNameMinLength = 5;
        }
    }
}
