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
    private int _currentCreature;
    private int _currentMove;
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature 
    {
        /* implement getter only */
        get { return Creatures[_currentCreature]; }
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName 
    {
        /* implement getter only */
        get { return Moves[_currentMove].ToString().ToLower(); }
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    { 
        /* implement */ 
        if (map == null) throw new ArgumentException(nameof(map));
        if (creatures == null || creatures.Count == 0) throw new ArgumentException(nameof(creatures));
        if (positions == null || positions.Count != creatures.Count) throw new ArgumentException(nameof(positions));
        if (moves == null) throw new ArgumentException(nameof(moves));
    
        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;
        _directions = DirectionParser.Parse(moves);
        
        for (int i = 0; i < creatures.Count; i++) 
        {
            Creatures[i].InitMapAndPosition(map, positions[i]);       
        }
        
        Finished = true;
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() 
    {
        /* implement */
        if (Finished) throw new InvalidOperationException("Simulation is finished");
        Creatures[_currentCreature].Go(_directions[_currentMove]);
        _currentCreature = (_currentCreature + 1) % (Creatures.Count);
        _currentMove++;

        Finished = true;
    }
}
