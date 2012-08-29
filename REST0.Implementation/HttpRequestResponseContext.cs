﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace REST0.Definition
{
    public sealed class HttpRequestResponseContext : IHttpRequestResponseContext, IDisposable
    {
        public IHttpAsyncHostHandlerContext HostContext { get; private set; }

        public HttpListenerRequest Request { get; private set; }
        public IPrincipal User { get; private set; }

        public HttpListenerResponse Response { get; private set; }

        public Stream OutputStream { get { return Response.OutputStream; } }
        public TextWriter Output { get; private set; }

        public HttpRequestResponseContext(IHttpRequestContext requestState, HttpListenerResponse response)
        {
            HostContext = requestState.HostContext;
            Request = requestState.Request;
            User = requestState.User;

            Response = response;
            Output = new StreamWriter(response.OutputStream, REST0.Definition.UTF8Encoding.WithoutBOM, 65536, true);
        }

        public void Dispose()
        {
            Output.Dispose();
        }
    }
}
