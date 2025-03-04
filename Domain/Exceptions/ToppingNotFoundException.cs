using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ToppingNotFoundException : BaseException
    {
        public ToppingNotFoundException(Guid toppingId): base($"Topping with ID {toppingId} was not found.", 404)
        { }
    }
}
