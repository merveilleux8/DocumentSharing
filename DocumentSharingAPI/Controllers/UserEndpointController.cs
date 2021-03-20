using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentSharingAPI.Models.Document;
using DocumentSharingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentSharingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEndpointController : ControllerBase
    {
        protected readonly IEndpointService _endpointService;

        public UserEndpointController(IEndpointService endpointService)
        {
            _endpointService = endpointService;
        }

        // POST api/<UserEndpointController>
        [HttpPost]
        public void CreateUserEndpoint([FromBody] AddUserEndpointModel addUserEndpointModel)
        {
            _endpointService.CreateUserEndpoint(addUserEndpointModel.User, addUserEndpointModel.Endpoint);
        }


        // GET: api/<UserEndpointController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _endpointService.GetReceiverUsers();
            return Ok(new ResponseResult { Data = result });
        }

    }
}
