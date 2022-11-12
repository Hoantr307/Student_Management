using Student_Management.DAO;
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

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePass f = new frmChangePass();
            f.ShowDialog();
        }

        private void tsbTeacher_Click(object sender, EventArgs e)
        {
            bool isExists = false;
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmTeacher")
                {
                    f.Activate();
                    isExists = true;
                    break;
                }
            }
            if (!isExists)
            {
                frmTeacher f = new frmTeacher();
                f.MdiParent = this;
                f.Dock = DockStyle.Fill;
                f.Show();
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("select DisplayName From account where UserName = '" + frmLogin.userName + "' and PassWord = '" + frmLogin.passWord + "' and AccountType = "+ frmLogin.type);
            foreach (DataRow item in dt.Rows)
            {
                lbDisplayName.Text = item["DisplayName"].ToString();
            }
            
        }

        private void tsiProfile_Click(object sender, EventArgs e)
        {
            frmProfile f = new frmProfile();
            f.ShowDialog();
        }

        private void tsbSubject_Click(object sender, EventArgs e)
        {
            bool isExists = false;
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmSubject")
                {
                    f.Activate();
                    isExists = true;
                    break;
                }
            }
            if (!isExists)
            {
                frmSubject f = new frmSubject();
                f.MdiParent = this;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
        }

        private void tsbHome_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
        }

        private void giảngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTeacher f = new frmTeacher();
            f.ShowDialog();
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubject f = new frmSubject();
            f.ShowDialog();
        }
    }
}
