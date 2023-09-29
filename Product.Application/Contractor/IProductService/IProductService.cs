using Product.Application.Contract;
using Product.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Contractor.IProductService
{
    public interface IProductService : IServiceGeneric<Product.Domain.Entites.Product>
    {

    }
}
