using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Planner.DataAccess
{
    public class Newclass
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString());

        public static bool UserIsValid(string username, string password)
        {
            bool authenticated = false;
            string query = string.Format("SELECT * FROM [User] where Username='{0}' and password='{1}'", username, password);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            authenticated = sdr.HasRows;
            conn.Close();
            return (authenticated);
        }

    }
}