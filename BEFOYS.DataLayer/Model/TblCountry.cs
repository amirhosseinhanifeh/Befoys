using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Country")]
    public partial class TblCountry
    {
        public TblCountry()
        {
            TblBrands = new HashSet<TblBrands>();
            TblProvince = new HashSet<TblProvince>();
        }

        [Key]
        [Column("Country_ID")]
        public int CountryId { get; set; }
        [Column("Country_Guid")]
        public Guid CountryGuid { get; set; }
        [Required]
        [Column("Country_Name")]
        [StringLength(50)]
        public string CountryName { get; set; }
        [Column("Country_FlagDocumentID")]
        public int? CountryFlagDocumentId { get; set; }

        [ForeignKey(nameof(CountryFlagDocumentId))]
        [InverseProperty(nameof(TblDocument.TblCountry))]
        public virtual TblDocument CountryFlagDocument { get; set; }
        [InverseProperty("BrandsCountryReference")]
        public virtual ICollection<TblBrands> TblBrands { get; set; }
        [InverseProperty("ProvinceCountry")]
        public virtual ICollection<TblProvince> TblProvince { get; set; }
    }
}
