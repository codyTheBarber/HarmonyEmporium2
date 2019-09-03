using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class BrandDAL
    {
        #region Direct Properties
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public DateTime BrandCreateDate { get; set; }
        public string BrandPhotoURL { get; set; }
        public string WebsiteURL { get; set; }
        #endregion
        
    }
}
