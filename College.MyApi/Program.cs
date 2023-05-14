using Autofac.Extensions.DependencyInjection;
using NLog;
using NLog.Web;

namespace College.MyApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();

            try
            {
                logger.Debug("init main");
                await CreateHostBuilder(args).Build().RunAsync();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                LogManager.Flush();
                LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureLogging(options => options.ClearProviders())
                .UseNLog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}