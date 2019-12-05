using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Tags")]
    public partial class TblTags
    {
        public TblTags()
        {
            TblProductCategoryTags = new HashSet<TblProductCategoryTags>();
            TblProductTags = new HashSet<TblProductTags>();
        }

        [Key]
        [Column("Tags_ID")]
        public int TagsId { get; set; }
        [Column("Tags_Guid")]
        public Guid TagsGuid { get; set; }
        [Required]
        [Column("Tags_Name")]
        public string TagsName { get; set; }
        [Column("Tags_IsDelete")]
        public bool TagsIsDelete { get; set; }

        [InverseProperty("PctTags")]
        public virtual ICollection<TblProductCategoryTags> TblProductCategoryTags { get; set; }
        [InverseProperty("PtTags")]
        public virtual ICollection<TblProductTags> TblProductTags { get; set; }
    }
}
