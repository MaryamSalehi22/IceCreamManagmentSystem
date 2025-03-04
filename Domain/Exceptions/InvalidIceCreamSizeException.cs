using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidIceCreamSizeException : BaseException
    {
        public InvalidIceCreamSizeException() : base("Unknown ice cream size.", 500)
        { }
    }
}
