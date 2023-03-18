using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Services.Interface
{
    public interface IEntityService<T>
    {
        IEnumerable<T> GetAll();
        T FindBy(object id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> AddUnitOfWork();
        void AddRange(IEnumerable<T> entity);
        void UpdateRange(IEnumerable<T> entity);
        void DeleteRange(IEnumerable<T> entity);
    }
}
