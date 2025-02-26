namespace OperationOOP.Api.Endpoints
{
    public class GetAllOrchids : IEndpoint
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
            return db.Flowers.Where(orchid => orchid is Rose)
                .Select(orchid => new Response
                (
                    orchid.Id,
                    orchid.Name,
                    orchid.Species,
                     orchid.AgeYears,
                    orchid.CareLevel
                 )).ToList();
        }
    }
}
