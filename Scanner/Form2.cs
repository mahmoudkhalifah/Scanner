using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scanner
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ListViewItem itm;
            string[] arr = new string[5];
            for (int i = 0; i < Form1.size; i++)
            {
                arr[0] = Form1.lineNo2[i];
                arr[1] = Form1.lexeme2[i];
                arr[2] = Form1.ReturnToken2[i];
                arr[3] = Form1.lexemeNoInLine2[i];
                arr[4] = Form1.matchability2[i];

                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);

            }
        }

       
    }
}
