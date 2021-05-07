using System.Collections.Generic;
using System.Text;

namespace ArnabDeveloper.HttpHealthCheck.ConsoleApp
{
    internal class HealthCheckManager
    {
        private readonly IHealthCheck _healthCheck;
        private readonly IEnumerable<ApiDetail> _urlDetails;

        public HealthCheckManager(IHealthCheck healthCheck, IEnumerable<ApiDetail> urlDetails)
        {
            _healthCheck = healthCheck;
            _urlDetails = urlDetails;
        }

        public string LogHealthCheckResult()
        {
            StringBuilder apiStatusMessages = new(string.Empty);
            foreach (ApiDetail urlDetail in _urlDetails)
            {
                if (urlDetail.IsEnable)
                {
                    apiStatusMessages.Append(GetApiStatusMessage(urlDetail));
                    apiStatusMessages.Append('\n');
                }
            }
            return apiStatusMessages.ToString();
        }

        private string GetApiStatusMessage(ApiDetail apiDetail)
        {
            try
            {
                bool isApiHealthy = false;
                if (apiDetail.ApiCredential is null ||
                    string.IsNullOrWhiteSpace(apiDetail.ApiCredential.UserName) ||
                    string.IsNullOrWhiteSpace(apiDetail.ApiCredential.Password))
                {
                    isApiHealthy = _healthCheck.IsApiHealthy(apiDetail.Url);
                }
                else
                {
                    isApiHealthy = _healthCheck.IsApiHealthy(apiDetail.Url, apiDetail.ApiCredential);
                }
                string apiStatusMessage = isApiHealthy ? "OK" : "Error";
                return $"{apiDetail.Name} status is: {apiStatusMessage}";
            }
            catch
            {
                return $"{apiDetail.Name} status is: Error";
            }
        }
    }
}
