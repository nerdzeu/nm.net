using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nerdz.Messages
{
    public interface IConversation
    {
        uint OtherId { get; }
        string OtherName { get; }
        DateTime LastDate { get; }
        /// <exception cref="IOException"></exception>
        /// <exception cref="HttpException"></exception>
        /// <exception cref="ContentException"></exception>
        List<IMessage> Messages(uint from = 0, short howMany = -1);
        bool NewMessages { get; set; }
    }
}
