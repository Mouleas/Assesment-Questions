using System;

namespace ConsoleApp1
{
    internal class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hero bullets: ");
            int h = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Villain bullets: ");
            int v = Convert.ToInt32(Console.ReadLine());

            int hc = 0, vc = 0;
            int round = 1; 
            while (h > 0 && v > 2)
            { 
                v -= 3;
                h -= 1;
                Console.WriteLine($"-----Round: {round++}-------");
                Console.WriteLine("Hero: " + h);
                Console.WriteLine("Villain: " + v);
                Console.WriteLine();
                hc += 1;
                vc += 1;
            }

            if (v > 3)
            {
                vc++;
            }
            if (h > 0)
            {
                hc++;
            }

            if (vc > hc)
            {
                Console.WriteLine("Villain will kill hero");
            }
            else if (hc > vc)
            {
                Console.WriteLine("Hero will kill villain");
            }
            else
            {
                Console.WriteLine("No one will die in the battle");
            }


        }
    }
}
