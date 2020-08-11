using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess
{
    public class BasicHttpMessageHandler : DelegatingHandler
    {
        private readonly HttpContext _httpContext;

        public BasicHttpMessageHandler(HttpContext httpContext)
        {
            _httpContext = httpContext;
            InnerHandler = new SocketsHttpHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var ex = new Exception("API Failure |" + _httpContext.TraceIdentifier);

                ex.Data.Add("API Route", $"GET {request.RequestUri}");
                ex.Data.Add("API Status", (int)response.StatusCode);

                throw ex;
            }

            return response;
        }
    }
}
