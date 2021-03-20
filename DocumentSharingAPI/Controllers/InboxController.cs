using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentSharingAPI.Models.Document;
using DocumentSharingData;
using DocumentSharingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentSharingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InboxController : ControllerBase
    {
        protected readonly IDocumentService _documentService;
        protected readonly IInboxService _inboxService;

        public InboxController(IDocumentService documentService, IInboxService inboxService)
        {
            _documentService = documentService;
            _inboxService = inboxService;
        }
        // POST api/<InboxController>
        [HttpPost]
        public async void ReceiveInbox([FromBody] ReceiveInboxModel receiveInboxModel)
        {
            await _documentService.CreateMessage(receiveInboxModel.Description, receiveInboxModel.RefNo, receiveInboxModel.Documents, DocumentType.inbox);
            await _inboxService.CreateInbox(receiveInboxModel.SenderUser, receiveInboxModel.RefNo);
        }


        // GET: api/<InboxController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _inboxService.GetInboxes();
            return Ok(new ResponseResult { Data = result });
        }
    }
}
