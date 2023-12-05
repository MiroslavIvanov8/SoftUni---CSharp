using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using Theatre.Data;
using Theatre.Utilities;
using Theatre.Data.Models;
using Theatre.Data.Models.Enums;
using Theatre.DataProcessor.ImportDto;

namespace Theatre.DataProcessor
{
    using System.ComponentModel.DataAnnotations;

    

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";



        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();

            ImportPlayDto[] playDtos = xmlHelper.Deserialize<ImportPlayDto[]>(xmlString,"Plays");

            ICollection<Play> validPlays = new HashSet<Play>();
            foreach (var playDto in playDtos)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan duration = TimeSpan.ParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture);

                if (duration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Genre genreVar;
                if (!Enum.TryParse<Genre>(playDto.Genre, out genreVar))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Raiting,
                    Genre = genreVar,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };

                

                validPlays.Add(play);
                sb.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating));
            }

            context.Plays.AddRange(validPlays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();

            ImportCastDto[] castDtos = xmlHelper.Deserialize<ImportCastDto[]>(xmlString, "Casts");

            ICollection<Cast> validCasts = new HashSet<Cast>();
            foreach (var castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                validCasts.Add(cast);
                string isMainOrSide = cast.IsMainCharacter ? "main" : "lesser";
                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, isMainOrSide));
            }

            context.Casts.AddRange(validCasts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportTheatreDto[] theatreDtos = JsonConvert.DeserializeObject<ImportTheatreDto[]>(jsonString);

            ICollection<Data.Models.Theatre> validTheatres = new HashSet<Data.Models.Theatre>();

            foreach (var theatreDto in theatreDtos)
            {
                if (!IsValid(theatreDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Data.Models.Theatre theatre = new Data.Models.Theatre()
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director
                };

                ICollection<Ticket> validTickets = new HashSet<Ticket>();
                foreach (var ticketDto in theatreDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };

                    validTickets.Add(ticket);
                }

                theatre.Tickets = validTickets;
                validTheatres.Add(theatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(validTheatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
