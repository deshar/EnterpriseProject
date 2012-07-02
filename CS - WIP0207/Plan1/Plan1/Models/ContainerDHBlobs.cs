using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plan1.Models
{
    public class ContainerDHBlobs
    {
        public string id { get; set; }

        public List<DHBlob> Blobs = new List<DHBlob>();

    }
}