using Student_Management.DAO;
using Student_Management.Report;
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
    public partial class frmReportStudent : Form
    {
        public frmReportStudent()
        {
            InitializeComponent();
        }

        private void frmReportStudent_Load(object sender, EventArgs e)
        {
            reportStudent rpt = new reportStudent();
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select * from Student");
            rpt.SetDataSource(dt);
            crvStudent.ReportSource = rpt;
            crvStudent.RefreshReport();
        }
    }
}
