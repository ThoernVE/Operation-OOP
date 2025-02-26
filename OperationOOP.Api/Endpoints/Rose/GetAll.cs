namespace OperationOOP.Api.Endpoints
{
    public class GetAllRoses : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
       .MapGet("/roses", Handle)
       .WithSummary("Roses");

        // Request and Response types
        public record RoseResponse(
         int Id,
         string Name,
         string Species,
         int AgeYears,
         CareLevel CareLevel
        );

        //Logic
        private static List<RoseResponse> Handle(IDatabase db)
        {
            return db.Flowers.Where(rose => rose is Rose)
                .Select(rose => new RoseResponse
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
