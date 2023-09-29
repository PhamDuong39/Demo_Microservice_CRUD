using Product.Infragstructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infragstructure.Contractor.IRepos
{
    public interface IProductRepos : IReposGeneric<Product.Domain.Entites.Product>
    {
        //Task<IEnumerable<Product.Domain.Entites.Product>> GetAll();
        //Task<Product.Domain.Entites.Product> GetById(int Id);
        Task<Product.Domain.Entites.Product> Add(Product.Domain.Entites.Product product);
        Task<Product.Domain.Entites.Product> Edit(Product.Domain.Entites.Product product);
       
    }
}
