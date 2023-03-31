using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_2
{
    internal class NewLicense
    {
        int License(string myName, int agent, string others)
        {
            string[] arr = others.Split(' ');

            List<string> list = new List<string>();
            foreach (string i in arr)
            {
                list.Add(i);
            }
            list.Add(myName);
            list.Sort();

            int totalTime = 0;
            int count = 0;
            foreach (string str in list)
            {
                if (str.Equals(myName))
                {
                    return totalTime+20;
                }
                else
                {
                    count++;
                    if (count == agent)
                    {
                        count = 0;
                        totalTime += 20;
                    }
                }
            }
            return totalTime;

        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter your name: ");
            //string myName = Console.ReadLine();
            //Console.WriteLine("Enter agent count: ");
            //int agentCount = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter other people name: ");
            //string others = Console.ReadLine();
            //Console.WriteLine("Time taken to get new license is: ");
            //Console.WriteLine(new NewLicense().License(myName, agentCount, others));



            Console.WriteLine(new NewLicense().License("Eric", 2, "Adam Caroline Rebecca Frank"));
            Console.WriteLine(new NewLicense().License("Zebediah", 1, "Bob Jim Becky Pat"));
            Console.WriteLine(new NewLicense().License("Aaron", 3, "Jane Max Olivia Sam"));
        }
    }
}
