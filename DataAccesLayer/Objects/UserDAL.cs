using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class UserDAL
    {
        #region Direct Properties
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public DateTime AccountCreateDate { get; set; }
        public string PhototURL { get; set; }
        #endregion direct properties

        #region indirect properties

        #endregion indirect properties

        
    }
}
