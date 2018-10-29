using Newtonsoft.Json;

namespace Train_api_Wrapper.Models.ServiceMetrics.Request
{
    public class ServiceMetricsRequest
    {
        [JsonProperty(PropertyName = "from_loc")]
        public string FromStation { get; set; }

        [JsonProperty(PropertyName = "to_loc")]
        public string ToStation { get; set; }

        [JsonProperty(PropertyName = "from_time")]
        public string FromTime { get; set; }

        [JsonProperty(PropertyName = "to_time")]
        public string ToTime { get; set; }

        [JsonProperty(PropertyName = "from_date")]
        public string FromDate { get; set; }

        [JsonProperty(PropertyName = "to_date")]
        public string ToDate { get; set; }

        [JsonProperty(PropertyName = "days")]
        public string Days { get; set; }
    }
}
