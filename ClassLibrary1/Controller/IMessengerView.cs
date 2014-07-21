using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nerdz.Messages;

namespace Nerdz.Messenger.Controller
{
    public interface IMessengerView
    {
        // Set controller
        IMessengerController Controller { set; get; }

        // Update/Create/Show methods
        void UpdateConversations(List<IConversation> conversations);
        void UpdateMessages(List<IMessage> messages);
        void ShowLogin();

        // Clear methods
        void ClearConversations();
        void ClearConversation();

        // Display errors
        void DisplayError(String error);
        void DisplayCriticalError(String error);
    }
}
