using MagazinAlimentar.Data;
using MagazinAlimentar.Models.One_to_Many;
using MagazinAlimentar.Repositories.GenericRepository;

namespace MagazinAlimentar.Repositories.ProductRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(MagazinContext magazinContext) : base(magazinContext) { }
    }
}
