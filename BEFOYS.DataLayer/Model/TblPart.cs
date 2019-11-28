using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Part")]
    public partial class TblPart
    {
        [Key]
        [Column("Part_ID")]
        public int PartId { get; set; }
        [Column("Part_GUID")]
        public Guid PartGuid { get; set; }
        [Required]
        [Column("Part_Name")]
        [StringLength(50)]
        public string PartName { get; set; }
        [Required]
        [Column("Part_Display")]
        [StringLength(50)]
        public string PartDisplay { get; set; }
        [Column("Part_CityID")]
        public int PartCityId { get; set; }

        [ForeignKey(nameof(PartCityId))]
        [InverseProperty(nameof(TblCity.TblPart))]
        public virtual TblCity PartCity { get; set; }
    }
}
