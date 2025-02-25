using OperationOOP.Core.Models;

namespace OperationOOP.Core.Data
{
    public interface IDatabase
    {
        List<Flower> Flowers { get; set; }

    }

    public class Database : IDatabase
    {
        public List<Flower> Flowers { get; set; }

        public Database()
        {
            Flowers = GenerateFlowers();
        }

        private List<Flower> GenerateFlowers()
        {
            var flowerList = new List<Flower>
            {
                new Orchid{ Id = 1, Name = "Ghost Orchid", Species = "Dendrophylax lindenii", AgeYears = 2, LastWatered = new DateTime(2025, 02, 20), CareLevel = CareLevel.Advanced, LastPruned = new DateTime(2023, 10, 03)},
                new Orchid{ Id = 2, Name = "Rothschilds Slipper", Species = "Paphiopedilum rothshildianum", AgeYears = 0, LastWatered = new DateTime(2025, 02, 20), CareLevel = CareLevel.Advanced, LastPruned = new DateTime(2024, 12, 30)},
                new Orchid{ Id = 3, Name = "Dragons Mouth", Species = "Arethusa bulbosa", AgeYears = 1, LastWatered = new DateTime(2025, 02, 20), CareLevel = CareLevel.Advanced, LastPruned = new DateTime(2024, 06, 04)},
                new Lotus{ Id = 4, Name = "Indian Lotus", Species = "Nelumbo nucifera", AgeYears = 3, LastWatered = new DateTime(2025, 02, 24), CareLevel = CareLevel.Advanced, LastPruned = new DateTime(2024, 11, 25)},
                new Bonsai{ Id = 5, Name = "Fir", Species = "Abies", AgeYears = 2, LastWatered = new DateTime(2025, 02, 25), CareLevel = CareLevel.Advanced, LastPruned = new DateTime(2024, 10, 11), Style = Interfaces.BonsaiStyle.Chokkan},
                new Bonsai{ Id = 6, Name = "Vine Maple", Species = "Acer circinatum", AgeYears = 5, LastWatered = new DateTime(2025, 02, 25), CareLevel = CareLevel.Advanced, LastPruned = new DateTime(2024, 10, 12), Style = Interfaces.BonsaiStyle.Moyogi},
                new Bonsai{ Id = 7, Name = "Trident Maple", Species = "Acer buergerianum", AgeYears = 11, LastWatered = new DateTime(2025, 02, 25), CareLevel = CareLevel.Master, LastPruned = new DateTime(2024, 10, 15), Style = Interfaces.BonsaiStyle.Moyogi},
                new Bonsai{ Id = 8, Name = "Dwarf Japanese Garden Juniper", Species = "Juniperus procumbens", AgeYears = 12, LastWatered = new DateTime(2025, 02, 25), CareLevel = CareLevel.Master, LastPruned = new DateTime(2024, 10, 16), Style = Interfaces.BonsaiStyle.HanKengai},
                new Bonsai{ Id = 9, Name = "Western Yellow Pine", Species = "Pinus ponderosa", AgeYears = 7, LastWatered = new DateTime(2025, 02, 25), CareLevel = CareLevel.Master, LastPruned = new DateTime(2024, 10, 17), Style = Interfaces.BonsaiStyle.Kengai},
                new Rose{ Id = 10, Name = "Rosa Knockout", Species = "Rosa Knockout", AgeYears = 1, LastWatered = new DateTime(2025, 02, 24), CareLevel = CareLevel.Advanced, LastPruned = new DateTime(2025, 01, 10)},
                new Rose{ Id = 11, Name = "Soft Downy-Rose", Species = "Rosa mollis", AgeYears = 0, LastWatered = new DateTime(2025, 02, 24), CareLevel = CareLevel.Advanced, LastPruned = new DateTime(2025, 01, 10)},
                new Rose{ Id = 12, Name = "Sherard's Downy-Rose", Species = "Rosa sherardii", AgeYears = 1, LastWatered = new DateTime(2025, 02, 24), CareLevel = CareLevel.Advanced, LastPruned = new DateTime(2025, 01, 11)}

            };

            return flowerList;
        }

    }
}
