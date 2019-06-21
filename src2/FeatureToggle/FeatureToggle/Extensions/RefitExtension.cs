using System;
using FeatureToggle.Handler;
using FeatureToggle.Service;
using FeatureToggle.Util;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace FeatureToggle.Extensions
{
    public static class RefitExtension
    {
        public static void AddRefit(this IServiceCollection services)
        {
            services.AddSingleton(new GitHeadersHandler());

            services.AddRefitClient<IGithubAPIService>()
                .ConfigurePrimaryHttpMessageHandler<GitHeadersHandler>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(ApplicationConstants.Services.API_BASE_ADDRESS);

                });
        }
    }
}