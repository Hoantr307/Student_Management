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
        }

        private void frmTeacher_Load(object sender, EventArgs e)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Teacher");
            dgvTeacher.DataSource = data;
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            string Query = $"insert Teacher values('{txtTeacherID.Text}', N'{txtTeacherName.Text}', N'{cboGender.Text}', '{txtPhone.Text}', '{txtEmail.Text}', N'{cboLevel.Text}')";
            DataProvider.Instance.ExecuteQuery(Query);
            frmTeacher_Load(sender, e);
        }
    }
}
