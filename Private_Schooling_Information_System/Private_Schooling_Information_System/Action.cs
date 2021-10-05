using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Private_Schooling_Information_System
{
    public partial class Action : Form
    {
        public Action()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Open Manage Violations
            Manage_Violations frmManageViolation = new Manage_Violations();
            frmManageViolation.Show();
            this.Close();
        }

        private void btnLogViolation_Click(object sender, EventArgs e)
        {
            //Open Log Violations
            Log_Violations frmLogViolation = new Log_Violations();
            frmLogViolation.Show();
            this.Close();
        }

        private void btnPullReport_Click(object sender, EventArgs e)
        {
            //Open Report
            Report frmReport = new Report();
            frmReport.Show();
            this.Close();
        }
    }
}
