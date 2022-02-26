using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeCourseServices.OrderInfrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace FreeCourseServices.OrderAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host=  CreateHostBuilder(args).Build();
            
            using(var scope=host.Services.CreateScope())
            {
                var serviceProvider=scope.ServiceProvider;
                var orderDbContext= serviceProvider.GetRequiredService<OrderDbContext>();
                orderDbContext.Database.Migrate();
            }
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
