using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Simulation
{
    private List<Direction> _directions;
    private int _currentMappable;
    private int _currentMove;

    public Map Map { get; }

    public List<IMappable> IMappables { get; }

    public List<Point> Positions { get; }

    public Dictionary<IMappable, Point> Locations { get; set; }
    public string Moves { get; }

    public bool Finished = false;

    public IMappable CurrentMappable 
    {
        get { return IMappables[_currentMappable]; }
    }

    public string CurrentMoveName 
    {
        get { return _directions[_currentMove].ToString().ToLower(); }
    }
    
    public SimulationHistory History { get; }
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    { 
        if (map == null) throw new ArgumentException(nameof(map));
        if (mappables == null || mappables.Count == 0) throw new ArgumentException(nameof(mappables));
        if (positions == null || positions.Count != mappables.Count) throw new ArgumentException(nameof(positions));
        if (moves == null) throw new ArgumentException(nameof(moves));
    
        Map = map;
        IMappables = mappables;
        Positions = positions;
        Moves = moves;
        _directions = DirectionParser.Parse(moves);
        History = new SimulationHistory();
        
        for (int i = 0; i < mappables.Count; i++) 
        {
            IMappables[i].InitMapAndPosition(map, positions[i]);       
        }

        Locations = new Dictionary<IMappable, Point>();
        Locations = IMappables.ToDictionary(m => m, m => m.Position);

        History.Snapshot(0, Locations, null, null);
        
        if (_directions.Count != 0) return;
        Finished = true;
    }

    public void Turn() 
    {
        if (Finished) throw new InvalidOperationException("Simulation is finished");
        IMappables[_currentMappable].Go(_directions[_currentMove]);
        _currentMappable = (_currentMappable + 1) % (IMappables.Count);
        
        Locations = IMappables.ToDictionary(m => m, m => m.Position);

        History.Snapshot(_currentMove, Locations, IMappables[_currentMappable], _directions[_currentMove]);
        _currentMove++;
        
        if (_currentMove != _directions.Count) return;
        Finished = true;
    }


}
