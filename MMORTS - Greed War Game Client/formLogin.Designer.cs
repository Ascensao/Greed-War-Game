namespace MMORTS___Greed_War_Game_Client
{
    partial class formLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLogin));
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBarLogin = new System.Windows.Forms.ProgressBar();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblLostAccount = new System.Windows.Forms.LinkLabel();
            this.lblNewAccount = new System.Windows.Forms.LinkLabel();
            this.lblQuest2 = new System.Windows.Forms.Label();
            this.lblQuest1 = new System.Windows.Forms.Label();
            this.checkBoxRemember = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.picBoxLogo = new System.Windows.Forms.PictureBox();
            this.btnFacebook = new System.Windows.Forms.Button();
            this.btnTwitter = new System.Windows.Forms.Button();
            this.btnYoutube = new System.Windows.Forms.Button();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.groupBoxLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxLogin.Controls.Add(this.lblProgress);
            this.groupBoxLogin.Controls.Add(this.progressBarLogin);
            this.groupBoxLogin.Controls.Add(this.btnLogin);
            this.groupBoxLogin.Controls.Add(this.lblLostAccount);
            this.groupBoxLogin.Controls.Add(this.lblNewAccount);
            this.groupBoxLogin.Controls.Add(this.lblQuest2);
            this.groupBoxLogin.Controls.Add(this.lblQuest1);
            this.groupBoxLogin.Controls.Add(this.checkBoxRemember);
            this.groupBoxLogin.Controls.Add(this.txtPassword);
            this.groupBoxLogin.Controls.Add(this.txtUsername);
            this.groupBoxLogin.Controls.Add(this.lblPassword);
            this.groupBoxLogin.Controls.Add(this.lblUsername);
            this.groupBoxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxLogin.ForeColor = System.Drawing.Color.White;
            this.groupBoxLogin.Location = new System.Drawing.Point(12, 20);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(290, 293);
            this.groupBoxLogin.TabIndex = 4;
            this.groupBoxLogin.TabStop = false;
            this.groupBoxLogin.Text = "Account Login";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(27, 194);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 11;
            // 
            // progressBarLogin
            // 
            this.progressBarLogin.Location = new System.Drawing.Point(24, 168);
            this.progressBarLogin.Name = "progressBarLogin";
            this.progressBarLogin.Size = new System.Drawing.Size(230, 23);
            this.progressBarLogin.TabIndex = 10;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLogin.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(168, 119);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(89, 29);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblLostAccount
            // 
            this.lblLostAccount.AutoSize = true;
            this.lblLostAccount.CausesValidation = false;
            this.lblLostAccount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLostAccount.ForeColor = System.Drawing.Color.White;
            this.lblLostAccount.LinkColor = System.Drawing.Color.White;
            this.lblLostAccount.Location = new System.Drawing.Point(139, 251);
            this.lblLostAccount.Name = "lblLostAccount";
            this.lblLostAccount.Size = new System.Drawing.Size(120, 13);
            this.lblLostAccount.TabIndex = 8;
            this.lblLostAccount.TabStop = true;
            this.lblLostAccount.Text = "Enter your email!";
            this.lblLostAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLostAccount_LinkClicked);
            // 
            // lblNewAccount
            // 
            this.lblNewAccount.AutoSize = true;
            this.lblNewAccount.CausesValidation = false;
            this.lblNewAccount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAccount.ForeColor = System.Drawing.Color.White;
            this.lblNewAccount.LinkColor = System.Drawing.Color.White;
            this.lblNewAccount.Location = new System.Drawing.Point(165, 216);
            this.lblNewAccount.Name = "lblNewAccount";
            this.lblNewAccount.Size = new System.Drawing.Size(89, 13);
            this.lblNewAccount.TabIndex = 7;
            this.lblNewAccount.TabStop = true;
            this.lblNewAccount.Text = "Sign up now!";
            this.lblNewAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNewAccount_LinkClicked);
            // 
            // lblQuest2
            // 
            this.lblQuest2.AutoSize = true;
            this.lblQuest2.CausesValidation = false;
            this.lblQuest2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuest2.ForeColor = System.Drawing.Color.White;
            this.lblQuest2.Location = new System.Drawing.Point(21, 251);
            this.lblQuest2.Name = "lblQuest2";
            this.lblQuest2.Size = new System.Drawing.Size(122, 13);
            this.lblQuest2.TabIndex = 6;
            this.lblQuest2.Text = "Forgot you account?";
            // 
            // lblQuest1
            // 
            this.lblQuest1.AutoSize = true;
            this.lblQuest1.CausesValidation = false;
            this.lblQuest1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuest1.ForeColor = System.Drawing.Color.White;
            this.lblQuest1.Location = new System.Drawing.Point(21, 216);
            this.lblQuest1.Name = "lblQuest1";
            this.lblQuest1.Size = new System.Drawing.Size(141, 13);
            this.lblQuest1.TabIndex = 5;
            this.lblQuest1.Text = "Don\'t have an account?";
            // 
            // checkBoxRemember
            // 
            this.checkBoxRemember.AutoSize = true;
            this.checkBoxRemember.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRemember.ForeColor = System.Drawing.Color.White;
            this.checkBoxRemember.Location = new System.Drawing.Point(24, 124);
            this.checkBoxRemember.Name = "checkBoxRemember";
            this.checkBoxRemember.Size = new System.Drawing.Size(138, 17);
            this.checkBoxRemember.TabIndex = 4;
            this.checkBoxRemember.Text = "Remember Account";
            this.checkBoxRemember.UseVisualStyleBackColor = true;
            this.checkBoxRemember.CheckedChanged += new System.EventHandler(this.checkBoxRemember_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(24, 96);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(233, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(24, 48);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(233, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(21, 77);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(70, 16);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(21, 29);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(72, 16);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // picBoxLogo
            // 
            this.picBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.picBoxLogo.Image = global::MMORTS___Greed_War_Game_Client.Properties.Resources.logoLogin;
            this.picBoxLogo.Location = new System.Drawing.Point(316, 83);
            this.picBoxLogo.Name = "picBoxLogo";
            this.picBoxLogo.Size = new System.Drawing.Size(250, 144);
            this.picBoxLogo.TabIndex = 5;
            this.picBoxLogo.TabStop = false;
            this.picBoxLogo.Click += new System.EventHandler(this.picBoxLogo_Click);
            // 
            // btnFacebook
            // 
            this.btnFacebook.BackColor = System.Drawing.Color.Transparent;
            this.btnFacebook.BackgroundImage = global::MMORTS___Greed_War_Game_Client.Properties.Resources.facebook;
            this.btnFacebook.Location = new System.Drawing.Point(369, 20);
            this.btnFacebook.Name = "btnFacebook";
            this.btnFacebook.Size = new System.Drawing.Size(48, 48);
            this.btnFacebook.TabIndex = 7;
            this.btnFacebook.UseVisualStyleBackColor = false;
            this.btnFacebook.Click += new System.EventHandler(this.btnFacebook_Click);
            // 
            // btnTwitter
            // 
            this.btnTwitter.BackColor = System.Drawing.Color.Transparent;
            this.btnTwitter.BackgroundImage = global::MMORTS___Greed_War_Game_Client.Properties.Resources.twitter;
            this.btnTwitter.Location = new System.Drawing.Point(420, 20);
            this.btnTwitter.Name = "btnTwitter";
            this.btnTwitter.Size = new System.Drawing.Size(48, 48);
            this.btnTwitter.TabIndex = 8;
            this.btnTwitter.UseVisualStyleBackColor = false;
            this.btnTwitter.Click += new System.EventHandler(this.btnTwitter_Click);
            // 
            // btnYoutube
            // 
            this.btnYoutube.BackColor = System.Drawing.Color.Transparent;
            this.btnYoutube.BackgroundImage = global::MMORTS___Greed_War_Game_Client.Properties.Resources.youtube;
            this.btnYoutube.Location = new System.Drawing.Point(470, 20);
            this.btnYoutube.Name = "btnYoutube";
            this.btnYoutube.Size = new System.Drawing.Size(48, 48);
            this.btnYoutube.TabIndex = 9;
            this.btnYoutube.UseVisualStyleBackColor = false;
            this.btnYoutube.Click += new System.EventHandler(this.btnYoutube_Click);
            // 
            // btnStartGame
            // 
            this.btnStartGame.Enabled = false;
            this.btnStartGame.Location = new System.Drawing.Point(316, 282);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(250, 31);
            this.btnStartGame.TabIndex = 10;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // formLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MMORTS___Greed_War_Game_Client.Properties.Resources.bgLogin;
            this.ClientSize = new System.Drawing.Size(597, 367);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.btnYoutube);
            this.Controls.Add(this.btnTwitter);
            this.Controls.Add(this.btnFacebook);
            this.Controls.Add(this.picBoxLogo);
            this.Controls.Add(this.groupBoxLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formLogin";
            this.Text = "Greed War Game Online";
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel lblLostAccount;
        private System.Windows.Forms.LinkLabel lblNewAccount;
        private System.Windows.Forms.Label lblQuest2;
        private System.Windows.Forms.Label lblQuest1;
        private System.Windows.Forms.CheckBox checkBoxRemember;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.PictureBox picBoxLogo;
        private System.Windows.Forms.ProgressBar progressBarLogin;
        private System.Windows.Forms.Button btnFacebook;
        private System.Windows.Forms.Button btnTwitter;
        private System.Windows.Forms.Button btnYoutube;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Label lblProgress;
    }
}

