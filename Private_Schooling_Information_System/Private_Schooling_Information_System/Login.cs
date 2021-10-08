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
    public partial class Login : Form
    {
        // Public variables
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\OneDrive\Documents\CMPG223\Private_Schooling_Information_System\Private_Schooling_Information_System\User_Info.mdf;Integrated Security = True; Connect Timeout = 30";
        SqlConnection conn;
        SqlCommand comm;
        DataSet ds;
        SqlDataAdapter adap;
        public Login()
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

        private void Login_Load(object sender, EventArgs e)
        {
            // Connecting String to database
            conn = new SqlConnection(constr);

            //Refresh data
            loadAll();
        }

        private void btnLogin2_Click(object sender, EventArgs e)
        {
            /*//Open Log Violations
            Action frmactions = new Action();
            frmactions.Show();
            this.Close();*/
            try
            {
                conn.Open();
                adap = new SqlDataAdapter("SELECT Role FROM TableUserInfo WHERE User_Name = '" + txtUserName.Text + "'AND Password = '" + txtPassword.Text + "'", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    //Open Actions
                    Action frmactions = new Action();
                    frmactions.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect Details! Please Check your Username and Password?");
                }
                conn.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }


        }
    }
}
