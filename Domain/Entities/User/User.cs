using Microsoft.AspNetCore.Identity;

namespace EcommerceShop.Domain.Entities.User
{
    public class User : IdentityUser
    {
        public virtual Cart.Cart Cart { get; set; } = default!;
    }
}
