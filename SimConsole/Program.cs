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
        SmallTorusMap map = new(6);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(4, 3), new(3, 1)];
        string moves = "dldldldldldlldldlddok";
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
