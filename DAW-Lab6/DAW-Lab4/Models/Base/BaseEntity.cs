using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAW_Lab4.Models.Base
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        // Generates a value when a row is inserted
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Generates a value when a row is inserted or updated
        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        // does not
        // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public DateTime? DateTime { get; set; }
        public DateTime? LastModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}
