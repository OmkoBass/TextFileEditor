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
            if (string.IsNullOrEmpty(temp))
            {
                MessageBox.Show("You didn't select a file to save.");
            }
            else
            {
                FileStream f = new FileStream(temp, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(f);
                writer.Write(displayText.Text);
                writer.Close();
                f.Close();
                temp = null;
                displayText.Text = null;
            }
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

        private void BlackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayText.BackColor = Color.Black;
            displayText.ForeColor = Color.White;
        }

        private void RedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayText.BackColor = Color.Red;
            displayText.ForeColor = Color.Black;
        }

        private void BlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayText.BackColor = Color.Blue;
            displayText.ForeColor = Color.White;
        }

        private void YellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayText.BackColor = Color.Yellow;
            displayText.ForeColor = Color.Black;
        }

        private void DefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayText.BackColor = Color.White;
            displayText.ForeColor = Color.Black;
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog f = new FontDialog();
            if(f.ShowDialog() == DialogResult.OK)
            {
                displayText.Font = f.Font;
            }
        }

        private void AboutThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Basic Text Editor for my first C# project.");
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Open a file.\nEdit it and then save.\nYou can change the font or background color.");
        }
    }
}
