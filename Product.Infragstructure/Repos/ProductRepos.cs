using Microsoft.EntityFrameworkCore;
using Product.Infragstructure.Contractor.IRepos;
using Product.Infragstructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infragstructure.Repos
{
    public class ProductRepos : IProductRepos
    {
        #region Private Members

        private readonly ProductDbContext _dbContext;

        #endregion

        #region Constructor

        public ProductRepos(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        #endregion

        #region CRUD

        public async Task<bool> AddAsync(Domain.Entites.Product entity)
        {
            throw new ArgumentException();
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var res = await _dbContext.Product.FirstOrDefaultAsync(x => x.Id == Id);
            if (res == null) return false;
            else
            {
                _dbContext.Product.Remove(res);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IReadOnlyList<Domain.Entites.Product>> GetAllAsync()
        {
            return await _dbContext.Product.ToListAsync();
        }

        public async Task<Domain.Entites.Product> GetByIdAsync(int Id)
        {
            var res = await _dbContext.Product.FirstOrDefaultAsync(x => x.Id == Id);
            if (res == null) return null;
            else return res;
        }

        public async Task<bool> UpdateAsync(Domain.Entites.Product entity)
        {
            throw new ArgumentException();
        }

        #endregion


        #region Other Methods

        public async Task<Domain.Entites.Product> Edit(Domain.Entites.Product product)
        {
            var res = await _dbContext.Product.FirstOrDefaultAsync(x => x.Id == product.Id);
            res.TypeProduct = product.TypeProduct;
            res.ProductName = product.ProductName;
            res.Price = product.Price;
            res.Description = product.Description;
            res.ExpDate = product.ExpDate;
            res.ProductSign = product.ProductSign;
            _dbContext.Product.Update(res);
            await _dbContext.SaveChangesAsync();
            return res;
        }

        public async Task<Domain.Entites.Product> Add(Domain.Entites.Product product)
        {
            if (product == null) return null;
            _dbContext.Product.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }


        #endregion
    }
}
