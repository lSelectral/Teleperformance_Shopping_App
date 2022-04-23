namespace Teleperformance_Shopping.API.Models
{
    public class UserUpdateModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
