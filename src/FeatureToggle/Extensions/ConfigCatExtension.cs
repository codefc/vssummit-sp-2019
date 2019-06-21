using ConfigCat.Client;
using Microsoft.Extensions.DependencyInjection;

namespace FeatureToggle.Extensions
{
    public static class ConfigCatExtension 
    {
        public static void AddConfigCat(this IServiceCollection services, string apiKey)
        {
            var clientConfiguration = new AutoPollConfiguration
            {
                ApiKey = apiKey,
                PollIntervalSeconds = 15
            };
            services.AddSingleton<IConfigCatClient>(new ConfigCatClient(clientConfiguration));
        }
    }
}