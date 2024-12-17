using Simulator;
using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole;
public class LogVisulizer
{
    SimulationHistory Log { get; }
    
    private string _gridTop = "";
    private string _gridBottom = "";
    private string _gridMiddle = "";
    private List<string> _gridData = new List<string>();
    public LogVisulizer(SimulationHistory log)
    {
        Log = log;
        this.GridLines();
    }

    public void Draw(int turnIndex)
    {
        if (turnIndex > Log.TurnLogs.Count - 1) { throw new ArgumentOutOfRangeException(nameof(turnIndex)); }
        this.GridData(turnIndex);
        List<string> grid = new List<string>();
        grid.Add(this._gridTop);
        for (int i = 0; i < 2 * _gridData.Count - 1; i++)
        {
            var line = (i % 2 == 0) ? _gridData[_gridData.Count - 1 - (i / 2)] : _gridMiddle;
            grid.Add(line);
        }
        grid.Add(this._gridBottom);
        Console.WriteLine($"Turn: {turnIndex}");
        Console.Write(string.Join("\n", grid) + "\n");
        if ((turnIndex == 0)) { Console.WriteLine("Pozycje startowe\n"); } else { Console.WriteLine($"{Log.TurnLogs[turnIndex].Mappable} => {Log.TurnLogs[turnIndex].Move}\n"); }
    }
    public void GridLines()
    {
        List<char> gridLine = new();

        gridLine.Add(Box.TopLeft);
        for (int i = 1; i < Log.SizeX; i++) { gridLine.Add(Box.TopMid); }
        gridLine.Add(Box.TopRight);
        _gridTop = string.Join(Box.Horizontal, gridLine.ToArray());
        gridLine.Clear();

        gridLine.Add(Box.BottomLeft);
        for (int i = 1; i < Log.SizeX; i++) { gridLine.Add(Box.BottomMid); }
        gridLine.Add(Box.BottomRight);
        _gridBottom = string.Join(Box.Horizontal, gridLine.ToArray());
        gridLine.Clear();

        gridLine.Add(Box.MidLeft);
        for (int i = 1; i < Log.SizeX; i++) { gridLine.Add(Box.Cross); }
        gridLine.Add(Box.MidRight);
        _gridMiddle = string.Join(Box.Horizontal, gridLine.ToArray());
        gridLine.Clear();
    }

    public void GridData(int turnIndex)
    {
        _gridData.Clear();
        for (int i = 0; i < Log.SizeY; i++)
        {
            string data = "";
            data += Box.Vertical.ToString();
            for (int j = 0; j < Log.SizeX; j++)
            {
                if (Log.TurnLogs[turnIndex].Symbols.ContainsKey(new Point(j, i)))
                {
                    data += Log.TurnLogs[turnIndex].Symbols[new Point(j, i)];
                }
                else
                {
                    data += " ";
                }
                /*List<IMappable>? list = Map.At(j, i);
                switch (list)
                {
                    case null:
                        data += " ";
                        break;
                    case List<IMappable>:
                        if (list.Count == 0) { data += " "; break; }
                        else if (list.Count > 1) { data += "X"; break; }
                        else { data += list[0].Symbol; break; }
                }*/
                data += Box.Vertical.ToString();
            }
            _gridData.Add(data);
        }
    }

}
