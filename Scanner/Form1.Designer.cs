
using System;

namespace Scanner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.compileBtn = new System.Windows.Forms.Button();
            this.browseBtn = new System.Windows.Forms.Button();
            this.newBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.fastColoredTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.autocompleteMenu1 = new AutocompleteMenuNS.AutocompleteMenu();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.commentBtm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // compileBtn
            // 
            this.compileBtn.Location = new System.Drawing.Point(1077, 86);
            this.compileBtn.Name = "compileBtn";
            this.compileBtn.Size = new System.Drawing.Size(94, 29);
            this.compileBtn.TabIndex = 1;
            this.compileBtn.Text = "Compile";
            this.compileBtn.UseVisualStyleBackColor = true;
            this.compileBtn.Click += new System.EventHandler(this.compileBtn_Click);
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(1077, 131);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(94, 29);
            this.browseBtn.TabIndex = 2;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // newBtn
            // 
            this.newBtn.Location = new System.Drawing.Point(1077, 41);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(94, 29);
            this.newBtn.TabIndex = 3;
            this.newBtn.Text = "New";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(1077, 178);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(94, 29);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // fastColoredTextBox1
            // 
            this.fastColoredTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fastColoredTextBox1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.autocompleteMenu1.SetAutocompleteMenu(this.fastColoredTextBox1, this.autocompleteMenu1);
            this.fastColoredTextBox1.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.fastColoredTextBox1.AutoScrollMinSize = new System.Drawing.Size(31, 18);
            this.fastColoredTextBox1.BackBrush = null;
            this.fastColoredTextBox1.CharHeight = 18;
            this.fastColoredTextBox1.CharWidth = 10;
            this.fastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fastColoredTextBox1.IsReplaceMode = false;
            this.fastColoredTextBox1.Location = new System.Drawing.Point(1, 1);
            this.fastColoredTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fastColoredTextBox1.Name = "fastColoredTextBox1";
            this.fastColoredTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox1.ServiceColors")));
            this.fastColoredTextBox1.Size = new System.Drawing.Size(1013, 688);
            this.fastColoredTextBox1.TabIndex = 5;
            this.fastColoredTextBox1.Zoom = 100;
            this.fastColoredTextBox1.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fastColoredTextBox1_TextChanged);
            // 
            // autocompleteMenu1
            // 
            this.autocompleteMenu1.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("autocompleteMenu1.Colors")));
            this.autocompleteMenu1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.autocompleteMenu1.ImageList = this.imageList1;
            this.autocompleteMenu1.Items = new string[] {
        "Pattern",
        "DerivedFrom",
        "TrueFor-Else",
        "Ity",
        "Sity",
        "Cwq",
        "CwqSequence",
        "Ifity",
        "Sifity",
        "Valueless",
        "Logical",
        "BreakFromThis",
        "Whatever",
        "Respondwith",
        "Srap",
        "Scan-Conditionof",
        "Require"};
            this.autocompleteMenu1.TargetControlWrapper = null;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this.fastColoredTextBox1;
            // 
            // commentBtm
            // 
            this.commentBtm.Location = new System.Drawing.Point(1066, 262);
            this.commentBtm.Name = "commentBtm";
            this.commentBtm.Size = new System.Drawing.Size(105, 29);
            this.commentBtm.TabIndex = 6;
            this.commentBtm.Text = "un/comment";
            this.commentBtm.UseVisualStyleBackColor = true;
            this.commentBtm.Click += new System.EventHandler(this.commentBtm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(20)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1199, 689);
            this.Controls.Add(this.commentBtm);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.newBtn);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.compileBtn);
            this.Controls.Add(this.fastColoredTextBox1);
            this.Name = "Form1";
            this.Text = "Notepad";
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button compileBtn;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button saveBtn;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
        private AutocompleteMenuNS.AutocompleteMenu autocompleteMenu1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button commentBtm;
    }
}

