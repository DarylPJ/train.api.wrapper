using System.Net.Http;
using System.Threading.Tasks;

namespace Train_api_Wrapper
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private HttpClient httpClient = new HttpClient();

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            return httpClient.SendAsync(httpRequestMessage);
        }
    }
}
