using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints
{
    public class GetAllLotuses : IEndpoint
    {

        public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/lotuses", Handle)
        .WithSummary("Lotus flowers");

        // Request and Response types
        public record Response(
         int Id,
         string Name,
         string Species,
         int AgeYears,
         CareLevel CareLevel
        );

        //Logic
        private static List<Response> Handle(IDatabase db)
        {
            List<Response> responseList = new List<Response>();
            for (int i = 0; i < db.Flowers.Count; i++)
            {
                if (db.Flowers[i] == null) continue;

                if (db.Flowers[i].GetType() == typeof(Lotus))
                {
                    var flower = db.Flowers[i];
                    var response = new Response(flower.Id, flower.Name, flower.Species, flower.AgeYears, flower.CareLevel);
                    responseList.Add(response);
                }
            }

            return responseList;
        }
    }
}
