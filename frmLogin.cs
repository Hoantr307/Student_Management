using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Student_Management.DAO;
using System.Diagnostics;

namespace Student_Management
{

    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            Process process = new Process();
            /*process.StartInfo.FileName = Application.StartupPath + "\\CreateDatabase.bat";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();*/


        }
        public static string userName;
        public static string passWord;
        public static int type;
        bool Login(string UserName, string Password, int type)
        {
            return AccountDAO.Instance.Login(UserName, Password, type);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName = txtUsername.Text;
            string Password = txtPassword.Text;
            int Type = cboPosition.Text == "Giáo Viên" ? 0 : 1;

            if (cboPosition.Text == "")
            {
                MessageBox.Show("Bạn Chưa Chọn Loại Tài Khoản! Yêu Cầu Nhập Lại!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (Login(UserName, Password, Type))
            {
                userName = UserName;
                passWord = Password;
                type = Type;
                if (type == 0)
                {
                    frmMain f = new frmMain();
                    f.Show();
                    this.Hide();
                    f.Exit += F_Exit;

                }
                else
                {
                    frmSearchScore f = new frmSearchScore();
                    f.Show();
                    Hide();
                    f.Exit += F_Exit1;
                }
            }
            else
            {
                MessageBox.Show("Bạn Nhập Sai Tài Khoản, Mật Khẩu Hoặc Sai Loại Tài Khoản! Yêu Cầu Nhập Lại!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void F_Exit1(object sender, EventArgs e)
        {
            (sender as frmSearchScore).isExit = false;
            (sender as frmSearchScore).Close();
            this.Show();
        }

        private void F_Exit(object sender, EventArgs e)
        {
            (sender as frmMain).isExit = false;
            (sender as frmMain).Close();
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmCreateAccount f = new frmCreateAccount();
            f.ShowDialog();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
