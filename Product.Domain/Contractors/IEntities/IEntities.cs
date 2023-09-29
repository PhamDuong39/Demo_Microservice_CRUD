using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Contractors.IEntities
{
    public interface IEntities<T>
    {
        T Id { get; set; }
    }
}
