using System.Collections.Generic;
using Train_api_Wrapper.Models.ServiceMetrics.Request;
using Train_api_Wrapper.Models.ServiceMetricsWrapper.Request;

namespace Train_api_Wrapper.Mappers
{
    public class ServiceMetricsMapper: IServiceMetricsMapper
    {
        public ServiceMetricsMapper()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ServiceMetricsWrapperRequest, ServiceMetricsRequest>();
            });
        }

        public List<ServiceMetricsRequest> MapServiceMetrics(ServiceMetricsWrapperRequest serviceMetricsWrapperRequest)
        {
            var serviceMetricsRequestList = new List<ServiceMetricsRequest>();

            foreach (var serviceMetricsWrapperRequestJourney in serviceMetricsWrapperRequest.Journeys)
            {
                var serviceMetricsRequest = AutoMapper.Mapper.Map<ServiceMetricsRequest>(serviceMetricsWrapperRequest);
                serviceMetricsRequest.FromStation = serviceMetricsWrapperRequestJourney.FromStation;
                serviceMetricsRequest.ToStation = serviceMetricsWrapperRequestJourney.ToStation;

                serviceMetricsRequestList.Add(serviceMetricsRequest);
            }

            return serviceMetricsRequestList;
        }
    }
}
