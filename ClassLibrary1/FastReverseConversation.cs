using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nerdz;
using System.Collections;

namespace Nerdz.Messages.Impl {
    class FastReverseConversation : IConversation {
        private eu.nerdz.api.messages.Conversation conversation;
        private eu.nerdz.api.messages.ConversationHandler handl;

        public FastReverseConversation(eu.nerdz.api.messages.ConversationHandler handl, eu.nerdz.api.messages.Conversation conversation) {
            this.conversation = conversation;
            this.handl = handl;
        }

        public uint OtherId {
            get { return (uint) this.conversation.getOtherID(); }
        }

        public string OtherName {
            get { return this.conversation.getOtherName(); }
        }

        public DateTime LastDate {
            get {
                var jDate = this.conversation.getLastDate();
                return new DateTime((jDate.getTime() + 62135596800000L) * 10000, DateTimeKind.Utc).ToLocalTime();
            }
        }

        public bool NewMessages {
            get {
                return this.conversation.hasNewMessages();
            }
            set {
                this.conversation.setHasNewMessages(value);
            }
        }

        public IEnumerator<IMessage> GetEnumerator() {
            java.util.List jMsgs = null;
            try {
                jMsgs = this.handl.getMessages(this.conversation);
            } catch (java.lang.Throwable t) {
                Nerdz.ExceptionWrapper(t);
            }
            var jMsgsEnum = jMsgs.listIterator();

                while (jMsgsEnum.hasNext()) {
                    yield return new FastReverseMessage(this, jMsgsEnum.next() as eu.nerdz.api.messages.Message);
                }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

        public override string ToString() {
            return this.conversation.ToString();
        }
    }
}
