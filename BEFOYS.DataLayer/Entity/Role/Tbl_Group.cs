using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Role
{
    public class Tbl_Group
    {
        [Key]
        public int Group_ID { get; set; }
        public Guid Group_GUID { get; set; }
        public int Group_CodeID { get; set; }
        public string Group_Name { get; set; }
        public string Group_Display { get; set; }

    }
}
