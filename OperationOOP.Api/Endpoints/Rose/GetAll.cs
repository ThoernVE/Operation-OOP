namespace OperationOOP.Api.Endpoints
{
    public class GetAllRoses : IEndpoint 
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app //mapping endpoint.
       .MapGet("/roses", Handle)
       .WithSummary("Roses");

        // Request and Response types
        public record RoseResponse( //DTO for roseresponse.
         int Id,
         string Name,
         string Species,
         int AgeYears,
         CareLevel CareLevel
        );

        //Logic
        private static IResult Handle(IDatabase db) //endpoint to get all roses. Filters with LINQ to only get classtype Rose.
        {
            return Results.Ok(db.Flowers.Where(rose => rose is Rose)
                .Select(rose => new RoseResponse
                (
                    rose.Id,
                    rose.Name,
                    rose.Species,
                     rose.AgeYears,
                    rose.CareLevel
                 )).ToList());
        }
    }
}
