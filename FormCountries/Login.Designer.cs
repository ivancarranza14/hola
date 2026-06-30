namespace FormCountries
{
    partial class Login
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            icono = new PictureBox();
            txtUser = new TextBox();
            lblUsername = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            btnLogin = new Button();
            btnExit = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            lblTiempo = new Label();
            ((System.ComponentModel.ISupportInitialize)icono).BeginInit();
            SuspendLayout();
            // 
            // icono
            // 
            icono.BackColor = Color.Transparent;
            icono.Image = (Image)resources.GetObject("icono.Image");
            icono.Location = new Point(97, 12);
            icono.Name = "icono";
            icono.Size = new Size(620, 176);
            icono.TabIndex = 0;
            icono.TabStop = false;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(165, 239);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(534, 27);
            txtUser.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(87, 243);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(78, 20);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(165, 296);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(534, 27);
            txtPassword.TabIndex = 3;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(87, 300);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password:";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(247, 379);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(133, 29);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(451, 379);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(133, 29);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Location = new Point(19, 386);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(0, 20);
            lblTiempo.TabIndex = 7;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTiempo);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblUsername);
            Controls.Add(txtUser);
            Controls.Add(icono);
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)icono).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox icono;
        private TextBox txtUser;
        private Label lblUsername;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnLogin;
        private Button btnExit;
        private System.Windows.Forms.Timer timer1;
        private Label lblTiempo;
    }
}