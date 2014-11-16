namespace DataLoader
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.tabletextBox = new System.Windows.Forms.TextBox();
            this.buttonInvertSelection = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonDeselectAll = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.filelistView = new System.Windows.Forms.ListView();
            this.buttonOpenDir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DirectoryNameTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBoxDomainAuth = new System.Windows.Forms.CheckBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxBase = new System.Windows.Forms.TextBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(593, 349);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tabletextBox);
            this.tabPage1.Controls.Add(this.buttonInvertSelection);
            this.tabPage1.Controls.Add(this.buttonDeselectAll);
            this.tabPage1.Controls.Add(this.buttonSelectAll);
            this.tabPage1.Controls.Add(this.filelistView);
            this.tabPage1.Controls.Add(this.buttonOpenDir);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.DirectoryNameTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(585, 323);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Источник данных";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Таблица для загрузки";
            // 
            // tabletextBox
            // 
            this.tabletextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabletextBox.Location = new System.Drawing.Point(131, 37);
            this.tabletextBox.Name = "tabletextBox";
            this.tabletextBox.Size = new System.Drawing.Size(419, 20);
            this.tabletextBox.TabIndex = 10;
            // 
            // buttonInvertSelection
            // 
            this.buttonInvertSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInvertSelection.ImageIndex = 4;
            this.buttonInvertSelection.ImageList = this.imageList1;
            this.buttonInvertSelection.Location = new System.Drawing.Point(556, 121);
            this.buttonInvertSelection.Name = "buttonInvertSelection";
            this.buttonInvertSelection.Size = new System.Drawing.Size(23, 23);
            this.buttonInvertSelection.TabIndex = 9;
            this.buttonInvertSelection.UseVisualStyleBackColor = true;
            this.buttonInvertSelection.Click += new System.EventHandler(this.buttonInvertSelection_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "open_dir.png");
            this.imageList1.Images.SetKeyName(1, "upload.png");
            this.imageList1.Images.SetKeyName(2, "select_all.png");
            this.imageList1.Images.SetKeyName(3, "deselect_all.png");
            this.imageList1.Images.SetKeyName(4, "invert_selection.png");
            // 
            // buttonDeselectAll
            // 
            this.buttonDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeselectAll.ImageIndex = 3;
            this.buttonDeselectAll.ImageList = this.imageList1;
            this.buttonDeselectAll.Location = new System.Drawing.Point(556, 92);
            this.buttonDeselectAll.Name = "buttonDeselectAll";
            this.buttonDeselectAll.Size = new System.Drawing.Size(23, 23);
            this.buttonDeselectAll.TabIndex = 8;
            this.buttonDeselectAll.UseVisualStyleBackColor = true;
            this.buttonDeselectAll.Click += new System.EventHandler(this.buttonDeselectAll_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectAll.BackColor = System.Drawing.Color.Transparent;
            this.buttonSelectAll.ImageIndex = 2;
            this.buttonSelectAll.ImageList = this.imageList1;
            this.buttonSelectAll.Location = new System.Drawing.Point(556, 63);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(23, 23);
            this.buttonSelectAll.TabIndex = 7;
            this.buttonSelectAll.UseVisualStyleBackColor = false;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // filelistView
            // 
            this.filelistView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filelistView.CheckBoxes = true;
            this.filelistView.Location = new System.Drawing.Point(9, 63);
            this.filelistView.Name = "filelistView";
            this.filelistView.Size = new System.Drawing.Size(541, 252);
            this.filelistView.TabIndex = 6;
            this.filelistView.UseCompatibleStateImageBehavior = false;
            this.filelistView.View = System.Windows.Forms.View.List;
            // 
            // buttonOpenDir
            // 
            this.buttonOpenDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenDir.ImageIndex = 0;
            this.buttonOpenDir.ImageList = this.imageList1;
            this.buttonOpenDir.Location = new System.Drawing.Point(556, 9);
            this.buttonOpenDir.Name = "buttonOpenDir";
            this.buttonOpenDir.Size = new System.Drawing.Size(23, 23);
            this.buttonOpenDir.TabIndex = 5;
            this.buttonOpenDir.UseVisualStyleBackColor = true;
            this.buttonOpenDir.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Каталог с данными";
            // 
            // DirectoryNameTextBox
            // 
            this.DirectoryNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DirectoryNameTextBox.Enabled = false;
            this.DirectoryNameTextBox.Location = new System.Drawing.Point(131, 11);
            this.DirectoryNameTextBox.Name = "DirectoryNameTextBox";
            this.DirectoryNameTextBox.Size = new System.Drawing.Size(419, 20);
            this.DirectoryNameTextBox.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBoxDomainAuth);
            this.tabPage2.Controls.Add(this.buttonConnect);
            this.tabPage2.Controls.Add(this.textBoxPassword);
            this.tabPage2.Controls.Add(this.textBoxUser);
            this.tabPage2.Controls.Add(this.textBoxBase);
            this.tabPage2.Controls.Add(this.textBoxServer);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(585, 323);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Параметры подключения";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBoxDomainAuth
            // 
            this.checkBoxDomainAuth.AutoSize = true;
            this.checkBoxDomainAuth.Location = new System.Drawing.Point(414, 58);
            this.checkBoxDomainAuth.Name = "checkBoxDomainAuth";
            this.checkBoxDomainAuth.Size = new System.Drawing.Size(147, 17);
            this.checkBoxDomainAuth.TabIndex = 9;
            this.checkBoxDomainAuth.Text = "Доменная авторизация";
            this.checkBoxDomainAuth.UseVisualStyleBackColor = true;
            this.checkBoxDomainAuth.CheckedChanged += new System.EventHandler(this.checkBoxDomainAuth_CheckedChanged);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(96, 106);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(79, 23);
            this.buttonConnect.TabIndex = 8;
            this.buttonConnect.Text = "Подключить";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Location = new System.Drawing.Point(96, 80);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(307, 20);
            this.textBoxPassword.TabIndex = 7;
            // 
            // textBoxUser
            // 
            this.textBoxUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUser.Location = new System.Drawing.Point(96, 56);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(307, 20);
            this.textBoxUser.TabIndex = 6;
            // 
            // textBoxBase
            // 
            this.textBoxBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBase.Location = new System.Drawing.Point(96, 32);
            this.textBoxBase.Name = "textBoxBase";
            this.textBoxBase.Size = new System.Drawing.Size(483, 20);
            this.textBoxBase.TabIndex = 5;
            // 
            // textBoxServer
            // 
            this.textBoxServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServer.Location = new System.Drawing.Point(96, 9);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(483, 20);
            this.textBoxServer.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Пользователь";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "База данных";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Сервер";
            // 
            // buttonExecute
            // 
            this.buttonExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExecute.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonExecute.ImageIndex = 1;
            this.buttonExecute.ImageList = this.imageList1;
            this.buttonExecute.Location = new System.Drawing.Point(12, 367);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(83, 23);
            this.buttonExecute.TabIndex = 2;
            this.buttonExecute.Text = "Выполнить";
            this.buttonExecute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClose.Location = new System.Drawing.Point(101, 367);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(83, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 397);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(617, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 419);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Загрузчик данных";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonOpenDir;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DirectoryNameTextBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ListView filelistView;
        private System.Windows.Forms.Button buttonInvertSelection;
        private System.Windows.Forms.Button buttonDeselectAll;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxBase;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tabletextBox;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.CheckBox checkBoxDomainAuth;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;

    }
}

