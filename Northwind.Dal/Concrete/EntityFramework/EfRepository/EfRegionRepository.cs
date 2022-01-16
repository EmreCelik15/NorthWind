using Microsoft.EntityFrameworkCore;
using Northwind.Dal.Abstract.IRepository;
using Northwind.Dal.Concrete.EntityFramework.GenericRepository;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.EntityFramework.EfRepository
{
    public class EfRegionRepository : EfGenericRepository<Region>, IRegionRepository
    {
        public EfRegionRepository(DbContext context) : base(context)
        {
        }
        public IQueryable CustomerReport()
        {
            return set.AsQueryable();
        }
    
    }
}
