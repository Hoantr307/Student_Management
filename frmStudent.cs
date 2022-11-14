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
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
            txtKeyword.Text = "Mã Sinh Viên";
            txtKeyword.ForeColor = Color.Gray;
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Student");
            dgvStudent.DataSource = data;
            DataTable dt = DataProvider.Instance.ExecuteQuery("select * from Class");
            cboClassID.DataSource = dt;
            cboClassID.DisplayMember = "ClassName";
            cboClassID.ValueMember = "ClassID";
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = $"insert Student values('{txtStudentID.Text}', N'{txtStudentName.Text}', '{txtBirth.Text}',N'{cboGender.Text}', '{txtAddress.Text}', N'{cboClassID.Text}')";
                DataProvider.Instance.ExecuteQuery(Query);
                frmStudent_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn Nhập Sai Dữ Liệu Sinh Viên! Yêu Cầu Nhập Lại!");
            }

        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            string query = $"update Student set " +
                $"StudentName = N'{txtStudentName.Text}', Birthday = '{txtBirth.Text}', Gender = N'{cboGender.Text}', Address = N'{txtAddress.Text}', ClassID = {cboClassID.Text} where StudentID = {txtStudentID.Text}";
            DataProvider.Instance.ExecuteQuery(query);
            frmStudent_Load(sender, e);
        }



        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStudentID.Text = dgvStudent.CurrentRow.Cells[0].Value.ToString();
            txtStudentName.Text = dgvStudent.CurrentRow.Cells[1].Value.ToString();
            txtBirth.Text = dgvStudent.CurrentRow.Cells[2].Value.ToString();
            cboGender.Text = dgvStudent.CurrentRow.Cells[3].Value.ToString();
            txtAddress.Text = dgvStudent.CurrentRow.Cells[4].Value.ToString();
            cboClassID.Text = dgvStudent.CurrentRow.Cells[5].Value.ToString();

            dgvStudent.CurrentRow.ContextMenuStrip = contextMenuStrip;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = $"delete Student where StudentID = '{txtStudentID.Text}'";
            DataProvider.Instance.ExecuteQuery(query);
            txtStudentID.Text = "";
            txtStudentName.Text = "";
            txtBirth.Text = "";
            cboGender.Text = "";
            txtAddress.Text = "";
            cboClassID.Text = "";
            frmStudent_Load(sender, e);
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvStudent.Rows)
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
                txtKeyword.Text = "Mã Sinh Viên";
                txtKeyword.ForeColor = Color.Gray;
            }
        }

        private void txtKeyword_Enter(object sender, EventArgs e)
        {
            if (txtKeyword.Text == "Mã Sinh Viên")
            {
                txtKeyword.Text = "";
                txtKeyword.ForeColor = Color.Black;
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            frmReportStudent f = new frmReportStudent();
            f.Show();
        }

        private void tsbExcel_Click(object sender, EventArgs e)
        {
            if (dgvStudent.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                XcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvStudent.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dgvStudent.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgvStudent.Rows.Count; i++)
                {

                    for (int j = 0; j < dgvStudent.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dgvStudent.Rows[i].Cells[j].Value.ToString();
                    }
                }

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
                        if (dgvStudent.ColumnCount == data.Columns.Count)
                        {
                            dgvStudent.Columns.Clear();
                            dgvStudent.DataSource = data;
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

       

       
    }
}
