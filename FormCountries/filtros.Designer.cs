namespace dbAmonic
{
    partial class filtros
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
            datamostrar = new DataGridView();
            btnchange = new Button();
            button2 = new Button();
            menuStrip1 = new MenuStrip();
            addUserToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            comboffice = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)datamostrar).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // datamostrar
            // 
            datamostrar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            datamostrar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datamostrar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datamostrar.Location = new Point(12, 84);
            datamostrar.Name = "datamostrar";
            datamostrar.RowHeadersWidth = 51;
            datamostrar.Size = new Size(776, 306);
            datamostrar.TabIndex = 0;
            // 
            // btnchange
            // 
            btnchange.Location = new Point(12, 409);
            btnchange.Name = "btnchange";
            btnchange.Size = new Size(94, 29);
            btnchange.TabIndex = 1;
            btnchange.Text = "Change";
            btnchange.UseVisualStyleBackColor = true;
            btnchange.Click += btnchange_Click;
            // 
            // button2
            // 
            button2.Location = new Point(133, 409);
            button2.Name = "button2";
            button2.Size = new Size(209, 29);
            button2.TabIndex = 2;
            button2.Text = "Enable/Disable Login";
            button2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { addUserToolStripMenuItem, exitToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // addUserToolStripMenuItem
            // 
            addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            addUserToolStripMenuItem.Size = new Size(84, 24);
            addUserToolStripMenuItem.Text = "Add User";
            addUserToolStripMenuItem.Click += addUserToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(47, 24);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 37);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 4;
            label1.Text = "Offices";
            // 
            // comboffice
            // 
            comboffice.FormattingEnabled = true;
            comboffice.Location = new Point(74, 34);
            comboffice.Name = "comboffice";
            comboffice.Size = new Size(151, 28);
            comboffice.TabIndex = 5;
            comboffice.SelectedIndexChanged += comboffice_SelectedIndexChanged;
            // 
            // filtros
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboffice);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(btnchange);
            Controls.Add(datamostrar);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "filtros";
            Text = "filtros";
            ((System.ComponentModel.ISupportInitialize)datamostrar).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView datamostrar;
        private Button btnchange;
        private Button button2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem addUserToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Label label1;
        private ComboBox comboffice;
    }
}