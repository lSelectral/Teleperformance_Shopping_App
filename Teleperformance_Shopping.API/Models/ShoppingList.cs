using System.ComponentModel.DataAnnotations.Schema;

namespace Teleperformance_Shopping.API.Models
{
    public class ShoppingList : BaseEntity
    {
        public bool IsEditable { get; set; } = true;
        public virtual ICollection<ShoppingListProduct> Products { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}