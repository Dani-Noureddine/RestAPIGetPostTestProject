using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using Newtonsoft.Json;
using System.Net;

namespace RestAPI_GetPost_task
{
    public class Tests
    {
        private static ISettingsFile TestData => new JsonSettingsFile("testsData.json");

        [Test]
        public void Test1()
        {
            Console.WriteLine("Check that posts are in ascending order, status code is OK and response is in json format");
            var response = ApiManager.GetPostById();
            List<PostModel>? Posts = JsonConvert.DeserializeObject<List<PostModel>>(response.Content!.ToString());
            Assert.True(PostModel.IsInAscendingOrder(Posts!), "Posts are not in ascending order");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not 200");
            Assert.True(JsonUtils.IsJsonFormat(response.Content!.ToString()), "Response is not in a json format");

            Console.WriteLine("Get a post by ID and check response code is OK, test id is correct and user id is correct");
            response = ApiManager.GetPostById(TestData.GetValue<int>("Test2ID"));
            PostModel Post = JsonConvert.DeserializeObject<PostModel>(response.Content!.ToString())!;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not 200");
            Assert.That(Post!.Id, Is.EqualTo(TestData.GetValue<int>("Test2ID")), "test id is not correct");
            Assert.That(Post!.UserId, Is.EqualTo(TestData.GetValue<int>("Test2UserID")), "User id is not correct");
            Assert.Multiple(() =>
            {
                Assert.True(Post!.Title != "", "Title is empty");
                Assert.True(Post!.Body != "", "Body is empty");
            });

            Console.WriteLine("Get post by Id and check that its not found and response body is empty");
            response = ApiManager.GetPostById(TestData.GetValue<int>("Test3ID"));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Post = JsonConvert.DeserializeObject<PostModel>(response.Content!.ToString())!;
            Assert.True(Post.Body == null, "Response body is not empty");

            Console.WriteLine("Posts an id, body and title from test data and check status code is created (201) and that its correctly posted");
            response = ApiManager.PostRandom();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Status code is not 201");
            Post = JsonConvert.DeserializeObject<PostModel>(response.Content!.ToString())!;
            Assert.Multiple(() =>
            {
                Assert.That(Post!.UserId, Is.EqualTo(TestData.GetValue<int>("PostUserID")), "User id is not correct");
                Assert.That(Post!.Title, Is.EqualTo(TestData.GetValue<string>("PostTitle")), "Title is wrong");
                Assert.That(Post!.Body, Is.EqualTo(TestData.GetValue<string>("PostBody")), "Body is wrong");
                Assert.True(Post!.Id != null, "Id is not present");
            });

            Console.WriteLine("Gets all users, checks status code is OK, response is in json and that the userof some id is the same as expected one");
            response = ApiManager.GetUsersById();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not 200");
            Assert.True(JsonUtils.IsJsonFormat(response.Content!.ToString()), "Response is not in a json format");
            List<User> Users = JsonConvert.DeserializeObject<List<User>>(response.Content!.ToString())!;
            User User5ExpectedData = JsonConvert.DeserializeObject<User>(File.ReadAllText("Resources\\User5TestData.json"))!;
            User CheckedUser = Users[TestData.GetValue<int>("CheckedUserID") - 1];
            Assert.That(CheckedUser, Is.EqualTo(User5ExpectedData), "Users' data arent the same");

            Console.WriteLine("Gets user ID and checks response code, then checks if the user received is same as expected data");
            response = ApiManager.GetUsersById(TestData.GetValue<int>("CheckedUserID"));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code is not 200");
            User UserReceived = JsonConvert.DeserializeObject<User>(response.Content!.ToString())!;
            User5ExpectedData = JsonConvert.DeserializeObject<User>(File.ReadAllText("Resources\\User5TestData.json"))!;
            Assert.That(UserReceived, Is.EqualTo(User5ExpectedData), "Users' data arent the same");
        }
    }
}