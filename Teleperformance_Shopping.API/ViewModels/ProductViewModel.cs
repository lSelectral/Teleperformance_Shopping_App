namespace Teleperformance_Shopping.API.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
    }
}