using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints
{
    public class GetAllLotuses : IEndpoint
    {

        public static void MapEndpoint(IEndpointRouteBuilder app) => app //mapping endpoint.
        .MapGet("/lotuses", Handle)
        .WithSummary("Lotus flowers");

        // Request and Response types
        public record LotusResponse( //DTO for lotusresponse.
         int Id,
         string Name,
         string Species,
         int AgeYears,
         CareLevel CareLevel
        );

        //Logic
        private static IResult Handle(IDatabase db) //endpoint to get all lotuses. Filters with LINQ to only get classtype Lotus.
        {
            return Results.Ok(db.Flowers.Where(lotus => lotus is Rose)
                 .Select(lotus => new LotusResponse
                 (
                     lotus.Id,
                     lotus.Name,
                     lotus.Species,
                      lotus.AgeYears,
                     lotus.CareLevel
                  )).ToList());
        }
    }
}
