﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if MS
using System.Json;
#else
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
#endif

#pragma warning disable 1998

namespace REST0.Definition
{
    public sealed class JsonResponse : IHttpResponseAction
    {
        readonly JObject _value;

        public JsonResponse(JObject value)
        {
            _value = value;
        }

        public async Task Execute(IHttpRequestResponseContext context)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.ContentEncoding = UTF8.WithoutBOM;

            using (context.Response.OutputStream)
            using (var tw = new StreamWriter(context.Response.OutputStream, REST0.Definition.UTF8.WithoutBOM))
                Json.Serializer.Serialize(tw, _value);
        }
    }
}
