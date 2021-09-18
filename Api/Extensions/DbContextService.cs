using Framework.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace Api.Extensions
{
    public static class DbContextService
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration Configuration )
        {
            var connectionString = Configuration.GetConnectionString("Default");
            var FormsConnectionString = Configuration.GetConnectionString("FormsConnectionString");
            services.AddDbContext<aalafContext>(options =>
           options.UseMySQL(connectionString, b => b.MigrationsAssembly("Persistence")));
        }
    }
}
