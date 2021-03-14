using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentSharingAPI.Models.Document
{
    public class AddUserEndpointModel
    {
        public string User { get; set; }
        public string Endpoint { get; set; }
    }
}
