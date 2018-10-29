using System.Collections.Generic;
using System.Net.Http;
using Train_api_Wrapper.Models.ServiceMetrics.Request;

namespace Train_api_Wrapper
{
    public interface IServiceMetricsRequestBuilder
    {
        List<HttpRequestMessage> ServiceMetrics(List<ServiceMetricsRequest> serviceMetricsRequests);
    }
}