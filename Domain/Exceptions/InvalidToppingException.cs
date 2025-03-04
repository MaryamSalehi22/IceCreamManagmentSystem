using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidToppingException : BaseException
    {
        public InvalidToppingException(int id) : base($"Topping with ID {id} is invalid", 400) { }
    }
}
