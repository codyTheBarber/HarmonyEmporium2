using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harmony_Emporium.Models.ViewModels
{
    public class UserViewModel
    {
        public ModelUser SingleUser { get; set; }
        public List<ModelUser> AllUsers { get; set; }
        public List<ModelRoles> AllRoles { get; set; }
        public UserViewModel()
        {
            SingleUser = new ModelUser();
            AllUsers = new List<ModelUser>();
            AllRoles = new List<ModelRoles>();
        }
    }
}
//roleID is the foriegn key