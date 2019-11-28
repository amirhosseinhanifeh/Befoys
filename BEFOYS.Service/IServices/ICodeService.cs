using BEFOYS.DataLayer.Enums;
using BEFOYS.DataLayer.Model;
using System;

namespace BEFOYS.Service.IServices
{
    public interface ICodeService:IDisposable
    {
        TblCode GetByLabel(Enum_Code label);
    }
}
