namespace OperationOOP.Api.Endpoints
{
    public class CreateRose : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/roses", Handle)
        .WithSummary("Roses");

        public record RoseRequest(
            int Id,
            string Name,
            string Species,
            int AgeYears,
            CareLevel CareLevel
            );
        public record RoseResponse(int id);

        private static Ok<RoseResponse> Handle(RoseRequest request, IDatabase db)
        {
            var rose = new Lotus();

            rose.Id = db.Flowers.Any()
                ? db.Flowers.Max(rose => rose.Id) + 1
                : 1;
            rose.Name = request.Name;
            rose.Species = request.Species;
            rose.AgeYears = request.AgeYears;
            rose.CareLevel = request.CareLevel;

            db.Flowers.Add(rose);

            return TypedResults.Ok(new RoseResponse(rose.Id));
        }
    }
}
