using Microsoft.AspNetCore.Http;
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
        //public List<Files> Documents { get; set; } 
        public IFormFileCollection File{ get; set; }
    }

}
