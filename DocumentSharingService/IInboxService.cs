using DocumentSharingData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSharingService
{
    public interface IInboxService
    {
        Task CreateInbox(string senderUser, string refNo);
        Task<List<Inbox>> GetInboxes();
    }
}
