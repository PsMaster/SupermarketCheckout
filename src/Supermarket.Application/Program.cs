using CartCalculator;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Core.Interfaces;
using Supermarket.Core.Services;
using Supermarket.DataAccess;

namespace Supermarket.Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddSingleton<ICheckout, CheckoutService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();
            services.AddTransient<IRulesService, RulesService>();
            services.AddTransient<App>();
            using var serviceProvider = services.BuildServiceProvider();
            var app = serviceProvider.GetRequiredService<App>();
            app.Run();
        }
    }
}
