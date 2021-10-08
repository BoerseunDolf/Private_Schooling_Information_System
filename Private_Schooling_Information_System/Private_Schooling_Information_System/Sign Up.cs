using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Private_Schooling_Information_System
{
    public partial class Sign_Up : Form
    {
        // Public variables
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\OneDrive\Documents\CMPG223\Private_Schooling_Information_System\Private_Schooling_Information_System\User_Info.mdf;Integrated Security = True; Connect Timeout = 30";
        SqlConnection conn;
        SqlCommand comm;
        DataSet ds;
        SqlDataAdapter adap;
        public Sign_Up()
        {
            InitializeComponent();
        }

        private void loadAll()
        {
            try
            {
                string sql;
                //Open conection to database
                conn.Open();

                adap = new SqlDataAdapter();
                ds = new DataSet();

                sql = $"SELECT * FROM [TableUserInfo ] ";
                comm = new SqlCommand(sql, conn);

                //Filling the dataset
                adap.SelectCommand = comm;
                adap.Fill(ds, "Table");

               //Closing conection to database
                conn.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Sign_Up_Load(object sender, EventArgs e)
        {
            // Connecting String to database
            conn = new SqlConnection(constr);
        }

        private void btnSignUp2_Click(object sender, EventArgs e)
        {
            //Compare passwords if Passwords match add data to data base   
            if (txtPassword2.Text == txtConfirmPassword.Text )
            {
                //Random nuber for ID
                Random random = new Random();
                int Id = random.Next(99) * 999;

                //Open conection to database
                conn.Open();

                string sql = "INSERT INTO [TableUserInfo](User_Name, Password, Name, Surname, EmailAddress, Role, Unique_Number) VALUES(@userName, @password, @name, @surname, @email, @role, @uni_num)";
                comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@userName", txtUserName2.Text);
                comm.Parameters.AddWithValue("@password", txtPassword2.Text);
                comm.Parameters.AddWithValue("@name", txtName.Text);
                comm.Parameters.AddWithValue("@surname", txtSurname.Text);
                comm.Parameters.AddWithValue("@email", txtEmail.Text);
                comm.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString());
                comm.Parameters.AddWithValue("@uni_num", txtUniqueNum.Text);
                comm.ExecuteNonQuery();

                //Close connection to database
                conn.Close();

                //Refresh data
                loadAll();

                //Success messgae
                MessageBox.Show("You sucessfully signed up, please go to the login page to login");

                //Close window
                Welcome1 frmwelcome = new Welcome1();
                frmwelcome.Show();
                this.Close();
            }
            //Compare passwords if Passwords do not match do not add data to data base show message box
            else if (txtPassword2.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Cancel Sign Up
            Welcome1 frmwelcome = new Welcome1();
            frmwelcome.Show();
            this.Close();
        }
    }
}
