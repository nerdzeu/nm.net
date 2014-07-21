using Nerdz.Messenger.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nerdz.Messenger.View {
    public partial class NerdzMessenger : Form {
        private IMessengerController _controller;

        public NerdzMessenger() {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e) {
            loginPanel.Location = new Point(
                this.ClientSize.Width / 2 - loginPanel.Size.Width / 2,
                this.ClientSize.Height / 2 -loginPanel.Size.Height / 2
                );
        }

        private void loginButton_Click(object sender, EventArgs e) {
            var credentials = new Credentials(username.Text, password.Text);

            try 
            {
                _controller = new MessengerController(this, credentials);
            } 
            catch (LoginException) 
            {
                MessageBox.Show(
                    "Wrong username or password", 
                    "Login failed", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );

                username.Text = password.Text = String.Empty;
            }
        }

        private void checkButton() {
            loginButton.Enabled = username.TextLength > 0 && password.TextLength > 0;
        }

        private void username_TextChanged(object sender, EventArgs e) {
            this.checkButton();
        }

        private void password_TextChanged(object sender, EventArgs e) {
            this.checkButton();
        }

        private void registerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) 
        {
            System.Diagnostics.Process.Start(Factory.SERVER_URL);
        }
    }
}
