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
    public partial class NotepadAbout : Form
    {
        public NotepadAbout()
        {
            InitializeComponent();
        }

        private void Sure_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
