using DAW_Lab4.Models.Base;

namespace DAW_Lab4.Models.One_to_Many
{
    public class Model2 : BaseEntity
    {
        public string Name { get; set; }

        // relation
        public Model1 Models1 { get; set; }

        public Guid Model1Id { get; set; }
    }
}
