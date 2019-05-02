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
    
    public partial class Evaluation : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS ;Initial Catalog=ProjectA;Integrated Security=True");
        public Evaluation()
        {
            InitializeComponent();
        }
        int ID;
        private void ClearData()
        {
            name.Text = "";
            totalmarks.Text = "";
            totalweightage.Text = "";
            
            
            ID = 0;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            ID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            totalweightage.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            totalmarks.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string s1 = "INSERT INTO Evaluation values(@Name,@TotalMarks, @TotalWeightage)";
            SqlCommand cmd1;
            cmd1 = new SqlCommand(s1, con);
           
            cmd1.Parameters.AddWithValue("@Name", firstname1.Text);
            cmd1.Parameters.AddWithValue("@TotalMarks", totalmarks.Text);
            cmd1.Parameters.AddWithValue("@TotalWeightage", totalweightage.Text);
            

            cmd1.ExecuteNonQuery();

            con.Close();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Evaluation", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
            ClearData();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd;
            cmd = new SqlCommand("UPDATE dbo.Evaluation SET Name = '" + name.Text + "', TotalMarks = '" + totalmarks.Text + "' , TotalWeightage = '" + totalweightage + "' WHERE @Id = ID", con);
            cmd.Parameters.AddWithValue("@Id", ID);
            cmd.Parameters.AddWithValue("@TotalMarks", totalmarks.Text);
            cmd.Parameters.AddWithValue("@TotalWeightage", totalweightage.Text);



            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            con.Close();



            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Evaluation", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd;
            // SqlCommand cmd1;
            cmd = new SqlCommand("DELETE FROM dbo.Evaluation WHERE ID = @Id ", con);


            cmd.Parameters.AddWithValue("@Id", ID);


            cmd.ExecuteNonQuery();
            // cmd1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record deleted Successfully");


            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Evaluation", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main m = new Main();
            m.ShowDialog();
            m.Close();
            this.Hide();
        }
    }
}
