namespace dbAmonic
{
    partial class AddUser
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtEmail = new TextBox();
            txtName = new TextBox();
            txtName2 = new TextBox();
            txtPassword = new TextBox();
            comboOfficeUser = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            dateTimePickerAge = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 25);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 0;
            label1.Text = "Email address";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 63);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 1;
            label2.Text = "First name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 109);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 2;
            label3.Text = "Last name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 158);
            label4.Name = "label4";
            label4.Size = new Size(90, 20);
            label4.TabIndex = 3;
            label4.Text = "Office name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 206);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 4;
            label5.Text = "Birthdate";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 253);
            label6.Name = "label6";
            label6.Size = new Size(70, 20);
            label6.TabIndex = 5;
            label6.Text = "Password";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(137, 22);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(409, 27);
            txtEmail.TabIndex = 6;
            // 
            // txtName
            // 
            txtName.Location = new Point(137, 61);
            txtName.Name = "txtName";
            txtName.Size = new Size(409, 27);
            txtName.TabIndex = 7;
            // 
            // txtName2
            // 
            txtName2.Location = new Point(137, 104);
            txtName2.Name = "txtName2";
            txtName2.Size = new Size(409, 27);
            txtName2.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(137, 250);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(409, 27);
            txtPassword.TabIndex = 11;
            // 
            // comboOfficeUser
            // 
            comboOfficeUser.FormattingEnabled = true;
            comboOfficeUser.Location = new Point(137, 155);
            comboOfficeUser.Name = "comboOfficeUser";
            comboOfficeUser.Size = new Size(409, 28);
            comboOfficeUser.TabIndex = 12;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(185, 348);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(369, 348);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerAge
            // 
            dateTimePickerAge.CustomFormat = "";
            dateTimePickerAge.Format = DateTimePickerFormat.Short;
            dateTimePickerAge.Location = new Point(137, 205);
            dateTimePickerAge.Name = "dateTimePickerAge";
            dateTimePickerAge.Size = new Size(409, 27);
            dateTimePickerAge.TabIndex = 15;
            dateTimePickerAge.ValueChanged += dateTimePickerAge_ValueChanged;
            // 
            // AddUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dateTimePickerAge);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(comboOfficeUser);
            Controls.Add(txtPassword);
            Controls.Add(txtName2);
            Controls.Add(txtName);
            Controls.Add(txtEmail);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddUser";
            Text = "AddUser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtEmail;
        private TextBox txtName;
        private TextBox txtName2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox txtPassword;
        private ComboBox comboOfficeUser;
        private Button btnSave;
        private Button btnCancel;
        private DateTimePicker dateTimePickerAge;
    }
}