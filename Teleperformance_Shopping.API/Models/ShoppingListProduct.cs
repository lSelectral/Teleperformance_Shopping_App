using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Teleperformance_Shopping.API.Models
{
    public class ShoppingListProduct : BaseEntity
    {
        [JsonIgnore]
        public new int Id { get; set; }
        [JsonIgnore]
        public new string Name { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public int Amount { get; set; }

        public int ShoppingListId { get; set; }
        [ForeignKey(nameof(ShoppingListId))]
        public virtual ShoppingList ShoppingList { get; set; }

        public bool IsAddedToCart { get; set; }
    }
}