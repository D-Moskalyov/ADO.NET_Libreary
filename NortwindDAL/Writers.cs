using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortwindDAL
{
    public class Writers
    {
        int writerID;

        public int WriterID
        {
            get { return writerID; }
            set { writerID = value; }
        }
        string firstName = string.Empty;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        string lastName = string.Empty;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
}
