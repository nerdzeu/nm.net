using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nerdz;

namespace Nerdz.Messages {
    public interface IMessage {
        IConversation Conversation { get; }
        bool Read { get; }
        bool Received { get; }
        string Text { get; }
    }
}
