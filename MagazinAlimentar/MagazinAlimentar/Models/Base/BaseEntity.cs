using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagazinAlimentar.Models.Base
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        // generate a value when row is inserted
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}
