using System;

namespace ConsoleApp1
{
    internal class Test
    {

        public static void sortArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++) 
            {
                for(int j = i+1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        int tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            {
                Console.Write("Enter number of Elements: ");
                int n = Convert.ToInt32(Console.ReadLine());

                int[] A = new int[n];
                int[] B = new int[n];

                Console.WriteLine("Enter array A elements: ");
                for (int i = 0; i < n; i++)
                {
                    A[i] = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("Enter array B elements: ");
                for (int i = 0; i < n; i++)
                {
                    B[i] = Convert.ToInt32(Console.ReadLine());
                }
                sortArray(A);
                sortArray(B);
                int[] sortedArray = new int[n + n];

                int idx = 0;
                int x = 0, y = 0;
                while (idx < n+n)
                {
                    if (x < n && y < n)
                    {
                        if (A[x] < B[y])
                        {
                            sortedArray[idx++] = A[x];
                            x++;
                        }
                        else if (A[x] > B[y])
                        {
                            sortedArray[idx++] = B[y];
                            y++;
                        }
                        else
                        {
                            sortedArray[idx++] = A[x++];
                        }
                    }
                    else if (x < n)
                    {
                        sortedArray[idx++] = A[x++];
                    }
                    else if (y < n)
                    {
                        sortedArray[idx++] = B[y++];
                    }
                }
                Console.WriteLine("The Sorted Array is: ");
                foreach (var item in sortedArray)
                {
                    Console.Write(item + " ");
                }

            }
        }

    }
}
