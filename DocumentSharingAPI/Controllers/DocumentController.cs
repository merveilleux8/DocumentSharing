using System;
using System.Collections.Generic;
using System.IO;
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
    public class DocumentController : ControllerBase
    {
        protected readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        // GET: api/<DocumentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _documentService.GetMessages(DocumentType.outbox);
            return Ok(new ResponseResult { Data = result });
        }

        // GET api/<DocumentController>/5
        [HttpGet("{refNo}")]
        public async Task<Document> Get(string refNo)
        {
            return await _documentService.GetMessage(refNo);
        }

        // POST api/<DocumentController>
        [HttpPost]
        public void Post([FromForm] AddDocumentModel addDocumentModel)
        {
            _documentService.CreateMessage(addDocumentModel.Description, addDocumentModel.RefNo, addDocumentModel.File?.ToDictionary(x => x.FileName, x => ConvertToByteArray(x)), DocumentType.outbox);
        }

        // PUT api/<DocumentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DocumentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private byte[] ConvertToByteArray(IFormFile file)
        {
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    return fileBytes;
                }
            }
            else
                return Array.Empty<byte>();
        }
    }
}
