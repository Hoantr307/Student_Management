using ExcelDataReader;
using Student_Management.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            cboGender.Text = dgvTeacher.CurrentRow.Cells[2].Value.ToString() == "Nam" ? "Nam" : "Nữ";
            txtPhone.Text = dgvTeacher.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dgvTeacher.CurrentRow.Cells[4].Value.ToString();
            cboLevel.Text = dgvTeacher.CurrentRow.Cells[5].Value.ToString();

            dgvTeacher.CurrentRow.ContextMenuStrip = contextMenuStrip;
        }

        private void btnDelete_Click(object sender, EventArgs e)
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

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            frmReportTeacher f = new frmReportTeacher();
            f.Show();
        }

        private void tsbExcel_Click(object sender, EventArgs e)
        {
            if (dgvTeacher.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                XcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvTeacher.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dgvTeacher.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgvTeacher.Rows.Count; i++)
                {
                    
                    for (int j = 0; j < dgvTeacher.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dgvTeacher.Rows[i].Cells[j].Value.ToString();
                    }
                }

                XcelApp.Cells[dgvTeacher.Rows.Count + 4, 1] = "Người Lập danh sách";
                XcelApp.Cells[dgvTeacher.Rows.Count + 4, 5] = "Ký và Ghi rõ họ tên";
                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;
            }
        }

        private void tsbImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel File|*.xlsx|Excel File 97-2003|*.xls", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DataSet ds;
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        txtFilePath.Text = ofd.FileName;
                        IExcelDataReader reader;
                        if (ofd.FilterIndex == 2)
                        {
                            reader = ExcelReaderFactory.CreateBinaryReader(stream);
                        }
                        else
                        {
                            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        }

                        ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });


                        DataTable data = ds.Tables[0];
                        if (dgvTeacher.ColumnCount == data.Columns.Count)
                        {
                            dgvTeacher.Columns.Clear();
                            dgvTeacher.DataSource = data;
                            txtFilePath.Text = ofd.FileName;
                        }
                        else
                        {
                            MessageBox.Show("File Excel Bạn Vừa Chọn Không Chứa Được Trong Bảng");
                        }

                        reader.Close();

                    }
                }
            }
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTeacher_Load(sender, e);
        }
    }
}
