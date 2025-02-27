using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OperationOOP.Core.Interfaces
{
    public interface IBonsai
    {
        public BonsaiStyle Style { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BonsaiStyle
    {
        Chokkan,    // Formal Upright
        Moyogi,     // Informal Upright
        Shakan,     // Slanting
        Kengai,     // Cascade
        HanKengai   // Semi-cascade
    }
}
