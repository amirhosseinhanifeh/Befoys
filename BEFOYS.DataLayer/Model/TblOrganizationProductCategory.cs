using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_OrganizationProductCategory")]
    public partial class TblOrganizationProductCategory
    {
        [Key]
        [Column("OPC_ID")]
        public int OpcId { get; set; }
        [Column("OPC_Guid")]
        public Guid OpcGuid { get; set; }
        [Column("OPC_OrganizationID")]
        public int OpcOrganizationId { get; set; }
        [Column("OPC_PCID")]
        public int OpcPcid { get; set; }
        [Column("OPC_IsAccept")]
        public bool OpcIsAccept { get; set; }
        [Column("OPC_Reason")]
        public string OpcReason { get; set; }

        [ForeignKey(nameof(OpcOrganizationId))]
        [InverseProperty(nameof(TblOrganization.TblOrganizationProductCategory))]
        public virtual TblOrganization OpcOrganization { get; set; }
        [ForeignKey(nameof(OpcPcid))]
        [InverseProperty(nameof(TblProductCategory.TblOrganizationProductCategory))]
        public virtual TblProductCategory OpcPc { get; set; }
    }
}
