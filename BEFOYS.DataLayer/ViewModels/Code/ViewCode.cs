using BEFOYS.DataLayer.Model;

namespace BEFOYS.DataLayer.ViewModels.Code
{
    public class ViewCode
    {
        public int? ID { get; set; }
        public int Code_CGID { get; set; }
        public string Code_Name { get; set; }
        public string Code_Display { get; set; }
        public ViewCode() { }
        public ViewCode(TblCode model)
        {
            Code_CGID = model.CodeCgid;
            Code_Display = model.CodeDisplay;
            Code_Name = model.CodeName;
            ID = model.CodeId;
        }
    }
}
