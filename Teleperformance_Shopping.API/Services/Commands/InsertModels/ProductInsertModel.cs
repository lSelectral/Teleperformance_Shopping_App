namespace Teleperformance_Shopping.API.Services.Commands.InsertModels
{
    public class ProductInsertModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
    }
}