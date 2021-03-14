using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Upwork.SocialMediaAutoPoster.Service
{
    public interface IFileService<T>
    {
        Task<T> GetById(string fileName, Expression<Func<T, bool>> filter);
        Task Add(string fileName, T data);
        Task Update(string fileName, T data, Expression<Func<T, bool>> filter);
        Task Delete(string fileName, Expression<Func<T, bool>> filter);
        Task<List<T>> Get(string fileName, Expression<Func<T, bool>> filter = null);
    }
}
