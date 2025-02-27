using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class Flower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int AgeYears { get; set; }
        public DateTime LastWatered { get; set; }
        public CareLevel CareLevel { get; set; }
        public DateTime LastPruned { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CareLevel
    {
        Beginner,
        Intermediate,
        Advanced,
        Master
    }
}
