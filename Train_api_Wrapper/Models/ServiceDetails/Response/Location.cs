using Newtonsoft.Json;

namespace Train_api_Wrapper.Models.ServiceDetails.Response
{
    public class Location
    {
        [JsonProperty(PropertyName = "location")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "gbtt_ptd")]
        public string TimetableDeparture { get; set; }

        [JsonProperty(PropertyName = "gbtt_pta")]
        public string TimetableArrival { get; set; }

        [JsonProperty(PropertyName = "actual_td")]
        public string ActualDeparture { get; set; }

        [JsonProperty(PropertyName = "actual_ta")]
        public string ActualArrival { get; set; }

        [JsonProperty(PropertyName = "late_canc_reason")]
        public string LateOrCancelReason { get; set; }
    }
}
