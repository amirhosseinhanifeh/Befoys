using BEFOYS.DataLayer.Enums;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.Service.IServices;
using System.Linq;

namespace BEFOYS.Service.Services
{
    public class CodeService:ICodeService
    {
        private readonly ServiceContext _context;

        public CodeService(ServiceContext context)
        {
            _context = context;
        }

        public TblCode GetByLabel(Enum_Code label)
        {
            return _context.TblCode.FirstOrDefault(x => x.CodeDisplay == label.ToString());
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
