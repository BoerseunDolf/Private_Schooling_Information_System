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
    public partial class Welcome1 : Form
    {
        public Welcome1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Open Login Page
            Login frmLogin = new Login();
            frmLogin.Show();
            this.Hide();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            //Open Sign Up Page
            Sign_Up frmSign_Up = new Sign_Up();
            frmSign_Up.Show();
            this.Hide();
        }

        private void btnLearn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You need to sign up if you are a first time user, if you alredy signed up click on the Login button");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
