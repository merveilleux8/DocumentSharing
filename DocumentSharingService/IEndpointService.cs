using DocumentSharingData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSharingService
{
    public interface IEndpointService
    {
        Task CreateUserEndpoint(string user, string endpoint);
        Task<List<UserEndpoint>> GetUserEndpoints();
        Task<UserEndpoint> GetUserEndpoint(string user);
        Task<UserEndpoint> GetMyUserEndpoint();
    }
}
