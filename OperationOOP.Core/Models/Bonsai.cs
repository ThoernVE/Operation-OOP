using OperationOOP.Core.Interfaces;

namespace OperationOOP.Core.Models;
public class Bonsai : Flower, IBonsai
{
    public BonsaiStyle Style { get; set; }

}


