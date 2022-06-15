using DemoDecorator.Services;
using System.Configuration;

namespace DemoDecorator.Extentions
{
    public static class ConfigServiceExtention
    {
        public static IServiceCollection AddConfigService(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddScoped<IPlayerService, PlayerService>();

            if (Convert.ToBoolean(configuration["EnableCaching"]))
            {
                service.Decorate<IPlayerService, PlayerServiceCachingDecorator>();
            }
            if (Convert.ToBoolean(configuration["EnableLogging"]))
            {
                service.Decorate<IPlayerService, PlayerServiceLoggingDecorator>();
            }
            return service;
        }
    }
}
