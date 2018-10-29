using System.Collections.Generic;
using System.Net.Http;
using Train_api_Wrapper.Models.ServiceDetails.Request;

namespace Train_api_Wrapper
{
    public interface IServiceDetailsRequestBuilder
    {
        List<HttpRequestMessage> ServiceDetails(List<ServiceDetailsRequest> serviceDetailsRequests);
    }
}