using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using RestSharp;

namespace RestAPI_GetPost_task
{
    public static class ApiUtils
    {
        private static ISettingsFile ApiData => new JsonSettingsFile("ApiData.json");

        public static RestResponse GetRequest(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest();
            return client.Get(request);
        }

        public static RestResponse PostRequest(string url, PostModel post)
        {
            var client = new RestClient(url);
            var request = new RestRequest();
            request.AddJsonBody(post);
            return client.Post(request);
        }
    }
}
