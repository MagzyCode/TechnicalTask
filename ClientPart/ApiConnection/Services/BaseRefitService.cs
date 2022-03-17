using ClientPart.ApiConnection.Contracts;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public abstract class BaseRefitService<T>
        where T : IApiData
    {
        private protected readonly T _data;

        public BaseRefitService(string baseUrl = "https://localhost:5001")
        {
            _data = RestService.For<T>(baseUrl);
        }
    }
}
