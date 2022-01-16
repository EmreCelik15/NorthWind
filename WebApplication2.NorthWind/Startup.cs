using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Northwind.Bll;
using Northwind.Dal.Abstract;
using Northwind.Dal.Abstract.IGenericRepository;
using Northwind.Dal.Abstract.IRepository;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Dal.Concrete.EntityFramework.EfRepository;
using Northwind.Dal.Concrete.EntityFramework.GenericRepository;
using Northwind.Dal.Concrete.EntityFramework.UnitOfWork;
using Northwind.Entity.Mapper;
using Northwind.Entity.Models;
using Northwind.InterfaceLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.NorthWind
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();
            services.AddSingleton<ICustomerRepository, EfCustomerRepository>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IGenericRepository<Customer>, EfGenericRepository<Customer>>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<DbContext, NORTHWNDContext>();
            services.AddAutoMapper(typeof(MappingProfile));
   
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication2.NorthWind", Version = "v1" });
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication2.NorthWind v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
