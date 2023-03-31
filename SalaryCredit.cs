namespace SalaryCredit
{
    public class Program
    {
        public string getSalary(double start, double end, double hour, double overtime)
        {
            if (start > end)
            {
                return "Not a valid input";
            }
            else
            {
                double tot = 0;
                if (start >= 9 && end <= 17)
                {
                    tot += (end - start) * hour;
                }
                else if (start >= 9 && start <= 17 && end > 17) 
                {
                    tot += (17 - start) * hour;
                    tot += (end - 17) * overtime * hour;
                }
                else if (start > 17)
                {
                    tot += (start - end) * overtime * hour;
                }

                tot = Math.Round(tot, 2);
                return "$"+String.Format("{0:0.00}", tot);
            }

        }
        public static void Main(string[] args)
        {
            //Console.WriteLine("Entry time:");
            //double startTime = Convert.ToDouble(Console.ReadLine());

            //Console.WriteLine("Out time: ");
            //double endTime = Convert.ToDouble(Console.ReadLine());

            //Console.WriteLine("Hourly wage: ");
            //double hourWage = Convert.ToDouble(Console.ReadLine());

            //Console.WriteLine("Overtime wage: ");
            //double overtimeWage = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine(new Program().getSalary(startTime, endTime, hourWage, overtimeWage));

            Console.WriteLine(new Program().getSalary(9, 17, 30, 1.5)); // 240
            Console.WriteLine(new Program().getSalary(16, 18, 30, 1.8)); // 84
            Console.WriteLine(new Program().getSalary(13.25d, 15, 30, 1.5)); // 52.50
        }
    }
}