using System.Collections.Generic;
using Train_api_Wrapper.Models.ServiceDetails.Request;
using Train_api_Wrapper.Models.ServiceDetailsWrapper.Request;

namespace Train_api_Wrapper.Mappers
{
    public class ServiceDetailsMapper : IServiceDetailsMapper
    {
        public List<ServiceDetailsRequest> MapServiceDetails(ServiceDetailsWrapperRequest serviceDetailsWrapperRequest)
        {
            var serviceDetailsRequestList = new List<ServiceDetailsRequest>();

            foreach (var rid in serviceDetailsWrapperRequest.Rids)
            {
                serviceDetailsRequestList.Add(new ServiceDetailsRequest
                {
                    rid = rid
                });
            }

            return serviceDetailsRequestList;
        }
    }
}
