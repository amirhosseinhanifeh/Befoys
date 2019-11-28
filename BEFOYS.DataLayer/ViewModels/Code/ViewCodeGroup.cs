using BEFOYS.DataLayer.Model;

namespace BEFOYS.DataLayer.ViewModels.Code
{
    public class ViewCodeGroup
    {
        public int? ID { get; set; }
        public string CG_Name { get; set; }
        public string CG_Display { get; set; }
        public ViewCodeGroup() { }
        public ViewCodeGroup(TblCodeGroup model)
        {
            CG_Display = model.CgDisplay;
            CG_Name = model.CgName;
            ID = model.CgId;
        }
    }
}
