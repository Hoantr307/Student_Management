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

namespace Student_Management
{

    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            //
            txtUsername.Text = "Hoan";
            txtPassword.Text = "Hoan";
            cboPosition.SelectedIndex = 1;
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

                frmMain f = new frmMain();
                f.Show();
                this.Hide();
                f.Exit += F_Exit;
            }
            else
            {
                MessageBox.Show("Bạn Nhập Sai Tài Khoản, Mật Khẩu Hoặc Sai Loại Tài Khoản! Yêu Cầu Nhập Lại!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
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
    }
}
