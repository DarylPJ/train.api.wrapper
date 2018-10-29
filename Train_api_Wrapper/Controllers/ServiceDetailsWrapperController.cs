using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Train_api_Wrapper.Models.ServiceDetailsWrapper.Request;
using Train_api_Wrapper.Mappers;

namespace Train_api_Wrapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceDetailsWrapperController
    {
        private readonly IServiceDetailsMapper serviceDetailsMapper;
        private readonly IServiceDetailsRequestBuilder serviceDetailsRequestBuilder;
        private readonly IServiceDetails serviceDetails;
        private readonly IServiceDetailsWrapperResponseMapper serviceDetailsWrapperResponseWrapper;

        public ServiceDetailsWrapperController(IServiceDetailsMapper serviceDetailsMapper, IServiceDetailsRequestBuilder serviceDetailsRequestBuilder,
                                               IServiceDetails serviceDetails, IServiceDetailsWrapperResponseMapper serviceDetailsWrapperResponseWrapper)
        {
            this.serviceDetailsMapper = serviceDetailsMapper;
            this.serviceDetailsRequestBuilder = serviceDetailsRequestBuilder;
            this.serviceDetails = serviceDetails;
            this.serviceDetailsWrapperResponseWrapper = serviceDetailsWrapperResponseWrapper;
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostAsync([FromBody] ServiceDetailsWrapperRequest serviceDetailsWrapperRequest)
        {
            if (serviceDetailsWrapperRequest.Rids.Count > 4)
            {
                return new BadRequestObjectResult("Cannot have more than 4 requests");
            }

            var serviceDetailsList = serviceDetailsMapper.MapServiceDetails(serviceDetailsWrapperRequest);
            var serviceDetailsRequests = serviceDetailsRequestBuilder.ServiceDetails(serviceDetailsList);
            var serviceDetailsResponses = await serviceDetails.GetResposesAsync(serviceDetailsRequests);
            var serivceDetailsWrapperResponse = serviceDetailsWrapperResponseWrapper.Map(serviceDetailsResponses);
            
            return new OkObjectResult(serivceDetailsWrapperResponse);
        }
    }
}
