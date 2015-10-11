using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NortwindDAL;

namespace WinForms_DAL
{
    public class Publicher
    {
        private Publichers publicherFromList;
        private string title;

        public Publicher(Publichers pbl, string tl)
        {
            publicherFromList = pbl;
            title = tl;
        }

        public Publichers PublicherFromList
        {
            get
            {
                return publicherFromList;
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
