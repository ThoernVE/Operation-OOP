using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints.Flower
{
    public class GetFlower : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app //mapping endpoint.
        .MapGet("/flowers/{id}", Handle)
        .WithSummary("Flowers");

        public record FlowerRequest(int Id); //DTO for flowerrequest.

        public record FlowerResponse( //DTO for flowerresponse.
         int Id,
         string Name,
         string Species,
         int AgeYears,
         CareLevel CareLevel,
         BonsaiStyle? Style
        );

        private static IResult Handle([AsParameters] FlowerRequest request, IDatabase db) //endpoint to get a flower by using a specific ID.
        {
            var flower = db.Flowers.Find(flower => flower.Id == request.Id);
            if (flower == null) return Results.NotFound("Flower not found");

            // map flower to response dto
            var response = new FlowerResponse(
                Id: flower.Id,
                Name: flower.Name,
                Species: flower.Species,
                AgeYears: flower.AgeYears,
                Style: (flower as Bonsai)?.Style,
                CareLevel: flower.CareLevel
                );


            return Results.Ok(response);
        }
    }
}
