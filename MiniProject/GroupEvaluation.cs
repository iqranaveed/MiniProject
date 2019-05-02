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
    public partial class GroupEvaluation : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS ;Initial Catalog=ProjectA;Integrated Security=True");
        public GroupEvaluation()
        {
            InitializeComponent();
        }

        int ID = 0;

        

        private void ClearData()
        {
            obtainedmarks.Text = "";
            evaluationdate.Text = "";
            

            ID = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string s2 = "INSERT INTO GroupEvaluation values(@GroupId, @EvaluationId,@ObtainedMarks,@EvaluationDate )";
            SqlCommand cmd2;
            SqlCommand cmd1;
            cmd1 = new SqlCommand(s2, con);
            cmd2 = new SqlCommand(s2, con);
            string ev = string.Format("SELECT Id FROM Evaluation WHERE Id = '" + comboBox2.Text + "'");
            string id = string.Format("SELECT Id FROM [Group] WHERE Id = '"+comboBox1.Text+"'");
            SqlCommand cmd4;
            SqlCommand cmd3;
            cmd3 = new SqlCommand(ev, con);
            cmd4 = new SqlCommand(id, con);
            int ev_id = (Int32)cmd3.ExecuteScalar();
            int id_g = (Int32)cmd4.ExecuteScalar();
            cmd2.Parameters.AddWithValue("@GroupId", id_g);
            cmd2.Parameters.AddWithValue("@EvaluationId", ev_id);
            cmd2.Parameters.AddWithValue("@ObtainedMarks", obtainedmarks.Text);
            cmd2.Parameters.AddWithValue("@EvaluationDate", evaluationdate.Text);

            cmd2.ExecuteNonQuery();

            con.Close();
            //SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Person,Student", con);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);

            //dataGridView1.DataSource = dt;
            ClearData();

        }
    
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd;
            comboBox1.Items.Clear();
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Id FROM [Group]";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["Id"].ToString());
            }
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd;
            comboBox1.Items.Clear();
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Id FROM Evaluation";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["Id"].ToString());
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Evaluation m = new Evaluation();
            m.ShowDialog();
            m.Close();
            this.Hide();
        }
    }
}
