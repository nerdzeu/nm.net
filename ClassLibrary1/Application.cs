using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nerdz {
    public interface IApplication {
        string Username { get; }
        uint UserId { get; }
        bool Valid { get; }

        uint IdFromName(string username);
    }
}
