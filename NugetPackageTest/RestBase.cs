using RestSharp;
using System.Collections.Specialized;
using System.Configuration;

namespace NugetPackageTest
{
    public class RestBase
    {
        public ApiScenarioContextKeys _apiScenarioContextKeys;
        protected ApiResources _apiResources;

        public RestBase(ApiScenarioContextKeys apiScenarioContextKeys)
        {

            _apiResources = new ApiResources();
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

        private readonly ApiSettings _apiSettings = new ApiSettings();

        public ApiResources()
        {

            host = _apiSettings.host;
            DB_Connection = _apiSettings.DB_Connection;
        }

    }

    public class ApiSettings
    {
        private readonly NameValueCollection _commonConfig = (NameValueCollection)ConfigurationManager.GetSection("appSettings");

        public string host => _commonConfig["host"];
        public string DB_Connection => _commonConfig["DB_Connection"];

        public string branchAll => _commonConfig["branchAll"];

        public string authCookieName => _commonConfig["authCookieName"];
        public string authCookieValue => _commonConfig["authCookieValue"];
        public string sessionCookieName => _commonConfig["sessionCookieName"];
        public string sessionCookieValue => _commonConfig["sessionCookieValue"];
        public string domain => _commonConfig["domain"];
    }
}
