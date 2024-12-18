using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator.Maps;
using Simulator;
using System.Diagnostics.Metrics;

namespace Razor_Pages.Pages;

    public class SimulationModel : PageModel
{
    public void OnGet()
    {
        turn = HttpContext.Session.GetInt32("turn") ?? 0;
    }
        
    public void OnPost() { }
        
    public void OnPostNext() 
    {
        turn = HttpContext.Session.GetInt32("turn") ?? 0;
        if (turn < history.TurnLogs.Count - 1) { turn++; }
        HttpContext.Session.SetInt32("turn", turn);
    }
    public void OnPostPrevious() 
    {
        turn = HttpContext.Session.GetInt32("turn") ?? 0;
        if (turn > 0) { turn--; }
        HttpContext.Session.SetInt32("turn", turn);
    }
    
    public static BigBounceMap map = new(8, 6);
    public static List<IMappable> creatures = new List<IMappable>
        {
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals { Description = "Rabbits", Size = 7 },
            new Birds { Description = "Eagles", Size = 2, CanFly = true },
            new Birds { Description = "Ostriches", Size = 3, CanFly = false }
        };
    public static List<Point> points = new List<Point>
        {
            new(4, 3),
            new(3, 1),
            new(1, 2),
            new(2, 3),
            new(6, 4),
        };
    public static string moves = "ludrurldrudldurddurd";
    public static Simulation simulation = new(map, creatures, points, moves);
    public static SimulationHistory history = new SimulationHistory(simulation);
    public static int turn { get; private set; }

}
