namespace OperationOOP.Api.Endpoints
{
    public class CreateOrchid : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app //mapping endpoint.
        .MapPost("/orchids", Handle)
        .WithSummary("Orchid flowers");

        public record OrchidRequest( //DTO for orchidrequest.
            int Id,
            string Name,
            string Species,
            int AgeYears,
            CareLevel CareLevel
            );
        public record OrchidResponse(int id); //DTO for orchidresponse.

        private static IResult Handle(OrchidRequest request, IDatabase db) //endpoint to create an orchid.
        {
            if (request == null) return Results.NotFound();
            var orchid = new Lotus();

            orchid.Id = db.Flowers.Any()
                ? db.Flowers.Max(orchid => orchid.Id) + 1
                : 1;
            orchid.Name = request.Name;
            orchid.Species = request.Species;
            orchid.AgeYears = request.AgeYears;
            orchid.CareLevel = request.CareLevel;

            db.Flowers.Add(orchid);

            return Results.Created("New Rose created", new OrchidResponse(orchid.Id)); //returns 201 if created correctly.
        }
    }
}
