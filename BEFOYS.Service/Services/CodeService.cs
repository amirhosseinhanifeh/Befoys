using BEFOYS.DataLayer.Entity.Code;
using BEFOYS.DataLayer.Enums;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.Service.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEFOYS.Service.Services
{
    public class CodeService:ICodeService
    {
        private readonly ServiceContext _context;

        public CodeService(ServiceContext context)
        {
            _context = context;
        }

        public Tbl_Code GetByLabel(Enum_Code label)
        {
            return _context.Tbl_Code.FirstOrDefault(x => x.Code_Display == label.ToString());
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
