using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentSharingAPI.Models.Document;
using DocumentSharingData;
using DocumentSharingService;
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
        public async Task<List<Document>> Get()
        {
            var result = await _documentService.GetMessages();
            return result;
        }

        // GET api/<DocumentController>/5
        [HttpGet("{refNo}")]
        public async Task<Document> Get(string refNo)
        {
            return await _documentService.GetMessage(refNo);
        }

        // POST api/<DocumentController>
        [HttpPost]
        public void Post([FromBody] AddDocumentModel addDocumentModel)
        {
            _documentService.CreateMessage(addDocumentModel.Description, addDocumentModel.RefNo, addDocumentModel.Documents);
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
    }
}
