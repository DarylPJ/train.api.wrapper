using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Train_api_Wrapper.Models.ServiceDetails.Response;

namespace Train_api_Wrapper
{
    public interface IServiceDetails
    {
        Task<List<ServiceDetailsResponse>> GetResposesAsync(List<HttpRequestMessage> httpRequestMessages);
    }
}