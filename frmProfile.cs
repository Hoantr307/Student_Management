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
using DataTable = System.Data.DataTable;

namespace Student_Management
{
    public partial class frmProfile : Form
    {
        public frmProfile()
        {
            InitializeComponent();
        }

        

        bool Exist(string UserName)
        {

            string CommandText = "select * from Account where UserName = '" + UserName + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(CommandText);
            return dt.Rows.Count > 0;
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (Exist(txtUsername.Text))
            {
                lbExist.Visible = true;
            }
            else
            {
                lbExist.Visible = false;
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Space)
            {
                e.Handled = true;

            }
        }

        private void btnDeleteAcc_Click(object sender, EventArgs e)
        {
            string CommandText = "delete Account where UserName = '"+frmLogin.userName+"'";
            DataProvider.Instance.ExecuteQuery(CommandText);
            MessageBox.Show("Xóa Tài Khoản Thành Công Thành Công");
            this.Close();
            MessageBox.Show("Khởi Động Lại Ứng Dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Windows.Forms.Application.Restart();
        }
        string Query(string userName = "", string displayName = "", int type = -1)
        {
            string commandText = "update Account set ";
            if (userName != "")
            {
                commandText += "UserName = '" + userName + "'";
            }
            if (userName != "" && displayName != "")
            {
                commandText += ",";
            }
            
            if (displayName != "")
            {
                commandText += "DisplayName = N'" + displayName + "'";
            }
            if (displayName != "" || userName != "")
            {
                if (type == -1)
                {
                    goto conti;
                }
                commandText += ",";
            }
            
            if (type != -1)
            {
                commandText += "AccountType = '" + type + "'";
            }
            conti:
            commandText += " where UserName = '"+frmLogin.userName+"'";

            if (userName == "" && displayName == "" && type == -1)
            {
                commandText = "";
            }
            return commandText;
        }

        private void btnSaveAcc_Click(object sender, EventArgs e)
        {
            int type = cboAccType.Text == "Giáo Viên" ? 0 : 1;
            if (cboAccType.Text == "")
            {
                type = -1;
            }
            if (Query(txtUsername.Text, txtDisplayName.Text, type) == "")
            {
                MessageBox.Show("Tài Khoản chưa Được Cập nhật Thông Tin gì!");
                return;
            }
            DataProvider.Instance.ExecuteQuery(Query(txtUsername.Text, txtDisplayName.Text, type));
            MessageBox.Show("Cập Nhật Mật Khẩu Thành Công");
            MessageBox.Show("Khởi Động Lại Ứng Dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Windows.Forms.Application.Restart();
        }
    }
}
