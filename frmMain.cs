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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }





        public bool isExit = true;

        public event EventHandler Exit;
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit)
            {
                Application.Exit();
            }

        }

        

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit(this, new EventArgs());
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
