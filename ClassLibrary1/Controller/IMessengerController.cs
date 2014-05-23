using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerdz.Controller
{
    public interface IMessengerController
    {
        /// <exception cref="IOException"></exception>
        /// <exception cref="CriticalException"></exception>
        void Conversations();

        /// <exception cref="CriticalException"></exception>
        /// <exception cref="IOException"></exception>
        void Conversation(int index, uint from = 0, short howMany = 10);

        /// <exception cref="CriticalException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="BadStatusException"></exception>
        /// <exception cref="UserNotFoundException"></exception>
        void Send(String to, String message);

        void Logout();
    }
}
