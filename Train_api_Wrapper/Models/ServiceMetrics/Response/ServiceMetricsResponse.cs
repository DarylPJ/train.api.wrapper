using System.Collections.Generic;

namespace Train_api_Wrapper.Models.ServiceMetrics.Response
{
    public class ServiceMetricsResponse
    {
        public Header header { get; set; }
        public List<Service> Services { get; set; }
    }
}
