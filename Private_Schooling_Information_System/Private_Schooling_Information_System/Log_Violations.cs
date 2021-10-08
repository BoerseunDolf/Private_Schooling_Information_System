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
    public partial class Log_Violations : Form
    {
        // Public variables
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\OneDrive\Documents\CMPG223\Private_Schooling_Information_System\Private_Schooling_Information_System\User_Info.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection conn;
        SqlCommand comm;
        DataSet ds;
        SqlDataAdapter adap;
        public Log_Violations()
        {
            InitializeComponent();
        }

        private void cmbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sql;

                sql = $"SELECT StudentNum, Name, Surname FROM [StudentTable] WHERE StudentGrade = {cmbGrade.SelectedValue.ToString()}";

                adap = new SqlDataAdapter(sql, conn);

                ds = new DataSet();

                adap.Fill(ds, "StudentTable");

                ds.Tables[0].Columns.Add("StudentInfo", typeof(string));

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    row["StudentInfo"] = String.Concat(row["StudentNum"], ", ", row["Name"], " ", row["Surname"]);
                }

                cmbStudent.DisplayMember = "StudentInfo";
                cmbStudent.ValueMember = "StudentNum";
                cmbStudent.DataSource = ds.Tables["StudentTable"];
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }

            //Closing conection to database
            conn.Close();
        }

        private void Log_Violations_Load(object sender, EventArgs e)
        {
            // Connecting String to database
            conn = new SqlConnection(constr);

            PopulateComboBox();
        }

        public void PopulateGrade()
        {
            try
            {
                string sql;

                sql = "SELECT DISTINCT StudentGrade FROM [StudentTable]";

                adap = new SqlDataAdapter(sql, conn);

                //Open conection to database
                conn.Open();

                ds = new DataSet();

                adap.Fill(ds, "StudentTable");


                cmbGrade.DisplayMember = "StudentGrade";
                cmbGrade.ValueMember = "StudentGrade";
                cmbGrade.DataSource = ds.Tables["StudentTable"];

            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public void PopulateViolation()
        {
            try
            {
                string sql;

                sql = "SELECT Ref, Description FROM [ViolationTable]";

                adap = new SqlDataAdapter(sql, conn);

                //Open conection to database
                conn.Open();

                ds = new DataSet();

                adap.Fill(ds, "ViolationTable");

                cmbViolation.DisplayMember = "Description";
                cmbViolation.ValueMember = "Ref";
                cmbViolation.DataSource = ds.Tables["ViolationTable"];

            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public void PopulateComboBox()
        {
            PopulateGrade();
            PopulateViolation();

            //Closing conection to database
            conn.Close();
        }

        private void btnSaveViolation_Click(object sender, EventArgs e)
        {
            //Open conection to database
            conn.Open();

            string sql = "INSERT INTO [ViolationLogTable](StudentNumber, DateOfViolation, ViolationType) VALUES(@StudentNum, @Date, @ViolationType)";
            comm = new SqlCommand(sql, conn);
            comm.Parameters.AddWithValue("@StudentNum", cmbStudent.SelectedValue);
            comm.Parameters.AddWithValue("@Date", monthCalendar1.SelectionStart);
            comm.Parameters.AddWithValue("@ViolationType", cmbViolation.SelectedValue);
            comm.ExecuteNonQuery();

            MessageBox.Show("Violation logged!!");

            //Close connection to database
            conn.Close();
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
