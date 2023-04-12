namespace BalancedBrackets
{
    internal class Program
    {
        List<string> brackets = new List<string>();

        void generateBrackets(string combination, int open, int close)
        {
            if (open > 0)
            {
                generateBrackets(combination+"(", open-1, close);
            }
            if (close > open)
            {
                generateBrackets(combination+")", open, close-1);
            }
            if (close == 0)
            {
                brackets.Add(combination);
            }
            return;
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            int num = int.Parse(Console.ReadLine());
            obj.generateBrackets("",num,num);
            foreach (var combination in obj.brackets)
            {
                Console.WriteLine(combination);
            }
        }
    }
}