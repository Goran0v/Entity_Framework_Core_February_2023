namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;
    using Trucks.Utilities;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and rating {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        private static StringBuilder sb;
        private static XmlHelper xmlHelper;

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            sb = new StringBuilder();
            xmlHelper = new XmlHelper();
            ImportPlayDto[] playDtos =
                xmlHelper.Deserialize<ImportPlayDto[]>(xmlString, "Plays");

            ICollection<Play> validPlays = new HashSet<Play>();
            foreach (var playDto in playDtos)
            {
                string[] info = playDto.Duration.Split(":").ToArray();
                string hours = info[0];
                string genre = playDto.Genre;
                bool isValid = false;
                int genreValue = 0;
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (hours[0] == '0' && hours[1] == '0')
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (genre == "Drama")
                {
                    genreValue = 0;
                    isValid = true;
                }
                else if (genre == "Comedy")
                {
                    genreValue = 1;
                    isValid = true;
                }
                else if (genre == "Romance")
                {
                    genreValue = 2;
                    isValid = true;
                }
                else if(genre == "Musical")
                {
                    genreValue = 3;
                    isValid = true;
                }

                if ((genre != "Drama" || genre != "Comedy" || genre != "Romance" || genre != "Musical") && !isValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = playDto.Title,
                    Duration = TimeSpan.Parse(playDto.Duration),
                    Rating = (float)playDto.Rating,
                    Genre = (Genre)genreValue,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };
                play.Duration.ToString("c", CultureInfo.InvariantCulture);

                validPlays.Add(play);
                sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, genre, play.Rating));
            }

            context.Plays.AddRange(validPlays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            sb = new StringBuilder();
            xmlHelper = new XmlHelper();
            ImportCastDto[] castDtos =
                xmlHelper.Deserialize<ImportCastDto[]>(xmlString, "Casts");

            ICollection<Cast> validCasts = new HashSet<Cast>();
            foreach (var castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                string character;
                if (castDto.IsMainCharacter)
                {
                    character = "main";
                }
                else
                {
                    character = "lesser";
                }

                Cast cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };
                validCasts.Add(cast);
                sb.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, character));
            }

            context.Casts.AddRange(validCasts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            sb = new StringBuilder();
            ImportTheatreDto[] theatreDtos =
                JsonConvert.DeserializeObject<ImportTheatreDto[]>(jsonString);

            ICollection<Theatre> validTheatres = new HashSet<Theatre>();
            foreach (var theatreDto in theatreDtos)
            {
                if (!IsValid(theatreDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

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

                Theatre theatre = new Theatre()
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director,
                    Tickets = validTickets
                };
                validTheatres.Add(theatre);
                sb.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
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
