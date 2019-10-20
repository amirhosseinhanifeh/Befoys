using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Entity.Code
{
    public class Tbl_Code
    {
        [Key]
        public int Code_ID { get; set; }
        public Guid Code_GUID { get; set; } = Guid.NewGuid();
        public int Code_CGID { get; set; }
        public string Code_Name { get; set; }
        public string Code_Display { get; set; }

        [ForeignKey("Code_CGID")]
        public Tbl_CodeGroup CodeGroup { get; set; }
    }
}
