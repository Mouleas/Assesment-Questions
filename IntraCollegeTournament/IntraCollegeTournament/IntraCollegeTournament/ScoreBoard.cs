using ConsoleTables;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IntraCollegeTournament
{
    public class ScoreBoard : Connection
    {
        public bool ValidTournament(int TID)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT STATUS FROM TOURNAMENT WHERE TID={TID}";
            SqlDataReader reader = cmd.ExecuteReader();
            string status = "";
            while (reader.Read())
            {
                status = ("" + reader[0]).Trim();
            }
            connection.Close();
            reader.Close();
            return !status.Equals("ENDED");
        }
        public void EditScoreBoard(int TID)
        {
            if (!ValidTournament(TID))
            {
                Console.WriteLine("********************************");
                Console.WriteLine("|   THIS TOURNAMENT IS ENDED   |");
                Console.WriteLine("********************************\n");
                return;
            }
            ConsoleTable table = new ConsoleTable("(Player/Team) ID", "(Player/Team) Name","Score");
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT ID,PNAME,SCORE FROM PLAYERS WHERE TID={TID}";
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine(":::::::::::::::::::::::::::::::\n");
            Console.WriteLine("List of players participating in this tournament: ");
            while (reader.Read())
            {
                table.AddRow(reader[0], ("" + reader[1]).Trim(), reader[2]);
            }
            table.Write();
            Console.WriteLine(":::::::::::::::::::::::::::::::\n");
            Console.WriteLine("Enter player/team ID: ");
            connection.Close();
            int PID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter points scored");
            int score = int.Parse(Console.ReadLine());
            connection.Open();
            cmd = connection.CreateCommand();
            cmd.CommandText = $"UPDATE PLAYERS SET SCORE = {score} WHERE ID = {PID}";
            cmd.ExecuteReader();
            Console.WriteLine();
            reader.Close();
            connection.Close();
        }
    }
}
