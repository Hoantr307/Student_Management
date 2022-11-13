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
    public partial class frmReportTeacher : Form
    {
        public frmReportTeacher()
        {
            InitializeComponent();
        }

        private void frmReportTeacher_Load(object sender, EventArgs e)
        {
            Report.reportTeacher rpt = new Report.reportTeacher();
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select * from Teacher");
            rpt.SetDataSource(dt);
            crvTeacher.ReportSource = rpt;
            crvTeacher.RefreshReport();
        }
    }
}
