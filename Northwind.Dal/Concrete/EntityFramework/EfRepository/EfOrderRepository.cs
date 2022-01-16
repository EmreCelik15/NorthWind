using Microsoft.EntityFrameworkCore;
using Northwind.Dal.Abstract.IRepository;
using Northwind.Dal.Concrete.EntityFramework.GenericRepository;
using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.EntityFramework.EfRepository
{
    public class EfOrderRepository : EfGenericRepository<Order> ,IOrderRepository
    {
        public EfOrderRepository(DbContext context) : base(context)
        {
        }

        public IQueryable CustomerReport(int orderId)
        {
            return set.AsQueryable();
        }
    }
}
