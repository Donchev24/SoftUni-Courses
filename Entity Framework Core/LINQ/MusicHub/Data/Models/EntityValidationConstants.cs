namespace MusicHub.Data.Models
{
    public static class EntityValidationConstants
    {
        public static class SongConstants
        {
            public const int SongNameMaxLength = 20;
        }

        public static class AlbumConstants
        {
            public const int AlbumNameMaxLength = 40;
        }

        public static class PerformerConstants
        {
            public const int FirstNameMaxLength = 20;
            public const int LastNameMaxLength = 20;
        }

        public static class ProducerConstants
        {
            public const int ProducerNameMaxLength = 30;
        }

        public static class WriterConstants
        {
            public const int WriterNameMaxLength = 20;
        }
    }
}
