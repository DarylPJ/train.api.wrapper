namespace Train_api_Wrapper.Models.ServiceDetailsWrapper.Response
{
    public class StationData
    {
        public string DayOfTheWeek { get; set; }

        public string Date { get; set; }

        public string TrainOperator { get; set; }

        public string Station { get; set; }

        public string TrainOriginLocation { get; set; }

        public string TrainDestinationLocation { get; set; }

        public string TimeTableDepartureTimeMins { get; set; }

        public string ActualDepartureTimeMins { get; set; }

        public string TimeTableArrivalTime { get; set; }

        public string ActualArrivalTime { get; set; }
    }
}
