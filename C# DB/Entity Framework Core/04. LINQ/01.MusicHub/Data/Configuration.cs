namespace MusicHub.Data
{
    public static class Configuration
    {
        public static string ConnectionString =
            @"Server=.;Database=MusicHub;Trusted_Connection=True";

        public const int SongNameMaxLength = 20;

        public const int AlbumNameMaxLength = 40;

        public const int ProducerNameMaxLength = 30;

        public const int PerformerNameMaxLength = 20;

        public const int WriterNameMaxLength = 20;
    }
}
