using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints;
public class GetAllBonsais : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app //mapping endpoint.
        .MapGet("/bonsais", Handle)
        .WithSummary("Bonsai trees");

    // Request and Response types
    public record BonsaiResponse( //DTO for bonsairesponse.
     int Id,
     string Name,
     string Species,
     int AgeYears,
     CareLevel CareLevel,
     BonsaiStyle Style
    );

    //Logic
    private static IResult Handle(IDatabase db) //endpoint to get all bonsais. Filters with LINQ to only get classtype Bonsai.
    {
        return Results.Ok(db.Flowers.Where(bonsai => bonsai is Bonsai)
                .Select(bonsai  => new BonsaiResponse
                (
                    bonsai.Id,
                    bonsai.Name,
                    bonsai.Species,
                    bonsai.AgeYears,
                    bonsai.CareLevel,
                    (bonsai as Bonsai).Style //Defining the bonsai as classtype Bonsai to access the Style-property.
                 )).ToList());
    }
}