using Product.Infragstructure.Contract;
using Product.Infragstructure.Contractor.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infragstructure.UnitOfWord
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IProductRepos productRepos)
        {
            ProductRepos = productRepos;
        }
        public IProductRepos ProductRepos { get;  }
    }
}
