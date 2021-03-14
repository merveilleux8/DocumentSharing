using DocumentSharingData;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Upwork.SocialMediaAutoPoster.Service;

namespace DocumentSharingService.Impl
{
    public class EndpointService : IEndpointService
    {

        private readonly IFileService<UserEndpoint> _fileService;
        public const string FileName = "userEndpoints.json";
        public EndpointService(IFileService<UserEndpoint> fileService)
        {
            _fileService = fileService;
        }
        public async Task CreateUserEndpoint(string user, string endpoint)
        {
            await _fileService.Add(FileName, new UserEndpoint() { User = user, Endpoint = endpoint });
        }

        public async Task<UserEndpoint> GetUserEndpoint(string user)
        {
            return await _fileService.GetById(FileName, filter => filter.User == user);
        }

        public async Task<List<UserEndpoint>> GetUserEndpoints()
        {
            return await _fileService.Get(FileName);
        }

        public async Task<UserEndpoint> GetMyUserEndpoint()
        {
            //todo:  get hostname automatically from the server
            
            var endpoint = "https://localhost:44337";
            return await _fileService.GetById(FileName, filter => filter.Endpoint == endpoint);
        }
    }
}
