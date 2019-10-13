using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Account
{
    public class Tbl_BaseRole
    {
        [Key]
        public int BR_ID { get; set; }
        public Guid BR_GUID { get; set; }
    }
}
