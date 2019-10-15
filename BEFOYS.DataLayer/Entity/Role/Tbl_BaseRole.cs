using BEFOYS.DataLayer.Entity.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Role
{
    public class Tbl_BaseRole
    {
        [Key]
        public int BR_ID { get; set; }
        public Guid BR_GUID { get; set; }
        public string BR_Name { get; set; }
        public string BR_Display { get; set; }


        public ICollection<Tbl_AccountControl> AccountControls { get; set; }
    }
}
