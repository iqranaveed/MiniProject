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

namespace MiniProject
{
    public partial class GroupStudent : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS ;Initial Catalog=ProjectA;Integrated Security=True");
        public GroupStudent()
        {
            InitializeComponent();
        }
        int ID;
        private void ClearData()
        {
            groupid.Text = "";
            studentid.Text = "";
            comboBox1.Text = "";
            assignmentdate.Text = "";

            ID = 0;
        }
        private void button_1_Click(object sender, EventArgs e)
        {
            //(Select Id from Group where Id = @GroupId)
            // (Select Id from Student where Id = @StudentId)
            con.Open();
            string s1 = "INSERT INTO GroupStudent values(@GroupId, @StudentId, @Status,@AssignmentDate)";
            DateTime t = DateTime.Now;
            SqlCommand cmd1;
            cmd1 = new SqlCommand(s1, con);
            string stat = string.Format("SELECT Id FROM Lookup WHERE Value = 'Active'");
            SqlCommand cmd4;
            cmd4 = new SqlCommand(stat, con);
            int id_g = (Int32)cmd4.ExecuteScalar();
            cmd1.Parameters.AddWithValue("@GroupId", groupid.Text);
            cmd1.Parameters.AddWithValue("@StudentId", studentid.Text);
            cmd1.Parameters.AddWithValue("@Status", id_g);
            cmd1.Parameters.AddWithValue("@AssignmentDate", t);
            

            cmd1.ExecuteNonQuery();

            con.Close();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM GroupStudent", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
            ClearData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Active");
            comboBox1.Items.Add("InActive");
        }

        private void assignmentdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Group g = new Group();
            g.ShowDialog();
            g.Close();
            this.Hide();
        }
    }
}
