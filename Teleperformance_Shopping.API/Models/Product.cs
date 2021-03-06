using System.ComponentModel.DataAnnotations.Schema;

namespace Teleperformance_Shopping.API.Models
{
    public class Product : BaseEntity
    {
        public string Description { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
    }
}