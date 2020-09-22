using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ContactBook.Wrapper
{
    public class ResponseWrapper
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Content { get; set; }
    }
}
