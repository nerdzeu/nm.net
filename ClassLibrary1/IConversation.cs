using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nerdz.Messages {
    public interface IConversation {
        uint OtherId { get; }
        string OtherName { get; }
        DateTime LastDate { get; }
        List<IMessage> Messages(uint from = 0, short howMany = -1);
        bool NewMessages { get; set; }
    }
}
