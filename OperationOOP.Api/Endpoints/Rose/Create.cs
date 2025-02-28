namespace OperationOOP.Api.Endpoints
{
    public class CreateRose : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app // mapping endpoint
        .MapPost("/roses", Handle)
        .WithSummary("Roses");

        public record RoseRequest( //DTO for roserequest.
            int Id,
            string Name,
            string Species,
            int AgeYears,
            CareLevel CareLevel
            );
        public record RoseResponse(int id); //DTO for roseresponse.

        private static IResult Handle(RoseRequest request, IDatabase db) //endpoint to create a rose.
        {
            if (request == null) return Results.NotFound(); //return not found statuscode if request is null.
            var rose = new Lotus();

            rose.Id = db.Flowers.Any()
                ? db.Flowers.Max(rose => rose.Id) + 1
                : 1;
            rose.Name = request.Name;
            rose.Species = request.Species;
            rose.AgeYears = request.AgeYears;
            rose.CareLevel = request.CareLevel;

            db.Flowers.Add(rose);

            return TypedResults.Created("New Rose created", new RoseResponse(rose.Id));//returns 201 if created correctly.
        }
    }
}
