using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;

namespace NugetPackageTest
{
    public class RestHelper
    {
        public RestClient ConfigureRestClient(string host, string username = null, string password = null)
        {
            RestClient restClient = new RestClient(host);
            if (username != null && password != null)
            { restClient.Authenticator = new HttpBasicAuthenticator(username, password); }
            restClient.CookieContainer = new CookieContainer();
            restClient.FollowRedirects = false;
            restClient.FailOnDeserializationError = true;

            return restClient;
        }

        public RestClient ConfigureRestClientWithoutCookieContainer(string host, string username = null, string password = null)
        {
            RestClient restClient = new RestClient(host);
            if (username != null && password != null)
            { restClient.Authenticator = new HttpBasicAuthenticator(username, password); }

            return restClient;
        }

        public IRestResponse GetRequest(string host, string resource)
        {
            var request = new RestRequest(resource, Method.GET);
            TestContext.WriteLine("GET REQUEST: " + host + resource);
            // execute the request
            return Execute(ConfigureRestClient(host), request);
        }

        public IRestResponse GetRequest(RestClient restClient, string resource)
        {
            var request = new RestRequest(resource, Method.GET);

            TestContext.WriteLine("GET REQUEST: " + restClient.BaseUrl + resource);
            // execute the request
            return Execute(restClient, request);
        }
        public IRestResponse Execute(RestClient restClient, RestRequest request)
        {
            //This Line Caters For SSL Certificate Errors
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            return restClient.Execute(request);
        }

    }
}
