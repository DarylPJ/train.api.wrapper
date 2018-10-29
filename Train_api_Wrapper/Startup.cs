using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Train_api_Wrapper.Mappers;
using Train_api_Wrapper.Models;

namespace Train_api_Wrapper
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var credentials = Configuration.GetSection("Credentials");
            services.Configure<Credentials>(credentials);


            services.AddSingleton<IHttpClientWrapper, HttpClientWrapper>();
            services.AddSingleton<IServiceMetricsMapper, ServiceMetricsMapper>();
            services.AddSingleton<IServiceDetailsMapper, ServiceDetailsMapper>();
            services.AddSingleton<IServiceMetricsRequestBuilder, RequestBuilder>();
            services.AddSingleton<IServiceDetailsRequestBuilder, RequestBuilder>();
            services.AddSingleton<IServiceMetric, ServiceMetric>();
            services.AddSingleton<IServiceDetails, ServiceDetails>();
            services.AddSingleton<IServiceDetailsWrapperResponseMapper, ServiceDetailsWrapperResponseMapper>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
