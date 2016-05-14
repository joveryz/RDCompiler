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

        private void NotepadParserResult_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void NotepadParserResult_Load(object sender, EventArgs e)
        {
            int m = Application.OpenForms["NotepadForm"].Right;
            int n = Application.OpenForms["NotepadForm"].Top;
            Size = new Size(450, Application.OpenForms["NotepadForm"].Size.Height);
            Location = new Point(m - 16, n);
        }
    }
}
