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
    public partial class Main : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS ;Initial Catalog=ProjectA;Integrated Security=True");
        public Main()
        {
            InitializeComponent();
           

        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student f1 = new Student();
            f1.ShowDialog();
            f1.Close();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Group g = new Group();
            g.ShowDialog();
            g.Close();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Project p = new Project();
            p.ShowDialog();
            p.Close();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Evaluation eval = new Evaluation();
            eval.ShowDialog();
            eval.Close();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Advisor a = new Advisor();
            a.ShowDialog();
            a.Close();
            this.Hide();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
