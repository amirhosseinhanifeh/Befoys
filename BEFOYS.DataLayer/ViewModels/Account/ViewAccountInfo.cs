using BEFOYS.DataLayer.ViewModels.Permission;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Account
{
   public class ViewAccountInfo
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsBan { get; set; }
        public string Picture { get; set; }
        public List<ViewPermission> Permissions { get; set; }
    }
}
