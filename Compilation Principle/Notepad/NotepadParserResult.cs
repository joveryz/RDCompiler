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
        public NotepadParserResult()
        {
            InitializeComponent();
        }

        public void SetDataSource(DataTable dt)
        {
            ParserReTreelist.DataSource = dt;
            for (int i = 1; i < ParserReTreelist.Columns.Count - 1; i++)
            {
                ParserReTreelist.Columns[i].VisibleIndex = -1;

            }
            ParserReTreelist.ExpandAll();
            ParserReTreelist.BestFitColumns();
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
            if (ParserReTreelist.Columns[1].VisibleIndex != -1)
                ParserReTreelist.Columns[1].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[1].VisibleIndex = 1;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[2].VisibleIndex != -1)
                ParserReTreelist.Columns[2].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[2].VisibleIndex = 1;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[3].VisibleIndex != -1)
                ParserReTreelist.Columns[3].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[3].VisibleIndex = 1;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[4].VisibleIndex != -1)
                ParserReTreelist.Columns[4].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[4].VisibleIndex = 1;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[5].VisibleIndex != -1)
                ParserReTreelist.Columns[5].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[5].VisibleIndex = 1;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[6].VisibleIndex != -1)
                ParserReTreelist.Columns[6].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[6].VisibleIndex = 1;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[7].VisibleIndex != -1)
                ParserReTreelist.Columns[7].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[7].VisibleIndex = 1;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[8].VisibleIndex != -1)
                ParserReTreelist.Columns[8].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[8].VisibleIndex = 1;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[9].VisibleIndex != -1)
                ParserReTreelist.Columns[9].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[9].VisibleIndex = 1;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[10].VisibleIndex != -1)
                ParserReTreelist.Columns[10].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[10].VisibleIndex = 1;
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[11].VisibleIndex != -1)
                ParserReTreelist.Columns[11].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[11].VisibleIndex = 1;
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[12].VisibleIndex != -1)
                ParserReTreelist.Columns[12].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[12].VisibleIndex = 1;
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[13].VisibleIndex != -1)
                ParserReTreelist.Columns[13].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[13].VisibleIndex = 1;
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[14].VisibleIndex != -1)
                ParserReTreelist.Columns[14].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[14].VisibleIndex = 1;
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[15].VisibleIndex != -1)
                ParserReTreelist.Columns[15].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[15].VisibleIndex = 1;
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[16].VisibleIndex != -1)
                ParserReTreelist.Columns[16].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[16].VisibleIndex = 1;
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[17].VisibleIndex != -1)
                ParserReTreelist.Columns[17].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[17].VisibleIndex = 1;
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[18].VisibleIndex != -1)
                ParserReTreelist.Columns[18].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[18].VisibleIndex = 1;
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (ParserReTreelist.Columns[19].VisibleIndex != -1)
                ParserReTreelist.Columns[19].VisibleIndex = -1;
            else
                ParserReTreelist.Columns[19].VisibleIndex = 1;
        }
    }
}
