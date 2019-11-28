using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Province")]
    public partial class TblProvince
    {
        public TblProvince()
        {
            TblCity = new HashSet<TblCity>();
        }

        [Key]
        [Column("Province_ID")]
        public int ProvinceId { get; set; }
        [Column("Province_GUID")]
        public Guid ProvinceGuid { get; set; }
        [Required]
        [Column("Province_Name")]
        [StringLength(50)]
        public string ProvinceName { get; set; }
        [Required]
        [Column("Province_Display")]
        [StringLength(50)]
        public string ProvinceDisplay { get; set; }
        [Column("Province_CityID")]
        public int ProvinceCityId { get; set; }

        [InverseProperty("CityProvince")]
        public virtual ICollection<TblCity> TblCity { get; set; }
    }
}
