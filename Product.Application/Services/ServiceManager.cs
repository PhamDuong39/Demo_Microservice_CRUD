using Product.Application.Contract;
using Product.Application.Contractor.IProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Services
{
    public class ServiceManager : IServiceManager
    {
        public ServiceManager(IProductService productService)
        {
            ProductService = productService;
        }

        public IProductService ProductService { get; }
    }
}
