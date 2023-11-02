using DAW_Lab3.Models.Base;

namespace DAW_Lab3.Models
{
    public class Student : BaseEntity
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
