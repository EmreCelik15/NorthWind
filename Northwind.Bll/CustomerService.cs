using Northwind.Bll.Base;
using Northwind.Dal.Abstract;
using Northwind.Dal.Abstract.IRepository;
using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using Northwind.InterfaceLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bll
{
    public class CustomerService :BllBase<Customer,DtoCustomer>, ICustomerService
    {
        public readonly ICustomerRepository customerRepository;
        public CustomerService(IServiceProvider service) :base(service)
        {
            
        }

        public IQueryable CustomerReport()
        {
            throw new NotImplementedException();
        }
    }
}
