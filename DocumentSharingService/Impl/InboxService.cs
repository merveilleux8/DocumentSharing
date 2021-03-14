using DocumentSharingData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Upwork.SocialMediaAutoPoster.Service;

namespace DocumentSharingService.Impl
{
    public class InboxService :IInboxService
    {
        private readonly IFileService<Inbox> _fileService;
        public const string FileName = "inbox.json";
        public InboxService(IFileService<Inbox> fileService)
        {
            _fileService = fileService;
        }

        public async Task CreateInbox(string senderUser, string refNo)
        {
            await _fileService.Add(FileName, new Inbox() { SenderUser = senderUser, RefNo = refNo });
        }
    }
}
