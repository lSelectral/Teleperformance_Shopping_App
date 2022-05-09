using System.ComponentModel.DataAnnotations.Schema;

namespace Teleperformance_Shopping.API.Models
{
    public class Category : BaseEntity
    {
        [ForeignKey("CategoryId")]
        public virtual Product Product { get; set; }
    }
}
