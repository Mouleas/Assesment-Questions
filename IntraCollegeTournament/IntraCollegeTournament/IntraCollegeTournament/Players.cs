using ConsoleTables;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace IntraCollegeTournament
{
    public class Players : Connection
    {

        int GetPayment(int TID)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT M.FEE FROM MASTERSPORTS M WHERE M.SPORT_ID = (SELECT T.SPORT_ID FROM TOURNAMENT T LEFT JOIN PLAYERS P ON P.TID = T.TID WHERE T.TID = {TID})";

            SqlDataReader reader = cmd.ExecuteReader();
            int fee = 0;
            while (reader.Read())
            {
                fee = (int)reader[0];
            }
            reader.Close();
            connection.Close();
            return fee;
        }
        public void ShowPlayers(int TID)
        {
            ConsoleTable table = new ConsoleTable("Player ID", "Player Name", "Sport Name", "Score");
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT P.ID,P.PNAME,M.SPORT_NAME,P.SCORE FROM PLAYERS P INNER JOIN (SELECT T.TID, M.SPORT_NAME FROM TOURNAMENT T INNER JOIN MASTERSPORTS M ON T.SPORT_ID = M.SPORT_ID) M ON P.TID=M.TID WHERE P.TID = {TID};";

            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("Players in the tournament:");
            Console.WriteLine(":::::::::::::::::::::::::::::::");

            while (reader.Read())
            {
                table.AddRow(reader[0], (""+reader[1]).Trim(), (""+reader[2]).Trim(), reader[3]);
            }
            table.Write();
            Console.WriteLine(":::::::::::::::::::::::::::::::\n");

            reader.Close();
            connection.Close();

        }

        public void AddPlayerOrTeam()
        {
            new Tournament().ShowTournament();
            Console.WriteLine("Enter tournament ID: ");
            int TID = int.Parse(Console.ReadLine());
            int fee = GetPayment(TID);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            Console.WriteLine("Enter Name: ");
            string playerName = Console.ReadLine();
            Console.WriteLine($"Entry Fee payment: ${fee}");
            Console.WriteLine("Press any key to pay");
            Console.ReadKey();
            cmd.CommandText = $"INSERT INTO PLAYERS VALUES('{playerName}',{TID},DEFAULT)";
            cmd.ExecuteReader();
            connection.Close();
        }

        public void RemovePlayer(int PID) 
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"DELETE FROM PLAYERS WHERE ID={PID}";
            cmd.ExecuteReader();
            connection.Close();
        }
    }
}
