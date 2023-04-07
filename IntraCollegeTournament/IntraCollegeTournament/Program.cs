using Microsoft.Data.SqlClient;

namespace IntraCollegeTournament
{
    internal class Program : Connection
    {
        static void Main(string[] args)
        {
            Program programObj = new Program();
            Tournament tournamentObj = new Tournament();
            MasterDB masterObj = new MasterDB();
            
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1.ADD SPORTS TO MASTER DB");
                Console.WriteLine("2.ADD TOURNAMENT");
                Console.WriteLine("3.DELETE SPORT");
                Console.WriteLine("4.REMOVE TOUNAMENT");
                Console.WriteLine("5.SHOW SPORTS");
                Console.WriteLine("6.SHOW TOURNAMENT");

                Console.WriteLine("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter sports name: ");
                        string sport = Console.ReadLine();
                        masterObj.AddSports(sport.ToUpper());
                        Console.WriteLine();
                        break;

                    case 2:
                        masterObj.ShowSports();
                        Console.WriteLine("Enter tournament name: ");
                        sport = Console.ReadLine();
                        tournamentObj.AddTournament(sport.ToUpper());
                        Console.WriteLine();
                        break;

                    case 3:
                        masterObj.ShowSports();
                        Console.WriteLine("Enter sports name: ");
                        sport = Console.ReadLine();
                        masterObj.RemoveSports(sport.ToUpper());
                        Console.WriteLine();
                        break;

                    case 4:
                        tournamentObj.ShowTournament();
                        Console.WriteLine("Enter tournament ID: ");
                        int ID = int.Parse(Console.ReadLine());
                        tournamentObj.RemoveTournament(ID);
                        Console.WriteLine();
                        break;

                    case 5:
                        masterObj.ShowSports();
                        Console.WriteLine();
                        break;

                    case 6:
                        tournamentObj.ShowTournament();
                        Console.WriteLine();
                        break;

                    default:
                        flag = false;
                        break;
                }

            }
          
        }
    }
}