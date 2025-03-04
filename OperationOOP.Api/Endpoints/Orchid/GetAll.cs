﻿namespace OperationOOP.Api.Endpoints
{
    public class GetAllOrchids : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app //mapping endpoint.
        .MapGet("/orchids", Handle)
        .WithSummary("Orchids");

        // Request and Response types
        public record OrchidResponse( //DTO for orchidresponse.
         int Id,
         string Name,
         string Species,
         int AgeYears,
         CareLevel CareLevel
        );

        //Logic
        private static IResult Handle(IDatabase db) //endpoint to get all orchids. Filters with LINQ to only get classtype Orchid.
        {
            return Results.Ok(db.Flowers.Where(orchid => orchid is Orchid)
                .Select(orchid => new OrchidResponse
                (
                    orchid.Id,
                    orchid.Name,
                    orchid.Species,
                    orchid.AgeYears,
                    orchid.CareLevel
                 )).ToList());
        }
    }
}
