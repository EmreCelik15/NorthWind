using Northwind.Entity.Dto;
using Northwind.Entity.IBase;
using Northwind.Entity.Models;
using Northwind.InterfaceLayer.IGenericService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.InterfaceLayer.Abstract
{
    public interface IUserService : IGenericService<User, DtoUser>
    {
        IResponseBase<DtoUserToken> Login(DtoLogin login);
    }
}
