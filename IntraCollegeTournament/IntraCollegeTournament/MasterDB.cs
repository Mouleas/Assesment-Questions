using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntraCollegeTournament
{
    public class MasterDB : Connection
    {
        public void ShowSports()
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM MASTERSPORTS";
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("Available Sports in MASTER-DB:");
            int sportId = 0;
            while (reader.Read())
            {
                Console.WriteLine($"{++sportId}: {reader[0]}");
            }
            reader.Close();
            connection.Close();

        }

        public void AddSports(string sport)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = $"INSERT INTO MASTERSPORTS VALUES('{sport}')";
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{sport} is already present in the table...");
            }
            Console.WriteLine();
            connection.Close();
        }

        public void RemoveSports(string sport)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"DELETE FROM MASTERSPORTS WHERE SPORTS='{sport}'";
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{sport} is not present in the table...");
            }
            Console.WriteLine();
            connection.Close();

        }
    }
}
