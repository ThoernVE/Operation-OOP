using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints
{
    public class GetAllFlowers : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app //mapping endpoint.
        .MapGet("/flowers", Handle)
        .WithSummary("Flowers");

        // Request and Response types
        public record FlowerResponse( //DTO for flowerresponse.
         int Id,
         string Name,
         string Species,
         int AgeYears,
         CareLevel CareLevel,
         BonsaiStyle? Style
        );

        //Logic
        private static IResult Handle(IDatabase db) //endpoint to get all flowers.
        {
            return Results.Ok(db.Flowers.Select(x => new FlowerResponse
            (
                Id: x.Id,
                Name: x.Name,
                Species: x.Species,
                AgeYears: x.AgeYears,
                CareLevel: x.CareLevel,
                Style: (x as Bonsai)?.Style //setting bonsai as nullable in order to be able to map through all flowers with the same method, so flowers that doenst implement style kan set this to null while bonsai will keep it.
            )).ToList());
        }
    }
}
