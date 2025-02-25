using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public enum CareLevel
    {
        Beginner,
        Intermediate,
        Advanced,
        Master
    }
}
