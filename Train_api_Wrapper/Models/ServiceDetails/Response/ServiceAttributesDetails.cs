using Newtonsoft.Json;
using System.Collections.Generic;

namespace Train_api_Wrapper.Models.ServiceDetails.Response
{
    public class ServiceAttributesDetails
    {
        [JsonProperty(PropertyName = "date_of_service")]
        public string DateOfService { get; set; }

        [JsonProperty(PropertyName = "toc_code")]
        public string TrainOperator { get; set; }

        [JsonProperty(PropertyName = "rid")]
        public string Rid { get; set; }

        [JsonProperty(PropertyName = "locations")]
        public List<Location> Locations { get; set; }
    }
}
