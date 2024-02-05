using MagazinAlimentar.Models.Many_to_Many;
using MagazinAlimentar.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace MagazinAlimentar.Repositories.LocationRepository
{
    public interface ILocationRepository : IGenericRepository<Location>
    {
        IQueryable<LocationEmployeeRelation> GetAllLocationEmployeeRelations();
    }
}
