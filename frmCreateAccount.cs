using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Student_Management
{
    public partial class frmCreateAccount : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=HOAN;Initial Catalog=QLSinhVien;Integrated Security=True;TrustServerCertificate=True");
        public frmCreateAccount()
        {
            InitializeComponent();
        }

        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            try
            {

                int type = cboPosition.Text == "Giáo Viên" ? 0 : 1;
                if (txtUsername.Text != "" && txtDisplayName.Text !="" && txtPassword.Text != "" && txtRePassword.Text == txtPassword.Text && txtRePassword.Text != "")
                {
                    conn.Open();
                    string CommandText = "Insert Account values('"+txtUsername.Text+"', N'"+txtDisplayName.Text+"', '"+txtPassword.Text+"', "+type+")";
                    SqlCommand cmd = new SqlCommand(CommandText, conn);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bạn Nhập Thiếu Thông Tin");
                }
            }
            catch 
            {
                MessageBox.Show("Lỗi!");
            }
        }

        private void txtRePassword_Leave(object sender, EventArgs e)
        {
            if (txtRePassword.Text != txtPassword.Text)
            {
                lbnotify.Visible = true;
            }
            else
            {
                lbnotify.Visible = false;
            }
        }

        private void txtRePassword_Enter(object sender, EventArgs e)
        {
            lbnotify.Visible = false;
        }

        bool Exist(string UserName)
        {
            conn.Open();
            string CommandText = "select * from Account where UserName = '" + UserName + "'";
            SqlCommand cmd = new SqlCommand(CommandText, conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt.Rows.Count > 0;
        }
        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (Exist(txtUsername.Text))
            {
                lbExist.Visible = true;
            }
            else lbExist.Visible = false;
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            lbExist.Visible = false;
        }
    }
}
