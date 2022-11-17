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
    public partial class frmReportScore : Form
    {
        public frmReportScore()
        {
            InitializeComponent();
        }

        private void frmReportScore_Load(object sender, EventArgs e)
        {
            reportScoreManage rpt = new reportScoreManage();
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select * from Result");
            rpt.SetDataSource(dt);
            crvScore.ReportSource = rpt;
            crvScore.RefreshReport();
        }

        private void crvClass_Load(object sender, EventArgs e)
        {

        }
    }
}
