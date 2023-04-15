namespace ELB_LogAnalyzer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Units_Label = new System.Windows.Forms.Label();
            this.Models_Label = new System.Windows.Forms.Label();
            this.DGrid1 = new System.Windows.Forms.DataGridView();
            this.testname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile_Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileDiagMain = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DGrid1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.05208F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.94791F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(661, 460);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.Units_Label, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Models_Label, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(617, 66);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Processed Files";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Model";
            // 
            // Units_Label
            // 
            this.Units_Label.AutoSize = true;
            this.Units_Label.Location = new System.Drawing.Point(157, 0);
            this.Units_Label.Name = "Units_Label";
            this.Units_Label.Size = new System.Drawing.Size(35, 13);
            this.Units_Label.TabIndex = 2;
            this.Units_Label.Text = "label3";
            // 
            // Models_Label
            // 
            this.Models_Label.AutoSize = true;
            this.Models_Label.Location = new System.Drawing.Point(157, 33);
            this.Models_Label.Name = "Models_Label";
            this.Models_Label.Size = new System.Drawing.Size(35, 13);
            this.Models_Label.TabIndex = 3;
            this.Models_Label.Text = "label4";
            // 
            // DGrid1
            // 
            this.DGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DGrid1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.DGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.testname});
            this.DGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGrid1.Location = new System.Drawing.Point(3, 104);
            this.DGrid1.Name = "DGrid1";
            this.DGrid1.ReadOnly = true;
            this.DGrid1.RowHeadersWidth = 62;
            this.DGrid1.Size = new System.Drawing.Size(655, 336);
            this.DGrid1.TabIndex = 1;
            // 
            // testname
            // 
            this.testname.HeaderText = "Test Name";
            this.testname.MinimumWidth = 8;
            this.testname.Name = "testname";
            this.testname.ReadOnly = true;
            this.testname.Width = 84;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(661, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenuBtn
            // 
            this.FileMenuBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFile_Btn,
            this.ExitBtn});
            this.FileMenuBtn.Name = "FileMenuBtn";
            this.FileMenuBtn.Size = new System.Drawing.Size(37, 22);
            this.FileMenuBtn.Text = "File";
            // 
            // OpenFile_Btn
            // 
            this.OpenFile_Btn.Name = "OpenFile_Btn";
            this.OpenFile_Btn.Size = new System.Drawing.Size(103, 22);
            this.OpenFile_Btn.Text = "Open";
            this.OpenFile_Btn.Click += new System.EventHandler(this.OpenFile_Btn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(103, 22);
            this.ExitBtn.Text = "Exit";
            // 
            // OpenFileDiagMain
            // 
            this.OpenFileDiagMain.Filter = "Text Files|*.txt|CSV Files|*.csv";
            this.OpenFileDiagMain.Multiselect = true;
            this.OpenFileDiagMain.Title = "\"Choose the Files to Analize\"";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 484);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Test Result Data Analyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Units_Label;
        private System.Windows.Forms.Label Models_Label;
        private System.Windows.Forms.DataGridView DGrid1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem OpenFile_Btn;
        private System.Windows.Forms.ToolStripMenuItem ExitBtn;
        private System.Windows.Forms.OpenFileDialog OpenFileDiagMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn testname;
    }
}

