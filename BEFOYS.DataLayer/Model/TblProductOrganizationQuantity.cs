using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductOrganizationQuantity")]
    public partial class TblProductOrganizationQuantity
    {
        [Key]
        [Column("POQ_ID")]
        public int PoqId { get; set; }
        [Column("POQ_Guid")]
        public Guid PoqGuid { get; set; }
        [Column("POQ_POID")]
        public int PoqPoid { get; set; }
        [Column("POQ_ColorID")]
        public int? PoqColorId { get; set; }
        [Column("POQ_Inventory")]
        public int PoqInventory { get; set; }
        [Column("POQ_ProvinceID")]
        public int? PoqProvinceId { get; set; }

        [ForeignKey(nameof(PoqColorId))]
        [InverseProperty(nameof(TblColors.TblProductOrganizationQuantity))]
        public virtual TblColors PoqColor { get; set; }
        [ForeignKey(nameof(PoqPoid))]
        [InverseProperty(nameof(TblProductOrganization.TblProductOrganizationQuantity))]
        public virtual TblProductOrganization PoqPo { get; set; }
        [ForeignKey(nameof(PoqProvinceId))]
        [InverseProperty(nameof(TblProvince.TblProductOrganizationQuantity))]
        public virtual TblProvince PoqProvince { get; set; }
    }
}
