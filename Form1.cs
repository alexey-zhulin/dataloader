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
using Microsoft.Win32;

namespace BIR_Analitic_Loader
{
    enum selectTypes
    {
        SelectAll, SelectNone, InvertSelection   
    }
    
    public partial class Form1 : Form
    {
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
            folderBrowserDialog1.SelectedPath = Registry.CurrentUser.GetValue("DefaultPath", "") as string;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                DirectoryNameTextBox.Text = folderBrowserDialog1.SelectedPath;
                fillFileList(folderBrowserDialog1.SelectedPath);
                Registry.CurrentUser.SetValue("DefaultPath", folderBrowserDialog1.SelectedPath);
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
    }
}
