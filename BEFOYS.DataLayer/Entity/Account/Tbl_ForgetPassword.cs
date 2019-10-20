using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Account
{
    public class Tbl_ForgetPassword
    {
        [Key]
        public int FP_ID { get; set; }
        public Guid FP_GUID { get; set; } = Guid.NewGuid();
    }
}
