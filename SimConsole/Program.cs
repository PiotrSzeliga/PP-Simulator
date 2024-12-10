using Simulator.Maps;
using Simulator;
using System.Text;
using System.Runtime.CompilerServices;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("SIMULATION!");
        BigBounceMap map = new(8, 6);
        List<IMappable> creatures = new List<IMappable> 
        {
            new Orc("Gorbag"), 
            new Elf("Elandor"), 
            new Animals { Description = "Rabbits", Size = 7 },
            new Birds { Description = "Eagles", Size = 2, CanFly = true },
            new Birds { Description = "Ostriches", Size = 3, CanFly = false } 
        };
        List<Point> points = new List<Point> 
        { 
            new(4, 3), 
            new(3, 1),
            new(1, 2),
            new(2, 3),
            new(6, 4),
        };
        
        string moves = "luuduluuduluuduluudu";
        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer Visualizer = new(simulation.Map);
        
        Console.WriteLine("\nStarting positions:");
        Visualizer.Draw();
        int turn = 1;
        while (!simulation.Finished)
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine($"Turn: {turn}");
            turn ++;
            Console.Write($"{(object)simulation.CurrentMappable} goes {simulation.CurrentMoveName}:\n");
            simulation.Turn();
            Visualizer.Draw();
        }
        Console.WriteLine("End of simulation!");
    }
}
