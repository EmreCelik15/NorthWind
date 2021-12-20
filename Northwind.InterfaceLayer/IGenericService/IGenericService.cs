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
        TDto Add(TDto entity);
        Task<TDto> AddAsync(TDto entity);
        bool DeleteById(int id);
        Task<bool> DeleteByIdAsync(int id);
        bool Delete(TDto entity);
        Task<bool> DeleteAsync(TDto entity);
        TDto Update(TDto entity);
        Task<TDto> UpdateAsync(TDto entity);
        TDto Find(int id);
        IQueryable<T> GetIQueryable();
        List<TDto> GetAll();
        List<TDto> GetAll(Expression<Func<T, bool>> expression);
    }
}
