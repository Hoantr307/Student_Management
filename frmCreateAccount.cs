using Student_Management.DAO;
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


namespace Student_Management
{
    public partial class frmCreateAccount : Form
    {
        public frmCreateAccount()
        {
            InitializeComponent();
        }

        
        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
          /*  try
            {*/
                int type = cboPosition.Text == "Giáo Viên" ? 0 : 1;
                if (txtUsername.Text != "" && txtDisplayName.Text != "" && txtPassword.Text != "" && txtRePassword.Text == txtPassword.Text && txtRePassword.Text != "" && cboPosition.Text != "")
                {
                    if (!Exist(txtUsername.Text))
                    {
                        lbExist.Visible = true;
                        return;
                    }
                    else lbExist.Visible = false;
                    string CommandText = "USP_CreateAccount @userName , @displayName , @passWord , @accountType";

                    DataProvider.Instance.ExecuteQuery(CommandText, new object[] { txtUsername.Text.Trim(), txtDisplayName.Text.Trim(), txtPassword.Text.Trim(), type });
                    MessageBox.Show("Tạo Tài Khoản Thành Công");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Bạn Nhập Thiếu Thông Tin");
                }
            /*}
            catch 
            {
                MessageBox.Show("Lỗi!");
            }*/
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
            DataTable dt;
            if (cboPosition.Text == "Sinh Viên")
            {
                string CommandText = "select * from Student where studentID = '" + UserName + "'";
                dt = DataProvider.Instance.ExecuteQuery(CommandText);

            }
            else
            {
                string CommandText = "select * from Teacher where TeacherID = '" + UserName + "'";
                dt = DataProvider.Instance.ExecuteQuery(CommandText);
            }
            
            return dt.Rows.Count > 0;
        }

       

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            lbExist.Visible = false;
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Space )
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

        private void txtRePassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Space)
            {
                e.Handled = true;

            }
        }

    }
}
