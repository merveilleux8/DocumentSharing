using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentSharingAPI.Models.Document
{
    public class Files
    {
        public string Name { get; set; }
        public byte[] Document { get; set; }
    }
}
