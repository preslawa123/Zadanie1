using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_2.Data
{
    public static class Database
    {
        private static string ConnectonString = "Server = DESKTOP-H6STNB7; database = E_R_I_(1); integrated security = true;";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectonString);
        }
    }
}
