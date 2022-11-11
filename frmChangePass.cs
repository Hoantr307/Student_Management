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
    public partial class frmChangePass : Form
    {
        public frmChangePass()
        {
            InitializeComponent();
        }

        bool Exist(string Password)
        {
            return txtPassword.Text == Password;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (!Exist(frmLogin.passWord))
            {
                lbExist.Visible = true;
            }
            else
            {
                lbExist.Visible = false;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Space)
            {
                e.Handled = true;

            }
        }

        private void txtNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Space)
            {
                e.Handled = true;

            }
        }

        private void txtNewRePassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Space)
            {
                e.Handled = true;

            }
        }

        private void btnSavePass_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == txtNewRePassword.Text)
            {
                string query = "Update Account set Password = '" + txtNewPassword.Text + "' where UserName = '" + frmLogin.userName + "'";
                DataProvider.Instance.ExecuteQuery(query);
                this.Close();
            }
            
        }

        private void txtNewRePassword_Leave(object sender, EventArgs e)
        {
            if (txtNewPassword.Text != txtNewRePassword.Text)
            {
                lbnotify.Visible = true;
            }
            else
            {
                lbnotify.Visible = false;
            }
        }
    }
}
