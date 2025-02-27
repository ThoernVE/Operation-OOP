using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints
{
    public class GetAllLotuses : IEndpoint
    {

        public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/lotuses", Handle)
        .WithSummary("Lotus flowers");

        // Request and Response types
        public record LotusResponse(
         int Id,
         string Name,
         string Species,
         int AgeYears,
         CareLevel CareLevel
        );

        //Logic
        private static IResult Handle(IDatabase db)
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
