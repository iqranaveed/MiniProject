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
    public partial class ProjectAdvisor : Form
    {
        public int Flagg = 0;
        public int Flagg2 = 0;
        SqlCommand cmd1;
        SqlCommand cmd2;
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS ;Initial Catalog=ProjectA;Integrated Security=True");
        int ID = 0;
        int ID1 = 0;

        public ProjectAdvisor()
        {

            InitializeComponent();
            Flagg = 0;
        }
        public ProjectAdvisor(int f)
        {
            InitializeComponent();
            Flagg = f;
            Flagg2 = f;
        }

        private void DisplayGroup()
        {
            SqlDataAdapter adp;
            con.Open();
            DataTable dt = new DataTable();
            adp = new SqlDataAdapter("SELECT AdvisorId, ProjectId, Title, AdvisorRole, AssignmentDate FROM ProjectAdvisor JOIN Project ON ProjectAdvisor.ProjectId = Project.Id", con);
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            DataGridViewButtonColumn UpData;
            UpData = new DataGridViewButtonColumn();
            UpData.HeaderText = "Update";
            UpData.Text = "Update";
            UpData.UseColumnTextForButtonValue = true;
            UpData.Width = 60;
            dataGridView1.Columns.Add(UpData);
            int b = 0;
            while (b < dataGridView1.Rows.Count)
            {
                dataGridView1.Rows[b].Cells[0].ReadOnly = true;
                b++;
            }
            DataGridViewButtonColumn DeleteData;
            DeleteData = new DataGridViewButtonColumn();
            DeleteData.HeaderText = "Delete";
            DeleteData.Text = "Delete";
            DeleteData.UseColumnTextForButtonValue = true;
            DeleteData.Width = 60;
            dataGridView1.Columns.Add(DeleteData);
            int a = 0;
            while (a < dataGridView1.Rows.Count)
            {
                dataGridView1.Rows[a].Cells[0].ReadOnly = true;
                a++;
            }
            con.Close();
        }

        private void ProjectAdvisor_Load(object sender, EventArgs e)
        {
            fillcombo();
            DisplayGroup();
        }
        public void fillcombo()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Title from [dbo].[Project]", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            comboBox2.DisplayMember = "Title";
            comboBox2.DataSource = dt;

            con.Close();
        }
        bool projectId()
        {
            bool a = false;
            if (comboBox1.Text == "")
            {
                a = true;
                return a;
            }
            return a;
        }
        bool adRole()
        {
            bool b = false;
            if (comboBox2.Text == "")
            {
                b = true;
                return b;
            }
            return b;
        }

        bool adId()
        {
            bool b = false;
            if (textBox2.Text == "")
            {
                b = true;
                return b;
            }
            return b;
        }
        bool StId_Exists(int A_Id, string P_Id)
        {
            con.Open();
            bool a = false;
            SqlDataAdapter sda = new SqlDataAdapter("Select * from ProjectAdvisor Join Project ON ProjectAdvisor.ProjectId = Project.Id", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["AdvisorId"]) == A_Id && (row["Title"].ToString()) == P_Id)
                {
                    con.Close();
                    return true;
                }
            }
            con.Close();
            return a;
        }
        private void ClearData()
        {
            textBox2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";

            ID = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool x = adId();
            if (x == false)
            {
                bool a = projectId();
                if (a == false)
                {
                    bool t = adRole();
                    if (t == false)
                    {
                        bool c = StId_Exists(Convert.ToInt32(textBox2.Text), comboBox2.Text);
                        if (c == false)
                        {
                            if (Flagg2 == 0)
                            {
                                con.Open();
                                string ProjectId = string.Format("SELECT Id From Project WHERE Title = '{0}'", comboBox2.Text);
                                SqlCommand cmd = new SqlCommand(ProjectId, con);
                                int p = (Int32)cmd.ExecuteScalar();

                                string RoleId = string.Format("SELECT Id From Lookup WHERE Value = '{0}'", comboBox1.Text);
                                SqlCommand cmd2 = new SqlCommand(RoleId, con);
                                int s = (Int32)cmd2.ExecuteScalar();
                                DateTime time = DateTime.Now;
                                cmd2 = new SqlCommand("insert into ProjectAdvisor(AdvisorId, ProjectId, AdvisorRole, AssignmentDate) values ('" + textBox2.Text + "','" + p + "','" + s + "' , @time)", con);
                                cmd2.Parameters.AddWithValue("@time", time);
                                //int gI = Convert.ToInt32(comboBox1.Text);
                                cmd2.ExecuteNonQuery();
                                MessageBox.Show("Inserted Successfully");
                                con.Close();
                                this.Hide();
                                ProjectAdvisor f4 = new ProjectAdvisor();
                                f4.ShowDialog();
                                this.Close();
                            }
                            if (Flagg2 > 0)
                            {
                                con.Open();
                                string ProjectId = string.Format("SELECT Id From Project WHERE Title = '{0}'", comboBox2.Text);
                                SqlCommand cmd = new SqlCommand(ProjectId, con);
                                int p = (Int32)cmd.ExecuteScalar();

                                string RoleId = string.Format("SELECT Id From Lookup WHERE Value = '{0}'", comboBox1.Text);
                                SqlCommand cmd2 = new SqlCommand(RoleId, con);
                                int s = (Int32)cmd2.ExecuteScalar();
                                DateTime time = DateTime.Now;
                                cmd2 = new SqlCommand("UPDATE ProjectAdvisor set AdvisorId = @AdvisorId , ProjectId = @ProjectId, AdvisorRole = @AdvisorRole, AssignmentDate = @AssignmentDate WHERE AdvisorId = @d1 AND ProjectId = @d2", con);
                                cmd2.Parameters.AddWithValue("@d1", Flagg2);
                                cmd2.Parameters.AddWithValue("@d2", ID1);
                                cmd2.Parameters.AddWithValue("@AdvisorId", Convert.ToInt32(textBox2.Text));
                                cmd2.Parameters.AddWithValue("@ProjectId", Convert.ToInt32(p));
                                cmd2.Parameters.AddWithValue("@AdvisorRole", s);
                                cmd2.Parameters.AddWithValue("@AssignmentDate", time);
                                cmd2.ExecuteNonQuery();
                                MessageBox.Show("Updated successfully Successfully");
                                con.Close();
                                this.Hide();
                                ProjectAdvisor f4 = new ProjectAdvisor();
                                f4.ShowDialog();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("This project is already assigned to this Advisor");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Select Advisor role");
                    }
                }
                else
                {
                    MessageBox.Show("First add projects");
                }
            }
            else
            {
                MessageBox.Show("Select Addvisor");
            }
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM ProjectAdvisor", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            ClearData();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports f1 = new Reports();
            f1.ShowDialog();
            f1.Close();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main g = new Main();
            g.ShowDialog();
            g.Close();
            this.Hide();
        }
    }
}



        

    
       
    
       

      

      