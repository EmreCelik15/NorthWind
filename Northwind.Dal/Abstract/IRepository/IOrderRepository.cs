using Northwind.Dal.Abstract.IGenericRepository;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Abstract.IRepository
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        //TODO : örnek olması için deneme amaçlı metod.
        //TODO : bu sınıfa generic repositoryden kalıtım vermemiz gerekmez miydi?
        IQueryable CustomerReport(int orderId);
    }
}
