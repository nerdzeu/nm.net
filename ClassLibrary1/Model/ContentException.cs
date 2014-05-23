using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nerdz
{
    public class ContentException : Exception
    {
        public ContentException(string msg) : base(msg) { }
    }
}
