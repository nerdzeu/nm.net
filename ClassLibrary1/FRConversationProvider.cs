using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Nerdz.Messages.Impl {

    internal static class TypeSystem {
        internal static Type GetElementType(Type seqType) {
            Type ienum = TypeSystem.FindIEnumerable(seqType);
            if (ienum == null) {
                return seqType;
            }
            return ienum.GetGenericArguments()[0];
        }

        private static Type FindIEnumerable(Type seqType) {
            if (seqType == null || seqType == typeof(string)) {
                return null;
            }

            if (seqType.IsArray) {
                return typeof(IEnumerable<>).MakeGenericType(seqType.GetElementType());
            }

            if (seqType.IsGenericType) {
                foreach (Type arg in seqType.GetGenericArguments()) {
                    Type ienum = typeof(IEnumerable<>).MakeGenericType(arg);
                    if (ienum.IsAssignableFrom(seqType)) {
                        return ienum;
                    }
                }
            }

            Type[] ifaces = seqType.GetInterfaces();
            if (ifaces != null && ifaces.Length > 0) {
                foreach (Type iface in ifaces) {
                    Type ienum = FindIEnumerable(iface);
                    if (ienum != null) { 
                        return ienum; 
                    }
                }
            }

            if (seqType.BaseType != null && seqType.BaseType != typeof(object)) {
                return TypeSystem.FindIEnumerable(seqType.BaseType);
            }

            return null;
        }
    }

    class FRConversationProvider : IQueryProvider {
        private eu.nerdz.api.messages.ConversationHandler handl;
        private eu.nerdz.api.messages.MessageFetcher conversation;

        public FRConversationProvider(eu.nerdz.api.messages.ConversationHandler handl, eu.nerdz.api.messages.MessageFetcher conversation) {
            this.handl = handl;
            this.conversation = conversation;
        }
        public IQueryable CreateQuery(Expression expression) {
            Type elementType = TypeSystem.GetElementType(expression.Type);
            try {
                return (IQueryable)Activator.CreateInstance(typeof(FastReverseConversation<>).MakeGenericType(elementType), new object[] { this.handl, this.conversation, this, expression });
            } catch (System.Reflection.TargetInvocationException tie) {
                throw tie.InnerException;
            }
        }

        public TResult Execute<TResult>(Expression expression) {
            throw new NotImplementedException();
        }

        public object Execute(Expression expression) {
            throw new NotImplementedException();
        }
    }
}
