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
    public partial class frmSubject : Form
    {
        public frmSubject()
        {
            InitializeComponent();
            txtKeyword.Text = "Tên Môn Học";
            txtKeyword.ForeColor = Color.Gray;
        }

        

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            
            try
            {
                string Query = $"insert Subject values('{txtSubjectID.Text}', N'{txtSubjectName.Text}', {txtLessonNumber.Text}, '{cboTeachers.SelectedValue}', {cboSemester.Text})";
                DataProvider.Instance.ExecuteQuery(Query);
                frmSubject_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn Nhập Sai Dữ Liệu Môn Học! Yêu Cầu Nhập Lại!");
            }

        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            string query = $"update Subject set SubjectName = N'{txtSubjectName.Text}', LessonNumber = {txtLessonNumber.Text}, TeacherID = {cboTeachers.SelectedValue}, Semester = {cboSemester.Text} Where SubjectID = '{txtSubjectID.Text}'";
            DataProvider.Instance.ExecuteQuery(query);
            frmSubject_Load(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = $"delete Subject Where SubjectID = '{txtSubjectID.Text}'";
            DataProvider.Instance.ExecuteQuery(query);
            txtSubjectID.Text = "";
            txtSubjectName.Text = "";
            txtLessonNumber.Text = "";
            cboTeachers.Text = "";
            cboSemester.Text = "";
            frmSubject_Load(sender, e);
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSubject.Rows)
            {
                if (row.Cells[1].Value.ToString().Contains(txtKeyword.Text))
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
                txtKeyword.Text = "Tên Môn Học";
                txtKeyword.ForeColor = Color.Gray;
            }
        }

        private void txtKeyword_Enter(object sender, EventArgs e)
        {
            if (txtKeyword.Text == "Tên Môn Học")
            {
                txtKeyword.Text = "";
                txtKeyword.ForeColor = Color.Black;
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            frmReportSubject f = new frmReportSubject();
            f.ShowDialog();
            f.WindowState = FormWindowState.Maximized;
            f.StartPosition = FormStartPosition.CenterParent;
        }

        private void tsbExcel_Click(object sender, EventArgs e)
        {
            if (dgvSubject.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                XcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvSubject.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dgvSubject.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgvSubject.Rows.Count; i++)
                {

                    for (int j = 0; j < dgvSubject.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dgvSubject.Rows[i].Cells[j].Value.ToString();
                    }
                }

                /*XcelApp.Cells[dgvSubject.Rows.Count + 4, 1] = "Người Lập danh sách";
                XcelApp.Cells[dgvSubject.Rows.Count + 4, 5] = "Ký và Ghi rõ họ tên";*/
                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;
            }
        }

        private void cboTeachers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Subject where TeacherID = "+ cboTeachers.SelectedValue);
            dgvSubject.DataSource = data;

        }

        private void frmSubject_Load(object sender, EventArgs e)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Subject");
            dgvSubject.DataSource = data;
            DataTable dt = DataProvider.Instance.ExecuteQuery("select * from Teacher");
            cboTeachers.DataSource = dt;
            cboTeachers.DisplayMember = "TeacherName";
            cboTeachers.ValueMember = "TeacherID";
        }

        private void dgvSubject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSubjectID.Text = dgvSubject.CurrentRow.Cells[0].Value.ToString();
            txtSubjectName.Text = dgvSubject.CurrentRow.Cells[1].Value.ToString();
            txtLessonNumber.Text = dgvSubject.CurrentRow.Cells[2].Value.ToString();
            cboTeachers.Text = dgvSubject.CurrentRow.Cells[3].Value.ToString();
            cboSemester.Text = dgvSubject.CurrentRow.Cells[4].Value.ToString();

            dgvSubject.CurrentRow.ContextMenuStrip = contextMenuStrip;
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubject_Load(sender, e);
            txtSubjectID.Text = "";
            txtSubjectName.Text = "";
            txtLessonNumber.Text = "";
            cboTeachers.Text = "";
            cboSemester.Text = "";
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
                        if (dgvSubject.ColumnCount == data.Columns.Count)
                        {
                            dgvSubject.Columns.Clear();
                            dgvSubject.DataSource = data;
                            txtFileName.Text = ofd.FileName;
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
