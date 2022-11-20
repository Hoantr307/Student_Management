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
    public partial class frmSearchScore : Form
    {
        public frmSearchScore()
        {
            InitializeComponent();
        }

        public bool isExit = true;
        public event EventHandler Exit;

        private void frmsearchscore_Load(object sender, EventArgs e)
        {
            lbStudentID.Text = frmLogin.userName;
            DataTable dt = DataProvider.Instance.ExecuteQuery("select * from student where studentID = "+ lbStudentID.Text);
            foreach (DataRow item in dt.Rows)
            {
                lbStudentName.Text = item["StudentName"].ToString();
                LbClassID.Text = item["ClassID"].ToString();
            }

            DataTable data = DataProvider.Instance.ExecuteQuery("select SubjectID, ScoreAvg, ScoreElement, ScorePractice, ScoreFinal, Conduct, Description from result where studentID = " + lbStudentID.Text); 
            dgvScores.DataSource = data;
        }

        private void frmsearchscore_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit)
            {
                Application.Exit();
            }
        }
    }
}
