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
    public partial class frmScoreManage : Form
    {
        public frmScoreManage()
        {
            InitializeComponent();
            txtKeyword.Text = "Mã Sinh Viên";
            txtKeyword.ForeColor = Color.Gray;
        }

        private void frmTeacher_Load(object sender, EventArgs e)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from teacher");
            dgvStudents.DataSource = data;
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
            txtTeacherID.Text = dgvStudents.CurrentRow.Cells[0].Value.ToString();
            txtTeacherName.Text = dgvStudents.CurrentRow.Cells[1].Value.ToString();
            cboGender.Text = dgvStudents.CurrentRow.Cells[2].Value.ToString();
            txtPhone.Text = dgvStudents.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dgvStudents.CurrentRow.Cells[4].Value.ToString();
            cboLevel.Text = dgvStudents.CurrentRow.Cells[5].Value.ToString();

            dgvStudents.CurrentRow.ContextMenuStrip = contextMenuStrip;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = $"delete student where StudentID = '{txtTeacherID.Text}'";
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
            foreach (DataGridViewRow row in dgvStudents.Rows)
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

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbExcel_Click(object sender, EventArgs e)
        {
            if (dgvStudents.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                XcelApp.Application.Workbooks.Add(Type.Missing);
                XcelApp.Cells[1, 4] = "Danh Sách Giảng Viên";
                for (int i = 1; i < dgvStudents.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[2, i] = dgvStudents.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgvStudents.Rows.Count; i++)
                {

                    for (int j = 0; j < dgvStudents.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 3, j + 1] = dgvStudents.Rows[i].Cells[j].Value.ToString();
                    }
                }

                XcelApp.Cells[dgvStudents.Rows.Count + 4, 1] = "Người Lập danh sách";
                XcelApp.Cells[dgvStudents.Rows.Count + 4, 5] = "Ký và Ghi rõ họ tên";
                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;
            }
        }
    }
}
