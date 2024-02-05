using MagazinAlimentar.Models.Base;

namespace MagazinAlimentar.Models.Many_to_Many
{
    public class Employee : BaseEntity
    {
        public string? Name { get; set; }

        public ICollection<LocationEmployeeRelation> LocationEmployeeRelations { get; set; }
    }
}
