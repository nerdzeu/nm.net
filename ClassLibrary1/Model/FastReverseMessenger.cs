using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JavaFRMess = eu.nerdz.api.impl.fastreverse.messages.FastReverseMessenger;
using JavaConvHandl = eu.nerdz.api.messages.ConversationHandler;
using Nerdz;

namespace Nerdz.Messages.Impl
{
    class FastReverseMessenger : IMessenger
    {
        private JavaFRMess real;
        private JavaConvHandl handl;

        public FastReverseMessenger(string username, string password)
        {
            try
            {
                this.real = new JavaFRMess(username, password);
            }
            catch (java.lang.Throwable t)
            {
                Factory.ExceptionWrapper(t);
            }
        }

        public List<IConversation> Conversations()
        {
            try
            {
                if (this.handl == null)
                {
                    this.handl = this.real.getConversationHandler();
                }

                var jConvs = this.handl.getConversationsAsFetchers();

                var jConvsIter = jConvs.listIterator();
                var ret = new List<IConversation>(jConvs.size());

                while (jConvsIter.hasNext())
                {
                    ret.Add(new FastReverseConversation(jConvsIter.next() as eu.nerdz.api.messages.MessageFetcher));
                }

                return ret;
            }
            catch (java.lang.Throwable t)
            {
                Factory.ExceptionWrapper(t);
                return null; //unreachable
            }
        }

        public IMessage Send(string to, string message)
        {
            try
            {
                var jMess = this.real.sendMessage(to, message);
                return new FastReverseMessage(new FastReverseConversation(jMess.thisConversation() as eu.nerdz.api.messages.MessageFetcher), jMess);
            }
            catch (java.lang.Throwable t)
            {
                Factory.ExceptionWrapper(t);
                return null; //unreachable
            }
        }

        public uint UnreadMessages()
        {
            try
            {
                return (uint)this.real.newMessages();
            }
            catch (java.lang.Throwable t)
            {
                Factory.ExceptionWrapper(t);
                return 0U; //unreachable
            }
        }

        public string Username
        {
            get { return this.real.getUsername(); }
        }

        public uint UserId
        {
            get { return (uint)this.real.getUserID(); }
        }

        public bool Valid
        {
            get
            {
                try
                {
                    return this.real.checkValidity();
                }
                catch (eu.nerdz.api.LoginException)
                {
                    return false;
                }
                catch (java.lang.Throwable t)
                {
                    Factory.ExceptionWrapper(t);
                    return false;
                }
            }
        }

        public uint IdFromName(string username)
        {
            return (uint)this.real.getUserIdForName(username);
        }
    }
}
