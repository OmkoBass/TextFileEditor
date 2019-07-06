using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFileEditor
{
    public partial class main : Form
    {

        string temp;

        public main()
        {
            InitializeComponent();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.ShowDialog();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileDialog f = new OpenFileDialog();
            if(f.ShowDialog() == DialogResult.OK)
            {
                FileStream file = new FileStream(f.FileName, FileMode.Open, FileAccess.Read);
                temp = f.FileName;
                StreamReader reader = new StreamReader(file);
                string getText = reader.ReadToEnd();
                displayText.Text = getText;
                reader.Close();
                file.Close();
            }
        }

        private void SaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileStream f = new FileStream(temp, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(f);
            writer.Write(displayText.Text);
            writer.Close();
            f.Close();
            displayText.Text = null;
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileDialog f = new OpenFileDialog();
            if(f.ShowDialog() == DialogResult.OK)
            {
                FileStream file = new FileStream(f.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(file);
                writer.Write(displayText.Text);
                writer.Close();
                file.Close();
                MessageBox.Show("Saved successfuly.");
                displayText.Text = null;
            }
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
