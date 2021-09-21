using System;
using System.Net;

namespace Shoppy
{
    public class ShoppyException : Exception
    {
        public HttpStatusCode Code { get; private set; }

        public ShoppyException(HttpStatusCode code, string msg) : base($"{(int)code} {msg}")
        {
            Code = code;
        }
    }
}
