﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aardwolf
{
    /// <summary>
    /// An exception to be converted to a JSON error result.
    /// </summary>
    public sealed class JsonResultException : Exception
    {
        private readonly int _statusCode;
        public JsonResultException(int statusCode, string message)
            : base(message)
        {
            _statusCode = statusCode;
        }
        public int StatusCode { get { return _statusCode; } }
    }
}
