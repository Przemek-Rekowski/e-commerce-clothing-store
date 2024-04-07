using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotFoundException(string resourceType, string resourceId)
        : Exception($"{resourceType} with id: {resourceId} doesn't exist")
    {
    }
}
