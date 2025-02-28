using OperationOOP.Core.Interfaces;
using OperationOOP.Core.Models;

namespace OperationOOP.Api.Endpoints
{
    public class CreateLotus : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app //mapping endpoint.
        .MapPost("/lotuses", Handle)
        .WithSummary("Lotus flowers");

        public record LotusRequest( //DTO for lotusrequest.
            int Id,
            string Name,
            string Species,
            int AgeYears,
            CareLevel CareLevel
            );
        public record LotusResponse(int id); //DTO for lotusresponse.

        private static IResult Handle(LotusRequest request, IDatabase db) //endpoint to create a lotus.
        {
            if (request == null) return Results.NotFound(); //return not found statuscode if request is null.
            var lotus = new Lotus();

            lotus.Id = db.Flowers.Any()
                ? db.Flowers.Max(lotus => lotus.Id) + 1
                : 1;
            lotus.Name = request.Name;
            lotus.Species = request.Species;
            lotus.AgeYears = request.AgeYears;
            lotus.CareLevel = request.CareLevel;

            db.Flowers.Add(lotus);

            return Results.Created("New Rose created", new LotusResponse(lotus.Id)); //returns 201 if created correctly.
        }
    }
}
