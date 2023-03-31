using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment
{
    internal class Polymorphism
    {
        bool opposite = false;
        void calculator(int a, int b)
        {
            if (opposite)
            {
                Console.WriteLine($"A+B:{a - b}");
                Console.WriteLine($"A-B:{a + b}");
            }
            else
            {
                Console.WriteLine($"A+B:{a + b}");
                Console.WriteLine($"A-B:{a - b}");
            }

        }

        void calculator(int a, int b, int c)
        {
            if (opposite)
            {
                Console.WriteLine($"A+B+C:{a - b - c}");
                Console.WriteLine($"A-B-C:{a + b + c}");
            }
            else
            {
                Console.WriteLine($"A+B+C:{a + b + c}");
                Console.WriteLine($"A-B-C:{a - b - c}");
            }


        }
        static void Main(string[] args)
        {
            Polymorphism obj = new Polymorphism();
            Console.WriteLine("Enter number of inputs 2 or 3?");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num == 2)
            {
                Console.WriteLine("Enter two numbers: ");
                int x = Convert.ToInt32(Console.ReadLine());
                int y = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the mode: ");
                Console.WriteLine("1.Normal\n2.Opposite");
                Console.WriteLine("Enter 1 or 2");

                string mode = Console.ReadLine();

                if (mode == "2") obj.opposite = true;
                else obj.opposite = false;

                obj.calculator(x, y);

            }
            else if (num == 3)
            {
                Console.WriteLine("Enter three numbers: ");
                int x = Convert.ToInt32(Console.ReadLine());
                int y = Convert.ToInt32(Console.ReadLine());
                int z = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the mode: ");
                Console.WriteLine("1.Normal\n2.Opposite");
                Console.WriteLine("Enter 1 or 2");

                string mode = Console.ReadLine();

                if (mode == "2") obj.opposite = true;
                else obj.opposite = false;

                obj.calculator(x, y, z);

            }
            else
            {
                Console.WriteLine("!Incorrect input...");
            }



        }
    }
}
