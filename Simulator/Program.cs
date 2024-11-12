namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        static void Lab5a() 
        {
            Rectangle a = new(1, 1, 7, 7);
            Point m = new Point(2,2);
            Point n = new Point(8,8);
            Rectangle b = new(m,n);
            Console.WriteLine(b.ToString());
            Console.WriteLine(a);
          
            try
            {
                //Rectangle c = new(1, 7, 1, 9);
                Point o = new Point(2,9);
                Point p = new Point(3,9);
                Rectangle d = new(o, p);
            }
            catch (Exception X)
            {
                Console.WriteLine(X);
            }
            
            Rectangle e = new(1,8,2,3);
            Console.WriteLine(e);

            Point h = new Point(5, 5);
            if (a.Contains(h)) { Console.WriteLine("a"); };
            if (b.Contains(h)) { Console.WriteLine("b"); };
            if (e.Contains(h)) { Console.WriteLine("c"); };
        }
        Lab5a();
    }

    
}
