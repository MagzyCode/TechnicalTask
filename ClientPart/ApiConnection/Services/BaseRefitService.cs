using ClientPart.ApiConnection.Contracts;
using ClientPart.ApiConnection.HttpClientHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Refit;
using System;
using System.Net.Http;

namespace ClientPart.ApiConnection.Services
{
    public abstract class BaseRefitService<T>
        where T : IApiData
    {
        private protected readonly T _data;
        private protected readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationService _authenticationService;

        public BaseRefitService(IConfiguration configuration)
        {
            _configuration = configuration;

            var hostUrl = _configuration.GetValue<string>("Refit:BaseUrl");
            _data = RestService.For<T>(hostUrl);
        }

        public BaseRefitService(
            IConfiguration configuration, 
            IHttpContextAccessor httpContextAccessor,
            AuthenticationService authenticationService)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _authenticationService = authenticationService;

            var hostUrl = _configuration.GetValue<string>("Refit:BaseUrl");
            _data = RestService.For<T>(new HttpClient(
                new AuthenticatedHttpClientHandler(
                    _httpContextAccessor,
                    _authenticationService))
                {
                    BaseAddress = new Uri(hostUrl)
                }
            );
        }
    }
}
