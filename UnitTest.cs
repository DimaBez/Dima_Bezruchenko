using NUnit.Framework;
using System.Threading.Tasks;
using RestSharp;

namespace WebAPI
{
    public class Tests
    {
        Web_API api = new Web_API();

        [Test, Order(1)]
        public async Task TestUpload()
        {
            RestClient client = api.GetClient();
            RestRequest request = api.GetUploadRequest();

            var response = await client.ExecutePostAsync<Root_1>(request);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            api.Dispose(client);
        }

        [Test, Order(2)]
        public async Task TestGetMetadata()
        {
            RestClient client = api.GetClient();
            RestRequest request = api.GetMetadataRequest();

            var response = await client.ExecutePostAsync<Root_1>(request);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            api.Dispose(client);
        }

        [Test, Order(3)]
        public async Task TestDelete()
        {
            RestClient client = api.GetClient();
            RestRequest request = api.GetDeleteRequest();

            var response = await client.ExecutePostAsync<Root_2>(request);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            api.Dispose(client);
        }
    }
}