using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Assesment
{
    internal class Candy
    {
        private string color = "";
        public Candy(string color) 
        {
            this.color = color;
        }
        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
    }
    internal class ChocolateDispenser
    {
        public ArrayList box = new ArrayList();

        // Trial 1
        public void addChocolates(int n, string color)
        {  
            for (int i = 0; i < n; i++)
            {
                Candy obj = new Candy(color);
                box.Add(obj);
            }
            Console.WriteLine("Chocolates Added Successfully...");
        }

        //Trial 2
        public void removeChocolates(int n)
        {
            if (n > box.Count)
            {
                box = new ArrayList();
            }
            else
            {
                while (n > 0)
                {
                    box.RemoveAt(box.Count-1);
                    n--;
                }
            }
            Console.WriteLine("Chocolates removed Successfully...");

        }

        //Trial 3
        public void dispenseChocolates(int n)
        {
            if (n > box.Count)
            {
                box = new ArrayList();
            }
            else
            {
                while (n > 0)
                {
                    box.RemoveAt(0);
                    n--;
                }

            }
            Console.WriteLine("Chocolates dispensed successfully...");
            
        }

        //Trial 4
        public void dispenseChocolatesOfColor(string color, int number)
        {
            color = color.ToLower();
            List<int> index = new List<int>();
            for (int i = 0; i < box.Count; i++)
            {
                Candy obj = (Candy)box[i];
                if (obj.Color.Equals(color))
                {
                    index.Add(i);
                }
            }

            foreach (int i in index)
            {
                if (number > 0)
                {
                    box.RemoveAt(i);
                    number--;
                }
                
            }
            Console.WriteLine(color + " Chocolates dispensed successfully");
        }

        //Trial 5
        public void noOfChocolates()
        {
            List<string> colors = new List<string>() { "green", "silver", "blue", "crimson", "purple", "red", "pink" };
            Dictionary<string, int> map = new Dictionary<string, int>();
            for (int i = 0;i < colors.Count; i++)
            {
                map.Add(colors[i], 0);
            }

            foreach (Candy obj in box)
            {
                int val = map[obj.Color];
                map[obj.Color] += 1;
            }

            Console.WriteLine("Number of chocolates in each color");
            foreach (string i in colors)
            {
                Console.WriteLine(i + ": " + map[i]);
            }


        }

        //Trial 6
        public void sortChocolateBasedOnCount()
        {
            List<string> colors = new List<string>() { "green", "silver", "blue", "crimson", "purple", "red", "pink" };
            Dictionary<string, int> map = new Dictionary<string, int>();
            for (int i = 0; i < colors.Count; i++)
            {
                map[colors[i]] = 0;
            }

            foreach (Candy obj in box) {

                map[obj.Color]++;
            }

            Dictionary<string,int> ordered = map.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var i in ordered)
            {
                Console.WriteLine(i.Key+": "+i.Value);
            }
        }

        //Trial 7
        public void changeChocolateColor(int n, string color, string final)
        {
            foreach (Candy obj in box)
            {
                if (n > 0 && obj.Color.Equals(color))
                {
                    obj.Color = final;
                    n--;
                }
            }
            Console.WriteLine("Color replacement is done...");
        }

        //Trial 8
        public void changeChocolateColorAllOfxCount(string color, string final)
        {
            foreach (Candy obj in box)
            {
                if (obj.Color.Equals(color))
                {
                    obj.Color = final;
                }
            }
            Console.WriteLine("Color replacement is done...");
        }

        //Challenge 1
        public void removeChocolatesOfColor(string color)
        {
            int idx = -1;
            for (int i = box.Count-1; i >= 0; i--)
            {
                if (((Candy)box[i]).Color.Equals(color))
                {
                    idx = i;
                    break;
                }
            }
            if (idx == -1)
            {
                Console.WriteLine("Sorry no chocolate found in the color: " + color);
            }
            else
            {
                box.RemoveAt(idx);
                Console.WriteLine("Chocolate dispensed sucessfully...");
            }
        }

        //Challenge 2
        public void dispenseRainbowChocolates(int n)
        {
            int rainbow = 0;
            Dictionary<string, int> map = new Dictionary<string, int>();

            ArrayList colors = new ArrayList() { "green", "silver", "blue", "crimson", "purple", "red", "pink" };


            foreach (string s in colors)
            {
                map[s] = 0;
            }
            
            foreach (Candy obj in box)
            {
                map[obj.Color]++;
            }

            foreach (var x in map)
            {
                rainbow += (x.Value / 2);
            }

            Console.WriteLine("The Amount of rainbow chocolates we get: "+ rainbow);
        }

        static void Main(string[] args)
        {
            ChocolateDispenser obj = new ChocolateDispenser();

            // Trial choices
            ArrayList choice = new ArrayList();
            choice.Add("0.Print dispenser");
            choice.Add("1.Add N chocolates");
            choice.Add("2.Remove N chocolates");
            choice.Add("3.Dispense N chocolates");
            choice.Add("4.Dispense chocolates with color X");
            choice.Add("5.Number of chocolates in the dispenser");
            choice.Add("6.Sort chocolates based on count");
            choice.Add("7.Change N chocolate color");
            choice.Add("8.Change all chocolate to other color");
            choice.Add("9.Remove chocolate from top");
            choice.Add("10.Count Rainbow color chocolates");

            while (true)
            {
                foreach (var i in choice)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine();
                Console.Write("Enter your Choice: ");
                int trial = Convert.ToInt32(Console.ReadLine());

                switch (trial)
                {
                    case 0:
                        obj.printDispenser();
                        Console.WriteLine();
                        break;

                    case 1:
                        Console.WriteLine("Enter number of Chocolates to be added: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        obj.printColors();
                        Console.WriteLine("Enter color of chocolates: ");
                        string color = Console.ReadLine();
                        obj.addChocolates(n, color);
                        Console.WriteLine();
                        break;

                    case 2:
                        Console.WriteLine("Enter number of Chocolates to be removed: ");
                        n = Convert.ToInt32(Console.ReadLine());
                        obj.removeChocolates(n);
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.WriteLine("Enter number of Chocolates to be dispensed: ");
                        int number = Convert.ToInt32(Console.ReadLine());
                        obj.dispenseChocolates(number);
                        Console.WriteLine();
                        break;

                    case 4:
                        obj.printColors();
                        Console.WriteLine("Enter color of the chocolate: ");
                        color = Console.ReadLine();
                        Console.WriteLine("Enter number of Chocolates to be dispensed: ");
                        number = Convert.ToInt32(Console.ReadLine());
                        obj.dispenseChocolatesOfColor(color, number);
                        Console.WriteLine();
                        break;

                    case 5:
                        obj.noOfChocolates();
                        Console.WriteLine();
                        break;

                    case 6:
                        obj.sortChocolateBasedOnCount();
                        Console.WriteLine();
                        break;

                    case 7:
                        Console.WriteLine("Enter number of chocolates: ");
                        n = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the color you need to change: ");
                        obj.printColors();
                        color = Console.ReadLine();
                        Console.WriteLine("Enter the final color: ");
                        string finalColor = Console.ReadLine();
                        obj.changeChocolateColor(n, color, finalColor);
                        Console.WriteLine();
                        break;

                    case 8:
                        obj.printColors();
                        Console.WriteLine("Enter the color you need to change: ");
                        color = Console.ReadLine();
                        Console.WriteLine("Enter the final color: ");
                        finalColor = Console.ReadLine();
                        obj.changeChocolateColorAllOfxCount(color, finalColor);
                        break;

                    case 9:
                        obj.printColors();
                        Console.WriteLine("Enter the color you want: ");
                        color = Console.ReadLine();
                        obj.removeChocolatesOfColor(color);
                        Console.WriteLine(); 
                        break;

                    case 10:
                        Console.WriteLine("Chocolates to be dispensed: ");
                        n = Convert.ToInt32(Console.ReadLine());
                        obj.dispenseRainbowChocolates(n);
                        Console.WriteLine();
                        break;

                    default:
                        return;

                }

            }
        }
        public void printColors()
        {
            ArrayList colors = new ArrayList() { "green", "silver", "blue", "crimson", "purple", "red", "pink" };
            Console.WriteLine("Available Colors...");
            foreach (var i in colors)
            {
                Console.Write(i + ", ");
            }
            Console.WriteLine();
        }
        public void printDispenser()
        {

            Console.WriteLine("........CHOCOLATE DISPENSER.......");
            Console.WriteLine();
            Console.WriteLine("Count: " + box.Count);
            for (int i = box.Count-1; i >= 0; i--)
            {
                Console.WriteLine(((Candy)box[i]).Color);
            }
            Console.WriteLine();
        }
    }
}
