using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductCode")]
    public partial class TblProductCode
    {
        [Key]
        [Column("PC_ID")]
        public int PcId { get; set; }
        [Column("PC_Guid")]
        public Guid PcGuid { get; set; }
        [Required]
        [Column("PC_Code")]
        public string PcCode { get; set; }
        [Column("PC_ProductID")]
        public int PcProductId { get; set; }
        [Column("PC_OrganizationID")]
        public int PcOrganizationId { get; set; }
        [Column("PC_PColorsID")]
        public int? PcPcolorsId { get; set; }
        [Column("PC_QRCode")]
        public string PcQrcode { get; set; }

        [ForeignKey(nameof(PcOrganizationId))]
        [InverseProperty(nameof(TblOrganization.TblProductCode))]
        public virtual TblOrganization PcOrganization { get; set; }
        [ForeignKey(nameof(PcPcolorsId))]
        [InverseProperty(nameof(TblColors.TblProductCode))]
        public virtual TblColors PcPcolors { get; set; }
        [ForeignKey(nameof(PcProductId))]
        [InverseProperty(nameof(TblProduct.TblProductCode))]
        public virtual TblProduct PcProduct { get; set; }
    }
}
