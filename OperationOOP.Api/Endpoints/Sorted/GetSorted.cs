using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints
{
    public class GetSortedFlowers : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
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
        public record SortedResponse(
         int Id,
         string Name,
         string Species,
         int AgeYears,
         CareLevel CareLevel,
         BonsaiStyle? Style
        );

        //Logic
        private static List<SortedResponse> SortByFlowerType(IDatabase db)
        {
            var responses = new List<SortedResponse>();
            
            foreach (var flower in db.Flowers)
            {
                responses.Add(new SortedResponse(
                    Id: flower.Id,
                    Name: flower.Name,
                    Species: flower.Species,
                    AgeYears: flower.AgeYears,
                    CareLevel: flower.CareLevel,
                    Style: (flower as Bonsai)?.Style
                ));
            }
            
            // Sort the list using a custom comparison with stringname.
            responses.Sort((a, b) => 
            {
                var flowerA = db.Flowers.First(f => f.Id == a.Id);
                var flowerB = db.Flowers.First(f => f.Id == b.Id);
                
                return string.Compare(flowerA.GetType().Name, flowerB.GetType().Name);
            });
            
            return responses;
        }
        private static List<SortedResponse> SortById(IDatabase db)
        {
            return db.Flowers.Select(x => new SortedResponse
            (
                Id: x.Id,
                Name: x.Name,
                Species: x.Species,
                AgeYears: x.AgeYears,
                CareLevel: x.CareLevel,
                Style: (x as Bonsai)?.Style // Null if not a Bonsai
            )).OrderBy(x => x.Id).ToList();
        }
        private static List<SortedResponse> SortByAge(IDatabase db)
        {
            return db.Flowers.Select(x => new SortedResponse
            (
                Id: x.Id,
                Name: x.Name,
                Species: x.Species,
                AgeYears: x.AgeYears,
                CareLevel: x.CareLevel,
                Style: (x as Bonsai)?.Style // Null if not a Bonsai
            )).OrderBy(x => x.AgeYears).ToList();
        }
        private static List<SortedResponse> SortByCareLevel(IDatabase db)
        {
            return db.Flowers.Select(x => new SortedResponse
            (
                Id: x.Id,
                Name: x.Name,
                Species: x.Species,
                AgeYears: x.AgeYears,
                CareLevel: x.CareLevel,
                Style: (x as Bonsai)?.Style // Null if not a Bonsai
            )).OrderBy(x => x.CareLevel).ToList();
        }
    }
}
