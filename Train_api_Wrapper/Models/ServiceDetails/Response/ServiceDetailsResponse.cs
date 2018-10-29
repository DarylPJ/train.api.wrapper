using Newtonsoft.Json;

namespace Train_api_Wrapper.Models.ServiceDetails.Response
{
    public class ServiceDetailsResponse
    {
        [JsonProperty(PropertyName = "serviceAttributesDetails")]
        public ServiceAttributesDetails ServiceAttributesDetails { get; set; }
    }
}
