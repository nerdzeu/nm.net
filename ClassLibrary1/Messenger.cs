using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nerdz;

namespace Nerdz.Messages {
    public interface IMessenger : IApplication {
        List<IConversation> Conversations();
        IMessage Send(string to, string message);
        uint UnreadMessages();
    }
}
