using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Product.Application.Contractor.IProductService;
using Product.Common.Extensions;
using Product.Common.Response;
using Product.Domain.Entites;
using Product.Infragstructure.Contract;
using Product.Infragstructure.Contractor.IRepos;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Services
{
    public class ProductService : IProductService
    {
        #region Private Member

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductService> _logger;

        private const string ClassName = nameof(ProductService);
        
        #endregion


        #region Constructor

        public ProductService(IUnitOfWork unitOfWork, ILogger<ProductService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #endregion


        #region CRUD
        public async Task<ApiResponse<Domain.Entites.Product>> GetAllAsync()
        {
            try
            {
                var res = await _unitOfWork.ProductRepos.GetAllAsync();
                _logger.LogInformation("Get all Product".GeneratedLog(ClassName, LogEventLevel.Information));
                return res.Any()
                    ? new ApiResponse<Domain.Entites.Product>()
                    {
                        Success = true,
                        Message = $"Lay danh sach san pham thanh cong",
                        Result = res,
                        StatusCode = StatusCodes.Status200OK
                    }
                    : new ApiResponse<Domain.Entites.Product>()
                    {
                        Success = false,
                        Message = "Lay danh sach san pham that bai",
                        StatusCode = StatusCodes.Status404NotFound
                    };
            }
            catch (Exception e)
            {
                _logger.LogError($"Faild to get products {e.Message}".GeneratedLog(ClassName, LogEventLevel.Error));
                return new ApiResponse<Domain.Entites.Product>()
                {
                    Success = false,
                    Message = e.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        public async Task<ApiResponse<Domain.Entites.Product>> AddAsync(Domain.Entites.Product entity)
        {
            try
            {
                var res = await _unitOfWork.ProductRepos.Add(entity);
                _logger.LogInformation("Add product".GeneratedLog(ClassName, LogEventLevel.Information));
                return res == null
                    ? new ApiResponse<Domain.Entites.Product>()
                    {
                        Success = true,
                        Message = $"Tao thanh cong product id {entity.Id}",
                        Result = new[] { entity },
                        StatusCode = StatusCodes.Status200OK
                    }
                    : new ApiResponse<Domain.Entites.Product>()
                    {
                        Success = false,
                        Message = "Tao san pham that bai",
                        StatusCode = StatusCodes.Status406NotAcceptable
                    };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to add product {e.Message}".GeneratedLog(ClassName, LogEventLevel.Information));
                return new ApiResponse<Domain.Entites.Product>()
                {
                    Success = false,
                    Message = e.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        public async Task<ApiResponse<Domain.Entites.Product>> UpdateAsync(Domain.Entites.Product entity)
        {
            try
            {
                var res = await _unitOfWork.ProductRepos.Edit(entity);
                return res == null
                   ? new ApiResponse<Domain.Entites.Product>()
                   {
                       Success = true,
                       Message = $"Edit thanh cong product id {entity.Id}",
                       Result = new[] { entity },
                       StatusCode = StatusCodes.Status200OK
                   }
                   : new ApiResponse<Domain.Entites.Product>()
                   {
                       Success = false,
                       Message = "EDIT san pham that bai",
                       StatusCode = StatusCodes.Status406NotAcceptable
                   };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to EDIT product {e.Message}".GeneratedLog(ClassName, LogEventLevel.Information));
                return new ApiResponse<Domain.Entites.Product>()
                {
                    Success = false,
                    Message = e.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        public Task<ApiResponse<Domain.Entites.Product>> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<Domain.Entites.Product>> GetByIdAsync(int Id)
        {
            try
            {
                var res = await _unitOfWork.ProductRepos.GetByIdAsync(Id);
                _logger.LogInformation("Get Product By Id".GeneratedLog(ClassName, LogEventLevel.Information));
                return res == null
                    ? new ApiResponse<Domain.Entites.Product>()
                    {
                        Success = true,
                        Message = $"Lay thong cong product co ID {Id}",
                        Result = new[] { res },
                        StatusCode = StatusCodes.Status200OK
                    }
                    : new ApiResponse<Domain.Entites.Product>()
                    {
                        Success = false,
                        Message = "Khong lay duoc san pham",
                        StatusCode = StatusCodes.Status404NotFound
                    };
            }
            catch (Exception e)
            {
                _logger.LogError($"Faild to get product {e.Message}".GeneratedLog(ClassName, LogEventLevel.Error));
                return new ApiResponse<Domain.Entites.Product>()
                {
                    Success = false,
                    Message = e.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        #endregion
    }
}
