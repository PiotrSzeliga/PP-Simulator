using Simulator.Maps;

namespace Simulator;

internal class Program
{
    static void Main(string[] args) 
    {
        List<IMappable> creatures = new List<IMappable>
        {
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals { Description = "Rabbits", Size = 7 },
            new Birds { Description = "Eagles", Size = 2, CanFly = true },
            new Birds { Description = "Ostriches", Size = 3, CanFly = false },
            new Elf("Galandier"),
            new Orc("Uruk-hai")
        };
    }

}
