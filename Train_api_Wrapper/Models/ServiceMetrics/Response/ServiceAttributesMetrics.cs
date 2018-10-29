using System.Collections.Generic;

namespace Train_api_Wrapper.Models.ServiceMetrics.Response
{
    public class ServiceAttributesMetrics
    {
        public string origin_location { get; set; }
        public string destination_location { get; set; }
        public string gbtt_ptd { get; set; }
        public string gbtt_pta { get; set; }
        public string toc_code { get; set; }
        public string matched_services { get; set; }
        public List<string> rids { get; set; }
    }
}
