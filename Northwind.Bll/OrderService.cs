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
    public class OrderService : BllBase<Order, DtoOrder>, IOrderService
    {
        public readonly IOrderDetailRepository orderRepository;
        public OrderService(IServiceProvider service) : base(service)
        {

        }
        public IQueryable OrderReport(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
