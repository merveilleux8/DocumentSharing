using DocumentSharingData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSharingService
{
    public interface IOutboxService
    {
        public Task CreateOutbox(string receiverUser, string refNo);
        public Task<List<Outbox>> GetOutboxes(); 
    }
}
