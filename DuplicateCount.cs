using System.Collections;
using System.ComponentModel;
using System.Threading.Tasks.Dataflow;

namespace ConsoleApp1
{
    internal class Test
    {
        static void Main(string[] args)
        {
            Console.Write("Enter total number of Elements: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            HashSet<int> set = new HashSet<int>();
            foreach (int i in arr)
            {
                set.Add(i);
            }

            int length = set.Count();
            Console.WriteLine("Duplicate Count: "+(n - length));

            

        }
    }
}
