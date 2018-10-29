using System.Collections.Generic;
using Train_api_Wrapper.Models.ServiceMetrics.Request;
using Train_api_Wrapper.Models.ServiceMetricsWrapper.Request;

namespace Train_api_Wrapper.Mappers
{
    public interface IServiceMetricsMapper
    {
        List<ServiceMetricsRequest> MapServiceMetrics(ServiceMetricsWrapperRequest serviceMetricsWrapperRequest);
    }
}