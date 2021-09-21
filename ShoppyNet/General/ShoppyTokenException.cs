using System;

namespace Shoppy
{
    public class ShoppyTokenException : Exception
    {
        public ShoppyTokenException() : base("Invalid token encountered")
        { }
    }
}
