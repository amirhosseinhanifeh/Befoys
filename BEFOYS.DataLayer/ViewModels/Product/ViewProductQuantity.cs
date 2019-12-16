using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Product
{
    public class ViewProductQuantity
    {
        public int PoqId { get; set; }
        public int? PoqColorId { get; set; }
        public int PoqInventory { get; set; }
        public int? PoqProvinceId { get; set; }
        public int? PoqBasePrice { get; set; }
    }
}
