using ConsoleTables;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntraCollegeTournament
{
    public class Tournament : Connection
    {
        public void ShowTournament()
        {
            ConsoleTable table = new ConsoleTable("Tournament ID", "Tournament Name","Winner","Satus");
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT T.TID, M.SPORT_NAME, T.WINNER, T.STATUS FROM TOURNAMENT T INNER JOIN MASTERSPORTS M ON T.SPORT_ID = M.SPORT_ID;";

            SqlDataReader reader = cmd.ExecuteReader();
            
            Console.WriteLine(":::::::::::::::::::::::::::::::\n");
            Console.WriteLine("*********\\TOURNAMENT DETAILS/*********");

            while (reader.Read())
            {
                table.AddRow(reader[0], ("" + reader[1]).Trim(), ("" + reader[2]).Trim(), (""+reader[3]).Trim());

            }
            table.Write();
            Console.WriteLine(":::::::::::::::::::::::::::::::");
            reader.Close();
            connection.Close();
        }
        public void AddTournament(int ID)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"INSERT INTO TOURNAMENT VALUES({ID},NULL,'IN PROGRESS')";
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ID} is not present in the MasterDB...");
            }
            Console.WriteLine();
            connection.Close();
        }

        public void RemoveTournament(int TID)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"DELETE FROM TOURNAMENT WHERE TID={TID}";
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{TID} is not present in the table...");
            }
            Console.WriteLine();
            connection.Close();
        }

        public void EndTournament( int TID )
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"SELECT PNAME,SCORE FROM PLAYERS WHERE SCORE = (SELECT MAX(SCORE) FROM PLAYERS) AND TID = {TID};";

            SqlDataReader reader = cmd.ExecuteReader();
            int count = 0;
            string name = "";
            while ( reader.Read() )
            {
                name = (""+reader[0]).Trim();
                count++;
            }
            reader.Close();
            cmd.CommandText = $"UPDATE TOURNAMENT SET STATUS = 'ENDED' WHERE TID={TID}";
            cmd.ExecuteReader();
            connection.Close();
            if (count == 1)
            {
                connection.Open();
                cmd = connection.CreateCommand();
                Console.WriteLine(name);
                cmd.CommandText = $"UPDATE TOURNAMENT SET WINNER = '{name}'  WHERE TID={TID}";
                cmd.ExecuteReader();
            }
            connection.Close();
        }
    }
}
