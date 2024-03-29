﻿using System.Text;
using System.Threading.Channels;
using MusicHub.Data.Models;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);
            int duration = int.Parse(Console.ReadLine());
            Console.WriteLine(ExportSongsAboveDuration(context, duration));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums.Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    albumName = a.Name,
                    releaseDate = a.ReleaseDate,
                    producerName = a.Producer.Name,
                    albumPrice = a.Price,
                    albumSongs = a.Songs.Select(s => new
                    {
                        songName = s.Name,
                        songPrice = s.Price,
                        songWriterName = s.Writer.Name
                    }).OrderByDescending(s => s.songName)
                        .ThenBy(s => s.songWriterName)
                        .ToList()
                })
                .ToList();

            StringBuilder sb = new();

            foreach (var album in albums.OrderByDescending(a => a.albumPrice))
            {
                sb.AppendLine($"-AlbumName: {album.albumName}");
                sb.AppendLine($"-ReleaseDate: {album.releaseDate.ToString("MM/dd/yyyy")}");
                sb.AppendLine($"-ProducerName: {album.producerName}");

                sb.AppendLine($"-Songs:");

                int cnt = 0;
                foreach (var song in album.albumSongs)
                {
                    cnt++;
                    sb.AppendLine($"---#{cnt}");
                    sb.AppendLine($"---SongName: {song.songName}");
                    sb.AppendLine($"---Price: {song.songPrice:f2}");
                    sb.AppendLine($"---Writer: {song.songWriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.albumPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    songName = s.Name,
                    performers = s.SongPerformers.Select(p => new
                    {
                        performerFullName = p.Performer.FirstName + " " + p.Performer.LastName,
                        // think of selectMany and how it will act if its only one performer or none
                    }),
                    writerName = s.Writer.Name,
                    albumProducerName = s.Album.Producer.Name,
                    songDuration = s.Duration
                })
                .OrderBy(s => s.songName)
                .ThenBy(s => s.writerName)
                .ToList();

            StringBuilder sb = new ();
            int cnt = 0;
            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{++cnt}");
                sb.AppendLine($"---SongName: {song.songName}");
                sb.AppendLine($"---Writer: {song.writerName}");

                if (song.performers.Count() > 0)
                {
                    foreach (var performer in song.performers.OrderBy(p => p.performerFullName))
                    {
                        sb.AppendLine($"---Performer: {performer.performerFullName}");
                    }
                }

                sb.AppendLine($"---AlbumProducer: {song.albumProducerName}");
                sb.AppendLine($"---Duration: {song.songDuration.ToString("c")}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
