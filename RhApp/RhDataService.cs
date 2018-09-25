using Data.Model;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RhApp
{
    public class RhDataService
    {
        private readonly RhDataBase _repository;

        public RhDataService(RhDataBase repository)
        {
            _repository = repository;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            _repository.Set<TEntity>().Add(entity);
            ValidModel(entity);
        }

        public void ValidModel<TEntity>(TEntity entity) where TEntity : class
        {
            var errors = _repository.GetValidationErrors();

            if (errors.Count() == 0) return;

            var error = errors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage;
            _repository.Set<TEntity>().Remove(entity);
            throw new Exception(error);

        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            var result = _repository.Set<TEntity>().AsEnumerable();
            return result;
        }

        public void Update<TEntity>(TEntity model) where TEntity : class
        {
            _repository.Entry(model).State = EntityState.Modified;
            ValidModel(model);
        }

        public void Delete<TEntity>(TEntity model) where TEntity : class
        {
            _repository.Entry(model).State = EntityState.Modified;
            _repository.SaveChanges();
        }

        //public IEnumerable<TEntity> Get<TEntity>(int id) where TEntity : class
        //{
        //    ParameterExpression argExp = Expression.Parameter(typeof(TEntity), "model");
        //    var property = Expression.Property(argExp, "Id");
        //    var value = Expression.Constant(id);
        //    var filterExpression = Expression.Equal(property, value);

        //    var result = _repository.Set<TEntity>().Where(filterExpression).AsEnumerable();
        //    return result;
        //}

        public int Save()
        {
            return _repository.SaveChanges();
        }
    }
}
