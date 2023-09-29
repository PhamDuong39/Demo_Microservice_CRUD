using Product.Application.Contractor.IProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Contract
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
    }
}
