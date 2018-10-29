using System.Collections.Generic;
using Train_api_Wrapper.Models.ServiceDetails.Response;
using Train_api_Wrapper.Models.ServiceDetailsWrapper.Response;

namespace Train_api_Wrapper.Mappers
{
    public interface IServiceDetailsWrapperResponseMapper
    {
        ServiceDetailsWrapperResponse Map(List<ServiceDetailsResponse> serviceDetailsResponses);
    }
}