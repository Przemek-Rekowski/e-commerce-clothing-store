using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users
{
    public record CurrentUser(string Id,
        string Email)
    {

    }
}
