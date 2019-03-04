using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using MongoExample.CrossCutting.IoC;

namespace MongoExample.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AutofacConfig.Configure();
            CreateWebHostBuilder(args).Build().Run();            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
