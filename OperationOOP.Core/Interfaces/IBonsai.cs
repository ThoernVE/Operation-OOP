using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OperationOOP.Core.Interfaces
{
    public interface IBonsai //interface specifically for Bonsai model. Might be a bit reduntant for this use case but wanted to use composition instead of inhertiance for BonsaiStyle
    {
        public BonsaiStyle Style { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))] //converts json to string in swagger
    public enum BonsaiStyle //enum for bonsaistyle
    {
        Chokkan,    // Formal Upright
        Moyogi,     // Informal Upright
        Shakan,     // Slanting
        Kengai,     // Cascade
        HanKengai   // Semi-cascade
    }
}
