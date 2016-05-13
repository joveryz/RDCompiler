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
using System.Drawing.Printing;
using System.Collections;
using System.Text.RegularExpressions;
using RDCompiler.Lexical_Analyzer;
using RDCompiler.Syntactic_Analyzer;
using RDCompiler.Notepad;

namespace RDCompiler
{
    public partial class NotepadForm : Form
    {
        NotepadLexerResult _LexerReForm = new NotepadLexerResult();
        private bool _IsDirty = false;
        private string _CurrFileContent = "";
        private string _CurrFileName = "";
        private string _CurrFileFullPath = "";
        private string _CurrFileDirectory = "D:\\";
        Font CurrFont;
        string[] _SNLKeyWords = { "PROGRAM", "PROCEDURE", "TYPE", "VAR", "IF", "THEN", "ELSE", "FI", "WHILE", "DO", "ENDWH", "BEGIN", "END", "READ", "WRITE", "ARRAY", "OF", "RECORD", "RETURN", "INTEGER", "CHAR", "program", "procedure", "type", "var", "if", "then", "else", "fi", "while", "do", "endwh", "begin", "end", "read", "write", "array", "of", "record", "return", "integer", "char" };

        public NotepadForm()
        {

            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            CurrFont = CurrTextbox.SelectionFont;
            DebugGridview.Columns.Add("Code", "类型");
            DebugGridview.Columns.Add("Des", "说明");
            DebugGridview.Columns.Add("Project", "项目");
            DebugGridview.Columns.Add("File", "文件");
            DebugGridview.Columns.Add("LineNo", "行号");
            DebugGridview.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public class SynchronizedScrollRichTextBox : System.Windows.Forms.RichTextBox
        {
            public SynchronizedScrollRichTextBox Synchronized { get; set; }
            public const int WM_VSCROLL = 0x115;
            public const int EM_LINESCROLL = 0xB6;

            protected override void WndProc(ref System.Windows.Forms.Message msg)
            {
                if (msg.Msg == WM_VSCROLL || msg.Msg == EM_LINESCROLL)
                {
                    if (Synchronized != null)
                    {
                        Message message = msg;
                        message.HWnd = Synchronized.Handle;
                        Synchronized.PubWndProc(ref message);
                    }
                }
                base.WndProc(ref msg);
            }
            public void PubWndProc(ref System.Windows.Forms.Message msg)
            {
                base.WndProc(ref msg);
            }
        }

        private void HighLightText()
        {
            CurrTextbox.SelectAll();
            CurrTextbox.SelectionColor = Color.Black;
            CurrTextbox.SelectionFont = CurrFont;
            HighLightText(_SNLKeyWords, Color.Blue);
            CurrTextbox.Select(0, 0);

        }

        private void HighLightText(string[] wordList, Color color)
        {
            foreach (string word in wordList)
            {
                Regex r = new Regex(word, RegexOptions.IgnoreCase);
                foreach (Match m in r.Matches(CurrTextbox.Text))
                {
                    CurrTextbox.Select(m.Index, m.Length);
                    CurrTextbox.SelectionColor = color;
                }
            }
        }

        private void UpdateCurrNumberLabel()
        {
            int lines = 0;
            StringBuilder sb = new StringBuilder();
            string s = CurrTextbox.Text;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '\n')
                {
                    lines++;
                    sb.Append(lines + "\n");
                }
            }
            sb.Append(++lines + "\n");
            CurrLineNumber.Font = CurrFont;
            CurrLineNumber.Text = sb.ToString();
        }

        private void SetStatus(string name = "", string path = "", string dir = "")
        {
            _CurrFileContent = "";
            _CurrFileName = name;
            if (name != "")
                Text = _CurrFileName + " -  RDCompiler";
            else
                Text = "无标题 - SNLCompiler";
            _CurrFileFullPath = path;
            if (dir != "")
            {
                _CurrFileDirectory = dir;
            }
            else
            {
                _CurrFileDirectory = "D:\\";
            }
            WorkpathTextbox.Text = _CurrFileDirectory;
            CurrTextbox.Clear();
        }

        private bool IsDirty()
        {
            if (_CurrFileContent == CurrTextbox.Text)
                _IsDirty = false;
            else
                _IsDirty = true;
            return _IsDirty;
        }

        private void SaveAs()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.InitialDirectory = _CurrFileDirectory;
            savefile.Filter = "txt文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = File.CreateText(savefile.FileName);
                sw.Write(CurrTextbox.Text);
                sw.Flush();
                sw.Close();
                _CurrFileContent = CurrTextbox.Text;
                _CurrFileDirectory = Path.GetDirectoryName(savefile.FileName);
                _CurrFileName = Path.GetFileName(savefile.FileName);
                _CurrFileFullPath = savefile.FileName;
                Text = _CurrFileName + " -  RDCompiler";
            }

        }

        private void NewFile_Click(object sender, EventArgs e)
        {
            SetStatus();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog workfile = new OpenFileDialog();
            workfile.Filter = "所有文件(*.*)|*.*|txt文件(*.txt)|*.txt";
            if (workfile.ShowDialog() == DialogResult.OK)
            {
                SetStatus(workfile.SafeFileName, workfile.FileName, Path.GetDirectoryName(workfile.FileName));
                StreamReader sr = File.OpenText(workfile.FileName);
                CurrTextbox.Text = sr.ReadToEnd();
                sr.Close();
                _CurrFileContent = CurrTextbox.Text;
                UpdateCurrNumberLabel();

            }
            HighLightText();
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            if (CurrTextbox.Text != "")
                HighLightText();
            if (!IsDirty())
            {
                Console.WriteLine("budirty");
                return;
            }
            if (_CurrFileName == "")
            {
                SaveAs();
                return;
            }
            File.WriteAllText(_CurrFileFullPath, CurrTextbox.Text);
            _CurrFileContent = CurrTextbox.Text;
        }

        private void SaveAsFile_Click(object sender, EventArgs e)
        {
            HighLightText();
            SaveAs();
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            CurrTextbox.Undo();
        }

        private void Cut_Click(object sender, EventArgs e)
        {
            CurrTextbox.Cut();
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            CurrTextbox.Copy();
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            CurrTextbox.Paste();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            CurrTextbox.SelectedText = "";
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            CurrTextbox.SelectAll();
        }

        private void TimeDate_Click(object sender, EventArgs e)
        {
            CurrTextbox.SelectedText = DateTime.Now.ToShortTimeString() + " " + DateTime.Now.ToShortDateString();
        }
        

        private void CurrFileTextbox_TextChanged(object sender, EventArgs e)
        {
            UpdateCurrNumberLabel();
        }

        private void CurrFileTextbox_FontChanged(object sender, EventArgs e)
        {
            UpdateCurrNumberLabel();
        }

        private void Lexer_Click(object sender, EventArgs e)
        {
            if(LangChoose.Text!="SNL")
            {
                MessageBox.Show("请选择编程语言！", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            SNLLexer snllexer = new SNLLexer();
            snllexer.StartLexer(CurrTextbox.Text);
            List<SNLToken> TokenList = snllexer.GetTokenList();
            List<List<string>> DebugList = snllexer.GetDebugList();

            _LexerReForm.SetTokenList(TokenList);
            _LexerReForm.Show();
            
            bool flag = false;
            DebugGridview.Rows.Clear();
            DebugGridview.Columns.Clear();
            DebugGridview.Columns.Add("Code", "类型");
            DebugGridview.Columns.Add("Des", "说明");
            DebugGridview.Columns.Add("Project", "项目");
            DebugGridview.Columns.Add("File", "文件");
            DebugGridview.Columns.Add("LineNo", "行号");
            DebugGridview.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            flag = false;
            foreach (List<string> str in DebugList)
            {
                int index = DebugGridview.Rows.Add();
                DebugGridview.Rows[index].Cells[0].Value = "ERROR";
                DebugGridview.Rows[index].Cells[0].Style.ForeColor = Color.Red;
                DebugGridview.Rows[index].Cells[1].Value = str[2];
                DebugGridview.Rows[index].Cells[2].Value = "SNLLexer";
                DebugGridview.Rows[index].Cells[3].Value = _CurrFileName;
                DebugGridview.Rows[index].Cells[4].Value = str[0];
                flag = true;
            }
            if (flag)
                DebugGridview.Rows[0].Selected = false;
        }

        private void DebugGridview_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(DebugGridview.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((Convert.ToInt32(e.RowIndex) + 1).ToString(System.Globalization.CultureInfo.CurrentCulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void DebugGridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int line = Int32.Parse(DebugGridview.Rows[e.RowIndex].Cells[4].Value.ToString());
            int a = CurrTextbox.GetFirstCharIndexFromLine(line - 1);
            int b = CurrTextbox.GetFirstCharIndexFromLine(line);
            if (a == -1)
                return;
            else if (b == -1)
                b = CurrTextbox.TextLength - a;
            else
                b = b - a;
            Console.WriteLine(a);
            Console.WriteLine(b);
            CurrTextbox.Focus();
            CurrTextbox.Select(a, b);
            CurrTextbox.ScrollToCaret();
        }

        private void ChangeFont_Click(object sender, EventArgs e)
        {
            FontDialog changefont = new FontDialog();
            if (changefont.ShowDialog() == DialogResult.OK)
            {
                _LexerReForm.SetFont(changefont.Font);
                DebugGridview.Font = changefont.Font;
            }
        }

        private void NotepadAbout_Click(object sender, EventArgs e)
        {
            Form newForm = new NotepadAbout();
            newForm.ShowDialog();
            
        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("无法找到帮助文件！", "查找帮助文件", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NotepadForm_Load(object sender, EventArgs e)
        {
            NotepadWelcome form = new NotepadWelcome();
            form.TopMost = true;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (LangChoose.Text != "SNL")
                MessageBox.Show("该功能正在开发中!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LangChoose.Text = "SNL";
        }

        private void SaveRe_Click(object sender, EventArgs e)
        {
            StringBuilder sb = _LexerReForm.SaveRe();
            File.WriteAllText(_CurrFileDirectory + "\\TokenList.csv", sb.ToString(), Encoding.GetEncoding("gb2312"));
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(_CurrFileDirectory + "\\TokenList.csv");

        }

        private void Parser_Click(object sender, EventArgs e)
        {
            if (LangChoose.Text != "SNL")
            {
                MessageBox.Show("请选择编程语言！", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SNLLexer snllexer = new SNLLexer();
            snllexer.StartLexer(CurrTextbox.Text);
            List<SNLToken> TokenList = snllexer.GetTokenList();
            List<List<string>> DebugList = snllexer.GetDebugList();

            SNLParser snlparser = new SNLParser();
            snlparser.StartParser(TokenList);
            Console.WriteLine(snlparser.GetPointer());
        }

        private void NotepadForm_Move(object sender, EventArgs e)
        {
            int m = Right;
            int n = Top;
            _LexerReForm.Location = new Point(m - 16, n);
        }
    }
}
