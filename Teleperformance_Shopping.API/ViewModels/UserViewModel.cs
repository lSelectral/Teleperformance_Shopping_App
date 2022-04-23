﻿namespace Teleperformance_Shopping.API.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<ShoppingListViewModel> ShoppingLists { get; set; }
    }
}