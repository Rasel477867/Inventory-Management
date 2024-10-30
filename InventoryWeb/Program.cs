using Autofac.Extensions.DependencyInjection;
using InventoryWeb;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HMS.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static string AppVersion()
        {
            return "1.0.1";
        }
        public static string ProjectName()
        {
            return "IMS";
        }
        public static string ApplicantName()
        {
            return "Inventory Management System";
        }
        public static string ApplicantAddress()
        {
            return "DUET";
        }
        
    }
}
