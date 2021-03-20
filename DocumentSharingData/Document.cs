using System;
using System.Collections.Generic;

namespace DocumentSharingData
{
    public class Document
    {
        public string Description { get; set; }
        public string RefNo { get; set; }
        public Dictionary<string, byte[]> Documents { get; set; }
        public string CreationDate { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}
