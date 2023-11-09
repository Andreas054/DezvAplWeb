using DAW_Lab4.Models.Base;
using DAW_Lab4.Models.Many_to_Many;

namespace DAW_Lab4.Models.One_to_Many
{
    public class Model1 :BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Model2> Models2 { get; set; }
    }
}
