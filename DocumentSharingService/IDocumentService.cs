using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentSharingData;

namespace DocumentSharingService
{
    public interface IDocumentService
    {
        Task CreateMessage(string description, string refNo, Dictionary<string, byte[]> documentList, DocumentType documentType);
        Task<List<Document>> GetMessages(DocumentType documentType);
        Task<Document> GetMessage(string refNo);
    }
}
