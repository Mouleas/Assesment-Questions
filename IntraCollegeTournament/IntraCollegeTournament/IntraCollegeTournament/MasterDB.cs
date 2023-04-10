using ConsoleTables;
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
            ConsoleTable table = new ConsoleTable("Sports Name", "Sports ID", "Entry fee");
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM MASTERSPORTS";
            SqlDataReader reader = cmd.ExecuteReader();
            
            Console.WriteLine(":::::::::::::::::::::::::::::::\n");
            Console.WriteLine("Available Sports in MASTER-DB:");
            while (reader.Read())
            {
                table.AddRow(("" + reader[0]).Trim(), reader[1], reader[2]);
            }
            table.Write();
            Console.WriteLine(":::::::::::::::::::::::::::::::");
            reader.Close();
            connection.Close();

        }

        public void AddSports(string sport, int ID, int fee)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = $"INSERT INTO MASTERSPORTS VALUES('{sport}',{ID},{fee})";
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ID} or {sport} is already present in the table...");
            }
            Console.WriteLine();
            connection.Close();
        }

        public void RemoveSports(int ID)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"DELETE FROM MASTERSPORTS WHERE SPORT_ID={ID}";
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
