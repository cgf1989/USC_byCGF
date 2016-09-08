using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace BCP.WebAPI.Controllers.File
{
    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(String path)
            : base(path)
        { }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            return base.GetLocalFileName(headers);
        }

        public override System.IO.Stream GetStream(HttpContent parent, System.Net.Http.Headers.HttpContentHeaders headers)
        {
            return base.GetStream(parent, headers);
        }
    }
}