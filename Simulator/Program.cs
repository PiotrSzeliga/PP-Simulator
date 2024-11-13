using Simulator.Maps;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        static void Lab5a()
        {
            Console.WriteLine("\n\nLab5a\n\n");
            Rectangle a = new(1, 1, 7, 7);
            Point m = new Point(2, 2);
            Point n = new Point(8, 8);
            Rectangle b = new(m, n);
            Console.WriteLine(b.ToString());
            Console.WriteLine(a);

            try
            {
                //Rectangle c = new(1, 7, 1, 9);
                Point o = new Point(2, 9);
                Point p = new Point(3, 9);
                Rectangle d = new(o, p);
            }
            catch (Exception X)
            {
                Console.WriteLine(X);
            }

            Rectangle e = new(1, 10, 10, 1);
            Console.WriteLine(e);
            Point h = new Point(5, 5);
            if (a.Contains(h)) { Console.WriteLine("a"); };
            if (b.Contains(h)) { Console.WriteLine("b"); };
            if (e.Contains(h)) { Console.WriteLine("c"); };
        }
        Lab5a();
        
        static void Lab5b() 
        {
            Console.WriteLine("\n\nLab5b\n\n");
            try
            {
                //SmallSquareMap a = new SmallSquareMap(29);
                SmallSquareMap b = new SmallSquareMap(3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            SmallSquareMap c = new SmallSquareMap(15);
            Point p1 = new Point(1,10);
            Point p2 = new Point(1,19);
            Console.WriteLine(c.Exist(p1));
            Console.WriteLine(c.Exist(p2));

            SmallSquareMap d = new SmallSquareMap(20);
            Point p3 = new Point(8, 19);
            Console.WriteLine(p3);
            Console.WriteLine(d.Exist(p3));
            Console.WriteLine(d.Next(p3, Direction.Up));
            Console.WriteLine(d.Next(p3, Direction.Down));
            Console.WriteLine(d.Next(p3, Direction.Left));
            Console.WriteLine(d.NextDiagonal(p3, Direction.Up));
            Console.WriteLine(d.NextDiagonal(p3, Direction.Down));
        }
        Lab5b();
    }

    
}
