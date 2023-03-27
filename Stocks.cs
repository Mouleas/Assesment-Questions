using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoforCS
{
    internal class Test2
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for (int i=0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            int left = 0;
            int right = 1;
            int profit = 0;

            for (int i=0; i < n-1; i++)
            {
                if (arr[left] <= arr[right])
                {
                    profit = Math.Max(profit, arr[right] - arr[left]);
                    right++;
                }
                else
                {
                    left = right;
                    right++;
                }
            }
            Console.WriteLine(profit);

        }
    }
}
