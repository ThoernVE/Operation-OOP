using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints
{
    public class GetAllFlowers : IEndpoint
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
         CareLevel CareLevel,
         BonsaiStyle? Style
        );

        //Logic
        private static List<Response> Handle(IDatabase db)
        {
            return db.Flowers.Select(x => new Response
            (
                Id: x.Id,
                Name: x.Name,
                Species: x.Species,
                AgeYears: x.AgeYears,
                CareLevel: x.CareLevel,
                Style: (x as Bonsai)?.Style // Null if not a Bonsai
            ))
                .ToList();
        }
    }
}
