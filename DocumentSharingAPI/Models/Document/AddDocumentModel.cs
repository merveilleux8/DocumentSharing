using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentSharingAPI.Models.Document
{
    public class AddDocumentModel
    {
        public string Description { get; set; }
        public string RefNo { get; set; }
        public Dictionary<string,byte[]> Documents { get; set; }
    }
}
