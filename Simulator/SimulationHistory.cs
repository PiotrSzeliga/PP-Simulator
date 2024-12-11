using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class SimulationHistory
{
    private readonly List<Snapshot> _history = new();

    public void Snapshot(int turn, Dictionary<IMappable, Point> mappables, IMappable? currentMappable, Direction? currentDirection)
    {
        _history.Add(new Snapshot
        {
            Turn = turn,
            Mappables = mappables,
            CurrentMappable = currentMappable,
            CurrentDirection = currentDirection,
        });
    }

    public void DisplaySnapshot(int turn) 
    {
        if (turn < 0 | turn >  _history.Count) { throw new ArgumentOutOfRangeException(nameof(turn)); }

        Snapshot snapshot = _history[turn];
        
        Console.WriteLine($"Turn: {turn}");
        foreach (var pair in snapshot.Mappables) 
        {
            Console.WriteLine($"{pair.Key} at {pair.Value}");
        }
        if (snapshot.CurrentMappable != null & snapshot.CurrentDirection != null) { Console.WriteLine($"{snapshot.CurrentMappable} goes: {snapshot.CurrentDirection}\n"); }
    }

}

public class Snapshot
{
    public int Turn { get; set; }
    public required Dictionary<IMappable, Point> Mappables { get; set; }
    public IMappable? CurrentMappable { get; set; }
    public Direction? CurrentDirection { get; set; }
}