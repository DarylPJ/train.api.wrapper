using System;
using System.Collections.Generic;
using System.Linq;
using Train_api_Wrapper.Models.ServiceDetails.Response;
using Train_api_Wrapper.Models.ServiceDetailsWrapper.Response;

namespace Train_api_Wrapper.Mappers
{
    public class ServiceDetailsWrapperResponseMapper : IServiceDetailsWrapperResponseMapper
    {
        public ServiceDetailsWrapperResponse Map(List<ServiceDetailsResponse> serviceDetailsResponses)
        {
            var stationDataList = new List<StationData>();

            foreach (var serivceDetailsResponse in serviceDetailsResponses)
            {
                var dateOfService = DateTime.Parse(serivceDetailsResponse.ServiceAttributesDetails.DateOfService);

                var baseData = new StationData
                {
                    DayOfTheWeek = dateOfService.DayOfWeek.ToString(),
                    Date = dateOfService.ToShortDateString(),
                    TrainOperator = serivceDetailsResponse.ServiceAttributesDetails.TrainOperator,
                    TrainOriginLocation = serivceDetailsResponse.ServiceAttributesDetails.Locations.First().Name,
                    TrainDestinationLocation = serivceDetailsResponse.ServiceAttributesDetails.Locations.Last().Name
                };

                foreach (var location in serivceDetailsResponse.ServiceAttributesDetails.Locations)
                {
                    var dataToSave = GetStationModel(location, baseData);
                    stationDataList.Add(dataToSave);
                }
            }

            return new ServiceDetailsWrapperResponse
            {
                StationDataList = stationDataList
            };
        }

        private StationData GetStationModel(Location location, StationData stationData)
        {
            return new StationData
            {
                DayOfTheWeek = stationData.DayOfTheWeek,
                Date = stationData.Date,
                TrainOperator = stationData.TrainOperator,
                TrainOriginLocation = stationData.TrainOriginLocation,
                TrainDestinationLocation = stationData.TrainDestinationLocation,
                Station = location.Name,
                TimeTableDepartureTimeMins = location.TimetableDeparture,
                ActualDepartureTimeMins = location.ActualDeparture,
                TimeTableArrivalTime = location.TimetableArrival,
                ActualArrivalTime = location.ActualArrival
            };
        }
    }
}
