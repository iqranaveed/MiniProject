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
    public partial class Advisor : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS ;Initial Catalog=ProjectA;Integrated Security=True");
        public Advisor()
        {
            InitializeComponent();
        }
        int ID = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            ID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            salary.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1;
            SqlCommand cmd2;
            string gId = string.Format("SELECT Lookup.Id From Lookup WHERE Value = '{0}'", comboBox1.Text);
            SqlCommand cmd3 = new SqlCommand(gId, con);
            int g = (Int32)cmd3.ExecuteScalar();
            cmd1 = new SqlCommand("insert into [Person] (FirstName, LastName, Contact, Email, DateOfBirth, gender) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text+ "','" + g + "')", con);
            string designation_Id = string.Format("SELECT Lookup.Id From Lookup WHERE Value = '{0}'", comboBox2.Text);
            SqlCommand cmd = new SqlCommand(designation_Id, con);
            int d_Id = (Int32)cmd.ExecuteScalar();
            cmd2 = new SqlCommand("insert into Advisor(Advisor.Id, Designation, Salary) values ( (SELECT MAX(Person.Id) From Person),'" + d_Id + "','" + salary.Text + "')", con);

            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Inserted Successfully");
           


            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Advisor", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
           // ClearData();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd;
            cmd = new SqlCommand("UPDATE dbo.Advisor SET Designation = '" + comboBox1.Text + "', Salary = '" + salary.Text + "' WHERE @Id = ID", con);
            string designation = string.Format("SELECT Id FROM Lookup WHERE Value = 'Professor' OR Value = 'Associate Professor' OR Value = 'Assistant Professor' OR Value = 'Lecturer' OR Value = 'Industry Professional'");
            SqlCommand cmd4;
            cmd4 = new SqlCommand(designation, con);
            int id_des = (Int32)cmd4.ExecuteScalar();
            cmd.Parameters.AddWithValue("@Id", ID);
            cmd.Parameters.AddWithValue("@Designation", id_des);
            cmd.Parameters.AddWithValue("@Salary", salary.Text);



            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            con.Close();



            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Advisor", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Professor");
            comboBox1.Items.Add("Associate Professor");
            comboBox1.Items.Add("Assistant Professor");
            comboBox1.Items.Add("Lecturer");
            comboBox1.Items.Add("Industry Professional");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main m = new Main();
            m.ShowDialog();
            m.Close();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Advisor", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            //ClearData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd;
            // SqlCommand cmd1;
            cmd = new SqlCommand("DELETE FROM dbo.Person WHERE ID = @Id ", con); 


            cmd.Parameters.AddWithValue("@Id", ID);


            cmd.ExecuteNonQuery();
            // cmd1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record deleted Successfully");


            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Advisor", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProjectAdvisor pa = new ProjectAdvisor();
            pa.ShowDialog();
            pa.Close();
            this.Hide();
        }
    }
}
