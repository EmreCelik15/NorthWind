using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Bll;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Dal.Concrete.EntityFramework.EfRepository;
using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using Northwind.InterfaceLayer.Abstract;
using Nortwind.WebApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nortwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ApiBaseController<ICustomerService, Customer, DtoCustomer>
    {
        public CustomersController(ICustomerService service) : base(service)
        {

        }
    }
}
