using FluentValidation;

namespace Teleperformance_Shopping.API.Models
{
    public class ShoppingListUpdateModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEditable { get; set; }
        public int UserId { get; set; }
    }
}
