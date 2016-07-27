using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class PassPrimaryKeyEventArgs : EventArgs
    {
        private int pk; //field to store primary key
        public int PK
        {
            get { return pk; }
            set { pk = value; }
        }
    }
}
