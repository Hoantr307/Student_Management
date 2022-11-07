using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmMain f = new frmMain();
            f.ShowDialog();
        }

        private void refesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin_Load(sender, e);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
