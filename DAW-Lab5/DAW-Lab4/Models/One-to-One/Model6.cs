using DAW_Lab4.Models.Base;

namespace DAW_Lab4.Models.One_to_One
{
    public class Model6 : BaseEntity
    {
        public string? Name { get; set; }

        // relation
        public Model5 Model5 { get; set; }
        public Guid Model5Id { get; set; }
    }
}
