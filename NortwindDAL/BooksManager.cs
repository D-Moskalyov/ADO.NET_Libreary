using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NortwindDAL
{
    public class BooksManager
    {
        static List<Books> books = new List<Books>();

        public static List<Books> Books
        {
            get { return books; }
            set { books = value; }
        }

        public static void LoadBook(SqlDataReader reader)
        {
            
            while (reader.Read())
            {
                Books book = new Books();

                book.BookID = (int)reader["BookID"];
                book.Title = reader["Title"].ToString();
                book.WriterID = (int)reader["WriterID"];
                book.PublicherID = (int)reader["PublicherID"];

                books.Add(book);
            }
        }

        public static bool SearchConnect()
        {
            if (BooksManager.Books.Count == 0)
            {
                if (!DataBase.GetStateConnection())
                {
                    if (DataBase.GetSqlConnection().State == ConnectionState.Open)
                    {
                        string query = "select * from Books";
                        SqlCommand command = new SqlCommand(query, DataBase.Sql);
                        SqlDataReader reader = command.ExecuteReader();
                        BooksManager.LoadBook(reader);
                        reader.Close();
                    }
                }
                else
                {
                    string query = "select * from Books";
                    SqlCommand command = new SqlCommand(query, DataBase.Sql);
                    SqlDataReader reader = command.ExecuteReader();
                    BooksManager.LoadBook(reader);
                    reader.Close();
                }
            }
            if (BooksManager.Books.Count != 0)
                return true;
            return false;
        }
    }
}
