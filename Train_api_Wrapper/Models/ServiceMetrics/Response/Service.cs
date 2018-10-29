using System.Collections.Generic;

namespace Train_api_Wrapper.Models.ServiceMetrics.Response
{
    public class Service
    {
        public ServiceAttributesMetrics serviceAttributesMetrics { get; set; }
        public List<Metric> Metrics { get; set; }
    }
}
