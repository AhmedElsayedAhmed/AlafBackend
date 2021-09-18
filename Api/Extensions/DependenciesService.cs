using Framework.Core.Repo;
using Framework.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Framework.Core.UOW;
using User.BAL.Services;
using Microsoft.AspNetCore.Identity;
using User.BAL.Models;
using Microsoft.AspNetCore.Http;
using Persistence.UnitOfWork;
using Framework.Core.Repo.Interfaces;
using Persistence.Repositories;
using Microsoft.Extensions.Caching.Memory;
using aalaf.BAL.Interfaces;
using aalaf.BAL;

namespace Api.Extensions
{
    public static class DependenciesService
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<UnitOfWork>();
            services.AddTransient<IUtility, Utilities>();
            services.AddScoped<TokenProvider>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Persistence.Repositories.Repository<>));
            services.AddTransient<IUsersService, UsersService>();
     
            services.AddTransient<IAccountService, AccountService>();
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            // aalaf
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddTransient<IOrderService, OrderService>();



        }
    }
}
