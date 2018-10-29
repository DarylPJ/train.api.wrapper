using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Train_api_Wrapper.Models.ServiceDetails.Response;

namespace Train_api_Wrapper
{
    public class ServiceDetails : IServiceDetails
    {
        private readonly IHttpClientWrapper httpClientWrapper;

        public ServiceDetails(IHttpClientWrapper httpClientWrapper)
        {
            this.httpClientWrapper = httpClientWrapper;
        }

        public async Task<List<ServiceDetailsResponse>> GetResposesAsync(List<HttpRequestMessage> httpRequestMessages)
        {
            var responseTasks = new List<Task<HttpResponseMessage>>();
            foreach (var httpRequestMessage in httpRequestMessages)
            {
                responseTasks.Add(httpClientWrapper.SendAsync(httpRequestMessage));
            }

            var serviceDetailsResponses = new List<ServiceDetailsResponse>();
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

                var serviceDetailsResponse = await response.Content.ReadAsStringAsync();
                var serviceDetailsModel = JsonConvert.DeserializeObject<ServiceDetailsResponse>(serviceDetailsResponse);
                serviceDetailsResponses.Add(serviceDetailsModel);
            }

            return serviceDetailsResponses;
        }
    }
}
