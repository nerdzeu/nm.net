using Nerdz.Messages;
using Nerdz.Messages.Impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Nerdz
{
    public class Factory
    {
        public static readonly string SERVER_URL = eu.nerdz.api.impl.reverse.AbstractReverseApplication.NERDZ_DOMAIN_NAME;

        public static IMessenger NewMessenger(string uName, string pass)
        {
            return new FastReverseMessenger(uName, pass);
        }

        internal static void ExceptionWrapper(java.lang.Throwable t)
        {
            string message = t.getLocalizedMessage();

            if (t is eu.nerdz.api.BadStatusException)
            {
                throw new BadStatusException(message);
            }

            if (t is eu.nerdz.api.ContentException)
            {
                throw new ContentException("Wrong server response.\nPlease try again later");
            }

            if (t is eu.nerdz.api.HttpException)
            {
                throw new HttpException(message);
            }

            if (t is java.io.IOException)
            {
                throw new IOException(message);
            }

            if (t is eu.nerdz.api.LoginException)
            {
                throw new LoginException(message);
            }

            if (t is eu.nerdz.api.UserNotFoundException)
            {
                throw new UserNotFoundException(message);
            }

            throw new JavaException(message);
        }
    }
}
