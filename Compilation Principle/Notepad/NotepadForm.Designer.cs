namespace RDCompiler
{
    partial class NotepadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotepadForm));
            this.MenuList = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeDate = new System.Windows.Forms.ToolStripMenuItem();
            this.FontMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeFont = new System.Windows.Forms.ToolStripMenuItem();
            this.CompileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Lexer = new System.Windows.Forms.ToolStripMenuItem();
            this.Parser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveLexerRe = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveParserRe = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SeeHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.NotepadAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkpathTextbox = new System.Windows.Forms.TextBox();
            this.WorkspaceLabel = new System.Windows.Forms.Label();
            this.LangLabel = new System.Windows.Forms.Label();
            this.LangChoose = new System.Windows.Forms.ComboBox();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.OriLabel = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.CurrTextbox = new RDCompiler.NotepadForm.SynchronizedScrollRichTextBox();
            this.CurrLineNumber = new RDCompiler.NotepadForm.SynchronizedScrollRichTextBox();
            this.DebugPanel = new System.Windows.Forms.Panel();
            this.DebugLabel = new System.Windows.Forms.Label();
            this.DebugGridview = new System.Windows.Forms.DataGridView();
            this.MenuList.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.DebugPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DebugGridview)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuList
            // 
            this.MenuList.BackColor = System.Drawing.Color.White;
            this.MenuList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.EditMenuItem,
            this.FontMenuItem,
            this.CompileMenuItem,
            this.HelpMenuItem});
            this.MenuList.Location = new System.Drawing.Point(0, 0);
            this.MenuList.Name = "MenuList";
            this.MenuList.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.MenuList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MenuList.Size = new System.Drawing.Size(877, 27);
            this.MenuList.TabIndex = 3;
            this.MenuList.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFile,
            this.OpenFile,
            this.SaveFile,
            this.SaveAsFile,
            this.toolStripSeparator1,
            this.Exit});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(58, 21);
            this.FileMenuItem.Text = "文件(F)";
            // 
            // NewFile
            // 
            this.NewFile.Name = "NewFile";
            this.NewFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewFile.Size = new System.Drawing.Size(174, 22);
            this.NewFile.Text = "新建(N)";
            this.NewFile.Click += new System.EventHandler(this.NewFile_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenFile.Size = new System.Drawing.Size(174, 22);
            this.OpenFile.Text = "打开(O)...";
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // SaveFile
            // 
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveFile.Size = new System.Drawing.Size(174, 22);
            this.SaveFile.Text = "保存(S)";
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // SaveAsFile
            // 
            this.SaveAsFile.Name = "SaveAsFile";
            this.SaveAsFile.Size = new System.Drawing.Size(174, 22);
            this.SaveAsFile.Text = "另存为(A)...";
            this.SaveAsFile.Click += new System.EventHandler(this.SaveAsFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(174, 22);
            this.Exit.Text = "退出(X)";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // EditMenuItem
            // 
            this.EditMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Undo,
            this.toolStripSeparator2,
            this.Cut,
            this.Copy,
            this.Paste,
            this.Delete,
            this.toolStripSeparator3,
            this.SelectAll,
            this.TimeDate});
            this.EditMenuItem.Name = "EditMenuItem";
            this.EditMenuItem.Size = new System.Drawing.Size(59, 21);
            this.EditMenuItem.Text = "编辑(E)";
            // 
            // Undo
            // 
            this.Undo.Name = "Undo";
            this.Undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.Undo.Size = new System.Drawing.Size(167, 22);
            this.Undo.Text = "撤销(U)";
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
            // 
            // Cut
            // 
            this.Cut.Name = "Cut";
            this.Cut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.Cut.Size = new System.Drawing.Size(167, 22);
            this.Cut.Text = "剪切(T)";
            this.Cut.Click += new System.EventHandler(this.Cut_Click);
            // 
            // Copy
            // 
            this.Copy.Name = "Copy";
            this.Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.Copy.Size = new System.Drawing.Size(167, 22);
            this.Copy.Text = "复制(C)";
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // Paste
            // 
            this.Paste.Name = "Paste";
            this.Paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.Paste.Size = new System.Drawing.Size(167, 22);
            this.Paste.Text = "粘贴(P)";
            this.Paste.Click += new System.EventHandler(this.Paste_Click);
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.Delete.Size = new System.Drawing.Size(167, 22);
            this.Delete.Text = "删除(L)";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // SelectAll
            // 
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.SelectAll.Size = new System.Drawing.Size(167, 22);
            this.SelectAll.Text = "全选(A)";
            this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // TimeDate
            // 
            this.TimeDate.Name = "TimeDate";
            this.TimeDate.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.TimeDate.Size = new System.Drawing.Size(167, 22);
            this.TimeDate.Text = "时间/日期(D)";
            this.TimeDate.Click += new System.EventHandler(this.TimeDate_Click);
            // 
            // FontMenuItem
            // 
            this.FontMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeFont});
            this.FontMenuItem.Name = "FontMenuItem";
            this.FontMenuItem.Size = new System.Drawing.Size(62, 21);
            this.FontMenuItem.Text = "格式(O)";
            // 
            // ChangeFont
            // 
            this.ChangeFont.Name = "ChangeFont";
            this.ChangeFont.Size = new System.Drawing.Size(123, 22);
            this.ChangeFont.Text = "字体(F)...";
            this.ChangeFont.Click += new System.EventHandler(this.ChangeFont_Click);
            // 
            // CompileMenuItem
            // 
            this.CompileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Lexer,
            this.Parser,
            this.toolStripSeparator4,
            this.SaveLexerRe,
            this.SaveParserRe});
            this.CompileMenuItem.Name = "CompileMenuItem";
            this.CompileMenuItem.Size = new System.Drawing.Size(60, 21);
            this.CompileMenuItem.Text = "编译(C)";
            // 
            // Lexer
            // 
            this.Lexer.Name = "Lexer";
            this.Lexer.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.Lexer.Size = new System.Drawing.Size(238, 22);
            this.Lexer.Text = "词法分析器(L)";
            this.Lexer.Click += new System.EventHandler(this.Lexer_Click);
            // 
            // Parser
            // 
            this.Parser.Name = "Parser";
            this.Parser.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.Parser.Size = new System.Drawing.Size(238, 22);
            this.Parser.Text = "语法分析器(P)";
            this.Parser.Click += new System.EventHandler(this.Parser_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(235, 6);
            // 
            // SaveLexerRe
            // 
            this.SaveLexerRe.Name = "SaveLexerRe";
            this.SaveLexerRe.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F6)));
            this.SaveLexerRe.Size = new System.Drawing.Size(238, 22);
            this.SaveLexerRe.Text = "保存词法分析结果(C)";
            this.SaveLexerRe.Click += new System.EventHandler(this.SaveLexerRe_Click);
            // 
            // SaveParserRe
            // 
            this.SaveParserRe.Name = "SaveParserRe";
            this.SaveParserRe.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F7)));
            this.SaveParserRe.Size = new System.Drawing.Size(238, 22);
            this.SaveParserRe.Text = "保存语法分析结果(Y)";
            this.SaveParserRe.Click += new System.EventHandler(this.SaveParserRe_Click);
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SeeHelp,
            this.toolStripSeparator5,
            this.NotepadAbout});
            this.HelpMenuItem.Name = "HelpMenuItem";
            this.HelpMenuItem.Size = new System.Drawing.Size(61, 21);
            this.HelpMenuItem.Text = "帮助(H)";
            // 
            // SeeHelp
            // 
            this.SeeHelp.Name = "SeeHelp";
            this.SeeHelp.Size = new System.Drawing.Size(152, 22);
            this.SeeHelp.Text = "查看帮助(H)";
            this.SeeHelp.Click += new System.EventHandler(this.SeeHelp_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // NotepadAbout
            // 
            this.NotepadAbout.Name = "NotepadAbout";
            this.NotepadAbout.Size = new System.Drawing.Size(152, 22);
            this.NotepadAbout.Text = "关于记事本(A)";
            this.NotepadAbout.Click += new System.EventHandler(this.NotepadAbout_Click);
            // 
            // WorkpathTextbox
            // 
            this.WorkpathTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkpathTextbox.BackColor = System.Drawing.Color.White;
            this.WorkpathTextbox.Enabled = false;
            this.WorkpathTextbox.Location = new System.Drawing.Point(86, 5);
            this.WorkpathTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WorkpathTextbox.Name = "WorkpathTextbox";
            this.WorkpathTextbox.ReadOnly = true;
            this.WorkpathTextbox.Size = new System.Drawing.Size(501, 23);
            this.WorkpathTextbox.TabIndex = 1;
            // 
            // WorkspaceLabel
            // 
            this.WorkspaceLabel.AutoSize = true;
            this.WorkspaceLabel.Location = new System.Drawing.Point(3, 9);
            this.WorkspaceLabel.Name = "WorkspaceLabel";
            this.WorkspaceLabel.Size = new System.Drawing.Size(68, 17);
            this.WorkspaceLabel.TabIndex = 4;
            this.WorkspaceLabel.Text = "工作目录：";
            // 
            // LangLabel
            // 
            this.LangLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LangLabel.AutoSize = true;
            this.LangLabel.Location = new System.Drawing.Point(595, 9);
            this.LangLabel.Name = "LangLabel";
            this.LangLabel.Size = new System.Drawing.Size(68, 17);
            this.LangLabel.TabIndex = 9;
            this.LangLabel.Text = "编程语言：";
            // 
            // LangChoose
            // 
            this.LangChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LangChoose.BackColor = System.Drawing.Color.White;
            this.LangChoose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LangChoose.FormattingEnabled = true;
            this.LangChoose.Items.AddRange(new object[] {
            "ASP",
            "Basic",
            "C",
            "C++",
            "C#",
            "Fortan",
            "JAVA",
            "MATLAB",
            "Pascal",
            "Perl",
            "PHP",
            "Python",
            "SNL"});
            this.LangChoose.Location = new System.Drawing.Point(678, 4);
            this.LangChoose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LangChoose.Name = "LangChoose";
            this.LangChoose.Size = new System.Drawing.Size(186, 25);
            this.LangChoose.TabIndex = 10;
            this.LangChoose.SelectionChangeCommitted += new System.EventHandler(this.LangChooseChangeCommitted);
            // 
            // InfoPanel
            // 
            this.InfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InfoPanel.Controls.Add(this.LangChoose);
            this.InfoPanel.Controls.Add(this.LangLabel);
            this.InfoPanel.Controls.Add(this.WorkspaceLabel);
            this.InfoPanel.Controls.Add(this.WorkpathTextbox);
            this.InfoPanel.Location = new System.Drawing.Point(0, 27);
            this.InfoPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(877, 33);
            this.InfoPanel.TabIndex = 0;
            // 
            // OriLabel
            // 
            this.OriLabel.AutoSize = true;
            this.OriLabel.Location = new System.Drawing.Point(3, 2);
            this.OriLabel.Name = "OriLabel";
            this.OriLabel.Size = new System.Drawing.Size(56, 17);
            this.OriLabel.TabIndex = 8;
            this.OriLabel.Text = "源码窗口";
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Controls.Add(this.CurrTextbox);
            this.MainPanel.Controls.Add(this.CurrLineNumber);
            this.MainPanel.Controls.Add(this.OriLabel);
            this.MainPanel.Location = new System.Drawing.Point(0, 59);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(877, 390);
            this.MainPanel.TabIndex = 10;
            // 
            // CurrTextbox
            // 
            this.CurrTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrTextbox.BackColor = System.Drawing.Color.White;
            this.CurrTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CurrTextbox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrTextbox.Location = new System.Drawing.Point(40, 20);
            this.CurrTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CurrTextbox.Name = "CurrTextbox";
            this.CurrTextbox.Size = new System.Drawing.Size(836, 369);
            this.CurrTextbox.Synchronized = this.CurrLineNumber;
            this.CurrTextbox.TabIndex = 6;
            this.CurrTextbox.Text = "";
            this.CurrTextbox.WordWrap = false;
            this.CurrTextbox.TextChanged += new System.EventHandler(this.CurrTextbox_TextChanged);
            // 
            // CurrLineNumber
            // 
            this.CurrLineNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CurrLineNumber.BackColor = System.Drawing.Color.White;
            this.CurrLineNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrLineNumber.Enabled = false;
            this.CurrLineNumber.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrLineNumber.Location = new System.Drawing.Point(0, 20);
            this.CurrLineNumber.Name = "CurrLineNumber";
            this.CurrLineNumber.ReadOnly = true;
            this.CurrLineNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CurrLineNumber.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.CurrLineNumber.Size = new System.Drawing.Size(41, 369);
            this.CurrLineNumber.Synchronized = null;
            this.CurrLineNumber.TabIndex = 7;
            this.CurrLineNumber.Text = "";
            this.CurrLineNumber.WordWrap = false;
            // 
            // DebugPanel
            // 
            this.DebugPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DebugPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DebugPanel.Controls.Add(this.DebugLabel);
            this.DebugPanel.Controls.Add(this.DebugGridview);
            this.DebugPanel.Location = new System.Drawing.Point(0, 448);
            this.DebugPanel.Name = "DebugPanel";
            this.DebugPanel.Size = new System.Drawing.Size(877, 169);
            this.DebugPanel.TabIndex = 11;
            // 
            // DebugLabel
            // 
            this.DebugLabel.AutoSize = true;
            this.DebugLabel.Location = new System.Drawing.Point(0, 0);
            this.DebugLabel.Name = "DebugLabel";
            this.DebugLabel.Size = new System.Drawing.Size(56, 17);
            this.DebugLabel.TabIndex = 2;
            this.DebugLabel.Text = "错误列表";
            // 
            // DebugGridview
            // 
            this.DebugGridview.AllowUserToAddRows = false;
            this.DebugGridview.AllowUserToDeleteRows = false;
            this.DebugGridview.AllowUserToResizeColumns = false;
            this.DebugGridview.AllowUserToResizeRows = false;
            this.DebugGridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DebugGridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DebugGridview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DebugGridview.BackgroundColor = System.Drawing.Color.White;
            this.DebugGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DebugGridview.Location = new System.Drawing.Point(0, 17);
            this.DebugGridview.Name = "DebugGridview";
            this.DebugGridview.ReadOnly = true;
            this.DebugGridview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DebugGridview.RowTemplate.Height = 23;
            this.DebugGridview.Size = new System.Drawing.Size(876, 151);
            this.DebugGridview.TabIndex = 1;
            this.DebugGridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DebugGridview_CellDoubleClick);
            this.DebugGridview.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DebugGridview_RowPostPaint);
            // 
            // NotepadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(877, 618);
            this.Controls.Add(this.DebugPanel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.MenuList);
            this.Controls.Add(this.InfoPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuList;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NotepadForm";
            this.Text = "无标题 - RDCompiler";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.NotepadForm_Load);
            this.Move += new System.EventHandler(this.NotepadForm_Move);
            this.MenuList.ResumeLayout(false);
            this.MenuList.PerformLayout();
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.DebugPanel.ResumeLayout(false);
            this.DebugPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DebugGridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuList;
        private System.Windows.Forms.ToolStripMenuItem CompileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewFile;
        private System.Windows.Forms.ToolStripMenuItem OpenFile;
        private System.Windows.Forms.ToolStripMenuItem SaveFile;
        private System.Windows.Forms.ToolStripMenuItem SaveAsFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.ComboBox LangChoose;
        private System.Windows.Forms.Label LangLabel;
        private System.Windows.Forms.Label WorkspaceLabel;
        private System.Windows.Forms.TextBox WorkpathTextbox;
        private System.Windows.Forms.ToolStripMenuItem EditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Undo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem Cut;
        private System.Windows.Forms.ToolStripMenuItem Copy;
        private System.Windows.Forms.ToolStripMenuItem Paste;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem SelectAll;
        private System.Windows.Forms.ToolStripMenuItem TimeDate;
        private System.Windows.Forms.Label OriLabel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel DebugPanel;
        private System.Windows.Forms.ToolStripMenuItem Lexer;
        private System.Windows.Forms.DataGridView DebugGridview;
        private System.Windows.Forms.Label DebugLabel;
        private System.Windows.Forms.ToolStripMenuItem FontMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeFont;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SeeHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem NotepadAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem SaveLexerRe;
        private System.Windows.Forms.ToolStripMenuItem Parser;
        private System.Windows.Forms.ToolStripMenuItem SaveParserRe;
        private SynchronizedScrollRichTextBox CurrTextbox;
        private SynchronizedScrollRichTextBox CurrLineNumber;
    }
}