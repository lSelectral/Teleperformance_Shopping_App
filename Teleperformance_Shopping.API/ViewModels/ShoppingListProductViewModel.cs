namespace Teleperformance_Shopping.API.ViewModels
{
    public class ShoppingListProductViewModel
    {
        public int ListProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public int Amount { get; set; }
        public bool IsAddedToCart { get; set; }
    }
}