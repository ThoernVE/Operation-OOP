using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints
{
    public class GetSortedFlowers : IEndpoint //class for sorting flowers with endpoints to show sortingfunctions. Inherits from IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) //method to map endpoints, will get mapped automatically by endpointsextensions
        {
            app.MapGet("/flowertypes", SortByFlowerType)
            .WithSummary("Sort by flowertypes");

            app.MapGet("/flowerids", SortById)
            .WithSummary("Sort by flowerid's");

            app.MapGet("/flowerages", SortByAge)
            .WithSummary("Sort by flower ages");

            app.MapGet("/flowercarelevels", SortByCareLevel)
            .WithSummary("Sort by flower carelevels");
        }

        // Request and Response types
        public record SortedResponse( //DTO-response for sorting.
         int Id,
         string Name,
         string Species,
         int AgeYears,
         CareLevel CareLevel,
         BonsaiStyle? Style
        );

        //Logic
        private static IResult SortByFlowerType(IDatabase db) //sorting by classtype
        {
            var responses = new List<SortedResponse>(); 
            
            foreach (var flower in db.Flowers) //adding all flowers to list of responses by mapping to the DTO.
            {
                responses.Add(new SortedResponse(
                    Id: flower.Id,
                    Name: flower.Name,
                    Species: flower.Species,
                    AgeYears: flower.AgeYears,
                    CareLevel: flower.CareLevel,
                    Style: (flower as Bonsai)?.Style //setting bonsai as nullable in order to be able to map through all flowers with the same method, so flowers that doenst implement style kan set this to null while bonsai will keep it.
                ));
            }
            
            // Sort the list using a custom comparison with stringname. 
            responses.Sort((a, b) => 
            {
                var flowerA = db.Flowers.First(f => f.Id == a.Id);
                var flowerB = db.Flowers.First(f => f.Id == b.Id);
                
                return string.Compare(flowerA.GetType().Name, flowerB.GetType().Name);
            });
            
            return Results.Ok(responses);
        }
        private static IResult SortById(IDatabase db) //sorting by Id
        {
            return Results.Ok(db.Flowers.Select(x => new SortedResponse
            (
                Id: x.Id,
                Name: x.Name,
                Species: x.Species,
                AgeYears: x.AgeYears,
                CareLevel: x.CareLevel,
                Style: (x as Bonsai)?.Style // Null if not a Bonsai
            )).OrderBy(x => x.Id).ToList());
        }
        private static IResult SortByAge(IDatabase db) //sorting by age
        {
            return Results.Ok(db.Flowers.Select(x => new SortedResponse
            (
                Id: x.Id,
                Name: x.Name,
                Species: x.Species,
                AgeYears: x.AgeYears,
                CareLevel: x.CareLevel,
                Style: (x as Bonsai)?.Style // using this syntax to make the Style set to null if the flower is not of the class bonsai.
            )).OrderBy(x => x.AgeYears).ToList());
        }
        private static IResult SortByCareLevel(IDatabase db) //sorting by carelevel
        {
            return Results.Ok(db.Flowers.Select(x => new SortedResponse
            (
                Id: x.Id,
                Name: x.Name,
                Species: x.Species,
                AgeYears: x.AgeYears,
                CareLevel: x.CareLevel,
                Style: (x as Bonsai)?.Style // Null if not a Bonsai
            )).OrderBy(x => x.CareLevel).ToList());
        }
    }
}
