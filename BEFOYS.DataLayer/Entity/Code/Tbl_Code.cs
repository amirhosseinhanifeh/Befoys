using System;
using System.ComponentModel.DataAnnotations;

namespace BEFOYS.DataLayer.Entity.Code
{
    public class Tbl_Code
    {
        [Key]
        public int Code_ID { get; set; }
        public Guid Code_GUID { get; set; }
    }
}
