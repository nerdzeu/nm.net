namespace Nerdz.Messenger.View {
    partial class NerdzMessenger {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NerdzMessenger));
            this.loginPanel = new System.Windows.Forms.Panel();
            this.loginButton = new System.Windows.Forms.Button();
            this.nerdzLabel = new System.Windows.Forms.Label();
            this.registerLink = new System.Windows.Forms.LinkLabel();
            this.username = new Nerdz.Messenger.View.WaterMarkTextBox();
            this.password = new Nerdz.Messenger.View.WaterMarkTextBox();
            this.loginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginPanel
            // 
            this.loginPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginPanel.Controls.Add(this.registerLink);
            this.loginPanel.Controls.Add(this.username);
            this.loginPanel.Controls.Add(this.password);
            this.loginPanel.Controls.Add(this.loginButton);
            this.loginPanel.Controls.Add(this.nerdzLabel);
            this.loginPanel.Location = new System.Drawing.Point(0, 0);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(422, 275);
            this.loginPanel.TabIndex = 0;
            // 
            // loginButton
            // 
            this.loginButton.Enabled = false;
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Location = new System.Drawing.Point(253, 190);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(51, 27);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // nerdzLabel
            // 
            this.nerdzLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nerdzLabel.AutoSize = true;
            this.nerdzLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nerdzLabel.Location = new System.Drawing.Point(116, 22);
            this.nerdzLabel.Name = "nerdzLabel";
            this.nerdzLabel.Size = new System.Drawing.Size(195, 55);
            this.nerdzLabel.TabIndex = 0;
            this.nerdzLabel.Text = "NERDZ";
            this.nerdzLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // registerLink
            // 
            this.registerLink.AutoSize = true;
            this.registerLink.Location = new System.Drawing.Point(123, 236);
            this.registerLink.Name = "registerLink";
            this.registerLink.Size = new System.Drawing.Size(46, 13);
            this.registerLink.TabIndex = 30;
            this.registerLink.TabStop = true;
            this.registerLink.Text = "Register";
            this.registerLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registerLink_LinkClicked);
            // 
            // username
            // 
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.username.Location = new System.Drawing.Point(126, 119);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(178, 20);
            this.username.TabIndex = 1;
            this.username.WaterMarkColor = System.Drawing.Color.Gray;
            this.username.WaterMarkText = "Username";
            this.username.TextChanged += new System.EventHandler(this.username_TextChanged);
            this.username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.username_KeyPress);
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.password.Location = new System.Drawing.Point(126, 155);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(178, 20);
            this.password.TabIndex = 2;
            this.password.UseSystemPasswordChar = true;
            this.password.WaterMarkColor = System.Drawing.Color.Gray;
            this.password.WaterMarkText = "Password";
            this.password.TextChanged += new System.EventHandler(this.username_TextChanged);
            this.password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.password_KeyPress);
            // 
            // NerdzMessenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 414);
            this.Controls.Add(this.loginPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NerdzMessenger";
            this.Text = "MainView";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Label nerdzLabel;
        private System.Windows.Forms.Button loginButton;
        private Messenger.View.WaterMarkTextBox username;
        private Messenger.View.WaterMarkTextBox password;
        private System.Windows.Forms.LinkLabel registerLink;
    }
}