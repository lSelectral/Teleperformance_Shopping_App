namespace Teleperformance_Shopping.API.ViewModels
{
    public class ShoppingListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEditable { get; set; }
        public ICollection<ShoppingListProductViewModel> Products { get; set; }
        public int UserId { get; set; }
    }
}