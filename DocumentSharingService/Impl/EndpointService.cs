using DocumentSharingData;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private static string myEndpoint;
        public const string FileName = "userEndpoints.json";
        public EndpointService(IFileService<UserEndpoint> fileService, IConfiguration configuration)
        {
            _fileService = fileService;
            myEndpoint = configuration.GetValue<string>("myEndpoint");
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
            
            return await _fileService.GetById(FileName, filter => filter.Endpoint == myEndpoint);
        }

        public async Task<List<string>> GetReceiverUsers()
        {
            var userEndpoints = await _fileService.Get(FileName, filter => filter.Endpoint != myEndpoint);

            return userEndpoints.Select(x => x.User).ToList();
        }
    }
}
