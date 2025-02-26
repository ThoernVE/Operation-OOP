using OperationOOP.Core.Interfaces;
using OperationOOP.Core.Models;

namespace OperationOOP.Api.Endpoints
{
    public class CreateLotus : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/lotuses", Handle)
        .WithSummary("Lotus flowers");

        public record LotusRequest(
            int Id,
            string Name,
            string Species,
            int AgeYears,
            CareLevel CareLevel
            );
        public record LotusResponse(int id);

        private static Ok<LotusResponse> Handle(LotusRequest request, IDatabase db)
        {
            var lotus = new Lotus();

            lotus.Id = db.Flowers.Any()
                ? db.Flowers.Max(lotus => lotus.Id) + 1
                : 1;
            lotus.Name = request.Name;
            lotus.Species = request.Species;
            lotus.AgeYears = request.AgeYears;
            lotus.CareLevel = request.CareLevel;

            db.Flowers.Add(lotus);

            return TypedResults.Ok(new LotusResponse(lotus.Id));
        }
    }
}
