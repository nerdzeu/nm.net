﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerdz.Messenger.Controller
{
    public class CriticalException : Exception
    {
        public CriticalException(String msg) : base(msg) { }
    }
}
