using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ArnabDeveloper.HttpHealthCheck
{
    /// <inheritdoc cref="IHealthCheck"/>
    public class HealthCheck : IHealthCheck
    {
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// Creates a new object of HealthCheck.
        /// </summary>
        /// <param name="httpClientFactory">Takes an object of HttpClientFactory.</param>
        public HealthCheck(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        async Task<bool> IHealthCheck.IsHealthy(string url, ApiCredential? credential)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            if (credential != null)
            {
                var byteArray = Encoding.ASCII.GetBytes($"{credential.UserName}:{credential.Password}");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(byteArray));
            }
            HttpResponseMessage consultationApiResponseMessage = await httpClient.GetAsync(url);
            return consultationApiResponseMessage.IsSuccessStatusCode;
        }
    }
}
