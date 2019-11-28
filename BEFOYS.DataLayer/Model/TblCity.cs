using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_City")]
    public partial class TblCity
    {
        public TblCity()
        {
            TblAddress = new HashSet<TblAddress>();
            TblAreaCode = new HashSet<TblAreaCode>();
            TblPart = new HashSet<TblPart>();
        }

        [Key]
        [Column("City_ID")]
        public int CityId { get; set; }
        [Column("City_GUID")]
        public Guid CityGuid { get; set; }
        [Required]
        [Column("City_Name")]
        [StringLength(50)]
        public string CityName { get; set; }
        [Required]
        [Column("City_Display")]
        [StringLength(50)]
        public string CityDisplay { get; set; }
        [Column("City_ProvinceID")]
        public int CityProvinceId { get; set; }
        [Column("City_IsCapital")]
        public bool CityIsCapital { get; set; }

        [ForeignKey(nameof(CityProvinceId))]
        [InverseProperty(nameof(TblProvince.TblCity))]
        public virtual TblProvince CityProvince { get; set; }
        [InverseProperty("AddressCity")]
        public virtual ICollection<TblAddress> TblAddress { get; set; }
        [InverseProperty("AcCity")]
        public virtual ICollection<TblAreaCode> TblAreaCode { get; set; }
        [InverseProperty("PartCity")]
        public virtual ICollection<TblPart> TblPart { get; set; }
    }
}
