using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Train_api_Wrapper.Models.ServiceMetricsWrapper.Request;
using Train_api_Wrapper.Models.ServiceMetricsWrapper.Response;
using Train_api_Wrapper.Mappers;

namespace Train_api_Wrapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceMetricsWrapperController
    {
        private readonly IServiceMetricsMapper serviceMetricsMapper;
        private readonly IServiceMetricsRequestBuilder serviceMetricsRequestBuilder;
        private readonly IServiceMetric serviceMetric;

        public ServiceMetricsWrapperController(IServiceMetricsMapper serviceMetricsMapper, IServiceMetricsRequestBuilder serviceMetricsRequestBuilder, IServiceMetric serviceMetric)
        {
            this.serviceMetricsMapper = serviceMetricsMapper;
            this.serviceMetricsRequestBuilder = serviceMetricsRequestBuilder;
            this.serviceMetric = serviceMetric;
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostAsync([FromBody] ServiceMetricsWrapperRequest serviceMetricsWrapperRequest)
        {
            if (serviceMetricsWrapperRequest.Journeys.Count > 4)
            {
                return new BadRequestObjectResult("Cannot have more than 4 requests");
            }

            var serviceMetricsList = serviceMetricsMapper.MapServiceMetrics(serviceMetricsWrapperRequest);
            var serviceMetricsRequests = serviceMetricsRequestBuilder.ServiceMetrics(serviceMetricsList);
            var serviceMetricResponses = await serviceMetric.GetResposesAsync(serviceMetricsRequests);

            var rids = new List<string>();

            foreach (var serviceMetricResponse in serviceMetricResponses)
            {
                foreach (var service in serviceMetricResponse.Services)
                {
                    foreach (var rid in service.serviceAttributesMetrics.rids)
                    {
                        rids.Add(rid);
                    }
                }
            }

            var serviceMetricsWrapperResponse = new ServiceMetricsWrapperResponse
            {
                Rids = rids
            };

            return new OkObjectResult(serviceMetricsWrapperResponse);
        }
    }
}
