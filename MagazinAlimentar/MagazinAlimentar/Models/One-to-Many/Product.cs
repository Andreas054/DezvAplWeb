using MagazinAlimentar.Models.Base;

namespace MagazinAlimentar.Models.One_to_Many
{
    public class Product : BaseEntity
    {
        public double Pret {  get; set; }

        // relation
        public Department Department { get; set; }

        public Guid DepartmentId { get; set; }
    }
}
