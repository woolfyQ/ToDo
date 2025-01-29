using Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public class Application
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ToDoService>();
            services.AddScoped<ColumnService>();
        }
    }
}
