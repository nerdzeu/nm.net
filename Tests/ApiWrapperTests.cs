using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nerdz;
using Nerdz.Messages;

namespace Tests.ApiWrapper {
    [TestClass]
    public class ApiWrapper {
        static private IMessenger messenger;
        static private System.Collections.Generic.List<IConversation> conversations;

        [TestMethod]
        public void TestNewMessenger() {
            ApiWrapper.messenger = Nerdz.Factory.newMessenger("user", "pass");
        }

        [TestMethod]
        public void TestFetchConversations() {
            ApiWrapper.conversations = ApiWrapper.messenger.Conversations();
        }

        [TestMethod]
        public void TestDumpConversations() {
            foreach (var conv in ApiWrapper.conversations) {
                System.Console.WriteLine(conv);
                foreach (var msg in conv.Messages()) {
                    System.Console.WriteLine(msg);
                }
                System.Console.WriteLine();
            }
        }

        [TestMethod]
        public void TestDumpAgain() {
            this.TestDumpConversations();
        }

        [TestMethod]
        [ExpectedException(typeof(LoginException))]
        public void TestFailedLogin() {
            Nerdz.Factory.newMessenger("idonotexist", "invalid");
        }
    }
}
