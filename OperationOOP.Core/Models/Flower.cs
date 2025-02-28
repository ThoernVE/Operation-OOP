using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class Flower //superclass for all flowers.
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int AgeYears { get; set; }
        public DateTime LastWatered { get; set; }
        public CareLevel CareLevel { get; set; }
        public DateTime LastPruned { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))] //jsonconverter for the enum Carelevel to show as string in Swagger
    public enum CareLevel //enum for the carelevel of flower.
    {
        Beginner,
        Intermediate,
        Advanced,
        Master
    }
}
