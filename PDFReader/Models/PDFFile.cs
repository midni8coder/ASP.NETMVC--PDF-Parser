using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDFReader.Models
{
    public class PDFFile
    {
        public string ImagePath { get; set; }
        public HttpPostedFile PDFFileName { get; set; }
    }

}