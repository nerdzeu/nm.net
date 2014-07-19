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
        private JavaFRMess _real;
        private JavaConvHandl _handl;

        public FastReverseMessenger(string username, string password)
        {
            try
            {
                this._real = new JavaFRMess(username, password);
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
                if (this._handl == null)
                {
                    this._handl = this._real.getConversationHandler();
                }

                var jConvs = this._handl.getConversationsAsFetchers();

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
                var jMess = this._real.sendMessage(to, message);
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
                return (uint)this._real.newMessages();
            }
            catch (java.lang.Throwable t)
            {
                Factory.ExceptionWrapper(t);
                return 0U; //unreachable
            }
        }

        public string Username
        {
            get { return this._real.getUsername(); }
        }

        public uint UserId
        {
            get { return (uint)this._real.getUserID(); }
        }

        public bool Valid
        {
            get
            {
                try
                {
                    return this._real.checkValidity();
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
            return (uint)this._real.getUserIdForName(username);
        }
    }
}
