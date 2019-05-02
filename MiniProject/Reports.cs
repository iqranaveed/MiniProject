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
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace MiniProject
{
    public partial class Reports : Form
    {
        public int Flags = 0;
        SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS ;Initial Catalog=ProjectA;Integrated Security=True");
        SqlDataAdapter adp;
        SqlDataAdapter sda = new SqlDataAdapter();
        int ID = 0;
        int ID1 = 0;

        public Reports()
        {
            InitializeComponent();
        }

        public void Reports_Generation(DataTable dataTable, string destinationpath)
        {
            Document file = new Document();
            PdfWriter writer = PdfWriter.GetInstance(file, new FileStream(destinationpath, FileMode.Create));
            file.Open();

            PdfPTable grid = new PdfPTable(dataTable.Columns.Count);
            grid.WidthPercentage = 100;

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(dataTable.Columns[i].ColumnName));

                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                cell.BackgroundColor = new iTextSharp.text.BaseColor(51, 102, 102);

                grid.AddCell(cell);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(dataTable.Rows[i][j].ToString()));
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    grid.AddCell(cell);
                }
            }

            file.Add(grid);
            file.Close();
        }


      

   

        private void button1_Click_1(object sender, EventArgs e)
        {
            string select = "SELECT Student.Id AS [Student Id], Student.RegistrationNo AS [Registration No], Person.FirstName, Person.LastName FROM (Student JOIN Person ON Student.Id = Person.Id)  ORDER BY Student.Id";
            SqlCommand cmd1 = new SqlCommand(select, con1);
            sda.SelectCommand = cmd1;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Reports_Generation(dt, "Report#3.pdf");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
                string select = "SELECT [Group].Id AS [Group Id], Evaluation.Name,Evaluation.TotalMarks AS [Total Marks], GroupEvaluation.ObtainedMarks AS [Obtained Marks], student.RegistrationNo AS [Registration No]  FROM  (((GroupEvaluation JOIN Evaluation ON  GroupEvaluation.EvaluationId = Evaluation.Id) JOIN [Group] ON [Group].Id = GroupEvaluation.GroupId) JOIN GroupStudent ON GroupStudent.GroupId = [Group].Id) JOIN Student ON Student.Id = GroupStudent.StudentId ";
                SqlCommand cmd = new SqlCommand(select, con1);
                sda.SelectCommand = cmd;
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Reports_Generation(dt, "Report#1.pdf");
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string select = "SELECT Project.Id AS [Project Id], Project.Title AS [Project Title],  ProjectAdvisor.AdvisorId AS [AdvisorId], Student.RegistrationNo AS [Registration No], Person.FirstName AS[Name] FROM (((((Project JOIN ProjectAdvisor ON Project.Id = ProjectAdvisor.ProjectId) JOIN GroupProject ON Project.Id = GroupProject.ProjectId) JOIN [Group] ON [Group].Id = GroupProject.GroupId) JOIN GroupStudent ON [Group].Id = GroupStudent.GroupId) JOIN Student ON Student.Id = GroupStudent.StudentId) JOIN Person ON Student.Id = Person.ProjectId ORDER BY Project.Id";
            SqlCommand cmd1 = new SqlCommand(select, con1);
            sda.SelectCommand = cmd1;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Reports_Generation(dt, "Report#2.pdf");
        }
    }
}


