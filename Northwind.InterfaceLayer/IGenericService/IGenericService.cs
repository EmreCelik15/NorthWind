using Northwind.Entity.Base;
using Northwind.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.InterfaceLayer.IGenericService
{
    public interface IGenericService<T, TDto> where T : EntityBase where TDto : IDtoBase 
    {
        IResponseBase<TDto> Add(TDto entity, bool saveChanges = true);
        Task<TDto> AddAsync(TDto entity);
        IResponseBase<bool> DeleteById(int id, bool saveChanges = true);
        Task<bool> DeleteByIdAsync(int id);
        bool Delete(TDto entity);
        Task<bool> DeleteAsync(TDto entity);
        TDto Update(TDto entity);
        Task<TDto> UpdateAsync(TDto entity);
        IResponseBase<TDto> Find(int id);
        IResponseBase<TDto> Find(string id);
        IQueryable<T> GetIQueryable();
        IResponseBase<List<TDto>> GetAll();
        IResponseBase<List<TDto>> GetAll(Expression<Func<T, bool>> expression);
        void Save();
    }
}
