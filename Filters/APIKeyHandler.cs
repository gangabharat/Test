using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Configuration;

namespace Arduino.Filters
{
    public class APIKeyHandler : DelegatingHandler
    {
        private string APIKeyToCheck = ConfigurationManager.AppSettings["APIKey"].ToString();
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool validkey = false;
            IEnumerable<string> requestHeaders;
            var CheckAPIKeyExists = request.Headers.TryGetValues("APIKey", out requestHeaders);
            if (CheckAPIKeyExists)
            {
                if (requestHeaders.FirstOrDefault().Equals(APIKeyToCheck))
                {
                    validkey = true;
                }
            }
            if (!validkey)
            {
                return request.CreateResponse(HttpStatusCode.Forbidden, "Invalid APIKey");
            }
            return await base.SendAsync(request, cancellationToken);
        }        
    }
}