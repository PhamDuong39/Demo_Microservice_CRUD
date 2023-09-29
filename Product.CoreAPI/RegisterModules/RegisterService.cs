using Product.Common.Helpers;
using Product.Infragstructure.Contract;
using Product.Infragstructure.Data.Context;
using Product.Infragstructure.UnitOfWord;
using System.Runtime;

namespace Product.CoreAPI.RegisterModules
{
    public static class RegisterService
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.Configure<DbSettings>(services.BuildServiceProvider().GetRequiredService<IConfiguration>()
           .GetSection("DbSettings"));
            services.AddSingleton<ProductDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //service

            //Repositories
        }
    }
}
