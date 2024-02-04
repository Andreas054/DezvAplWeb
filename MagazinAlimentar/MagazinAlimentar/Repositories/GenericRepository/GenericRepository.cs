using MagazinAlimentar.Data;
using MagazinAlimentar.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace MagazinAlimentar.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MagazinContext _magazinContext;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(MagazinContext magazinContext)
        {
            {
                _magazinContext = magazinContext;
                _table = _magazinContext.Set<TEntity>();
            }
        }

        // get all
        public List<TEntity> GetAll()
        {
            return _table.AsNoTracking().ToList();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        // create
        public void Create(TEntity entity) 
        {
            _table.Add(entity);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        // update
        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);   
        }

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
        }

        // find
        public TEntity FindById(Guid id)
        {
            return _table.Find(id);
        }

        public async Task<TEntity> FindByIdAsync(Guid id)
        {
            return await _table.FindAsync(id);
        }

        // save
        public bool Save()
        {
            return _magazinContext.SaveChanges() > 0;
        }

        public async Task<bool> SaveAsync()
        {
            return await _magazinContext.SaveChangesAsync() > 0;   
        }
    }
}
