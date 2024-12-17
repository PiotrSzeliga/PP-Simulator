using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        TurnLogs.Add(new SimulationTurnLog
        {
            Mappable = "",
            Move = "",
            Symbols = _simulation.Map.fields.ToDictionary(x => x.Key, x => (x.Value.Count == 1) ? x.Value[0].Symbol : 'X')
        });
        Run();
    }

    private void Run()
    {
        // implement
        while (!_simulation.Finished)
        {
            TurnLogs.Add(new SimulationTurnLog
            {
                Mappable = _simulation.CurrentMappable.ToString(),
                Move = _simulation.CurrentMoveName.ToString(),
                Symbols = _simulation.Map.fields.ToDictionary(x => x.Key, x => (x.Value.Count == 1) ? x.Value[0].Symbol : 'X')
            });
            _simulation.Turn();
        }
    }
    /// <summary>
    /// State of map after single simulation turn.
    /// </summary>
    public class SimulationTurnLog
    {
        /// <summary>
        /// Text representastion of moving object in this turn.
        /// CurrentMappable.ToString()
        /// </summary>
        public required string Mappable { get; init; }
        /// <summary>
        /// Text representation of move in this turn.
        /// CurrentMoveName.ToString();
        /// </summary>
        public required string Move { get; init; }
        /// <summary>
        /// Dictionary of IMappable.Symbol on the map in this turn.
        /// </summary>
        public required Dictionary<Point, char> Symbols { get; init; }
    }
}
