namespace Footballers.DataProcessor
{
    using AutoMapper;
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.DTOs.Import;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FootballersProfile>();
            });
            var mapper = new Mapper(config);

            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Coaches");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCoachDto[]), xmlRoot);

            StreamReader reader = new StreamReader(xmlString);
            ImportCoachDto[] coacheDtos = (ImportCoachDto[])serializer.Deserialize(reader);

            ICollection<Coach> coaches = new HashSet<Coach>();
            foreach (var coachDto in coacheDtos)
            {
                if (String.IsNullOrEmpty(coachDto.Name)
                    || String.IsNullOrEmpty(coachDto.Nationality)
                    || coachDto.Name.Length < 2
                    || coachDto.Name.Length > 40
                    || coachDto.Nationality.Contains("/")
                    || !IsValid(coachDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = mapper.Map<Coach>(coachDto);

                ICollection<Footballer> footballers = new HashSet<Footballer>();
                foreach (var footballerDto in coachDto.Footballers)
                {
                    if (String.IsNullOrEmpty(footballerDto.Name)
                        || footballerDto.ContractStartDate >= footballerDto.ContractEndDate
                        || footballerDto.Name.Length < 2
                        || footballerDto.Name.Length > 40
                        || !IsValid(footballerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer()
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = footballerDto.ContractStartDate,
                        ContractEndDate = footballerDto.ContractEndDate,
                        PositionType = footballerDto.PositionType,
                        BestSkillType = footballerDto.BestSkillType
                    };
                    coach.Footballers.Add(footballer);
                }

                coaches.Add(coach);
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }

            context.Coaches.AddRange(coaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportTeamDto[] teamDtos
                = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            ICollection<Team> teams = new HashSet<Team>();
            foreach (var teamDto in teamDtos)
            {
                if (String.IsNullOrEmpty(teamDto.Name) ||
                    String.IsNullOrEmpty(teamDto.Nationality) ||
                    teamDto.Trophies == 0 ||
                    !context.Teams.Any(t => t.Name == teamDto.Name)
                    || teamDto.Name.Length < 3
                    || teamDto.Name.Length > 40
                    || teamDto.Nationality.Length < 2
                    || teamDto.Nationality.Length > 40
                    || !IsValid(teamDto))
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
                foreach (var fDto in teamDto.Footballers.DistinctBy(f => f.FootballerId))
                {
                    if (!context.TeamsFootballers.Any(f => f.FootballerId == fDto.FootballerId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    TeamFootballer tf = new TeamFootballer()
                    {
                        Team = team,
                        Footballer = context.Footballers.FirstOrDefault(f => f.Id == fDto.FootballerId)
                    };
                    team.TeamsFootballers.Add(tf);
                }

                teams.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }

            context.Teams.AddRange(teams);
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
