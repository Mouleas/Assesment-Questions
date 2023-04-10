using Microsoft.Data.SqlClient;
using ConsoleTables;

namespace IntraCollegeTournament
{
    public class Program : Connection
    {
        static void Main(string[] args)
        {
            Tournament tournamentObj = new Tournament();
            MasterDB masterObj = new MasterDB();
            Players playerObj = new Players();
            ScoreBoard scoreBoardObj = new ScoreBoard();

            ConsoleTable table = new ConsoleTable("Director Handling", "Tournament Handling", "Player Handling", "ScoreBoard");

            bool flag = true;
            while (flag)
            {
                table.AddRow("1.ADD SPORTS TO MASTER DB", "4.ADD TOURNAMENT", "7.SHOW PLAYERS", "10.UPDATE BOARD");
                table.AddRow("2.REMOVE SPORT", "5.REMOVE TOUNAMENT", "8.REMOVE PLAYER", "11.END TOURNAMENT");
                table.AddRow("3.SHOW SPORTS", "6.SHOW TOURNAMENT", "9.ADD PLAYER", "");

                table.Write();
                
                Console.WriteLine();
                Console.WriteLine("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
               
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter sport name: ");
                        string sport = Console.ReadLine();
                        Console.WriteLine("Enter sport ID: ");
                        int ID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter fee: ");
                        int fee = int.Parse(Console.ReadLine());
                        masterObj.AddSports(sport.ToUpper(),ID,fee);
                        Console.WriteLine();
                        Console.WriteLine("PRESS ENTER TO CONTINUE...");
                        Console.ReadKey();
                        break;

                    case 2:
                        masterObj.ShowSports();
                        Console.WriteLine("Enter SPORT_ID: ");
                        ID = int.Parse(Console.ReadLine());
                        masterObj.RemoveSports(ID);
                        Console.WriteLine();
                        Console.WriteLine("PRESS ENTER TO CONTINUE...");
                        Console.ReadKey();
                        break;

                    case 3:
                        masterObj.ShowSports();
                        Console.WriteLine();
                        Console.WriteLine("PRESS ENTER TO CONTINUE...");
                        Console.ReadKey();
                        break;

                    case 4:
                        masterObj.ShowSports();
                        Console.WriteLine("Enter SPORT_ID: ");
                        ID = int.Parse(Console.ReadLine());
                        tournamentObj.AddTournament(ID);
                        Console.WriteLine();
                        Console.WriteLine("PRESS ENTER TO CONTINUE...");
                        Console.ReadKey();
                        break;

                    case 5:
                        tournamentObj.ShowTournament();
                        Console.WriteLine("Enter tournament ID: ");
                        ID = int.Parse(Console.ReadLine());
                        tournamentObj.RemoveTournament(ID);
                        Console.WriteLine();
                        Console.WriteLine("PRESS ENTER TO CONTINUE...");
                        Console.ReadKey();
                        break;

                    case 6:
                        tournamentObj.ShowTournament();
                        Console.WriteLine();
                        Console.WriteLine("PRESS ENTER TO CONTINUE...");
                        Console.ReadKey();
                        break;

                    case 7:
                        tournamentObj.ShowTournament();
                        Console.WriteLine("Enter tornament ID: ");
                        ID = int.Parse(Console.ReadLine());
                        playerObj.ShowPlayers(ID);
                        Console.WriteLine("PRESS ENTER TO CONTINUE...");
                        Console.ReadKey();
                        break;

                    case 8:
                        Console.WriteLine("Enter player ID: ");
                        ID = int.Parse(Console.ReadLine());
                        playerObj.RemovePlayer(ID);
                        Console.WriteLine("PRESS ENTER TO CONTINUE...");
                        Console.ReadKey();
                        break;

                    case 9:
                        playerObj.AddPlayerOrTeam();
                        Console.WriteLine("PRESS ENTER TO CONTINUE...");
                        Console.ReadKey();
                        break;

                    case 10:
                        tournamentObj.ShowTournament();
                        Console.WriteLine("Enter tournament ID: ");
                        ID = int.Parse(Console.ReadLine());
                        scoreBoardObj.EditScoreBoard(ID);
                        Console.WriteLine("PRESS ENTER TO CONTINUE...");
                        Console.ReadKey();
                        break;

                    case 11:
                        tournamentObj.ShowTournament();
                        Console.WriteLine("Enter tournament ID: ");
                        ID = int.Parse(Console.ReadLine());
                        tournamentObj.EndTournament(ID);
                        break;

                    default:
                        flag = false;
                        break;
                }

            }
          
        }
    }
}