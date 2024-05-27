using EcommerceShop.Domain.Entities.Cart;
using System.Data;

namespace Application.Users
{
    public record CurrentUser(string Id,
        string Email,
        IEnumerable<string> Roles)
    {
        public bool IsInRole(string role) => Roles.Contains(role);
    }
}
