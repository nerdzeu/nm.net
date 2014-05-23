using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nerdz.Messages;
using System.IO;
using System.Net;


namespace Nerdz.Controller
{
    public class MessengerController : IMessengerController
    {
        private IMessengerView _view;
        private IMessenger _messenger;
        private List<IConversation> _conversations;

        // Handle exception events. Send to the view the correct instructions and throw the right exception.
        private void WrapException(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            if (e is ContentException || e is JavaException || e is HttpException)
            {
                _view.DisplayCriticalError(e.Message);
                throw new CriticalException(e.Message);
            }
            _view.DisplayError(e.Message);
            //throw e;
        }

        public MessengerController(IMessengerView view, Credentials credentials)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(WrapException);

            _view = view;
            _view.Controller = this;
            _messenger = Nerdz.Factory.newMessenger(credentials.Username, credentials.Password);
            _conversations = _messenger.Conversations();
        }

        /// <exception cref="CriticalException"></exception>
        /// <exception cref="IOException"></exception>
        public void Conversations()
        {
            _conversations = _messenger.Conversations();
            _view.ClearConversations();
            _view.UpdateConversations(_conversations);
        }

        /// <exception cref="CriticalException"></exception>
        /// <exception cref="IOException"></exception>
        public void Conversation(int index, uint from = 0, short howMany = 10)
        {
            IConversation conversation = null;
            try
            {
                conversation = _conversations[index];
            }
            catch (Exception)
            {
                throw new CriticalException("Invalid conversation index");
            }

            if (from == 0)
            {
                _view.ClearConversation();
            }
            _view.UpdateMessages(conversation.Messages(from, howMany));
        }

        /// <exception cref="CriticalException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="BadStatusException"></exception>
        /// <exception cref="UserNotFoundException"></exception>
        public void Send(String to, String message)
        {
            _messenger.Send(to, message);
        }

        public void Logout()
        {
            // destroy messenger
            _messenger = null;
            // show login page
            _view.ShowLogin();
            // detach controller from view (it will be reattached at the next login)
            _view.Controller = null;
        }

    }
}
