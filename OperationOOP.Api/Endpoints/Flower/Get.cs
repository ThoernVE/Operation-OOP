using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints.Flower
{
    public class GetFlower : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/flowers/{id}", Handle)
        .WithSummary("Flowers");

        public record Request(int Id);

        public record Response(
         int Id,
         string Name,
         string Species,
         int AgeYears,
         CareLevel CareLevel,
         BonsaiStyle? Style
        );

        private static Response Handle([AsParameters] Request request, IDatabase db)
        {
            var flower = db.Flowers.Find(flower => flower.Id == request.Id);
            if (flower == null) return null;

            // map flower to response dto
            var response = new Response(
                Id: flower.Id,
                Name: flower.Name,
                Species: flower.Species,
                AgeYears: flower.AgeYears,
                Style: (flower as Bonsai)?.Style,
                CareLevel: flower.CareLevel
                );


            return response;
        }
    }
}
