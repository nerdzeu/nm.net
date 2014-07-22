using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nerdz.Messenger.Controller;
using Nerdz.Messages;
using Nerdz;

namespace Tests.Controller
{
    public class DummyUI : IMessengerView
    {
        private Credentials credentials;

        private IMessengerController controller;
        public IMessengerController Controller
        {
            set
            {
                controller = value;
            }
            get
            {
                return controller;
            }
        }

        public void UpdateConversations(System.Collections.Generic.List<Nerdz.Messages.IConversation> conversations)
        {
            Console.WriteLine("Conversations: ");
            foreach (IConversation c in conversations)
            {
                Console.WriteLine(c);
            }
        }

        public void UpdateMessages(System.Collections.Generic.List<Nerdz.Messages.IMessage> messages)
        {
            Console.WriteLine("Messages: ");
            foreach (IMessage m in messages)
            {
                Console.WriteLine(m);
            }
        }

        public void ShowLogin()
        {
            Console.WriteLine("Username: ");
            string username = "new user input from textbox";
            Console.WriteLine("Password: ");
            string password = "password input from textbox";
            credentials = new Credentials(username, password);
        }

        public void ClearConversations()
        {
            Console.WriteLine("\n\n\nConversations list cleaned\n\n");
        }

        public void ClearConversation()
        {
            Console.WriteLine("\n\nConversation cleaned\n\n");
        }

        public void DisplayError(string error)
        {
            Console.Error.WriteLine("[!] " + error);
        }

        public void DisplayCriticalError(string error)
        {
            Console.Error.WriteLine("CRITICAL: " + error);
        }

        public int ConversationDisplayed()
        {
            return 0;
        }
    }


    [TestClass]
    public class MessengerControllerTests
    {
        static private IMessengerView view;
        static private IMessengerController controller;

        [TestMethod]
        public void NewController()
        {
            Credentials c = new Credentials(0, "wrongpass");
            view = new DummyUI();
            try
            {
                controller = new MessengerController(view, c);
            }
            catch (LoginException)
            {
                Console.WriteLine("Wrong username and password (OK!)");
            }

            c = new Credentials("admin", "adminadmin");

            controller = new MessengerController(view, c);

        }

        [TestMethod]
        public void TestGetConversations()
        {
            controller.Conversations();
        }

        [TestMethod]
        public void TestGetConversationOK()
        {
            controller.Conversation(0); // exists, no exception expected
        }

        [ExpectedException(typeof(CriticalException))]
        [TestMethod]
        public void TestGetConversationFAIL()
        {
            controller.Conversation(110);
        }

        [TestMethod]
        public void TestSendOK()
        {
            controller.Send("Gaben", "great app :>");
            // user nessuno exists, no exception expected
        }

        [ExpectedException(typeof(BadStatusException))]
        [TestMethod]
        public void TestSendFAIL()
        {
            controller.Send("94949494", "great app :>");
            // numeric username can't exists, so this test shoudl fail
        }

        [TestMethod]
        public void TestLogout()
        {
            controller.Logout();
        }
    }
}
