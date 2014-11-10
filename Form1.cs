using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace DataLoader
{
    enum selectTypes
    {
        SelectAll, SelectNone, InvertSelection   
    }
    
    public partial class Form1 : Form
    {
        DBHandler dbhandler = new DBHandler();

        public Form1()
        {
            InitializeComponent();
        }

        private void fillFileList(string SelectedPath)
        {
            filelistView.Items.Clear();
            string[] files = Directory.GetFiles(SelectedPath);
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                if ((File.GetAttributes(file) & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    continue;
                }
                ListViewItem item = new ListViewItem(fileName);
                item.Tag = file;
                filelistView.Items.Add(item);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = (string)Properties.Settings.Default["SelectedPath"] ?? "";
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                DirectoryNameTextBox.Text = folderBrowserDialog1.SelectedPath;
                fillFileList(folderBrowserDialog1.SelectedPath);
                Properties.Settings.Default["SelectedPath"] = folderBrowserDialog1.SelectedPath;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkOperation(selectTypes selectType)
        {
            for (int i = 0; i < filelistView.Items.Count; i++)
            {
                if (selectType == selectTypes.SelectAll)
                {
                    filelistView.Items[i].Checked = true;
                }
                if (selectType == selectTypes.SelectNone)
                {
                    filelistView.Items[i].Checked = false;
                }
                if (selectType == selectTypes.InvertSelection)
                {
                    filelistView.Items[i].Checked = !(filelistView.Items[i].Checked);
                }
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            checkOperation(selectTypes.SelectAll);
        }

        private void buttonDeselectAll_Click(object sender, EventArgs e)
        {
            checkOperation(selectTypes.SelectNone);
        }

        private void buttonInvertSelection_Click(object sender, EventArgs e)
        {
            checkOperation(selectTypes.InvertSelection);
        }

        private void checkBoxDomainAuth_CheckedChanged(object sender, EventArgs e)
        {
            textBoxUser.Enabled = !checkBoxDomainAuth.Checked;
            textBoxPassword.Enabled = !checkBoxDomainAuth.Checked;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            buttonExecute.Enabled = false;
            dbhandler.ServerName = textBoxServer.Text;
            dbhandler.Database = textBoxBase.Text;
            dbhandler.UserName = textBoxUser.Text;
            dbhandler.Pwd = textBoxPassword.Text;
            dbhandler.DomainAuth = checkBoxDomainAuth.Checked;
            if (dbhandler.Connect())
            {
                Properties.Settings.Default["ServerName"] = textBoxServer.Text;
                Properties.Settings.Default["Database"] = textBoxBase.Text;
                Properties.Settings.Default["UserName"] = textBoxUser.Text;
                Properties.Settings.Default["Pwd"] = textBoxPassword.Text;
                Properties.Settings.Default["DomainAuth"] = checkBoxDomainAuth.Checked;
                buttonExecute.Enabled = true;
            }
            else
            {
                MessageBox.Show(dbhandler.ConnectException.Message, "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxServer.Text = (string)Properties.Settings.Default["ServerName"];
            textBoxBase.Text = (string)Properties.Settings.Default["Database"];
            textBoxUser.Text = (string)Properties.Settings.Default["UserName"];
            textBoxPassword.Text = (string)Properties.Settings.Default["Pwd"];
            checkBoxDomainAuth.Checked = (bool)Properties.Settings.Default["DomainAuth"];
            DirectoryNameTextBox.Text = (string)Properties.Settings.Default["SelectedPath"];
            fillFileList(DirectoryNameTextBox.Text);
            buttonExecute.Enabled = false;
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            if (dbhandler.connectionState != ConnectionState.Open)
            {
                MessageBox.Show("Текущее состояние подключения не является открытым. Попробуйте снова выполнить подключение.", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
