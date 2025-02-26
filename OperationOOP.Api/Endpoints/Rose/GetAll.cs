namespace OperationOOP.Api.Endpoints
{
    public class GetAllRoses : IEndpoint
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
            return db.Flowers.Where(rose => rose is Rose)
                .Select(rose => new Response
                (
                    rose.Id,
                    rose.Name,
                    rose.Species,
                     rose.AgeYears,
                    rose.CareLevel
                 )).ToList();
        }
    }
}
