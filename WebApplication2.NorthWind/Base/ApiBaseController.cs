using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Entity.Base;
using Northwind.Entity.IBase;
using Northwind.InterfaceLayer.IGenericService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nortwind.WebApi.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController<TInterface, T, TDto> : ControllerBase where TInterface : IGenericService<T, TDto> where T : EntityBase where TDto : DtoBase
    {
        private readonly TInterface service;

        public ApiBaseController(TInterface service)
        {
            this.service = service;
        }

        [HttpGet("Find")]
        public IResponseBase<TDto> Find(int id)
        {
            try
            {

                return service.Find(id);
            }
            catch (Exception ex)
            {
                return new ResponseBase<TDto>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

        [HttpGet("Finds")]
        public IResponseBase<TDto> Find(string id)
        {
            try
            {

                return service.Find(id);
            }
            catch (Exception ex)
            {
                return new ResponseBase<TDto>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

        [HttpGet("GetAll")]
        public IResponseBase<List<TDto>> GetAll()
        {
            try
            {
                return service.GetAll();
            }
            catch (Exception ex)
            {
                return new ResponseBase<List<TDto>>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }
    }
}
