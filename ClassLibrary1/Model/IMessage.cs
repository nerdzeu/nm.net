using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nerdz;

namespace Nerdz.Messages
{
    public interface IMessage
    {
        /// <exception cref="IOException"></exception>
        /// <exception cref="HttpException"></exception>
        /// <exception cref="ContentException"></exception>
        IConversation Conversation { get; }
        DateTime Date { get; }
        bool Read { get; }
        bool Received { get; }
        string Text { get; }
    }
}
