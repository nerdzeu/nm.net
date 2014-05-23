using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerdz.Controller
{
    public class Credentials
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string OAuthToken { get; private set; }

        public Credentials(String username, String password)
        {
            Username = username;
            Password = password;
        }

        public Credentials(uint id, String password)
        {
            Username = id.ToString();
            Password = password;
        }
    }
}
