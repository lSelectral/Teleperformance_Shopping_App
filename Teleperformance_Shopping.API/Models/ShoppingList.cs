namespace Teleperformance_Shopping.API.Models
{
    public class ShoppingList : BaseEntity
    {
        public IEnumerable<int> ProductIds
        {
            get { return Products.Select(x => x.Id); }
        }
        public virtual ICollection<Product> Products { get; set; }
    }
}