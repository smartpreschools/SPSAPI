using SPS.Repository.Interface;
using SPS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPS.Services.Services
{
    public class EntityService<T> : IEntityService<T> where T : class
    {
        protected IUnitOfWork UnitOfWork;
        protected IGenericRepository<T> Repository;
        public EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
        }
        public IEnumerable<T> GetAll()
        {
            return Repository.GetAll();
        }
        public T FindBy(object id)
        {
            return Repository.FindBy(id);
        }
        public void Create(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Repository.Add(entity);
        }
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Repository.Edit(entity);
        }
        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Repository.Delete(entity);
        }
        public async Task<bool> AddUnitOfWork()
        {
            var res = await UnitOfWork.CommitAsync() > 0;

            return res;
        }
        public void AddRange(IEnumerable<T> entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Repository.AddRange(entity);
        }
        public void UpdateRange(IEnumerable<T> entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Repository.UpdateRange(entity);
        }
        public void DeleteRange(IEnumerable<T> entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Repository.DeleteRange(entity);
        }
    }
}
