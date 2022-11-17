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
    public partial class frmReportClass : Form
    {
        public frmReportClass()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmReportClass_Load(object sender, EventArgs e)
        {
            reportClass rpt = new reportClass();
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select * from Class");
            rpt.SetDataSource(dt);
            crvClass.ReportSource = rpt;
            crvClass.RefreshReport();
        }
    }
}
