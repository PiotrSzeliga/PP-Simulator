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
    private List<string> gridData = new List<string>();
    private Map Map { get; }

    public MapVisualizer(Map map)
    {  
        Map = map;
        this.GridLines();
        this.GridData();
    }

    public void Draw() 
    { 
        this.GridLines();
        this.GridData();
        Console.WriteLine(_gridTop);
        for (int i = 0; i < 2 * gridData.Count -1; i++) 
        {
            var line = (i % 2 == 0) ? gridData[gridData.Count - 1 - (i / 2)] : _gridMiddle;
            Console.WriteLine(line);
        }
        Console.WriteLine(_gridBottom);
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
        gridData.Clear();
        for (int i = 0; i < Map.SizeX; i++) 
        {
            string data = "";
            data += Box.Vertical.ToString();
            for (int j = 0; j < Map.SizeX; j++)
            {
                List<Creature>? list = Map.At(j, i);
                switch (list)
                {
                    case null:
                        data += " ";
                        break;
                    case List<Creature>:
                        if (list.Count == 0) { data += " "; break; }
                        else if (list.Count > 1) { data += "X"; break; }
                        else if (list[0].GetType() == typeof(Orc)) { data += "O"; break; }
                        else { data += "E"; break; }
                }
                data += Box.Vertical.ToString();
            }
            gridData.Add(data);
        }
    }
}
