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
            conn.Open();
            string CommandText = "select * from Account where UserName = '"+ UserName + "'and PassWord = '"+Password+ "'and AccountType = "+ type;
            SqlCommand cmd = new SqlCommand(CommandText, conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt.Rows.Count > 0;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName = txtUsername.Text;
            string Password = txtPassword.Text;
            int type = cboPosition.Text == "Giáo Viên" ? 0 : 1;
            
            if (Login(UserName, Password, type))
            {
                frmMain f = new frmMain();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn Nhập Sai Mật Khẩu! Yêu Cầu Nhập Lại!");
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
