using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Northwind.Dal.Abstract.IRepository;
using Northwind.Dal.Concrete.EntityFramework.GenericRepository;
using Northwind.Entity.Dto;
using Northwind.Entity.Models;


namespace Northwind.Dal.Concrete.EntityFramework.EfRepository
{
    public class EfCustomerRepository : EfGenericRepository<Customer>, ICustomerRepository 
    {
        public EfCustomerRepository(DbContext context) : base(context)
        {
        }
        public IQueryable CustomerReport()
        {
            return set.AsQueryable();
        }
        public Customer Find(string id)
        {
            return set.Find(id);
        }
    }
}
