using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nerdz
{
    public class HttpException : Exception
    {
        public HttpException(string p) : base(p) { }
    }
}
