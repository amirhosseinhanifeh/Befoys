using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_OrganizationRole")]
    public partial class TblOrganizationRole
    {
        public TblOrganizationRole()
        {
            InverseOrOr = new HashSet<TblOrganizationRole>();
            TblEmployee = new HashSet<TblEmployee>();
            TblOrganizationRolePermission = new HashSet<TblOrganizationRolePermission>();
        }

        [Key]
        [Column("OR_ID")]
        public int OrId { get; set; }
        [Column("OR_Guid")]
        public Guid OrGuid { get; set; }
        [Column("OR_ORID")]
        public int OrOrid { get; set; }
        [Column("OR_OrganizationID")]
        public int OrOrganizationId { get; set; }
        [Column("OR_Display")]
        public string OrDisplay { get; set; }
        [Column("OR_CanCreateRole")]
        public bool OrCanCreateRole { get; set; }
        [ForeignKey(nameof(OrOrid))]
        [InverseProperty(nameof(TblOrganizationRole.InverseOrOr))]
        public virtual TblOrganizationRole OrOr { get; set; }
        [ForeignKey(nameof(OrOrganizationId))]
        [InverseProperty(nameof(TblOrganization.TblOrganizationRole))]
        public virtual TblOrganization OrOrganization { get; set; }
        [InverseProperty(nameof(TblOrganizationRole.OrOr))]
        public virtual ICollection<TblOrganizationRole> InverseOrOr { get; set; }
        [InverseProperty("EmployeeOr")]
        public virtual ICollection<TblEmployee> TblEmployee { get; set; }
        [InverseProperty("OrpOr")]
        public virtual ICollection<TblOrganizationRolePermission> TblOrganizationRolePermission { get; set; }
    }
}
