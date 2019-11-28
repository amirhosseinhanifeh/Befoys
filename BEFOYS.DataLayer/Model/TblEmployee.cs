using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Employee")]
    public partial class TblEmployee
    {
        public TblEmployee()
        {
            TblEmployeeRegistrationCode = new HashSet<TblEmployeeRegistrationCode>();
        }

        [Key]
        [Column("Employee_ID")]
        public int EmployeeId { get; set; }
        [Column("Employee_Guid")]
        public Guid EmployeeGuid { get; set; }
        [Column("Employee_LoginID")]
        public int? EmployeeLoginId { get; set; }
        [Column("Employee_OrganizationID")]
        public int EmployeeOrganizationId { get; set; }
        [Column("Employee_WalletSize")]
        public int EmployeeWalletSize { get; set; }
        [Column("Employee_IsAgent")]
        public bool EmployeeIsAgent { get; set; }
        [Column("Employee_ORID")]
        public int EmployeeOrid { get; set; }

        [ForeignKey(nameof(EmployeeLoginId))]
        [InverseProperty(nameof(TblLogin.TblEmployee))]
        public virtual TblLogin EmployeeLogin { get; set; }
        [ForeignKey(nameof(EmployeeOrid))]
        [InverseProperty(nameof(TblOrganizationRole.TblEmployee))]
        public virtual TblOrganizationRole EmployeeOr { get; set; }
        [ForeignKey(nameof(EmployeeOrganizationId))]
        [InverseProperty(nameof(TblOrganization.TblEmployee))]
        public virtual TblOrganization EmployeeOrganization { get; set; }
        [InverseProperty("ErcEmployee")]
        public virtual ICollection<TblEmployeeRegistrationCode> TblEmployeeRegistrationCode { get; set; }
    }
}
