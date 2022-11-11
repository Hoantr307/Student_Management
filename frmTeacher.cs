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
    public partial class frmTeacher : Form
    {
        public frmTeacher()
        {
            InitializeComponent();
            txtKeyword.Text = "Mã Giảng Viên";
            txtKeyword.ForeColor = Color.Gray;
        }

        private void frmTeacher_Load(object sender, EventArgs e)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Teacher");
            dgvTeacher.DataSource = data;
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = $"insert Teacher values('{txtTeacherID.Text}', N'{txtTeacherName.Text}', N'{cboGender.Text}', '{txtPhone.Text}', '{txtEmail.Text}', N'{cboLevel.Text}')";
                DataProvider.Instance.ExecuteQuery(Query);
                frmTeacher_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn Nhập Sai Dữ Liệu Giảng Viên! Yêu Cầu Nhập Lại!");
            }
            
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            string query = $"update Teacher set TeacherName = N'{txtTeacherName.Text}', Gender = N'{cboGender.Text}', Phone = '{txtPhone.Text}', Email = '{txtEmail.Text}', TeacherType = N'{cboLevel.Text}' where TeacherID = '{txtTeacherID.Text}'";
            DataProvider.Instance.ExecuteQuery(query);
            frmTeacher_Load(sender, e);
        }

        

        private void dgvTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTeacherID.Text = dgvTeacher.CurrentRow.Cells[0].Value.ToString();
            txtTeacherName.Text = dgvTeacher.CurrentRow.Cells[1].Value.ToString();
            cboGender.Text = dgvTeacher.CurrentRow.Cells[2].Value.ToString();
            txtPhone.Text = dgvTeacher.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dgvTeacher.CurrentRow.Cells[4].Value.ToString();
            cboLevel.Text = dgvTeacher.CurrentRow.Cells[5].Value.ToString();

            dgvTeacher.CurrentRow.ContextMenuStrip = contextMenuStrip;
        }

        private void xóaGiảngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query = $"delete Teacher where TeacherID = '{txtTeacherID.Text}'";
            DataProvider.Instance.ExecuteQuery(query);
            txtTeacherID.Text = "";
            txtTeacherName.Text = "";
            cboGender.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            cboLevel.Text = "";
            frmTeacher_Load(sender, e);
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTeacher.Rows)
            {
                if (row.Cells[0].Value.ToString().Contains(txtKeyword.Text))
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        private void txtKeyword_Leave(object sender, EventArgs e)
        {
            if (txtKeyword.Text == "")
            {
                txtKeyword.Text = "Mã Giảng Viên";
                txtKeyword.ForeColor = Color.Gray;
            }
        }

        private void txtKeyword_Enter(object sender, EventArgs e)
        {
            if (txtKeyword.Text == "Mã Giảng Viên")
            {
                txtKeyword.Text = "";
                txtKeyword.ForeColor = Color.Black;
            }
        }
    }
}
