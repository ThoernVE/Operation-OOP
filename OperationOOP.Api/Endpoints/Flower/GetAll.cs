﻿using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints
{
    public class GetAllFlowers : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/flowers", Handle)
        .WithSummary("Flowers");

        // Request and Response types
        public record FlowerResponse(
         int Id,
         string Name,
         string Species,
         int AgeYears,
         CareLevel CareLevel,
         BonsaiStyle? Style
        );

        //Logic
        private static List<FlowerResponse> Handle(IDatabase db)
        {
            return db.Flowers.Select(x => new FlowerResponse
            (
                Id: x.Id,
                Name: x.Name,
                Species: x.Species,
                AgeYears: x.AgeYears,
                CareLevel: x.CareLevel,
                Style: (x as Bonsai)?.Style // Null if not a Bonsai
            )).ToList();
        }
    }
}
