namespace OperationOOP.Api.Endpoints
{
    public class GetAllOrchids : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/orchids", Handle)
        .WithSummary("Orchids");

        // Request and Response types
        public record OrchidResponse(
         int Id,
         string Name,
         string Species,
         int AgeYears,
         CareLevel CareLevel
        );

        //Logic
        private static List<OrchidResponse> Handle(IDatabase db)
        {
            return db.Flowers.Where(orchid => orchid is Rose)
                .Select(orchid => new OrchidResponse
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
