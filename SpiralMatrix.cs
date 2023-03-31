using Demo;
using System.Text;

namespace DemoforCS
{
    public class Test
    {
        static void Main(string[] args)
        {
            int r = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());

            int[][] arr = new int[r][];

            for (int i = 0; i < r; i++)
            {
                int[] tmp = new int[c];
                for (int j = 0; j < c; j++)
                {
                    Console.Write(i+""+j+": ");
                    tmp[j] = Convert.ToInt32(Console.ReadLine());
                }
                arr[i] = tmp;
            }

            int rowStart = 0, colStart = 0;
            int rowEnd = r, colEnd = c;

            int x = 0, y = c-1;

            int count = 0;

            while (count < (r*c))
            {
                for (int i=x; i < colEnd; i++) 
                {
                    Console.Write(arr[x][i] + " ");
                    count++;
                    
                }
                if (count >= (r * c))
                {
                    break;
                }
                x++;
                colEnd--;

                for (int i=x; i < rowEnd; i++)
                {
                    Console.Write(arr[i][y] + " ");
                    count++;
                    
                }
                if (count >= (r * c))
                {
                    break;
                }
                y--;
                rowEnd--;

                for (int i=y; i >= colStart; i--)
                {
                    Console.Write(arr[rowEnd][i]+" ");
                    count++;
                }
                if (count >= (r * c))
                {
                    break;
                }
                colStart++;

                for (int i=rowEnd-1; i > rowStart; i--)
                {
                    Console.Write(arr[i][colStart - 1]+" ");
                    count++;
                }
                if (count >= (r * c))
                {
                    break;
                }
                rowStart++;
            }


            
            Console.WriteLine();

            foreach (int[] arr2 in arr)
            {
                foreach (int z in arr2)
                {
                    Console.Write(z + " ");
                }
                Console.WriteLine();
            }
        }
    }
}