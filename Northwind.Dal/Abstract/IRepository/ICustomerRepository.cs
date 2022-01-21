using Northwind.Dal.Abstract.IGenericRepository;
using Northwind.Entity.Base;
using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Abstract.IRepository
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {
        //TODO : örnek olması için deneme amaçlı metod.
        //TODO : bu sınıfa generic repositoryden kalıtım vermemiz gerekmez miydi?
        IQueryable CustomerReport();
        
    }
}
