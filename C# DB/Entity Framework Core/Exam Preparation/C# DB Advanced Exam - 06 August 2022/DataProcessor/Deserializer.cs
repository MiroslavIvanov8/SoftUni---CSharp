using System.Globalization;
using System.Text;
using Castle.Core.Internal;
using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ImportDto;
using Invoices.Utilities;
using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();

            ImportCoachDto[] coachDtos = xmlHelper.Deserialize<ImportCoachDto[]>(xmlString, "Coaches");

            ICollection<Coach> validCoaches = new HashSet<Coach>();

            foreach (var coachDto in coachDtos)
            {
                if (!IsValid(coachDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (String.IsNullOrEmpty(coachDto.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = new Coach()
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality,
                };

                ICollection<Footballer> validFootballers = new HashSet<Footballer>();
                foreach (var footballerDto in coachDto.Footballers)
                {
                    if (!IsValid(footballerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime startDate = DateTime.ParseExact(footballerDto.ContractStartDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);

                    DateTime endDate= DateTime.ParseExact(footballerDto.ContractEndDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);

                    if (startDate > endDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer()
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = startDate,
                        ContractEndDate = endDate,
                        BestSkillType = (BestSkillType)footballerDto.BestSkillType,
                        PositionType = (PositionType)footballerDto.PositionType,
                    };

                    validFootballers.Add(footballer);
                }

                coach.Footballers = validFootballers;
                validCoaches.Add(coach);
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }

            context.Coaches.AddRange(validCoaches);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportTeamDto[] teamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            ICollection<Team> validTeams = new HashSet<Team>();

            int[] existingFootballersIds = context.Footballers
                .Select(f => f.Id)
                .ToArray();

            foreach (var teamDto in teamDtos)
            {
                if (!IsValid(teamDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(teamDto.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (teamDto.Trophies == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = new Team()
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = teamDto.Trophies
                };

                ICollection<TeamFootballer> validTeamFootballer = new HashSet<TeamFootballer>();
                foreach (var footballerId in teamDto.Footballers.Distinct())
                {
                    if (!existingFootballersIds.Contains(footballerId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    TeamFootballer tf = new TeamFootballer()
                    {
                        FootballerId = footballerId,
                        Team = team
                    };

                    validTeamFootballer.Add(tf);
                }

                team.TeamsFootballers = validTeamFootballer;
                validTeams.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }

            context.Teams.AddRange(validTeams);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
