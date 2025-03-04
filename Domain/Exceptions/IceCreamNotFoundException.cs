using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class IceCreamNotFoundException : BaseException
    {
        public IceCreamNotFoundException(Guid iceCreamId)  : base($"Ice Cream with ID {iceCreamId} was not found.", 404)
        { }
    }
}
