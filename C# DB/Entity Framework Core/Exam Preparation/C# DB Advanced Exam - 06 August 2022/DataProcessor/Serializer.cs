using System.Globalization;
using Footballers.DataProcessor;
using Footballers.DataProcessor.ExportDto;
using Invoices.Utilities;
using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    using Data;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();
            ExportCoachDto[] coachDtos = context.Coaches
                .Where(c => c.Footballers.Any())
                .Select(c => new ExportCoachDto()
                {
                    CoachName = c.Name,
                    FootballerCount = c.Footballers.Count,
                    Footballers = c.Footballers.Select(f => new ExportFootballerDto()
                    {
                        Name = f.Name,
                        Position = f.PositionType.ToString()
                    })
                        .OrderBy(f => f.Name)
                        .ToArray()
                })
                .OrderByDescending(c => c.Footballers.Length)
                .ThenBy(c => c.CoachName)
                .ToArray();

            return xmlHelper.Serialize(coachDtos, "Coaches");

        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teamDots = context.Teams
                .ToArray()
                .Where(t => t.TeamsFootballers.Any(f => f.Footballer.ContractStartDate >= date))
                .Select(t => new 
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers
                        .Where(f => f.Footballer.ContractStartDate >= date)
                        .OrderByDescending(f => f.Footballer.ContractEndDate)
                        .ThenBy(f => f.Footballer.Name)
                        .Select(f => new 
                        {
                            FootballerName = f.Footballer.Name,
                            ContractStartDate = f.Footballer.ContractStartDate.ToString("d",CultureInfo.InvariantCulture),
                            ContractEndDate = f.Footballer.ContractEndDate.ToString("d",CultureInfo.InvariantCulture),
                            BestSkillType = f.Footballer.BestSkillType.ToString(),
                            PositionType = f.Footballer.PositionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(t => t.Footballers.Length)
                .ThenBy(t => t.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teamDots, Formatting.Indented);
        }
    }
}
