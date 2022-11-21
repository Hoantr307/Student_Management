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
            DataTable dt1 = DataProvider.Instance.ExecuteQuery("select DisplayName From account where UserName = '" + frmLogin.userName + "' and PassWord = '" + frmLogin.passWord + "' and AccountType = " + frmLogin.type);
            foreach (DataRow item in dt1.Rows)
            {
                lbDisplayName.Text = item["DisplayName"].ToString();
            }
        }

        private void frmsearchscore_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit)
            {
                Application.Exit();
            }
        }

        private void tsiProfile_Click(object sender, EventArgs e)
        {
            frmProfile f = new frmProfile();
            f.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePass f = new frmChangePass();
            f.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit(this, new EventArgs());
        }
    }
}
