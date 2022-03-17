
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.HttpClientHandlers
{
    public class AuthenticateHttpClientHandler : HttpClientHandler
    {
        private readonly string _token;

        public AuthenticateHttpClientHandler(IHttpContextAccessor httpAccessor)
        {
            var context = httpAccessor.HttpContext;
            _token = context.Request.HttpContext.Request.Headers["Authorization"];
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(_token) && request.Headers.Authorization != null)
            {
                var parameters = _token.Split(' ');
                request.Headers.Authorization = new AuthenticationHeaderValue(parameters[0], parameters[1]);
            }
            return await base.SendAsync(request, cancellationToken);
        }

    }
}
