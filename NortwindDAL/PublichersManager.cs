using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NortwindDAL
{
    public class PublichersManager
    {
        static List<Publichers> publichers = new List<Publichers>();

        public static List<Publichers> Publichers
        {
            get { return publichers; }
            set { publichers = value; }
        }

        public static void LoadPublicher(SqlDataReader reader)
        {
 
            while (reader.Read())
            {
                Publichers publicher = new Publichers();

                publicher.PublicherID = (int)reader["PublicherID"];
                publicher.Title = reader["Title"].ToString();

                publichers.Add(publicher);
            }
        }
        public static bool SearchConnect()
        {
            if (PublichersManager.Publichers.Count == 0)
            {
                if (!DataBase.GetStateConnection())
                {
                    if (DataBase.GetSqlConnection().State == ConnectionState.Open)
                    {
                        string query = "select * from Publichers";
                        SqlCommand command = new SqlCommand(query, DataBase.Sql);
                        SqlDataReader reader = command.ExecuteReader();
                        PublichersManager.LoadPublicher(reader);
                        reader.Close();
                    }
                }
                else
                {
                    string query = "select * from Publichers";
                    SqlCommand command = new SqlCommand(query, DataBase.Sql);
                    SqlDataReader reader = command.ExecuteReader();
                    PublichersManager.LoadPublicher(reader);
                    reader.Close();
                }
            }
            if (PublichersManager.Publichers.Count != 0)
                return true;
            return false;
        }
        public static Publichers GetPublicher(int id)
        {
            Publichers publicher = new Publichers();

            SearchConnect();

            //if (!DataBase.GetStateConnection())
            //{
            //    if (DataBase.GetSqlConnection().State == ConnectionState.Open)
            //    {
            //        string query = string.Format("select * from Publichers where PublicherID = {0}", id.ToString());
            //        SqlCommand command = new SqlCommand(query, DataBase.Sql);
            //        SqlDataReader reader = command.ExecuteReader();
            //        reader.Read();

            //        publicher.PublicherID = (int)reader["PublicherID"];
            //        publicher.Title = reader["Title"].ToString();
            //        reader.Close();
            //    }
            //}
            //else
            //{
            //    string query = string.Format("select * from Publichers where PublicherID = {0}", id.ToString());
            //    SqlCommand command = new SqlCommand(query, DataBase.Sql);
            //    SqlDataReader reader = command.ExecuteReader();
            //    reader.Read();

            //    publicher.PublicherID = (int)reader["PublicherID"];
            //    publicher.Title = reader["Title"].ToString();
            //    reader.Close();
            //}

            foreach (Publichers pbl in PublichersManager.Publichers)
            {
                if (pbl.PublicherID == id)
                    publicher = pbl;
            }

            return publicher;
        }
    }
}
