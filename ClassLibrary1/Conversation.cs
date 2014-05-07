using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nerdz.Messages {
    public interface IConversation : IEnumerable<IMessage> {
        uint OtherId { get; }
        string OtherName { get; }
        DateTime LastDate { get; }
        bool NewMessages { get; set; }
    }
}
