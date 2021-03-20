using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DocumentSharingAPI.Models.Document;
using DocumentSharingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DocumentSharingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutboxController : ControllerBase
    {
        protected readonly IDocumentService _documentService;
        protected readonly IOutboxService _outboxService;
        protected readonly IEndpointService _endpointService;

        public OutboxController(IDocumentService documentService, IOutboxService outboxService, IEndpointService endpointService)
        {
            _documentService = documentService;
            _outboxService = outboxService;
            _endpointService = endpointService;
        }
        // POST api/<OutboxController>
        [HttpPost]
        public async Task SendOutbox([FromBody] SendOutboxModel sendOutboxModel)
        {
            var userEndpoint = await _endpointService.GetUserEndpoint(sendOutboxModel.ReceiverUser);
            var url = $"{userEndpoint.Endpoint}/api/inbox";
            var message = await _documentService.GetMessage(sendOutboxModel.RefNo);
            var senderUserEndpoint = await _endpointService.GetMyUserEndpoint();

            var inboxModel = new ReceiveInboxModel()
            {
                SenderUser = senderUserEndpoint.User,
                RefNo = message.RefNo,
                Description = message.Description,
                Documents = message.Documents
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(inboxModel), Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var httpResponse = await client.PostAsync(url, stringContent);
            var content = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.StatusCode != HttpStatusCode.OK && httpResponse.StatusCode != HttpStatusCode.Created)
            {
                throw new Exception($"SendOutbox Error - { content }");
            }
            else
            {
                await _outboxService.CreateOutbox(userEndpoint.User, message.RefNo);
            }
        }

        // GET: api/<OutboxController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _outboxService.GetOutboxes();
            return Ok(new ResponseResult { Data = result });
        }
    }
}
