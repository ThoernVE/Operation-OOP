namespace OperationOOP.Api.Endpoints
{
    public class CreateOrchid : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/orchids", Handle)
        .WithSummary("Orchid flowers");

        public record OrchidRequest(
            int Id,
            string Name,
            string Species,
            int AgeYears,
            CareLevel CareLevel
            );
        public record OrchidResponse(int id);

        private static Ok<OrchidResponse> Handle(OrchidRequest request, IDatabase db)
        {
            var orchid = new Lotus();

            orchid.Id = db.Flowers.Any()
                ? db.Flowers.Max(orchid => orchid.Id) + 1
                : 1;
            orchid.Name = request.Name;
            orchid.Species = request.Species;
            orchid.AgeYears = request.AgeYears;
            orchid.CareLevel = request.CareLevel;

            db.Flowers.Add(orchid);

            return TypedResults.Ok(new OrchidResponse(orchid.Id));
        }
    }
}
