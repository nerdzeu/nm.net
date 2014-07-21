using Nerdz.Messenger.Controller;
using Nerdz.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nerdz.Messenger.View {
     public partial class NerdzMessenger : IMessengerView {
        private Credentials _credentials;
        private bool _invalid;

        private IMessengerController _controller;
        public IMessengerController Controller {
            set {
                _controller = value;
            }
            get {
                return _controller;
            }
        }

        public void UpdateConversations(List<Nerdz.Messages.IConversation> conversations) {
            Console.WriteLine("Conversations: ");
            foreach (IConversation c in conversations) {
                Console.WriteLine(c);
            }
        }

        public void UpdateMessages(System.Collections.Generic.List<Nerdz.Messages.IMessage> messages) {
            Console.WriteLine("Messages: ");
            foreach (IMessage m in messages) {
                Console.WriteLine(m);
            }
        }

        public void ShowLogin() {
            Console.WriteLine("Username: ");
            string username = "new user input from textbox";
            Console.WriteLine("Password: ");
            string password = "password input from textbox";
            _credentials = new Credentials(username, password);
        }

        public void ClearConversations() {
            Console.WriteLine("\n\n\nConversations list cleaned\n\n");
        }

        public void ClearConversation() {
            Console.WriteLine("\n\nConversation cleaned\n\n");
        }

        public void DisplayError(string error) {
            Console.Error.WriteLine("[!] " + error);
        }

        public void DisplayCriticalError(string error) {
            MessageBox.Show(
                    error,
                    "Critical error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            _invalid = true;
        }
    }
}
