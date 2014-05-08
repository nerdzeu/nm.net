using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nerdz;
using System.Collections;

namespace Nerdz.Messages.Impl {
    class FastReverseConversation : IConversation {
        private eu.nerdz.api.messages.MessageFetcher conversation;
        private List<IMessage> fetched;

        public FastReverseConversation(eu.nerdz.api.messages.MessageFetcher conversation) {
            this.conversation = conversation;
            this.fetched = new List<IMessage>();
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

        public override string ToString() {
            return this.conversation.ToString();
        }


        public List<IMessage> Messages(uint from = 0, short howMany = -1) {

            uint fetchUntil = (howMany >= 0) ? from + (uint) howMany : uint.MaxValue;

            //Anything the client wants has already been fetched.
            if (!this.conversation.hasMore().booleanValue() || fetchUntil < this.fetched.Count) {
                int ftchLen = (howMany >= 0) ? Math.Min(howMany, this.fetched.Count) : this.fetched.Count;
                return this.fetched.GetRange((int) from, ftchLen);
            }

            while (this.conversation.getFetchStart() < fetchUntil && this.conversation.hasMore().booleanValue()) {
                this.conversation.fetch();
            }

            var jFetcherIter = this.conversation.iterator();

            while (jFetcherIter.hasNext()) {
                this.fetched.Add(new FastReverseMessage(this, jFetcherIter.next() as eu.nerdz.api.messages.Message));
            }

            int fetchLen = (howMany >= 0) ? Math.Min(howMany, this.fetched.Count) : this.fetched.Count;
            return this.fetched.GetRange((int) from, fetchLen);
        }
    }
}
