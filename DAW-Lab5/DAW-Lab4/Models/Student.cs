using DAW_Lab4.Models.Base;

namespace DAW_Lab4.Models
{
    public class Student : BaseEntity
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
