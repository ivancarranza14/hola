namespace dbAmonic
{
    partial class change_roles
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
            txtemail = new TextBox();
            txtfirstname = new TextBox();
            txtlastname = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            radioadmin = new RadioButton();
            radiouser = new RadioButton();
            combooffice = new ComboBox();
            btnapply = new Button();
            btncancel = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // txtemail
            // 
            txtemail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtemail.Location = new Point(325, 37);
            txtemail.Name = "txtemail";
            txtemail.Size = new Size(231, 27);
            txtemail.TabIndex = 0;
            // 
            // txtfirstname
            // 
            txtfirstname.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtfirstname.Location = new Point(325, 92);
            txtfirstname.Name = "txtfirstname";
            txtfirstname.Size = new Size(231, 27);
            txtfirstname.TabIndex = 1;
            // 
            // txtlastname
            // 
            txtlastname.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtlastname.Location = new Point(325, 148);
            txtlastname.Name = "txtlastname";
            txtlastname.Size = new Size(231, 27);
            txtlastname.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(222, 45);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 4;
            label1.Text = "Email Adress";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(222, 104);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 5;
            label2.Text = "First Name";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(222, 160);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 6;
            label3.Text = "Last Name";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(236, 214);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 7;
            label4.Text = "Office";
            // 
            // radioadmin
            // 
            radioadmin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            radioadmin.AutoSize = true;
            radioadmin.Location = new Point(435, 276);
            radioadmin.Name = "radioadmin";
            radioadmin.Size = new Size(121, 24);
            radioadmin.TabIndex = 8;
            radioadmin.TabStop = true;
            radioadmin.Text = "Administrator";
            radioadmin.UseVisualStyleBackColor = true;
            // 
            // radiouser
            // 
            radiouser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            radiouser.AutoSize = true;
            radiouser.Location = new Point(328, 276);
            radiouser.Name = "radiouser";
            radiouser.Size = new Size(59, 24);
            radiouser.TabIndex = 9;
            radiouser.TabStop = true;
            radiouser.Text = "User";
            radiouser.UseVisualStyleBackColor = true;
            // 
            // combooffice
            // 
            combooffice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            combooffice.FormattingEnabled = true;
            combooffice.Location = new Point(325, 206);
            combooffice.Name = "combooffice";
            combooffice.Size = new Size(231, 28);
            combooffice.TabIndex = 10;
            // 
            // btnapply
            // 
            btnapply.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnapply.Location = new Point(270, 358);
            btnapply.Name = "btnapply";
            btnapply.Size = new Size(94, 29);
            btnapply.TabIndex = 11;
            btnapply.Text = "Apply";
            btnapply.UseVisualStyleBackColor = true;
            btnapply.Click += btnapply_Click;
            // 
            // btncancel
            // 
            btncancel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btncancel.Location = new Point(403, 358);
            btncancel.Name = "btncancel";
            btncancel.Size = new Size(94, 29);
            btncancel.TabIndex = 12;
            btncancel.Text = "Cancel";
            btncancel.UseVisualStyleBackColor = true;
            btncancel.Click += btncancel_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(243, 277);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 13;
            label5.Text = "Role";
            // 
            // change_roles
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(btncancel);
            Controls.Add(btnapply);
            Controls.Add(combooffice);
            Controls.Add(radiouser);
            Controls.Add(radioadmin);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtlastname);
            Controls.Add(txtfirstname);
            Controls.Add(txtemail);
            Name = "change_roles";
            Text = "change_roles";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtemail;
        private TextBox txtfirstname;
        private TextBox txtlastname;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private RadioButton radioadmin;
        private RadioButton radiouser;
        private ComboBox combooffice;
        private Button btnapply;
        private Button btncancel;
        private Label label5;
    }
}