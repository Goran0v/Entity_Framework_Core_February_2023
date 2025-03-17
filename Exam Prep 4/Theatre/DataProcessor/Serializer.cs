namespace Theatre.DataProcessor
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Text;
    using Theatre.Data;

    public class Serializer
    {
        private static StringBuilder sb;

        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres =
                context.Theatres
                .ToArray()
                .Where(t => t.NumberOfHalls >= numbersOfHalls
                && t.Tickets.Count >= 20)
                .Select(t => new
                {
                    t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                    .Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                    .Sum(t => t.Price),
                    Tickets = t.Tickets
                    .Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                    .Select(ti => new
                    {
                        ti.Price,
                        ti.RowNumber
                    })
                    .OrderByDescending(ti => ti.Price)
                    .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name);

            string json = JsonConvert.SerializeObject(theatres, Formatting.Indented);
            return json;
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            throw new NotImplementedException();
        }
    }
}
