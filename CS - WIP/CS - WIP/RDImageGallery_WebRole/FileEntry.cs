using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RDImageGallery_WebRole
{
    public class FileEntry
    {
        public Uri FileUri { get; set; }
        public string FileName { get; set; }
        public string Submitter { get; set; }
    }
}