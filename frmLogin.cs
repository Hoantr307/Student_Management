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
        SqlConnection conn = new SqlConnection(@"Data Source=HOAN;Initial Catalog=QLSinhVien;Integrated Security=True;TrustServerCertificate=True");
        public frmLogin()
        {
            InitializeComponent();
        }

        bool Login(string UserName, string Password, int type)
        {
            return AccountDAO.Instance.Login(UserName, Password, type);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName = txtUsername.Text;
            string Password = txtPassword.Text;
            int type = cboPosition.Text == "Giáo Viên" ? 0 : 1;

            if (cboPosition.Text == "")
            {
                MessageBox.Show("Bạn Chưa Chọn Loại Tài Khoản! Yêu Cầu Nhập Lại!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (Login(UserName, Password, type))
            {
                frmMain f = new frmMain();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn Nhập Sai Tài Khoản, Mật Khẩu Hoặc Sai Loại Tài Khoản! Yêu Cầu Nhập Lại!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn Thoát Ứng Dụng?","Thông Báo!",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
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

        
    }
}
