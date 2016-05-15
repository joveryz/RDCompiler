namespace RDCompiler.Notepad
{
    partial class NotepadLexerResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotepadLexerResult));
            this.ReGridview = new System.Windows.Forms.DataGridView();
            this.LineNoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeaningColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrammarColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StringColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ReGridview)).BeginInit();
            this.SuspendLayout();
            // 
            // ReGridview
            // 
            this.ReGridview.AllowUserToAddRows = false;
            this.ReGridview.AllowUserToDeleteRows = false;
            this.ReGridview.AllowUserToResizeColumns = false;
            this.ReGridview.AllowUserToResizeRows = false;
            this.ReGridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ReGridview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ReGridview.BackgroundColor = System.Drawing.Color.White;
            this.ReGridview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ReGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ReGridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNoColumn,
            this.MeaningColumn,
            this.GrammarColumn,
            this.StringColumn});
            this.ReGridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReGridview.Location = new System.Drawing.Point(0, 0);
            this.ReGridview.Name = "ReGridview";
            this.ReGridview.ReadOnly = true;
            this.ReGridview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ReGridview.RowTemplate.Height = 23;
            this.ReGridview.Size = new System.Drawing.Size(434, 644);
            this.ReGridview.TabIndex = 9;
            this.ReGridview.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ReGridview_RowPostPaint);
            // 
            // LineNoColumn
            // 
            this.LineNoColumn.HeaderText = "行号";
            this.LineNoColumn.Name = "LineNoColumn";
            this.LineNoColumn.ReadOnly = true;
            this.LineNoColumn.Width = 57;
            // 
            // MeaningColumn
            // 
            this.MeaningColumn.HeaderText = "语义信息";
            this.MeaningColumn.Name = "MeaningColumn";
            this.MeaningColumn.ReadOnly = true;
            this.MeaningColumn.Width = 81;
            // 
            // GrammarColumn
            // 
            this.GrammarColumn.HeaderText = "文法信息";
            this.GrammarColumn.Name = "GrammarColumn";
            this.GrammarColumn.ReadOnly = true;
            this.GrammarColumn.Width = 81;
            // 
            // StringColumn
            // 
            this.StringColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StringColumn.HeaderText = "字符串";
            this.StringColumn.Name = "StringColumn";
            this.StringColumn.ReadOnly = true;
            // 
            // NotepadLexerResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(434, 644);
            this.Controls.Add(this.ReGridview);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotepadLexerResult";
            this.ShowInTaskbar = false;
            this.Text = "词法分析结果";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NotepadLexerResult_FormClosing);
            this.Load += new System.EventHandler(this.NotepadLexerResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReGridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ReGridview;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeaningColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrammarColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StringColumn;
    }
}