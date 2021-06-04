using dictionary;
using FastColoredTextBoxNS;
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
        public static int size;
        public static string[] lineNo2 = new string[1000];
        public static string[] lexeme2 = new string[1000];
        public static string[] ReturnToken2 = new string[1000];
        public static string[] lexemeNoInLine2 = new string[1000];
        public static string[] matchability2 = new string[1000];
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
            Dictionary_ table = new Dictionary_();
            lexer.Tokinize(code, table);
            size = table.length();
            lineNo2 = table.get("lineNo");
            lexeme2 = table.get("lexeme");
            ReturnToken2 = table.get("ReturnToken");
            lexemeNoInLine2 = table.get("lexemeNoInLine");
            matchability2 = table.get("matchability");
            Form2 f2 = new Form2();
            f2.ShowDialog();
            /*for (int i = 0; i < lineNo2.Length; i++)
            {
                if (ReturnToken2[i] == "Error")
                {
                    int x = int.Parse(lineNo2[i]);
                    System.Diagnostics.Debug.WriteLine(fastColoredTextBox1.GetLineText(x-1));
                }
            }*/
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                code = sr.ReadToEnd();
                System.Diagnostics.Debug.WriteLine(code);
                sr.Close();
                Dictionary_ table = new Dictionary_();
                lexer.Tokinize(code, table);
                size = table.length();
                lineNo2 = table.get("lineNo");
                lexeme2 = table.get("lexeme");
                ReturnToken2 = table.get("ReturnToken");
                lexemeNoInLine2 = table.get("lexemeNoInLine");
                matchability2 = table.get("matchability");
                Form2 f2 = new Form2();
                f2.ShowDialog();
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
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.Write(fastColoredTextBox1.Text);
                sw.Close();
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
     

        }

        private void commentBtm_Click(object sender, EventArgs e)
        {
            if (fastColoredTextBox1.SelectedText.StartsWith("--"))
                fastColoredTextBox1.SelectedText = fastColoredTextBox1.SelectedText.Substring(2);
            else fastColoredTextBox1.SelectedText = "--" + fastColoredTextBox1.SelectedText;
        }
    }
}

