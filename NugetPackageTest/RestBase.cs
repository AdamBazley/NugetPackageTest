using RestSharp;
using System.Collections.Specialized;
using System.Configuration;

namespace NugetPackageTest
{
    public class RestBase
    {
        public ApiScenarioContextKeys _apiScenarioContextKeys;
        protected ApiResources _apiResources;

        public RestBase(ApiScenarioContextKeys apiScenarioContextKeys, ApiResources apiResources)
        {

            _apiResources = apiResources;
            _apiScenarioContextKeys = apiScenarioContextKeys;
        }

    }

    public class ApiScenarioContextKeys
    {
        public RestClient _restClient;
        public IRestResponse _restResponse;

    }

    public class ApiResources
    {

        public string host;
        public string DB_Connection;

        private readonly ApiSettings _apiSettings;

        public ApiResources(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
            host = _apiSettings.host;
            DB_Connection = _apiSettings.DB_Connection;
            
        }

    }

    public class ApiSettings
    {
        public string host { get; set; }
        public string DB_Connection { get; set; }

        public string authCookieName { get; set; }
        public string authCookieValue { get; set; }
        public string sessionCookieName { get; set; }
        public string sessionCookieValue { get; set; }
        public string domain { get; set; }
    }
}
