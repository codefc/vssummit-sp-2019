using ConfigCat.Client;
using Microsoft.Extensions.DependencyInjection;

namespace FeatureToggle.Extensions
{
    public static class ConfigCatExtension 
    {
        public static void AddConfigCat(this IServiceCollection services, string apiKey)
        {
            services.AddSingleton<IConfigCatClient>(new ConfigCatClient(new LazyLoadConfiguration
            {
                ApiKey = apiKey
            }));
        }
    }
}