using System.Text.Json.Serialization;

namespace Teleperformance_Shopping.API.Models
{
    public class User : BaseEntity
    {
        [JsonIgnore]
        public new string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}