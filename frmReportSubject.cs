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
    public partial class frmReportSubject : Form
    {
        public frmReportSubject()
        {
            InitializeComponent();
        }

        private void frmReportSubject_Load(object sender, EventArgs e)
        {
            Report.reportSubject rpt = new Report.reportSubject();
            rpt.SetDataSource(DataProvider.Instance.ExecuteQuery("select * from Subject"));
            crvSubject.ReportSource = rpt;
            crvSubject.RefreshReport();

        }
    }
}
