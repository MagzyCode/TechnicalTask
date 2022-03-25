using ClientPart.ApiConnection.Contracts;
using Microsoft.Extensions.Configuration;
using Refit;

namespace ClientPart.ApiConnection.Services
{
    public abstract class BaseRefitService<T>
        where T : IApiData
    {
        private protected readonly T _data;
        private protected readonly IConfiguration _configuration;

        public BaseRefitService(IConfiguration configuration)
        {
            _configuration = configuration;
            _data = RestService.For<T>(_configuration.GetValue<string>("Refit:BaseUrl"));
        }
    }
}
