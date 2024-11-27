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
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// IMappables moving on the map.
    /// </summary>
    public List<IMappable> IMappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentMappable 
    {
        /* implement getter only */
        get { return IMappables[_currentMappable]; }
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName 
    {
        /* implement getter only */
        get { return _directions[_currentMove].ToString().ToLower(); }
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    { 
        /* implement */ 
        if (map == null) throw new ArgumentException(nameof(map));
        if (mappables == null || mappables.Count == 0) throw new ArgumentException(nameof(mappables));
        if (positions == null || positions.Count != mappables.Count) throw new ArgumentException(nameof(positions));
        if (moves == null) throw new ArgumentException(nameof(moves));
    
        Map = map;
        IMappables = mappables;
        Positions = positions;
        Moves = moves;
        _directions = DirectionParser.Parse(moves);
        
        for (int i = 0; i < mappables.Count; i++) 
        {
            IMappables[i].InitMapAndPosition(map, positions[i]);       
        }

        if (_directions.Count != 0) return;
        Finished = true;
    }

    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() 
    {
        /* implement */
        if (Finished) throw new InvalidOperationException("Simulation is finished");
        IMappables[_currentMappable].Go(_directions[_currentMove]);
        _currentMappable = (_currentMappable + 1) % (IMappables.Count);
        _currentMove++;
        if (_currentMove != _directions.Count) return;
        Finished = true;
    }
}
