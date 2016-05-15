using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RDCompiler.Lexical_Analyzer;

namespace RDCompiler.Notepad
{
    public partial class NotepadLexerResult : Form
    {
        private List<SNLToken> _TokenList = new List<SNLToken>();

        public NotepadLexerResult()
        {

            InitializeComponent();
        }

        public void SetTokenList(List<SNLToken> TokenList)
        {
            _TokenList = TokenList;
            ReGridview.Rows.Clear();
            ReGridview.Columns.Clear();
            ReGridview.Columns.Add("LineNo", "行号");
            ReGridview.Columns.Add("LexType", "词法信息");
            ReGridview.Columns.Add("Sem", "语义信息");
            ReGridview.Columns.Add("Str", "字符串");
            ReGridview.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bool flag = false;
            foreach (SNLToken token in _TokenList)
            {
                int index = ReGridview.Rows.Add();
                ReGridview.Rows[index].Cells[0].Value = token.GetLineNo().ToString();
                ReGridview.Rows[index].Cells[1].Value = token.GetLexType().ToString();
                ReGridview.Rows[index].Cells[2].Value = token.GetSem();
                ReGridview.Rows[index].Cells[3].Value = token.GetString();
                flag = true;
            }
            if (flag)
                ReGridview.Rows[0].Selected = false;
        }

        public void SetFont(Font font)
        {
            ReGridview.Font = font;
        }

        public StringBuilder SaveRe()
        {
            StringBuilder sb = new StringBuilder();
            int row = ReGridview.Rows.Count;
            if (row == 0)
                return sb;

            sb.Append(",行号,词法信息,语义信息,字符串\r\n");
            for (int i = 0; i < row; i++)
            {
                sb.Append(i + "," + ReGridview.Rows[i].Cells[0].Value + "," + ReGridview.Rows[i].Cells[1].Value + "," + ReGridview.Rows[i].Cells[2].Value + "," + ReGridview.Rows[i].Cells[3].Value + "\r\n");
            }
            return sb;
        }

        private void NotepadLexerResult_Load(object sender, EventArgs e)
        {
            int m = Application.OpenForms["NotepadForm"].Right;
            int n = Application.OpenForms["NotepadForm"].Top;
            Size = new Size(450, Application.OpenForms["NotepadForm"].Size.Height);
            Location = new Point(m - 16, n);
        }

        private void ReGridview_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(ReGridview.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((Convert.ToInt32(e.RowIndex) + 1).ToString(System.Globalization.CultureInfo.CurrentCulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }

            ReGridview.RowsDefaultCellStyle.BackColor = Color.LightGray;
            ReGridview.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }

        private void NotepadLexerResult_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            ReGridview.Rows.Clear();
            ReGridview.Columns.Clear();
            ReGridview.Columns.Add("LineNo", "行号");
            ReGridview.Columns.Add("LexType", "词法信息");
            ReGridview.Columns.Add("Sem", "语义信息");
            ReGridview.Columns.Add("Str", "字符串");
            Hide();
        }
    }
}
