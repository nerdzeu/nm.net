using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nerdz
{
    public class LoginException : Exception
    {
        public LoginException(string p) : base(p) { }
    }
}
