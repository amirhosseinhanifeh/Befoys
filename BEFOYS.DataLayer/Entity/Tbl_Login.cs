using System;
using System.ComponentModel.DataAnnotations;

namespace BEFOYS.DataLayer.Entity
{
    public class Tbl_Login
    {
        [Key]
        public int Login_ID { get; set; }
        public Guid Login_GUID { get; set; }
        public string Login_PasswordHash { get; set; }
        public string Login_PasswordSalt { get; set; }
        public string Login_Email { get; set; }
        public string Login_Mobile { get; set; }
        public bool? Login_IsBan { get; set; }
        public bool? Login_IsDelete { get; set; }
        public bool? Login_IsRegister { get; set; }
        public int? Login_PTID { get; set; }
        public int? Login_BRID { get; set; }


    }
}
