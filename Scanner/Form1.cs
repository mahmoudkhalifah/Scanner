using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            code = fastColoredTextBox1.Text;
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
            fastColoredTextBox1.Text = "";
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt";
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                StreamWriter sr = new StreamWriter(sfd.FileName);
                sr.Write(fastColoredTextBox1.Text);
                sr.Close();
            }
        }

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void codeBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void fastColoredTextBox1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            Regex rx = new Regex("class");
            int index = fastColoredTextBox1.SelectionStart;

            foreach (Match m in rx.Matches(fastColoredTextBox1.Text))
            {
                fastColoredTextBox1.SelectionColor = Color.Blue;
                fastColoredTextBox1.SelectionStart = index;
                fastColoredTextBox1.SelectionColor = Color.Black;
            }
        }
    }
}

