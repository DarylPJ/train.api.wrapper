using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Train_api_Wrapper.Models;
using Train_api_Wrapper.Models.ServiceDetails.Request;
using Train_api_Wrapper.Models.ServiceMetrics.Request;

namespace Train_api_Wrapper
{
    public class RequestBuilder : IServiceMetricsRequestBuilder, IServiceDetailsRequestBuilder
    {
        private readonly Uri serviceMetricsUri = new Uri("https://hsp-prod.rockshore.net/api/v1/serviceMetrics");
        private readonly Uri serviceDetailsUri = new Uri("https://hsp-prod.rockshore.net/api/v1/serviceDetails");
        private AuthenticationHeaderValue BasicEncryptedToken { get; set; }

        public RequestBuilder(IOptions<Credentials> credentials)
        {
            var stringToEncrypt = string.Concat(credentials.Value.Username, ":", credentials.Value.Password);
            var plainTextBytes = Encoding.UTF8.GetBytes(stringToEncrypt);
            var BasicEncryptedString = Convert.ToBase64String(plainTextBytes);
            BasicEncryptedToken = new AuthenticationHeaderValue("Basic", BasicEncryptedString);
        }

        public List<HttpRequestMessage> ServiceMetrics(List<ServiceMetricsRequest> serviceMetricsRequests)
        {
            var httpRequestMessages = new List<HttpRequestMessage>();

            foreach (var serviceMetricsRequest in serviceMetricsRequests)
            {
                var request = new HttpRequestMessage(HttpMethod.Post, serviceMetricsUri);
                request.Headers.Authorization = BasicEncryptedToken;
                request.Headers.Host = "hsp-prod.rockshore.net";

                request.Content = new StringContent(JsonConvert.SerializeObject(serviceMetricsRequest), Encoding.UTF8, "application/json");

                httpRequestMessages.Add(request);
            }

            return httpRequestMessages;
        }

        public List<HttpRequestMessage> ServiceDetails(List<ServiceDetailsRequest> serviceDetailsRequests)
        {
            var httpRequestMessages = new List<HttpRequestMessage>();

            foreach (var serivceDetailsRequest in serviceDetailsRequests)
            {
                var request = new HttpRequestMessage(HttpMethod.Post, serviceDetailsUri);
                request.Headers.Authorization = BasicEncryptedToken;
                request.Headers.Host = "hsp-prod.rockshore.net";

                request.Content = new StringContent(JsonConvert.SerializeObject(serivceDetailsRequest), Encoding.UTF8, "application/json");

                httpRequestMessages.Add(request);
            }

            return httpRequestMessages;
        }
    }
}
