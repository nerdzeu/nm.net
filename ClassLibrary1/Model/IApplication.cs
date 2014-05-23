using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nerdz
{
    public interface IApplication
    {
        string Username { get; }
        uint UserId { get; }
        bool Valid { get; }

        /// <exception cref="IOException"></exception>
        /// <exception cref="HttpException"></exception>
        /// <exception cref="ContentException"></exception>
        /// <exception cref="UserNotFoundException"></exception>
        uint IdFromName(string username);
    }
}
