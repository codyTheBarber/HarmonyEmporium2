using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harmony_Emporium.Models
{
    public class ModelUser
    {// for  the Front end layer can get this data and do stuff with it
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
        public string PhotoURL { get; set; }
    }
}