using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nerdz
{
    public class BadStatusException : Exception
    {
        public BadStatusException(string message) : base(message) { }
    }
}
