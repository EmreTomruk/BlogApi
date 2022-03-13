using Blog.Data.Repository.Abstract;
using Blog.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Concrete
{
    public class Services<T> : IServices<T> where T : class
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;

        public Services(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task<bool> Add(T entity)
        {
            await _repository.Add(entity);
            await _unitOfWork.SaveAsync();

            return true;
        }

        public bool Delete(int id)
        {
             _repository.Delete(id);
            _unitOfWork.Save();

            return true;
        }

        public async Task<ICollection<T>> GetAll(Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            string includeProperties = null)
        {
            return await _repository.GetAll(filter, orderBy, includeProperties);
        }

        public async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null, 
            string includeProperties = null)
        {
            return await _repository.GetFirstOrDefault(filter, includeProperties);
        }

        public T Update(T entity)
        {
            var newEntity = _repository.Update(entity);
            _unitOfWork.Save();

            return newEntity;
        }
    }
}
