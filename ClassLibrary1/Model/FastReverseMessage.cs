using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nerdz.Messages.Impl
{
    class FastReverseMessage : IMessage
    {
        private eu.nerdz.api.messages.Message _message;
        private IConversation _father;

        public FastReverseMessage(IConversation father, eu.nerdz.api.messages.Message message)
        {
            this._father = father;
            this._message = message;
        }

        public IConversation Conversation
        {
            get { return this._father; }
        }

        public DateTime Date
        {
            get
            {
                var jDate = this._message.getDate();
                return new DateTime((jDate.getTime() + 62135596800000L) * 10000, DateTimeKind.Utc).ToLocalTime();
            }
        }

        public bool Read
        {
            get { return this._message.read(); }
        }

        public bool Received
        {
            get { return this._message.received(); }
        }

        public string Text
        {
            get { return this._message.getContent() as string; }
        }

        public override string ToString()
        {
            return this._message.ToString();
        }
    }
}
