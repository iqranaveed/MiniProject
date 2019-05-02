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
using System.Globalization;
using System.Threading;

namespace MiniProject
{
    public partial class Group : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS ;Initial Catalog=ProjectA;Integrated Security=True");
        public Group()
        {
            InitializeComponent();
        }
        int ID = 0;
        private void ClearData()
        {
            
            ID = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string s1 = "INSERT INTO [Group] values(@Created_On)";

            SqlCommand cmd1;
            cmd1 = new SqlCommand(s1, con);
            DateTime Created_On = DateTime.Now;
            cmd1.Parameters.AddWithValue("@Created_On", Created_On);


            cmd1.ExecuteNonQuery();
            

            con.Close();
           // SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Group", con);
           // DataTable dt = new DataTable();
           // sda.Fill(dt);

            //dataGridView1.DataSource = dt;
            ClearData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GroupStudent gs = new GroupStudent();
            gs.ShowDialog();
            gs.Close();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            GroupEvaluation ge = new GroupEvaluation();
            ge.ShowDialog();
            ge.Close();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            GroupProject gp = new GroupProject();
            gp.ShowDialog();
            gp.Close();
            this.Hide();
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
