using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Train_api_Wrapper.Models.ServiceMetrics.Response;

namespace Train_api_Wrapper
{
    public interface IServiceMetric
    {
        Task<List<ServiceMetricsResponse>> GetResposesAsync(List<HttpRequestMessage> httpRequestMessages);
    }
}