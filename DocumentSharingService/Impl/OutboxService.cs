using DocumentSharingData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Upwork.SocialMediaAutoPoster.Service;

namespace DocumentSharingService.Impl
{
    public class OutboxService : IOutboxService
    {
        private readonly IFileService<Outbox> _fileService;
        public const string FileName = "outbox.json";
        public OutboxService(IFileService<Outbox> fileService)
        {
            _fileService = fileService;
        }

        public async Task CreateOutbox(string receiverUser, string refNo)
        {
            await _fileService.Add(FileName, new Outbox() { ReceiverUser = receiverUser, RefNo = refNo });
        }

        public async Task<List<Outbox>> GetOutboxes()
        {
            return await _fileService.Get(FileName);
        }
    }
}
