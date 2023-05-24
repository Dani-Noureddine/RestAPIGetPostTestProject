using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using RestSharp;

namespace RestAPI_GetPost_task
{
    public class ApiManager
    {
        private static ISettingsFile ApiData => new JsonSettingsFile("ApiData.json");
        private static ISettingsFile UrlExtensions => new JsonSettingsFile("UrlExtensions.json");
        private static ISettingsFile TestData => new JsonSettingsFile("testsData.json");

        public static RestResponse GetPostById(int? id = null)
        {
            string urlBase = string.Format(ApiData.GetValue<string>("PageUrl"), UrlExtensions.GetValue<string>("Posts"));
            string clientUrl;
            if (id != null)
            {
                clientUrl = string.Format(urlBase, $"/{id}");
            }
            else
            {
                clientUrl = string.Format(urlBase, "");
            }

            return ApiUtils.GetRequest(clientUrl);
        }

        public static RestResponse GetUsersById(int? id = null)
        {
            string urlBase = string.Format(ApiData.GetValue<string>("PageUrl"), UrlExtensions.GetValue<string>("Users"));
            string clientUrl;
            if (id != null)
            {
                clientUrl = string.Format(urlBase, $"/{id}");
            }
            else
            {
                clientUrl = string.Format(urlBase, "");
            }

            return ApiUtils.GetRequest(clientUrl);
        }

        public static RestResponse PostRandom()
        {
            var body = new PostModel { Body = TestData.GetValue<string>("PostBody"), UserId = TestData.GetValue<int>("PostUserID"), Title = TestData.GetValue<string>("PostTitle") };
            string urlBase = string.Format(ApiData.GetValue<string>("PageUrl"), UrlExtensions.GetValue<string>("Posts"));
            string url = string.Format(urlBase, "");
            return ApiUtils.PostRequest(url, body);
        }
    }
}
