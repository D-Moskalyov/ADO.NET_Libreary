using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NortwindDAL;

namespace WinForms_DAL
{
    public class Book
    {
        private Books bookFromList;
        private string title;

        public Book(Books bk, string tl)
        {
            bookFromList = bk;
            title = tl;
        }

        public Books BookFromList
        {
            get
            {
                return bookFromList;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
        }
    }
}
