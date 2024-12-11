using Simulator;
using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole;

public class MapVisualizer
{
    private string _gridTop = "";
    private string _gridBottom = "";
    private string _gridMiddle = "";
    private List<string> _gridData = new List<string>();
    private Map Map { get; }

    public List<string> gridData { get { return _gridData; } }
    public MapVisualizer(Map map)
    {  
        Map = map;
        this.GridLines();
        this.GridData();
    }

    public void Draw() 
    { 
        this.GridData();
        List<string> grid = new List<string>();
        grid.Add(this._gridTop);
        for (int i = 0; i < 2 * _gridData.Count -1; i++) 
        {
            var line = (i % 2 == 0) ? _gridData[_gridData.Count - 1 - (i / 2)] : _gridMiddle;
            grid.Add(line);
        }
        grid.Add(this._gridBottom);
        Console.Write(string.Join("\n",grid) + "\n");
    }


    public void GridLines()
    {
        List<char> gridLine = new();
        
        gridLine.Add(Box.TopLeft);
        for (int i = 1; i < Map.SizeX; i++) { gridLine.Add(Box.TopMid); }
        gridLine.Add(Box.TopRight);
        _gridTop = string.Join(Box.Horizontal, gridLine.ToArray());  
        gridLine.Clear();

        gridLine.Add(Box.BottomLeft);
        for (int i = 1; i < Map.SizeX; i++) { gridLine.Add(Box.BottomMid); }
        gridLine.Add(Box.BottomRight);
        _gridBottom = string.Join(Box.Horizontal, gridLine.ToArray());
        gridLine.Clear();

        gridLine.Add(Box.MidLeft);
        for (int i = 1; i < Map.SizeX; i++) { gridLine.Add(Box.Cross); }
        gridLine.Add(Box.MidRight);
        _gridMiddle = string.Join(Box.Horizontal, gridLine.ToArray());
        gridLine.Clear();
    }

    public void GridData()
    {
        _gridData.Clear();
        for (int i = 0; i < Map.SizeY; i++) 
        {
            string data = "";
            data += Box.Vertical.ToString();
            for (int j = 0; j < Map.SizeX; j++)
            {
                List<IMappable>? list = Map.At(j, i);
                switch (list)
                {
                    case null:
                        data += " ";
                        break;
                    case List<IMappable>:
                        if (list.Count == 0) { data += " "; break; }
                        else if (list.Count > 1) { data += "X"; break; }
                        else { data += list[0].Symbol; break; }
                }
                data += Box.Vertical.ToString();
            }
            _gridData.Add(data);
        }
    }
}
