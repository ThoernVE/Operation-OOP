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
            return db.Flowers.Where(lotus => lotus is Rose)
                 .Select(lotus => new Response
                 (
                     lotus.Id,
                     lotus.Name,
                     lotus.Species,
                      lotus.AgeYears,
                     lotus.CareLevel
                  )).ToList();
        }
    }
}
