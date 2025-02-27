using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints.Flower
{
    public class GetFlower : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/flowers/{id}", Handle)
        .WithSummary("Flowers");

        public record FlowerRequest(int Id);

        public record FlowerResponse(
         int Id,
         string Name,
         string Species,
         int AgeYears,
         CareLevel CareLevel,
         BonsaiStyle? Style
        );

        private static IResult Handle([AsParameters] FlowerRequest request, IDatabase db)
        {
            var flower = db.Flowers.Find(flower => flower.Id == request.Id);
            if (flower == null) return null;

            // map flower to response dto
            var response = new FlowerResponse(
                Id: flower.Id,
                Name: flower.Name,
                Species: flower.Species,
                AgeYears: flower.AgeYears,
                Style: (flower as Bonsai)?.Style,
                CareLevel: flower.CareLevel
                );


            return Results.Ok(response.Id);
        }
    }
}
