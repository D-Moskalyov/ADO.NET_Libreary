using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortwindDAL
{
    public class Publichers
    {
        int publicherID;

        public int PublicherID
        {
            get { return publicherID; }
            set { publicherID = value; }
        }
        string title = string.Empty;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    }
}
