using BEFOYS.DataLayer.Model;

namespace BEFOYS.DataLayer.ViewModels.Register.General
{
    public class ViewAddress
    {
        public string CityID { get; set; }
        public string Address { get; set; }
        public ViewPhone[] Phones { get; set; }
        public ViewAddress() { }
        public ViewAddress(TblAddress model)
        {
            CityID = model.AddressCity.CityGuid.ToString();
            Address = model.AddressText;
            
        }
    }
}
