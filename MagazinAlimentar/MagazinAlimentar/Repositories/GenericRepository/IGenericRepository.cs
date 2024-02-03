using MagazinAlimentar.Models.Base;

namespace MagazinAlimentar.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        // get all data
        Task<List<TEntity>> GetAllAsync();

        // create
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        // update
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        // delete
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        // find
        TEntity FindById(Guid id);
        Task<TEntity> FindByIdAsync(Guid id);

        // save
        bool Save();
        Task<bool> SaveAsync(TEntity entity);
    }
}
