using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints;
public class CreateBonsai : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app //mapping endpoint.
        .MapPost("/bonsais", Handle)
        .WithSummary("Bonsai trees");

    public record BonsaiRequest( //DTO for bonsairequest.
        int Id,
        string Name,
        string Species,
        int AgeYears,
        CareLevel CareLevel,
        BonsaiStyle Style
        );
    public record BonsaiResponse(int id); //DTO for bonsairesponse.

    private static IResult Handle(BonsaiRequest request, IDatabase db) //endpoint to create a bonsai.
    {
        if (request == null) return Results.NotFound(); //return not found statuscode if request is null.
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

        return Results.Created("New Bonsai created.", new BonsaiResponse(bonsai.Id)); //returns 201 if created correctly.
    }
}

