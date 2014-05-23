using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nerdz;

namespace Nerdz.Messages
{
    public interface IMessenger : IApplication
    {
        /// <exception cref="IOException"></exception>
        /// <exception cref="HttpException"></exception>
        /// <exception cref="ContentException"></exception>
        List<IConversation> Conversations();

        /// <exception cref="IOException"></exception>
        /// <exception cref="HttpException"></exception>
        /// <exception cref="ContentException"></exception>
        /// <exception cref="BadStatusException"></exception>
        /// <exception cref="UserNotFoundException"></exception>
        IMessage Send(string to, string message);

        /// <exception cref="IOException"></exception>
        /// <exception cref="HttpException"></exception>
        /// <exception cref="ContentException"></exception>
        uint UnreadMessages();
    }
}
