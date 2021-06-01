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

namespace Scanner
{
    public partial class Form1 : Form
    {
        Lexer lexer = new Lexer();
        OpenFileDialog ofd = new OpenFileDialog
        {
            Filter="txt files (*.txt)|*.txt",
        };

        string code = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void compileBtn_Click(object sender, EventArgs e)
        {
            code = codeBox.Text;
            lexer.SetText(code);
            System.Diagnostics.Debug.WriteLine(code);
            lexer.Tokinize();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                code = sr.ReadToEnd();
                System.Diagnostics.Debug.WriteLine(code);
                sr.Close();
                lexer.SetText(code);
                lexer.Tokinize();
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            codeBox.Text = "";
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt";
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                StreamWriter sr = new StreamWriter(sfd.FileName);
                sr.Write(codeBox.Text);
                sr.Close();
            }
        }
    }
}
