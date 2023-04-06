
namespace Ciper
{
    internal class Program
    {  
        // IN:  crazy
        // OUT: 20143
        List<int> GenerateKey(string key)
        {
            string temp = key;
            key = String.Concat(key.OrderBy(c => c));
            List<int> modifiedKey = new List<int>();

            foreach (char currChar in key)
            {
                int index = temp.IndexOf(currChar);
                while (modifiedKey.Contains(index)) 
                {
                    index++;
                }
                modifiedKey.Add(index);
            }

            return modifiedKey;
        }

        // Converts given message to ciper word
        void NicoCipher(string msg, string key)
        {
            int length = key.Length;
            string[] splitedWords = msg.Split();
            int indexer = 0;

            List<string> wordList = new List<string>();

            while (indexer < msg.Length)
            {
                string row = "";
                for (int j = 0; j < length; j++)
                {
                    if (indexer >= msg.Length)
                    {
                        row += " ";
                    }
                    else
                    {
                        row += msg[indexer++];
                    }
                }
                wordList.Add(row);
            }

            List<int> modifiedKey = GenerateKey(key);

            string ciperWord = "";
            foreach (string currRow in wordList)
            {
                foreach (int idx in modifiedKey)
                {
                    ciperWord += currRow[idx];
                }
            }

            Console.WriteLine(ciperWord);

        }
        static void Main(string[] args)
        {
            //string msg = Console.ReadLine();
            //string key = Console.ReadLine();

            new Program().NicoCipher("mubashirhassan", "crazy");
            new Program().NicoCipher("edabitisamazing", "matt");
            new Program().NicoCipher("iloveher", "612345");

        }
    }
}