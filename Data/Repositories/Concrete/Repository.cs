using taller_mecanico.Data.DataContext;
using taller_mecanico.Data.Entities.Base;
using taller_mecanico.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace taller_mecanico.Data.Repositories.Concrete
{
    public class Repository<T>: IRepository<T> where T : EntityBase, new()
    {
        protected readonly BaseDataContext _baseDataContext;

        public Repository(BaseDataContext baseDataContext)
        {
            _baseDataContext = baseDataContext;
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return _baseDataContext.Set<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                var entity = await _baseDataContext.Set<T>().FindAsync(id);
                if (entity == null)
                    throw new KeyNotFoundException($"Entity {nameof(T)} was not found.");
                _baseDataContext.Entry(entity).State = EntityState.Detached;
                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{typeof(T).Name} could not retrieved");
            }
        }
        public async Task<T> AddAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException($"{nameof(entity)} should not be null");

            try
            {
                entity.Id = Guid.NewGuid();
                _baseDataContext.Add(entity);
                await _baseDataContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{typeof(T).Name} could not be saved");
            }
        }
        public async Task<T> UpdateAsync(T entity, Guid id)
        {
            try
            {
                var ent = await GetByIdAsync(id);
                entity.Id = ent.Id;
                _baseDataContext.Update(entity);
                await _baseDataContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{typeof(T).Name} could not be updated");
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var entity = _baseDataContext.Set<T>().FirstOrDefault(entity => entity.Id == id);
                if (entity == null)
                {
                    throw new KeyNotFoundException($"{nameof(T)} could not be deleted, id not found");
                }
                _baseDataContext.Remove(entity);
                await _baseDataContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception($"{typeof(T).Name} could not be deleted");
            }
        }
    }
}
