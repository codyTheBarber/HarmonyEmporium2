using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class CategoryDAL
    {
        #region Direct Properties
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public DateTime CategoryCreateDate { get; set; }


        #endregion direct properties

        #region indirect properties
        //there are no indirect properties cause there are no foriegn keys
        #endregion indirect properties

        
    }
}
