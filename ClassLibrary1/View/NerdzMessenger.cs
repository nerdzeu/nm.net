using Nerdz.Messenger.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nerdz.Messenger.View
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class NerdzMessenger : Form
    {

        private WebBrowser _browser;

        public NerdzMessenger()
        {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            loginPanel.Location = new Point(
                this.ClientSize.Width / 2 - loginPanel.Size.Width / 2,
                this.ClientSize.Height / 2 - loginPanel.Size.Height / 2
                );
        }

        private void DoLogin()
        {
            _credentials = new Credentials(username.Text, password.Text);
            _invalid = false;
            string buttText = loginButton.Text;

            loginButton.Enabled = username.Enabled = password.Enabled = false;
            loginButton.Text = "Wait...";

            try
            {
                _controller = new MessengerController(this, _credentials);

                if (!_invalid)
                {
                    this.loginPanel.Visible = false;
                    _browser = new WebBrowser();
                    _browser.Dock = DockStyle.Fill;
                    this.Controls.Add(_browser);
                    _browser.AllowWebBrowserDrop = false;
                    _browser.IsWebBrowserContextMenuEnabled = false;
                    _browser.WebBrowserShortcutsEnabled = false;
                    _browser.ObjectForScripting = this;
                    string curDir = Directory.GetCurrentDirectory();
                    _browser.DocumentText = Properties.Resources.app;
                    _browser.DocumentCompleted += WebBrowserCompleted;
                }
            }
            catch (LoginException)
            {
                MessageBox.Show(
                    "Wrong username or password",
                    "Login failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );


            }
            finally
            {
                username.Text = password.Text = String.Empty;
                username.Focus();
                username.Enabled = password.Enabled = true;
                loginButton.Text = buttText;
            }

        }

        private void WebBrowserCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            _browser.Document.InvokeScript("setUsername", new Object[] { _credentials.Username });
            _controller.Conversations();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.DoLogin();
        }

        private void checkButton()
        {
            loginButton.Enabled = username.TextLength > 0 && password.TextLength > 0;
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            this.checkButton();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            this.checkButton();
        }

        private void registerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Factory.SERVER_URL);
        }

        private void username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && loginButton.Enabled)
            {
                this.DoLogin();
            }
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && loginButton.Enabled)
            {
                this.DoLogin();
            }
        }
    }
}
