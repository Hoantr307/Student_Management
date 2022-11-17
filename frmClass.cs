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
    public partial class frmClass : Form
    {
        public frmClass()
        {
            InitializeComponent();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = $"insert Class values({txtClassID.Text}, N'{txtClassName.Text}')";
                DataProvider.Instance.ExecuteQuery(Query);
                frmClass_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn Nhập Sai Dữ Liệu Sinh Viên! Yêu Cầu Nhập Lại!");
            }
        }

        private void frmClass_Load(object sender, EventArgs e)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Class");
            dgvClasses.DataSource = data;
        }

        private void dgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtClassID.Text = dgvClasses.CurrentRow.Cells[0].Value.ToString();
            txtClassName.Text = dgvClasses.CurrentRow.Cells[1].Value.ToString();
            dgvClasses.CurrentRow.ContextMenuStrip = contextMenuStrip;
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            string Query = $"Update Class Set ClassName =  N'{txtClassName.Text}' where ClassID = {txtClassID.Text}";
            DataProvider.Instance.ExecuteQuery(Query);

            frmClass_Load(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = $"delete Class where ClassID = {txtClassID.Text}";
                DataProvider.Instance.ExecuteQuery(Query);
                frmClass_Load(sender, e);
            }
            catch (Exception)
            {

                MessageBox.Show("Bạn chưa thể xóa lớp này!");
            }
            
        }
    }
}
