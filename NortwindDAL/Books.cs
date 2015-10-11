using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NortwindDAL
{
    public class Books
    {
        int bookID;

        public int BookID
        {
            get { return bookID; }
            set { bookID = value; }
        }
        string title = string.Empty;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        int writerID;

        public int WriterID
        {
            get { return writerID; }
            set { writerID = value; }
        }
        int publicherID;

        public int PublicherID
        {
            get { return publicherID; }
            set { publicherID = value; }
        }

    }
}
