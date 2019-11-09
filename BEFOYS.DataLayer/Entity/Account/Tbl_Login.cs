using BEFOYS.DataLayer.Entity.Address;
using BEFOYS.DataLayer.Entity.Supplier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Entity.Account
{
    public class Tbl_Login
    {
        [Key]
        public int Login_ID { get; set; }
        public Guid Login_GUID { get; set; } = Guid.NewGuid();
        public string Login_FirstName { get; set; }
        public string Login_LastName { get; set; }
        public string Login_Email { get; set; }
        public string Login_Mobile { get; set; }
        public bool? Login_IsBan { get; set; } = false;
        public bool? Login_IsDelete { get; set; } = false;
        public bool? Login_IsRegister { get; set; } = true;
        public DateTime Login_CreateDate { get; set; }
        public DateTime Login_ModifyDate { get; set; }

    }
}
