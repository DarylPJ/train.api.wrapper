namespace Train_api_Wrapper.Models.ServiceMetrics.Response
{
    public class Metric
    {
        public string tolerance_value { get; set; }
        public string num_not_tolerance { get; set; }
        public string num_tolerance { get; set; }
        public string percent_tolerance { get; set; }
        public bool global_tolerance { get; set; }
    }
}
