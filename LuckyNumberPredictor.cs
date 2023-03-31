using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assesment
{
    abstract class ANumberPredictor
    { 
        public abstract int getLuckyNumber(int num);
        public abstract int getUnluckyNumber(int num);

        public static NumberPredictor getObj()
        {
            return new NumberPredictor();
        }

    }

    internal class NumberPredictor : ANumberPredictor
    {
        private static int getFibo(int num)
        {
            if (num == 0) return 0;

            int x = 0, y = 1;
            int z = x + y;

            while (z <= num)
            {
                x = y;
                y = z;
                z = x + y;
            }

            if (Math.Abs(z - num) >= Math.Abs(y - num))
            {
                return y;
            }
            return z;
        }

        public override int getLuckyNumber(int num)
        {
            return getFibo(num);
        }

        public override int getUnluckyNumber(int num)
        {
            throw new NotImplementedException();
        }
    }

    internal class LuckyNumberPredictor
    {
        static void Main(string[] args)
        {
            ANumberPredictor instance = ANumberPredictor.getObj();
            Console.WriteLine("Enter DOB(DDMMYYYY):");
            int dob = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Your Lucky number is {instance.getLuckyNumber(dob)}");
        }
    }
}
