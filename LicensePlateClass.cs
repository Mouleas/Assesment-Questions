namespace Assesment_2
{
    internal class LicensePlateClass
    {
        string LicensePlate(string dmvNumber, int n)
        {
            string plateNumber = "";
            string temp = "";
            foreach (char i in dmvNumber)
            {
                if (i != '-')
                {
                    temp += i;
                }
            }

            int count = 0;
            for (int i = temp.Length-1; i >= 0; i--)
            {
                if (count == n)
                {
                    plateNumber += "-";
                    count = 0;
                }
                if (Char.IsLetter(temp[i])){
                    plateNumber += Char.ToUpper(temp[i]);
                }
                else
                {
                    plateNumber += temp[i];
                }
                count++;

            }
            char[] reversedString = plateNumber.ToCharArray();
            Array.Reverse(reversedString);
            return new string(reversedString);

        }

        static void Main(string[] args)
        {
            //Console.Write("Enter dmv number: ");
            //string dmvNumber = Console.ReadLine();
            //Console.WriteLine("Enter n: ");
            //int n = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(new LicensePlateClass().LicensePlate(dmvNumber, n));

            Console.WriteLine(new LicensePlateClass().LicensePlate("5F3Z-2e-9-w", 4));
            Console.WriteLine(new LicensePlateClass().LicensePlate("2-5g-3-J", 2));
            Console.WriteLine(new LicensePlateClass().LicensePlate("2-4A0r7-4k", 3));
            Console.WriteLine(new LicensePlateClass().LicensePlate("nlj-206-fv", 3));
        }
    }
}