using Bookshelf.Services.Abstractions;
using Bookshelf.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bookshelf.Services
{
    public static class AppServicesRegistration
    {
        public static void ConfigureAppServices(this IServiceCollection services, bool registerOdbc = false)
        {
            services.AddScoped<IBookServices, BookServices>();
        }
    }
}