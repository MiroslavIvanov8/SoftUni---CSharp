using Newtonsoft.Json;
using Theatre.DataProcessor.ExportDto;
using Theatre.Utilities;

namespace Theatre.DataProcessor
{

    using System;
    using Theatre.Data;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .ToArray()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count > 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5).Sum(ti => ti.Price),
                    Tickets = t.Tickets.Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                        .Select(t => new
                        {
                            Price = t.Price,
                            RowNumber = t.RowNumber
                        })
                        .OrderByDescending( t => t.Price)
                }).OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theatres,Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            XmlHelper xmlHelper = new XmlHelper();
            ExportPlayDto[] playDtos = context.Plays
                .ToArray()
                .Where(p => p.Rating <= raiting)
                .Select(p => new ExportPlayDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts.Where(a => a.IsMainCharacter)
                        .Select(ac => new ExportActorDto()
                        {
                            FullName = ac.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .OrderByDescending(a => a.FullName)
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            return xmlHelper.Serialize(playDtos, "Plays");
        }
    }
}
