using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductOrganizationDiscount")]
    public partial class TblProductOrganizationDiscount
    {
        [Key]
        [Column("POD_ID")]
        public int PodId { get; set; }
        [Column("POD_Guid")]
        public Guid PodGuid { get; set; }
        [Column("POD_FromCount")]
        public int PodFromCount { get; set; }
        [Column("POD_ToCount")]
        public int PodToCount { get; set; }
        [Column("POD_PercentValue")]
        public double PodPercentValue { get; set; }
        [Column("POD_POID")]
        public int PodPoid { get; set; }
        [Column("POD_PreparationTime")]
        public double? PodPreparationTime { get; set; }

        [ForeignKey(nameof(PodPoid))]
        [InverseProperty(nameof(TblProductOrganization.TblProductOrganizationDiscount))]
        public virtual TblProductOrganization PodPo { get; set; }
    }
}
