using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentSharingAPI.Models.Document
{
    public class SendOutboxModel
    {
        public string ReceiverUser { get; set; }
        public string RefNo { get; set; }
    }
}
