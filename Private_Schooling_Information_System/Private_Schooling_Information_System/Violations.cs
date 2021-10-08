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
    public partial class Violations : Form
    {   
        // Public variables
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\OneDrive\Documents\CMPG223\Private_Schooling_Information_System\Private_Schooling_Information_System\User_Info.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection conn;
        SqlCommand comm;
        DataSet ds;
        SqlDataAdapter adap;
        SqlDataReader read;
        public Violations()
        {
            InitializeComponent();
        }

        private void Violations_Load(object sender, EventArgs e)
        {
            // Connecting String to database
            conn = new SqlConnection(constr);

            try
            {
                string sql;
                //Open conection to database
                conn.Open();

                adap = new SqlDataAdapter();
                ds = new DataSet();

                sql = $"SELECT * FROM [ViolationTable]";
                comm = new SqlCommand(sql, conn);

                //Filling the dataset
                adap.SelectCommand = comm;
                adap.Fill(ds, "Table");

                //Adding data in to data grid
                dataGridView.DataSource = ds;
                dataGridView.DataMember = "Table";

                //Closing conection to database
                conn.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Close form
            this.Close();
        }
    }
}
