using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nerdz.Messages.Impl {
    class FastReverseMessage : IMessage {
        private eu.nerdz.api.messages.Message message;
        private IConversation father;

        public FastReverseMessage(IConversation father, eu.nerdz.api.messages.Message message) {
            this.father = father;
            this.message = message;
        }

        public IConversation Conversation {
            get { return this.father; }
        }

        public bool Read {
            get { return this.message.read(); }
        }

        public bool Received {
            get { return this.message.received(); }
        }

        public string Text {
            get { return this.message.getContent() as string; }
        }

        public override string ToString() {
            return this.message.ToString();
        }
    }
}
