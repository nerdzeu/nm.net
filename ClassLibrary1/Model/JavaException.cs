using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nerdz
{
    public class JavaException : Exception
    {
        public JavaException(string msg) : base(msg) { }
    }
}
