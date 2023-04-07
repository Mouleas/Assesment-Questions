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
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM TOURNAMENT";
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("Tournaments Happening...");
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader[0]}");
                Console.WriteLine($"TournamentName: {reader[1]}");
                Console.WriteLine($"Winners: {reader[2]}\n");
            }
            reader.Close();
            connection.Close();
        }
        public void AddTournament(string tournament)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"INSERT INTO TOURNAMENT VALUES('{tournament}',NULL)";
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{tournament} is not present in the MasterDB...");
            }
            Console.WriteLine();
            connection.Close();
        }

        public void RemoveTournament(int ID)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"DELETE FROM TOURNAMENT WHERE ID={ID}";
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ID} is not present in the table...");
            }
            Console.WriteLine();
            connection.Close();

        }
    }
}
