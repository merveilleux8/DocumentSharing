using DocumentSharingData;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Upwork.SocialMediaAutoPoster.Service;

namespace DocumentSharingService.Impl
{
    public class DocumentService : IDocumentService
    {
        private readonly IFileService<Document> _fileService;
        public const string FileName = "message.json";
        public DocumentService(IFileService<Document> fileService)
        {
            _fileService = fileService;
        }

        public async Task CreateMessage(string description, string refNo, Dictionary<string, byte[]> documentDict, DocumentType documentType)
        {
            await _fileService.Add(FileName, new Document { Description = description, RefNo = refNo, Documents = documentDict, DocumentType = documentType, CreationDate = DateTime.UtcNow.ToString("dd MMMM, yyyy hh:mm tt") });
        }

        public async Task<List<Document>> GetMessages(DocumentType documentType)
        {
            return await _fileService.Get(FileName, filter => filter.DocumentType == documentType);
        }

        public async Task<Document> GetMessage(string refNo)
        {
            return await _fileService.GetById(FileName, filter => filter.RefNo == refNo);
        }
    }
}
