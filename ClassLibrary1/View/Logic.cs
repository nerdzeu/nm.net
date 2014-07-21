using Nerdz.Messenger.Controller;
using Nerdz.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace Nerdz.Messenger.View
{
    public partial class NerdzMessenger : IMessengerView
    {
        private Credentials _credentials;
        private bool _invalid;

        private IMessengerController _controller;
        public IMessengerController Controller
        {
            set
            {
                _controller = value;
            }
            get
            {
                return _controller;
            }
        }

        public void Conversation(int index, uint from = 0, short howMany = 10)
        {
            _controller.Conversation(index, from, howMany);
        }


        public void UpdateConversations(List<Nerdz.Messages.IConversation> conversations)
        {
            var jsonConversations = new JavaScriptSerializer().Serialize(conversations);
            _browser.Document.InvokeScript("updateConversations", new object[] { jsonConversations });
        }

        public void UpdateMessages(System.Collections.Generic.List<Nerdz.Messages.IMessage> messages)
        {
            var jsonMessages = new JavaScriptSerializer().Serialize(messages);
            _browser.Document.InvokeScript("updateMessages", new object[] { jsonMessages });
        }

        public void ShowLogin()
        {
            _browser.Visible = false;
            loginPanel.Visible = true;
            this.Controls.Remove(_browser);
            _browser = null;
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
