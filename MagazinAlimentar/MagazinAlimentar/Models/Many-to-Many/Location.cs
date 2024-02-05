using MagazinAlimentar.Models.Base;

namespace MagazinAlimentar.Models.Many_to_Many
{
    public class Location : BaseEntity
    {
        public string? County { get; set; }
        public string? City { get; set; }

        public ICollection<LocationEmployeeRelation> LocationEmployeeRelations { get; set; }
    }
}
