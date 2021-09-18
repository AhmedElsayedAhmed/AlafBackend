using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions
{
    public static class AutoMapperService
    {
        public static void ConfigureAutoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }
    }
}
