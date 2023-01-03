using System.Threading.Tasks;
using RestSharp;
using System.IO;

namespace WebAPI
{
    class Web_API
    {
        public RestClient GetClient()
        {
            var options = new RestClientOptions(Params.baseUrl);
            RestClient client = new RestClient(options);
            client.AddDefaultHeader("Authorization", "Bearer " + Params.token);
            return client;
        }

        public RestRequest GetUploadRequest()
        {
            byte[] fileData = File.ReadAllBytes(Params.path);

            RestRequest request = new RestRequest(Params.uploadUrl, Method.Post)
            .AddHeader("Dropbox-API-Arg", "{\"path\":\"/RMPh.pdf\"}")
            .AddHeader("Content-Type", "application/octet-stream")
            .AddParameter("application/octet-stream", fileData, ParameterType.RequestBody);

            return request;
        }

        public RestRequest GetMetadataRequest()
        {
            var request = new RestRequest(Params.metadataUrl, Method.Post)
               .AddHeader("Content-Type", "application/json")
               .AddJsonBody(new { include_deleted = false, include_has_explicit_shared_members = false, include_media_info = false, path = "/RMPh.pdf" });

            return request;
        }

        public RestRequest GetDeleteRequest()
        {
            var request = new RestRequest(Params.deleteUrl, Method.Post)
                .AddHeader("Content-Type", "application/json")
                .AddJsonBody(new { path = "/RMPh.pdf" });

            return request;
        }

        public void Dispose(RestClient client)
        {
            client.Dispose();
        }
    }
}
