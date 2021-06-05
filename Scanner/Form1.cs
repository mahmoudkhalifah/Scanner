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
        Dictionary_ table = Dictionary_.GetInstance();
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
        FastColoredTextBoxNS.Range range;
        int lineNo=0;
        private void compileBtn_Click(object sender, EventArgs e)
        {
            
            Style ErrorStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);
            Style DefaultStyle = new TextStyle(Brushes.Black, null, FontStyle.Regular);
            //fastColoredTextBox1.SelectAll();
            //fastColoredTextBox1.Selection.SetStyle(DefaultStyle);
            //fastColoredTextBox1.ClearStylesBuffer();
            //if (range != null)
            //{
            //    range.SetStyle(DefaultStyle);
            //    System.Diagnostics.Debug.WriteLine("hi"+range);
            //}
                
            
            code = fastColoredTextBox1.Text;
            
            lexer.Tokinize(code, table);
            lineNo2 = table.get("lineNo");
            lexeme2 = table.get("lexeme");
            ReturnToken2 = table.get("ReturnToken");
            lexemeNoInLine2 = table.get("lexemeNoInLine");
            matchability2 = table.get("matchability");
            int i = 0;
            
            while (lineNo2[i]!=null)
            {
                if (ReturnToken2[i] == "Error")
                {
                    lineNo = int.Parse(lineNo2[i]);
                    try
                    {
                        range = fastColoredTextBox1.GetLine(lineNo - 1);
                    }
                    catch { }
                    range.SetStyle(ErrorStyle);
                    while (lineNo2[i] != null && int.Parse(lineNo2[i]) == lineNo)
                        i++;
                }
                //else
                //{
                //    lineNo = int.Parse(lineNo2[i]);
                //    range = fastColoredTextBox1.GetLine(lineNo - 1);
                //    range.SetStyle(DefaultStyle);
                //}
                i++;
            }
            table.clearAll();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                code = sr.ReadToEnd();
                System.Diagnostics.Debug.WriteLine(code);
                sr.Close();
                lexer.Tokinize(code, table);
                lineNo2 = table.get("lineNo");
                lexeme2 = table.get("lexeme");
                ReturnToken2 = table.get("ReturnToken");
                lexemeNoInLine2 = table.get("lexemeNoInLine");
                matchability2 = table.get("matchability");
                table.clearAll();
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

