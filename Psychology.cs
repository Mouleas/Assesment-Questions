using System.Collections;

namespace Assesment
{
    
    internal class Psychology
    {
        public void Iteration1()
        {
            int stress = 0, depression = 0, anxity = 0;
            Console.WriteLine("How are you feeling Today?");
            Console.WriteLine("Rate in the scale of 1-10 for the following question");
            Console.WriteLine("How stress are you feeling today?");
            stress = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How depressed are you feeling today?");
            depression = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your anxity level:");
            anxity = Convert.ToInt32(Console.ReadLine());

            if (stress > 7 || depression > 7 || anxity > 7)
            {
                Console.WriteLine("Your mental health is really bad.");
            }
            else
            {
                Console.WriteLine("You are perfectly fine.");
            }

        }

        public void Iteration2()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();

            map.Add("Aries", "Taurus");
            map.Add("Taurus", "Aries");

            map.Add("Gemini", "Cancer");
            map.Add("Cancer", "Gemini");

            map.Add("Leo", "Virgo");
            map.Add("Virgo", "Leo");

            map.Add("Libra", "Scorpius");
            map.Add("Scorpius", "Libra");

            map.Add("Sagittarius", "Capricornus");
            map.Add("Capricornus", "Sagittarius");

            map.Add("Aquarius", "Pisces");
            map.Add("Pisces", "Aquarius");

            Console.WriteLine("Select your zodiac sign to find your match. ");

            ArrayList zodiac = new ArrayList() { "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpius", "Sagittarius", "Capricornus", "Aquarius", "Pisces" };

            int choice = 1;

            foreach (var s in zodiac)
            {
                Console.WriteLine(choice + ". " + s);
                choice++;
            }

            Console.WriteLine("Type your zodiac: ");
            string sign = Console.ReadLine();

            if (zodiac.Contains(sign))
            {
                Console.WriteLine("You are matched with the Zodiac sign.....");
                Console.WriteLine("---------------");
                Console.WriteLine("|"+" "+map[sign]+" "+"|");
                Console.WriteLine("---------------");
            }
            else
            {
                Console.WriteLine("Your sign is Incorrect");
                Psychology obj = new Psychology();
                obj.Iteration2();
            }

        }

        public void Iteration3()
        {
            Console.WriteLine("I,m going to guess your age.");
            Console.WriteLine("If my guess is higher than your age TYPE 1");
            Console.WriteLine("If my giess is lower than your age TYPE -1");
            Console.WriteLine("If my guess is correct TYPE 0");

            int l = 1, r = 150;

            while (l <= r)
            {
                int guess = l + (r - l) / 2;
                Console.WriteLine("My guess is: "+" "+guess);

                Console.WriteLine("Enter your answer: ");
                int num = Convert.ToInt32(Console.ReadLine());
                
                if (num == -1)
                {
                    l = guess + 1;
                }
                else if (num == 1)
                {
                    r = guess - 1;
                }
                else
                {
                    Console.WriteLine("Hurray! Your age is: " + " " + guess);
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            Psychology obj = new Psychology();

            // ITERATION 1
            obj.Iteration1();
            Console.WriteLine();

            // ITERATION 2
            obj.Iteration2();
            Console.WriteLine();

            // ITERATION 3
            obj.Iteration3();
            Console.WriteLine();

        }
    }
}