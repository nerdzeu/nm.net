using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nerdz;
using Nerdz.Messages;

namespace Tests {
    [TestClass]
    public class UnitTest1 {
        static private IMessenger messenger;
        static private System.Collections.Generic.List<IConversation> conversations;

        [TestMethod]
        public void TestNewMessenger() {
            UnitTest1.messenger = Nerdz.Nerdz.newMessenger("user", "pass");
        }

        [TestMethod]
        public void TestFetchConversations() {
            UnitTest1.conversations = UnitTest1.messenger.Conversations();
        }

        [TestMethod]
        public void TestDumpConversations() {
            foreach (var conv in UnitTest1.conversations) {
                System.Console.WriteLine(conv);
                foreach (var msg in conv) {
                    System.Console.WriteLine(msg);
                }
                System.Console.WriteLine();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(LoginException))]
        public void TestFailedLogin() {
            Nerdz.Nerdz.newMessenger("idonotexist", "invalid");
        }
    }
}
