using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints;
public class GetAllBonsais : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/bonsais", Handle)
        .WithSummary("Bonsai trees");

    // Request and Response types
    public record Response(
     int Id,
     string Name,
     string Species,
     int AgeYears,
     CareLevel CareLevel,
     BonsaiStyle Style
    );

    //Logic
    private static List<Response> Handle(IDatabase db)
    {
        return db.Flowers.Where(bonsai => bonsai is Bonsai)
                .Select(bonsai  => new Response
                (
                    bonsai.Id,
                    bonsai.Name,
                    bonsai.Species,
                    bonsai.AgeYears,
                    bonsai.CareLevel,
                    (bonsai as Bonsai).Style
                 )).ToList();
    }
}