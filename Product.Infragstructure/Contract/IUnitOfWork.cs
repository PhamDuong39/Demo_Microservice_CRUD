using Product.Infragstructure.Contractor.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infragstructure.Contract
{
    public interface IUnitOfWork
    {
        IProductRepos ProductRepos { get; }
    }
}
