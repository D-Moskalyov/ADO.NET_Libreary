using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NortwindDAL
{
    public class WritersManager
    {
        static List<Writers> writers = new List<Writers>();

        public static List<Writers> Writers
        {
            get { return writers; }
            set { writers = value; }
        }

        public static void LoadWriter(SqlDataReader reader)
        {
         
            while (reader.Read())
            {
                Writers writer = new Writers();

                writer.WriterID = (int)reader["WriterID"];
                writer.FirstName = reader["FirstName"].ToString();
                writer.LastName = reader["LastName"].ToString();

                writers.Add(writer);
            }
        }
        public static bool SearchConnect()
        {
            if (WritersManager.Writers.Count == 0)
            {
                if (!DataBase.GetStateConnection())
                {
                    if (DataBase.GetSqlConnection().State == ConnectionState.Open)
                    {
                        string query = "select * from Writers";
                        SqlCommand command = new SqlCommand(query, DataBase.Sql);
                        SqlDataReader reader = command.ExecuteReader();
                        WritersManager.LoadWriter(reader);
                        reader.Close();
                    }
                }
                else
                {
                    string query = "select * from Writers";
                    SqlCommand command = new SqlCommand(query, DataBase.Sql);
                    SqlDataReader reader = command.ExecuteReader();
                    WritersManager.LoadWriter(reader);
                    reader.Close();
                }
            }
            if (WritersManager.Writers.Count != 0)
                return true;
            return false;
        }
        public static Writers GetWriter(int id)
        {
            Writers writer = new Writers();

            SearchConnect();

            //string query = string.Format("select * from Writers where WriterID = {0}", id.ToString());
            //if (!DataBase.GetStateConnection())
            //{
            //    if (DataBase.GetSqlConnection().State == ConnectionState.Open)
            //    {
            //        SqlCommand command = new SqlCommand(query, DataBase.Sql);
            //        SqlDataReader reader = command.ExecuteReader();
            //        reader.Read();

            //        writer.WriterID = (int)reader["WriterID"];
            //        writer.FirstName = reader["FirstName"].ToString();
            //        writer.LastName = reader["LastName"].ToString();
            //        reader.Close();
            //    }
            //}
            //else
            //{
            //    SqlCommand command = new SqlCommand(query, DataBase.Sql);
            //    SqlDataReader reader = command.ExecuteReader();
            //    reader.Read();

            //    writer.WriterID = (int)reader["WriterID"];
            //    writer.FirstName = reader["FirstName"].ToString();
            //    writer.LastName = reader["LastName"].ToString();
            //    reader.Close();
            //}

            foreach (Writers wrt in WritersManager.Writers)
            {
                if (wrt.WriterID == id)
                    writer = wrt;
            }

            return writer;
        }
    }
}
