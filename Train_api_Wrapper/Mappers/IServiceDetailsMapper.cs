using System.Collections.Generic;
using Train_api_Wrapper.Models.ServiceDetails.Request;
using Train_api_Wrapper.Models.ServiceDetailsWrapper.Request;

namespace Train_api_Wrapper.Mappers
{
    public interface IServiceDetailsMapper
    {
        List<ServiceDetailsRequest> MapServiceDetails(ServiceDetailsWrapperRequest serviceDetailsWrapperRequest);
    }
}