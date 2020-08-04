using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDWebApi.Models
{
    public class EditDvd
    {
        public int dvdId { get; set; }
        public string title { get; set; }
        public int releaseYear { get; set; }
        public string director { get; set; }
        public string rating { get; set; }
        public string notes { get; set; }
    }
}