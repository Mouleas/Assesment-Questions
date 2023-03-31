using System;

namespace ConsoleApp1
{
    internal class Test
    {
        static void Main(string[] args)
        {
           
            Console.Write("Enter number of Elements: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] A = new int[n];

            Console.WriteLine("Enter elements of array: ");
            for (int i=0; i < n; i++)
            {
                A[i] = Convert.ToInt32(Console.ReadLine());
            }

            int odd = 0, even = 0;
            foreach (var i in A) 
            {
                if (i % 2 == 0)
                {
                    even++;
                }
                else
                {
                    odd++;
                }
            }

            int[] oddArray = new int[odd];
            int[] evenArray = new int[even];

            int oddIdx = 0, evenIdx = 0;

            foreach (var i in A)
            {
                if (i % 2 == 0)
                {
                    evenArray[evenIdx++] = i;
                }
                else
                {
                    oddArray[oddIdx++] = i;
                }
            }

            Console.WriteLine("Odd Array: ");
            foreach (var i in oddArray)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Even Array: ");
            foreach (var i in evenArray)
            {
                Console.Write(i + " ");
            }


        }

    }
}
