using BEFOYS.DataLayer.Entity.Account;
using BEFOYS.DataLayer.Entity.Organization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Employee
{
    public class Tbl_Employee
    {
        [Key]
        public int Employee_ID { get; set; }
        public Guid Employee_Guid { get; set; }
        public int Employee_LoginID { get; set; }
        public int Employee_OrganizationID { get; set; }
        public int Employee_TypeCodeID { get; set; }

        [ForeignKey("Employee_LoginID")]
        public Tbl_Login Login { get; set; }

        [ForeignKey("Employee_OrganizationID")]
        public Tbl_Organization MyProperty { get; set; }
    }
}
