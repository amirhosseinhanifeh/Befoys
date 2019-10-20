using BEFOYS.DataLayer.Entity.Code;
using BEFOYS.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.Service.IServices
{
    public interface ICodeService:IDisposable
    {
        Tbl_Code GetByLabel(Enum_Code label);
    }
}
