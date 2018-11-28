using Data.Model;
using Data.Repository;
using RhApp.Model;
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

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class, IBaseInterface
        {
            //var p = Expression.Parameter(typeof(TEntity));
            //var expr = Expression.Lambda(Expression.PropertyOrField(p, "Status"), p);
            
            //Expression.Equal(expr, )

            var result = _repository.Set<TEntity>().Where(i=>i.Status == ObjectStatus.Enable).AsNoTracking().AsEnumerable();
            return result;
        }

        private void ClearTracking()
        {
            var trackingObject = _repository.ChangeTracker.Entries().Where(i => i.State == EntityState.Added || i.State == EntityState.Modified || i.State == EntityState.Deleted);

            foreach(var t in trackingObject)
            {
                _repository.Entry(t.Entity).State = EntityState.Detached;
            }
        }

        public void Update<TEntity>(TEntity model) where TEntity : class
        {
            //ClearTracking();
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
