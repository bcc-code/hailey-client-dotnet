using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BccCode.Hailey.Client;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class HaileyClientInstaller
    {

        public static IServiceCollection AddHaileyClient(this IServiceCollection services, Action<HaileyClientOptions> options)
        {
            var opts = new HaileyClientOptions();
            if (options != null) options.Invoke(opts);
            return services.AddHaileyClient(opts);
        }

        public static IServiceCollection AddHaileyClient(this IServiceCollection services, HaileyClientOptions? options)
        {
            if (!services.Any(x => x.ServiceType == typeof(IHttpClientFactory)))
            {
                services.AddHttpClient();
            }

            return services.AddSingleton<IHaileyClient>(x =>
            {
                if (options == null)
                {
                    options = x.GetRequiredService<HaileyClientOptions>();
                }
                var clientFactory = x.GetRequiredService<IHttpClientFactory>();
                var client = new HaileyClient(options, clientFactory);
                return client;
            });
        }
    }
}
