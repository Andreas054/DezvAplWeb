using MagazinAlimentar.Data;
using MagazinAlimentar.Models.Many_to_Many;
using MagazinAlimentar.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace MagazinAlimentar.Repositories.LocationRepository
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(MagazinContext magazinContext) : base(magazinContext) { }

        public IQueryable<LocationEmployeeRelation> GetAllLocationEmployeeRelations()
        {
            return _magazinContext.LocationEmployeeRelations
                .Include(l => l.Location)
                .Include(e => e.Employee);
        }
    }
}
