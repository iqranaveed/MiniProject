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
    public partial class Project : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS ;Initial Catalog=ProjectA;Integrated Security=True");
        public Project()
        {
            InitializeComponent();
        }
        int ID;
        private void ClearData()
        {
            titlebox.Text = "";
            descriptionbox.Text = "";

            ID = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            titlebox.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            descriptionbox.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string s1 = "INSERT INTO Project values(@Title,@Description)";
            SqlCommand cmd1;
            cmd1 = new SqlCommand(s1, con);


            cmd1.Parameters.AddWithValue("@Title", titlebox.Text);
            cmd1.Parameters.AddWithValue("@Description", descriptionbox.Text);


            cmd1.ExecuteNonQuery();


            con.Close();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Project", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
            ClearData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (titlebox.Text != "" && descriptionbox.Text != "")
            {
                

                con.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("UPDATE dbo.Project SET Title ='" + titlebox.Text + "', Description = '" + descriptionbox.Text + "' WHERE ID = @Id", con);
                
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@Title", titlebox.Text);
                cmd.Parameters.AddWithValue("@Description", descriptionbox.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();







                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Project", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                ClearData();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Project", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            ClearData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main m = new Main();
            m.ShowDialog();
            m.Close();
            this.Hide();
        }
    }
}
