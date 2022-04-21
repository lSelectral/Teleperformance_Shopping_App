using System.Text.Json.Serialization;

namespace Teleperformance_Shopping.API.Models
{
    public class User : BaseEntity
    {
        [JsonIgnore]
        public new string? Name { get; set; }
        public string FirstName { get; set; }
        public int LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<int> ShoppingListIds { get => ShoppingLists.Select(x => x.Id); }
        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}