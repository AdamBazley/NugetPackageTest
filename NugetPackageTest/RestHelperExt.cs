using System;
using RestSharp;
using System.Net;
using NUnit.Framework;
using RestSharp.Authenticators;
using System.Collections.Generic;

namespace NugetPackageTest
{
    public class RestHelperExt : RestHelper
    {
        public IRestResponse GetRequestWithNtlmAuth(string host, string resource)
        {
            var request = new RestRequest(resource, Method.GET);
            RestClient _restClient = ConfigureRestClient(host);

            // Add NTLM authentication.
            _restClient.Authenticator = new NtlmAuthenticator();

            return Execute(_restClient, request);
        }

        public IRestResponse PostRequest(string host, string resource, object data)
        {
            var request = new RestRequest(resource, Method.POST);
            RestClient _restClient = ConfigureRestClient(host);

            // Add NTLM authentication.
            _restClient.Authenticator = new NtlmAuthenticator();

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(data);
            return Execute(_restClient, request);
        }

        public IRestResponse PostForm(string host, string resource, Dictionary<string, object> parameters = null, Dictionary<string, string> files = null)
        {
            var request = new RestRequest(resource, Method.POST);
            var _restClient = new RestClient(host)
            {
                // Add NTLM authentication.
                Authenticator = new NtlmAuthenticator()
            };

            // set the content type
            request.AddHeader("content-type", "multipart/form-data");

            // add all the parameters
            if (files != null)
            {
                foreach (var f in files)
                {
                    request.AddFile(f.Key, f.Value);
                }
            }

            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    request.AddParameter(p.Key, p.Value);
                }
            }

            return _restClient.Execute(request);
        }
    }
}
