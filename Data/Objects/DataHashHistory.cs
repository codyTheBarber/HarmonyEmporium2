using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Objects
{
    public class DataHashHistory
    {
        public int UserID { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
    }
}
