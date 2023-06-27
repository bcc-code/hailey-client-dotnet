using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BccCode.Hailey.Client
{
    public partial class HaileyClient
    {
        IHttpClientFactory _clientFactory;
        HaileyClientOptions _options;
        public HaileyClient(HaileyClientOptions options, IHttpClientFactory clientFactory) : this()
        {
            _clientFactory = clientFactory;
            _options = options;
            BaseUrl = options.ApiBasePath ?? BaseUrl;
        }

        public HaileyClient(HaileyClientOptions options) : this()
        {
            _clientFactory = new ClientFactory();
            _options = options;
            BaseUrl = options.ApiBasePath ?? BaseUrl;
        }

        internal class ClientFactory : IHttpClientFactory
        {
            public HttpClient CreateClient(string name) => new HttpClient();
        }


        public async Task<HttpClient> CreateHttpClientAsync(CancellationToken cancellation)
        {
            return _clientFactory.CreateClient();
        }

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _options.ApiKey);
        }
    }
}
