using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public class IceCreamRequestDto
    {
        public Guid IceCreamId { get; set; }
        public List<Guid> ToppingIds { get; set; }
        public IceCreamSize Size { get; set; } // اضافه کردن اندازه

    }
}
