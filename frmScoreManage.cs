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
    public partial class frmScoreManage : Form
    {
        public frmScoreManage()
        {
            InitializeComponent();
            txtKeyword.Text = "Mã Sinh Viên";
            txtKeyword.ForeColor = Color.Gray;
        }

        

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = $"insert Result values(" +
                    $"'{txtStudentID.Text}', N'{txtStudentName.Text}', '{cboClasses.SelectedValue}', '{cboSubject.SelectedValue}', {txtScoreAvg.Text}, {txtScoreElement.Text}, {txtScorePractice.Text}, {txtScoreFinal.Text}, N'{cboConduct.Text}', N'{txtDescription.Text}')";
                DataProvider.Instance.ExecuteQuery(Query);
                frmScoreManage_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn Nhập Sai Dữ Liệu Sinh Viên! Yêu Cầu Nhập Lại!");
            }

        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            string query = $"update Result set ClassID = {cboClasses.SelectedValue}, SubjectID = '{cboSubject.SelectedValue}', " +
                $"ScoreAvg = {txtScoreAvg.Text}, ScoreElement = {txtScoreElement.Text}, ScorePractice = {txtScorePractice.Text}, " +
                $"ScoreFinal = {txtScoreFinal.Text}, Conduct = N'{cboConduct.Text}',Description = N'{txtDescription.Text}' " +
                $"where StudentID = {txtStudentID.Text}";
            DataProvider.Instance.ExecuteQuery(query);
            frmScoreManage_Load(sender, e);
        }



        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = $"delete Result where StudentID = {txtStudentID.Text} ";
            DataProvider.Instance.ExecuteQuery(query);
            txtStudentID.Text = "";
            txtStudentName.Text = "";
            cboClasses.SelectedIndex = -1;
            cboSubject.SelectedIndex = -1;
            txtScoreAvg.Text = "";
            txtScoreElement.Text = "";
            txtScorePractice.Text = "";
            txtScoreFinal.Text = "";
            cboConduct.SelectedIndex = -1;
            txtDescription.Text = "";
            
            frmScoreManage_Load(sender, e);
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvScores.Rows)
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
            
        }

        private void tsbExcel_Click(object sender, EventArgs e)
        {
            if (dgvScores.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                XcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvScores.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dgvScores.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgvScores.Rows.Count; i++)
                {

                    for (int j = 0; j < dgvScores.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dgvScores.Rows[i].Cells[j].Value.ToString();
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
                        if (dgvScores.ColumnCount == data.Columns.Count)
                        {
                            dgvScores.Columns.Clear();
                            dgvScores.DataSource = data;
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

        private void dgvScores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStudentID.Text = dgvScores.CurrentRow.Cells[0].Value.ToString();
            txtStudentName.Text = dgvScores.CurrentRow.Cells[1].Value.ToString();
            cboClasses.Text = dgvScores.CurrentRow.Cells[2].Value.ToString();
            cboSubject.Text = dgvScores.CurrentRow.Cells[3].Value.ToString();
            txtScoreAvg.Text = dgvScores.CurrentRow.Cells[4].Value.ToString();
            txtScoreElement.Text = dgvScores.CurrentRow.Cells[5].Value.ToString();
            txtScorePractice.Text = dgvScores.CurrentRow.Cells[6].Value.ToString();
            txtScoreFinal.Text = dgvScores.CurrentRow.Cells[7].Value.ToString();
            cboConduct.Text = dgvScores.CurrentRow.Cells[8].Value.ToString();
            txtDescription.Text = dgvScores.CurrentRow.Cells[9].Value.ToString();

            dgvScores.CurrentRow.ContextMenuStrip = contextMenuStrip;
        }

        private void txtStudentID_Leave(object sender, EventArgs e)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("select StudentName, ClassID from Student where StudentID = " + txtStudentID.Text);
            foreach (DataRow item in dt.Rows)
            {
                txtStudentName.Text = item["StudentName"].ToString();
            }
        }

        private void frmScoreManage_Load(object sender, EventArgs e)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("GetResult");
            dgvScores.DataSource = data;
            DataTable dt = DataProvider.Instance.ExecuteQuery("select * from Class");
            cboClasses.DataSource = dt;
            cboClasses.DisplayMember = "ClassName";
            cboClasses.ValueMember = "ClassID";
            DataTable dt1 = DataProvider.Instance.ExecuteQuery("select * from Subject");
            cboSubject.DataSource = dt1;
            cboSubject.DisplayMember = "SubjectName";
            cboSubject.ValueMember = "SubjectID";
        }
    }
}
