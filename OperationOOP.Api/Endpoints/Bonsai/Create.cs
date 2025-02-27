using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints;
public class CreateBonsai : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/bonsais", Handle)
        .WithSummary("Bonsai trees");

    public record BonsaiRequest(
        int Id,
        string Name,
        string Species,
        int AgeYears,
        CareLevel CareLevel,
        BonsaiStyle Style
        );
    public record BonsaiResponse(int id);

    private static IResult Handle(BonsaiRequest request, IDatabase db)
    {
        if (request == null) return Results.NotFound();
        var bonsai = new Bonsai();

        bonsai.Id = db.Flowers.Any()
            ? db.Flowers.Max(bonsai => bonsai.Id) + 1
            : 1;
        bonsai.Name = request.Name;
        bonsai.Species = request.Species;
        bonsai.AgeYears = request.AgeYears;
        bonsai.Style = request.Style;
        bonsai.CareLevel = request.CareLevel;

        db.Flowers.Add(bonsai);

        return Results.Created("New Bonsai created.", new BonsaiResponse(bonsai.Id));
    }
}

