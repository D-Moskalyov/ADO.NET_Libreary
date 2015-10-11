using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NortwindDAL;

namespace WinForms_DAL
{
    public class Writer
    {
        private Writers writerFromList;
        private string firstLastName;

        public Writer(Writers wrt, string fn, string ln)
        {
            writerFromList = wrt;
            firstLastName = fn + " " + ln;
        }

        public Writers WriterFromList
        {
            get
            {
                return writerFromList;
            }
        }

        public string FirstLastName
        {
            get
            {
                return firstLastName;
            }
        }
    }
}
