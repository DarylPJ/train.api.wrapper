using System.Net.Http;
using System.Threading.Tasks;

namespace Train_api_Wrapper
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage);
    }
}