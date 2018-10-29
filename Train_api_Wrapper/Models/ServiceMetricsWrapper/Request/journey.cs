using Newtonsoft.Json;

namespace Train_api_Wrapper.Models.ServiceMetricsWrapper.Request
{
    public class Journey
    {
        [JsonProperty(Required = Required.Always)]
        public string FromStation { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string ToStation { get; set; }
    }
}
