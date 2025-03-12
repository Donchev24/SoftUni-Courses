namespace MusicHub
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            int songDuration = 4;

            string result = ExportSongsAboveDuration(context, songDuration);

            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context
                .Albums
                .Where(a => a.ProducerId.HasValue && a.ProducerId.Value == producerId)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer!.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                           SongName = s.Name,
                           SongPrice = s.Price.ToString("F2"),
                           SongWriter = s.Writer.Name
                        })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.SongWriter)
                    .ToArray(),
                    AlbumPrice = a.Price
                })
                .ToArray();

            albums = albums
                .OrderByDescending(a => a.AlbumPrice)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                int increment = 1;
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{increment++}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrice}");
                    sb.AppendLine($"---Writer: {song.SongWriter}");
                }
                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice.ToString("F2")}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            TimeSpan durationTimeSpan = TimeSpan.FromSeconds(duration);

            var songs = context
                .Songs
                .Where(s => s.Duration > durationTimeSpan)
                .Select(s => new
                {
                    s.Name,
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c"),
                    Performers = s.SongPerformers
                    .Select(s => new
                    {
                        PerformerFirstName = s.Performer.FirstName,
                        PerformerLastName = s.Performer.LastName,
                    }),
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            int increment = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{increment++}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}");

                if(song.Performers.Any())
                {
                    foreach (var performer in song.Performers.OrderBy(n => n.PerformerFirstName))
                    {
                        string firstName = performer.PerformerFirstName;
                        string lastName = performer.PerformerLastName;

                        sb.AppendLine($"---Performer: {firstName} {lastName}");
                    }
                }

                if(song.AlbumProducer != null)
                {
                    sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                }

                sb.AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
