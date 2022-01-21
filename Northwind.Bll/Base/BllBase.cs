using Northwind.Dal.Abstract;
using Northwind.Dal.Abstract.IGenericRepository;
using Northwind.Entity.Base;
using Northwind.InterfaceLayer.IGenericService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Entity.IBase;
using Microsoft.AspNetCore.Http;

namespace Northwind.Bll.Base
{
    public class BllBase<T, TDto> : IGenericService<T, TDto> where T : EntityBase where TDto : DtoBase
    {
        #region Variables
        public readonly IUnitOfWork unitOfWork;
        public readonly IServiceProvider service;
        public readonly IGenericRepository<T> repository;
        #endregion

        public BllBase(IServiceProvider service)
        {
            unitOfWork = service.GetService<IUnitOfWork>();
            repository = unitOfWork.GetRepository<T>();
            this.service = service;
            
        }

        public IResponseBase<TDto> Add(TDto entity, bool saveChanges = true)
        {
            try
            {
                var resolvedResult = "";
                var TResult = repository.Add(ObjectMapper.Mapper.Map<T>(entity));
                resolvedResult = String.Join(',', TResult.GetType().GetProperties().Select(x => $" - {x.Name} : {x.GetValue(TResult) ?? ""} - "));

                if (saveChanges)
                    Save();

                return new ResponseBase<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Succuess",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(TResult)
                };
            }
            catch (Exception ex)
            {
                
                return new ResponseBase<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public Task<TDto> AddAsync(TDto entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(TDto entity)
        {
            throw new NotImplementedException();
        }

        public IResponseBase<bool> DeleteById(int id, bool saveChanges = true)
        {
            try
            {
                repository.Delete(id);

                if (saveChanges) Save();

                return new ResponseBase<bool>
                {
                    Message = "Succuess",
                    StatusCode = StatusCodes.Status200OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseBase<bool>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = false
                };
            }
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IResponseBase<TDto> Find(int id)
        {
            try
            {
                return new ResponseBase<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(repository.Find(id))
                };
            }
            catch (Exception ex)
            {
                return new ResponseBase<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponseBase<List<TDto>> GetAll()
        {
            try
            {
                List<T> list = repository.GetAll();
                var dtoList = list.Select(x =>ObjectMapper.Mapper.Map<TDto>(x)).ToList();

                var response = new ResponseBase<List<TDto>>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = dtoList
                };

                return response;
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

        public IResponseBase<List<TDto>> GetAll(Expression<Func<T, bool>> expression)
        {
            try
            {
                List<T> list = repository.GetAll(expression).ToList();
                var dtoList = list.Select(x => ObjectMapper.Mapper.Map<TDto>(x)).ToList();

                var response = new ResponseBase<List<TDto>>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = dtoList
                };

                return response;
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

        public IQueryable<T> GetIQueryable()
        {
            throw new NotImplementedException();
        }

        public TDto Update(TDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<TDto> UpdateAsync(TDto entity)
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            unitOfWork.SaveChanges();
        }

        public IResponseBase<TDto> Find(string id)
        {
            try
            {
                return new ResponseBase<TDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(repository.Find(id))
                };
            }
            catch (Exception ex)
            {
                return new ResponseBase<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
    }
}
