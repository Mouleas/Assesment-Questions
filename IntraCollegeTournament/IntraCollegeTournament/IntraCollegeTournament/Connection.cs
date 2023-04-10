using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntraCollegeTournament
{
    public class Connection
    {
        public static string CONN_STRING = "Data Source=5CG9410FHT;Initial Catalog=Test3;Integrated Security=True;Encrypt=False";
        public static SqlConnection connection = new SqlConnection(CONN_STRING);

    }
}
