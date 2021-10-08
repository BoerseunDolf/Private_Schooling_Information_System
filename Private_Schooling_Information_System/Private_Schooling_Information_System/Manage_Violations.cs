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
    public partial class Manage_Violations : Form
    {
        // Public variables
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\OneDrive\Documents\CMPG223\Private_Schooling_Information_System\Private_Schooling_Information_System\User_Info.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection conn;
        SqlCommand comm;
        DataSet ds;
        SqlDataAdapter adap;
        SqlDataReader read;
        public Manage_Violations()
        {
            InitializeComponent();
        }

        private void btnViewViolations_Click(object sender, EventArgs e)
        {
            //Open Violations
            Violations frmShowViolation = new Violations();
            frmShowViolation.Show();
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

                sql = $"SELECT * FROM [ViolationTable] ";
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

        private void Manage_Violations_Load(object sender, EventArgs e)
        {
            // Connecting String to database
            conn = new SqlConnection(constr);

            //Load data
            loadAll();
        }

        private void btnAddViolation_Click(object sender, EventArgs e)
        {
            //Open conection to database
            conn.Open();

            string sql = "INSERT INTO [ViolationTable](Description, Penalty) VALUES(@des, @pen)";
            comm = new SqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@des", txtViolationdescrip.Text);
            comm.Parameters.AddWithValue("@pen", numUpDown.Text);
            comm.ExecuteNonQuery();

            //Close connection to database
            conn.Close();

            MessageBox.Show("Violation successfully added");

            txtViolationdescrip.Text = "";
            numUpDown.Text = "0";

            //Refresh data
            loadAll();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //Open connection
            conn.Open();

            string sql = "DELETE FROM [ViolationTable] WHERE Ref = @ref ";
            comm = new SqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@ref", txtRemove.Text);
            comm.ExecuteNonQuery();

            //Close connection
            conn.Close();

            MessageBox.Show("Violation record successfully removed");

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Back to action
            Action frmactions = new Action();
            frmactions.Show();
            this.Close();
        }
    }
}
