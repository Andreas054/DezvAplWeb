using DAW_Lab4.Models.Base;

namespace DAW_Lab4.Models.One_to_One
{
    public class Model5 : BaseEntity
    {
        public string? Name { get; set; }

        // relation

        public Model6 Model6 { get; set; }
    }
}
