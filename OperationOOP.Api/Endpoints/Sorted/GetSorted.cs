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
            return db.Flowers.Select(x => new SortedResponse
            (
                Id: x.Id,
                Name: x.Name,
                Species: x.Species,
                AgeYears: x.AgeYears,
                CareLevel: x.CareLevel,
                Style: (x as Bonsai)?.Style // Null if not a Bonsai
            )).OrderBy(x => GetTypeOrder(x)).ToList();
        }

        private static int GetTypeOrder(object flower)
        {

            if (flower.GetType() == typeof(Bonsai)) return 1;
            if (flower.GetType() == typeof(Lotus)) return 2;
            if (flower.GetType() == typeof(Orchid)) return 3;
            if (flower.GetType() == typeof(Rose)) return 4;
            return 99;

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
