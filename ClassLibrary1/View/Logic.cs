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
        private int _lastIndex;
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

        //Callback from jsUI
        public void Conversation(int index, uint from = 0, short howMany = 10)
        {
            _controller.Conversation(index, from, howMany);
            _lastIndex = index;
        }

        public void Send(string to, string message)
        {
            _controller.Send(to, message);
        }

        public void Logout()
        {
            _controller.Logout();
        }

        // Interface implementation

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
            _browser.Document.InvokeScript("clearConversations");
        }

        public void ClearConversation()
        {
            _browser.Document.InvokeScript("clearConversation");
        }

        public void DisplayError(string error)
        {
            _browser.Document.InvokeScript("error", new Object[] { error });
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

        public int ConversationDisplayed()
        {
            return _lastIndex;
        }
    }
}
