using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ViewModels.Register;
using BEFOYS.Service.BaseRepository;

namespace BEFOYS.Service.IServices
{
    public interface ILoginService : IBaseRepository<TblLogin>
    {
        bool Check(ViewBaseRegister model);
    }
}
