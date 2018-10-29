using Newtonsoft.Json;
using System.Collections.Generic;

namespace Train_api_Wrapper.Models.ServiceMetricsWrapper.Request
{
    public class ServiceMetricsWrapperRequest
    {
        [JsonProperty(Required = Required.Always)]
        public List<Journey> Journeys { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string FromTime { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string ToTime { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string FromDate { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string ToDate { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Days { get; set; }
    }
}
