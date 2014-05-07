using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nerdz {
    public class UserNotFoundException : Exception {
        public UserNotFoundException(string msg) : base(msg) {}
    }
}
