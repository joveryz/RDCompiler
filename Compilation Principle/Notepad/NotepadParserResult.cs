using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDCompiler.Notepad
{
    public partial class NotepadParserResult : Form
    {
        private DataTable _DataTable = new DataTable();

        public NotepadParserResult()
        {
            InitializeComponent();
        }

        public void SetDataSource(DataTable dt)
        {
            _DataTable = dt;
            ParserReTreelist.DataSource = _DataTable ;
            for (int i = 3; i < ParserReTreelist.Columns.Count; i++)
            {
                ParserReTreelist.Columns[i].Visible = false;
            }
            ParserReTreelist.ExpandAll();
            ParserReTreelist.BestFitColumns();
        }

        public StringBuilder SaveRe()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("NodeKind" + "," + "ID" + "," + "ParentID" + "," + "NodeID" + "," + "Priview" + "," + "Child" + "," + "Sibling" + "," + "LineNo" + "," + "K_Dec" + "," + "K_Stmt" + "," + "K_Exp" + "," + "ID_Num" + "," + "Name" + "," + "Table" + "," + "Attr" + "," + "TypeName" + "," + "AA_Low" + "," + "AA_Up" + "," + "AA_ChildType" + "," + "PA_Paramt" + "," + "EA_Op" + "," + "EA_Val" + "," + "EA_VarKind" + "," + "EA_Type"+",\n");
            foreach (DataRow row in _DataTable.Rows)
            {
                sb.Append(row["NodeKind"].ToString() + "," + row["ID"].ToString() + "," + row["ParentID"].ToString() + "," + row["NodeID"].ToString() + "," + row["Priview"].ToString() + "," + row["Child"].ToString() + "," + row["Sibling"].ToString() + "," + row["LineNo"].ToString() + "," + row["K_Dec"].ToString() + "," + row["K_Stmt"].ToString() + "," + row["K_Exp"].ToString() + "," + row["ID_Num"].ToString() + "," + row["Name"].ToString() + "," + row["Table"].ToString() + "," + row["Attr"].ToString() + "," + row["TypeName"].ToString() + "," + row["AA_Low"].ToString() + "," + row["AA_Up"].ToString() + "," + row["AA_ChildType"].ToString() + "," + row["PA_Paramt"].ToString() + "," + row["EA_Op"].ToString() + "," + row["EA_Val"].ToString() + "," + row["EA_VarKind"].ToString() + "," + row["EA_Type"].ToString() + ",\n");
            }
            return sb;
        }

        private void NotepadParserResult_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void NotepadParserResult_Load(object sender, EventArgs e)
        {
            int m = Application.OpenForms["NotepadForm"].Right;
            int n = Application.OpenForms["NotepadForm"].Top;
            Size = new Size(600, Application.OpenForms["NotepadForm"].Size.Height);
            Location = new Point(m - 16, n);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[3].VisibleIndex != -1)
                ParserReTreelist.Columns[3].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[3].VisibleIndex = 3;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[4].VisibleIndex != -1)
                ParserReTreelist.Columns[4].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[4].VisibleIndex = 4;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[5].VisibleIndex != -1)
                ParserReTreelist.Columns[5].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[5].VisibleIndex = 5;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[6].VisibleIndex != -1)
                ParserReTreelist.Columns[6].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[6].VisibleIndex = 6;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[7].VisibleIndex != -1)
                ParserReTreelist.Columns[7].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[7].VisibleIndex = 7;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[8].VisibleIndex != -1)
                ParserReTreelist.Columns[8].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[8].VisibleIndex = 8;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[9].VisibleIndex != -1)
                ParserReTreelist.Columns[9].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[9].VisibleIndex = 9;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[10].VisibleIndex != -1)
                ParserReTreelist.Columns[10].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[10].VisibleIndex = 10;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[11].VisibleIndex != -1)
                ParserReTreelist.Columns[11].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[11].VisibleIndex = 11;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[12].VisibleIndex != -1)
                ParserReTreelist.Columns[12].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[12].VisibleIndex = 12;
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[13].VisibleIndex != -1)
                ParserReTreelist.Columns[13].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[13].VisibleIndex = 13;
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[14].VisibleIndex != -1)
                ParserReTreelist.Columns[14].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[14].VisibleIndex = 14;
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[15].VisibleIndex != -1)
                ParserReTreelist.Columns[15].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[15].VisibleIndex = 15;
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[16].VisibleIndex != -1)
                ParserReTreelist.Columns[16].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[16].VisibleIndex = 16;
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[17].VisibleIndex != -1)
                ParserReTreelist.Columns[17].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[17].VisibleIndex = 17;
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[18].VisibleIndex != -1)
                ParserReTreelist.Columns[18].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[18].VisibleIndex = 18;
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[19].VisibleIndex != -1)
                ParserReTreelist.Columns[19].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[19].VisibleIndex = 19;
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[20].VisibleIndex != -1)
                ParserReTreelist.Columns[20].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[20].VisibleIndex = 20;
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[21].VisibleIndex != -1)
                ParserReTreelist.Columns[21].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[21].VisibleIndex = 21;
        }

        internal void SetFont(Font font)
        {
            ParserReTreelist.Appearance.HeaderPanel.Font = font;
            ParserReTreelist.Appearance.Row.Font = font;
        }

        private void ParserReTreelist_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (e.Column == ParserReTreelist.Columns[0])
            {
                if (e.CellValue.ToString() != "1")
                {
                    e.Appearance.BackColor = Color.LightGray;
                    e.Appearance.Options.UseBackColor = true;
                }
            }
        }
    }
}
