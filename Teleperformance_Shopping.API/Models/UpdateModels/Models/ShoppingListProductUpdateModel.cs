namespace Teleperformance_Shopping.API.Models
{
    public class ShoppingListProductUpdateModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int ProductId { get; set; }
        public int ShoppingListId { get; set; }
        public bool IsAddedToCart { get; set; }
    }
}