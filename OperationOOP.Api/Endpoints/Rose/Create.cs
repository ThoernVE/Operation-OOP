namespace OperationOOP.Api.Endpoints
{
    public class CreateRose : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/Roses", Handle)
        .WithSummary("Roses");

        public record Request(
            int Id,
            string Name,
            string Species,
            int AgeYears,
            CareLevel CareLevel
            );
        public record Response(int id);

        private static Ok<Response> Handle(Request request, IDatabase db)
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

            return TypedResults.Ok(new Response(rose.Id));
        }
    }
}
