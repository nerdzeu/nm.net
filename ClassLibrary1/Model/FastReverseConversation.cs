using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nerdz;
using System.Collections;

namespace Nerdz.Messages.Impl
{
    class FastReverseConversation : IConversation
    {
        private eu.nerdz.api.messages.MessageFetcher _conversation;
        private List<IMessage> _fetched;

        public FastReverseConversation(eu.nerdz.api.messages.MessageFetcher conversation)
        {
            this._conversation = conversation;
            this._fetched = new List<IMessage>();
        }

        public uint OtherId
        {
            get { return (uint)this._conversation.getOtherID(); }
        }

        public string OtherName
        {
            get { return this._conversation.getOtherName(); }
        }

        public DateTime LastDate
        {
            get
            {
                var jDate = this._conversation.getLastDate();
                return new DateTime((jDate.getTime() + 62135596800000L) * 10000, DateTimeKind.Utc).ToLocalTime();
            }
        }

        public bool NewMessages
        {
            get
            {
                return this._conversation.hasNewMessages();
            }
            set
            {
                this._conversation.setHasNewMessages(value);
            }
        }

        public override string ToString()
        {
            return this._conversation.ToString();
        }


        public List<IMessage> Messages(uint from = 0, short howMany = -1)
        {
            try
            {
                uint fetchUntil = (howMany >= 0) ? from + (uint)howMany : uint.MaxValue;

                //Anything the client wants has already been fetched.
                if (!this._conversation.hasMore().booleanValue() || fetchUntil < this._fetched.Count)
                {
                    int ftchLen = (howMany >= 0) ? Math.Min(howMany, this._fetched.Count) : this._fetched.Count;
                    return this._fetched.GetRange((int)from, ftchLen);
                }

                while (this._conversation.getFetchStart() < fetchUntil && this._conversation.hasMore().booleanValue())
                {
                    this._conversation.fetch();
                }

                var jFetcherIter = this._conversation.iterator();

                while (jFetcherIter.hasNext())
                {
                    this._fetched.Add(new FastReverseMessage(this, jFetcherIter.next() as eu.nerdz.api.messages.Message));
                }

                int fetchLen = (howMany >= 0) ? Math.Min(howMany, this._fetched.Count) : this._fetched.Count;
                return this._fetched.GetRange((int)from, fetchLen);
            }
            catch (java.lang.Throwable t)
            {
                Factory.ExceptionWrapper(t);
                return null; //unreachable
            }
        }
    }
}
