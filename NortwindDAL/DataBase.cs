using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NortwindDAL
{
    public class DataBase
    {
        static SqlConnection sql;

        public static SqlConnection Sql
        {
            get { return DataBase.sql; }
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["LibraryConnection"].ConnectionString;
        }

        public static SqlConnection GetSqlConnection()
        {
            sql = new SqlConnection(GetConnectionString());
            sql.Open();

            return sql;
        }

        public static void BeforeClosing()
        {
            if (sql != null && sql.State == ConnectionState.Open)
                sql.Close();
        }

        public static bool GetStateConnection()
        {
            if (sql != null && sql.State == ConnectionState.Open)
                return true;
            return false;
        }
    }
}
