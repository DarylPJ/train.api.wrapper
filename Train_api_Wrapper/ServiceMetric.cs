using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Train_api_Wrapper.Models.ServiceMetrics.Response;

namespace Train_api_Wrapper
{
    public class ServiceMetric : IServiceMetric
    {
        private readonly IHttpClientWrapper httpClientWrapper;

        public ServiceMetric(IHttpClientWrapper httpClientWrapper)
        {
            this.httpClientWrapper = httpClientWrapper;
        }

        public async Task<List<ServiceMetricsResponse>> GetResposesAsync(List<HttpRequestMessage> httpRequestMessages)
        {
            var responseTasks = new List<Task<HttpResponseMessage>>();
            foreach (var httpRequestMessage in httpRequestMessages)
            {
                responseTasks.Add(httpClientWrapper.SendAsync(httpRequestMessage));
            }

            var serviceMetricsResponses = new List<ServiceMetricsResponse>();
            foreach (var responseTask in responseTasks)
            {
                HttpResponseMessage response;
                try
                {
                    response = responseTask.Result;
                }
                catch (AggregateException)
                {
                    continue;
                }

                if (!response.IsSuccessStatusCode)
                {
                    continue;
                }

                var serviceMetricsResponse = await response.Content.ReadAsStringAsync();
                var serviceMetricsModel = JsonConvert.DeserializeObject<ServiceMetricsResponse>(serviceMetricsResponse);
                serviceMetricsResponses.Add(serviceMetricsModel);
            }

            return serviceMetricsResponses;
        }
    }
}
