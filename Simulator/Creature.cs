using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public abstract class Creature
{
    private string name="Unknown";
    private int level=1;
   
    public abstract int Power 
    {
        get;
    }
    public string Name
    {
        get { return name; }
        init
        {
           name = Validator.Shortener(value);
        }
    }
   public int Level
    {
        get { return level; }
        init
        { 
            level = Validator.Limiter(value);
        }
    }
    public abstract string Info 
    {
        get;
    }
    
    public Creature(string name = "Unknown", int level = 1)
    {
        name = Validator.Shortener(name, 3, 25);
    }
    public abstract string  Greetings();
        //Console.WriteLine($"Hi, I'm {name}, my level is {level}.");
    
    public void Upgrade()
    {
        if ( level < 10 )
        { 
        level++;
        }  
    }
    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    public string[] Go(Direction[] directions)
    {
        string[] result = new string[directions.Length];
        for (int i=0; i < directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }
        return result;
    }
    
    public string[] Go(string directions) => Go(DirectionParser.Parse(directions));
    
    public override string ToString()
    {
        return $"{this.GetType().Name.ToString().ToUpper()}: {Info}";
    }
}
