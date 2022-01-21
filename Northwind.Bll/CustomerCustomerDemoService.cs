using Northwind.Bll.Base;
using Northwind.Dal.Abstract.IRepository;
using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using Northwind.InterfaceLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bll
{
    public class CustomerCustomerDemoService : BllBase<CustomerCustomerDemo, DtoCustomerCustomerDemo>, ICustomerCustomerDemoService
    {
        public readonly ICustomerCustomerDemoRepository customerCustomerDemoRepository;
        public CustomerCustomerDemoService(IServiceProvider service) : base(service)
        {

        }
        public IQueryable CategoryReport()
        {
            throw new NotImplementedException();
        }
    }
}
