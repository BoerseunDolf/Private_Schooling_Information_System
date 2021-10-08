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
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;
using ExcelLibrary.BinaryDrawingFormat;
using ExcelLibrary.BinaryFileFormat;

namespace Private_Schooling_Information_System
{
    public partial class Report : Form
    {
        // Public variables
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\OneDrive\Documents\User_Info.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection conn;
        SqlCommand comm;
        DataSet ds;
        SqlDataAdapter adap;

        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
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

        public void PopulateComboBox()
        {
            PopulateGrade();

            //Closing conection to database
            conn.Close();
        }

        private void cmbGrade_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            //Open conection to database
            conn.Open();

            //Report for all students
            if (rbtnAllStudents.Checked)
            {
                adap = new SqlDataAdapter();
                ds = new DataSet();

                sql = $"SELECT s.StudentNum, s.[Name], s.[Surname], ISNULL(0 - SUM(v.[Penalty]), 0) Balance FROM[StudentTable] S LEFT JOIN[ViolationLogTable] vl   ON s.StudentNum = vl.StudentNumber  LEFT JOIN[ViolationTable] v  ON vl.ViolationType = v.Ref GROUP BY s.StudentNum, s.[Name], s.[Surname]";
                comm = new SqlCommand(sql, conn);

                //Filling the dataset
                adap.SelectCommand = comm;
                adap.Fill(ds, "Table");

                //Adding data in to data grid
                dataGridView.DataSource = ds;
                dataGridView.DataMember = "Table";
            }
            else 
            {
                //Report for slected students
                adap = new SqlDataAdapter();
                ds = new DataSet();

                sql = $"SELECT s.StudentNum, s.[Name], s.[Surname], vl.[DateOfViolation], v.[Description], v.[Penalty] FROM[ViolationLogTable] vl INNER JOIN[StudentTable] s ON vl.StudentNumber = s.StudentNum INNER JOIN[ViolationTable] v ON vl.ViolationType = v.Ref WHERE s.StudentNum = { cmbStudent.SelectedValue.ToString() } ";
                comm = new SqlCommand(sql, conn);

                //Filling the dataset
                adap.SelectCommand = comm;
                adap.Fill(ds, "Table");

                //Add balance table
                ds.Tables[0].Columns.Add("Balance");

                int balance = 0;

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    balance -= int.Parse(row["Penalty"].ToString());
                    row["Balance"] = balance;
                }

                //Adding data in to data grid
                dataGridView.DataSource = ds;
                dataGridView.DataMember = "Table";
            }
            //Closing conection to database
            conn.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Open Log Violations
            Action frmactions = new Action();
            frmactions.Show();
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            
                //create new xls file                
                ExcelLibrary.DataSetHelper.CreateWorkbook("MyStudentReport.xls",ds);

                    /*string file = "Report.xls";
                    Workbook workbook = new Workbook(); 
                    Worksheet worksheet = new Worksheet("First Sheet"); 
                    worksheet.Cells[0, 0] = new Cell("Table"); 
                    worksheet.Cells[0, 2] = new Cell(9999999);
                    worksheet.Cells[0, 3] = new Cell((decimal)3.45); 
                    worksheet.Cells[0, 4] = new Cell("Text string");
                    worksheet.Cells[0, 5] = new Cell("Second string"); 
                    worksheet.Cells[0, 6] = new Cell(32764.5, "#,##0.00");
                    worksheet.Cells[0, 7] = new Cell(DateTime.Now, @"YYYY-MM-DD"); 
                    worksheet.Cells.ColumnWidth[0, 1] = 3000; 
                    workbook.Worksheets.Add(worksheet); 
                    workbook.Save(file);*/

                    //open xls file
                    /*Workbook book = Workbook.Load(file); 
                    Worksheet sheet = book.Worksheets[0];*/
        }
    }
}
