using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class Student : Form
    {
        
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS ;Initial Catalog=ProjectA;Integrated Security=True");
        public Student()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //checking whether reg number already exist
        public void RegNoCheck()
        {
            //string constring = ConfigurationManager.ConnectionStrings["ConnData"].ConnectionString;
           //SqlConnection con = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand("Select * from Student WHERE RegistrationNo = @RegistrationNo", con);
            cmd.Parameters.AddWithValue("@RegistrationNo", this.regno.Text);
            con.Open();
            int TotalRows = 0;
            TotalRows = Convert.ToInt32(cmd.ExecuteScalar());
            if (TotalRows > 0)
            {
                MessageBox.Show("RegistrationNo Already exists");
                return;
            }
          //  SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
              //  if (dr.HasRows == true)
                //{
                  //  MessageBox.Show("RegistrationNo = " + dr[3].ToString() + "Already exists");
                    //return;
              //  }
                //return;
            //}
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (firstname.Text == "" || lastname.Text == "" || regno.Text == "" || email.Text == "" || dob.Text == "" || comboBox1.Text == "" || contact.Text == "")
            {
                firstname.BackColor = Color.LightBlue;
                lastname.BackColor = Color.LightBlue;
                regno.BackColor = Color.LightBlue;
                contact.BackColor = Color.LightBlue;
                email.BackColor = Color.LightBlue;
                dob.BackColor = Color.LightBlue;
                comboBox1.BackColor = Color.LightBlue;
                MessageBox.Show("Please enter details! Do not leave the fields empty.");
                return;
            }
            if (contact.Text == "")
            {
                contact.BackColor = Color.LightBlue;
                MessageBox.Show("Please enter contact number!");
                return;
            }
            else
            {
                int outcontact;
                if (!int.TryParse(contact.Text, out outcontact))
                {
                    contact.BackColor = Color.LightBlue;
                    MessageBox.Show("Please enter contact number again.It must be all integers.");
                    return;
                }
            }
            if (email.Text == "")
            {
                contact.BackColor = Color.LightBlue;
                MessageBox.Show("Please enter your email!");
                return;
            }
            else
            {
                System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

                if (email.Text.Length > 0)

                {

                    if (!rEMail.IsMatch(email.Text))

                    {

                        MessageBox.Show("E-Mail expected in the correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                }

            }

            RegNoCheck();
            con.Close();
            string s1 = "INSERT INTO Person values(@FirstName,@LastName,@Contact, @Email, @DateOfBirth,@Gender)";
            string s2 = "INSERT INTO Student values(@Id, @RegistrationNo)";
            con.Open();
            SqlCommand cmd1;
            SqlCommand cmd2;
            cmd1 = new SqlCommand(s1, con);
            cmd2 = new SqlCommand(s2, con);
            string id = string.Format("SELECT max(Id) FROM Person");
            SqlCommand cmd3 = new SqlCommand(id, con);
            string gender_id = string.Format("SELECT Id FROM Lookup WHERE Value = 'Male' OR Value = 'Female'");
            SqlCommand cmd4;
            cmd4 = new SqlCommand(gender_id, con);
            int id_g = (Int32)cmd4.ExecuteScalar();
            int id1 = (Int32)cmd3.ExecuteScalar();
            cmd2.Parameters.AddWithValue("@Id", id1);
            cmd1.Parameters.AddWithValue("@FirstName", firstname.Text);
            cmd1.Parameters.AddWithValue("@LastName", lastname.Text);
            cmd2.Parameters.AddWithValue("@RegistrationNo", regno.Text);
            cmd1.Parameters.AddWithValue("@Contact", contact.Text);
            cmd1.Parameters.AddWithValue("@Email", email.Text);
            cmd1.Parameters.AddWithValue("@DateOfBirth", dob.Text);
            cmd1.Parameters.AddWithValue("@Gender", id_g);

            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();

            con.Close();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Person,Student", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
            ClearData();



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        int ID = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            ID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            firstname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            lastname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            regno.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            contact.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            email.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            dob.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void ClearData()
        {
            firstname.Text = "";
            lastname.Text = "";
            regno.Text = "";
            contact.Text = "";
            email.Text = "";
            dob.Text = "";

            ID = 0;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

          ///  con.Open();
            //SqlCommand cmd;
           // SqlCommand cmd1;
         //   cmd = new SqlCommand("UPDATE dbo.Person SET FirstName = '" + firstname.Text + "', LastName = '" + lastname.Text + "', Contact = '" + contact.Text + "', Email = '" + email.Text + "',DateOfBirth = '" + dob.Text + "', Gender = '" + comboBox1.Text + "' WHERE @Id = ID", con);
            //cmd1 = new SqlCommand("UPDATE dbo.Student SET RegistrationNo = '" + regno.Text + "'", con);
            //string gender_id = string.Format("SELECT Id FROM Lookup WHERE Value = 'Male' OR Value = 'Female'");
           // SqlCommand cmd4;
           // cmd4 = new SqlCommand(gender_id, con);
           // int id_g = (Int32)cmd4.ExecuteScalar();
           // cmd.Parameters.AddWithValue("@Id", ID);
           // cmd.Parameters.AddWithValue("@FirstName", firstname.Text);
           // cmd.Parameters.AddWithValue("@LastName", lastname.Text);
           // cmd1.Parameters.AddWithValue("@RegistrationNo", regno.Text);
           // cmd.Parameters.AddWithValue("@Contact", contact.Text);
           // cmd.Parameters.AddWithValue("@Email", email.Text);
           // cmd.Parameters.AddWithValue("@DateOfBirth", dob.Text);
           // cmd.Parameters.AddWithValue("@Gender", id_g);



           // cmd.ExecuteNonQuery();
           // cmd1.ExecuteNonQuery();
            //MessageBox.Show("Record Updated Successfully");
            //con.Close();


            
           // SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Person,Student", con);
           // DataTable dt = new DataTable();
           // sda.Fill(dt);
           // dataGridView1.DataSource = dt;
           // ClearData();
            //this.Hide();
            //Form2 f2 = new Form2();
            //f2.ShowDialog();
            //f2.Close();
            //this.Hide();


        }

        private void button3_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Delete from Person where Id = "+dataGridView1.Rows[selectedid].Cells[0].Value;
            cmd.CommandText = "Delete from Student where Id = " + dataGridView1.Rows[selectedid].Cells[0].Value;
            cmd.ExecuteNonQuery();
            con.Close();
            dataGridView1.Rows.RemoveAt(selectedid);
            MessageBox.Show("Record deleted Successfully");
            con.Close();
            // SqlCommand cmd1;
            //  cmd = new SqlCommand("DELETE FROM dbo.Person WHERE ID = @Id ", con);// SET FirstName = '" + firstname.Text + "', LastName = '" + lastname.Text + "', Contact = '" + contact.Text + "', Email = '" + email.Text + "', DateOfBirth = '" + dob.Text + "'", con);
            //cmd1 = new SqlCommand("DELETE FROM dbo.Student WHERE ID =@Id", con); //SET RegistrationNo = '" + regno.Text + "'", con);


            //  cmd.Parameters.AddWithValue("@Id", ID);


            //  cmd.ExecuteNonQuery();
            // cmd1.ExecuteNonQuery();
            // con.Close();
            // MessageBox.Show("Record deleted Successfully");


           // SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Person,Student", con);
          //  DataTable dt = new DataTable();
          //  sda.Fill(dt);
          //  dataGridView1.DataSource = dt;
          //  ClearData();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");
            //con.Open();
            //string combo = "SELECT Id FROM Lookup";
            //SqlCommand combo1 = new SqlCommand(combo, con);
            //SqlDataReader myreader;
            //myreader = combo1.ExecuteReader();
            //while(myreader.Read())
            //{
            //  string combo2 = myreader.GetString("Male");
            // comboBox1.Items.Add(combo2);
            //}

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearData();
            comboBox1.SelectedIndex = -1;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Person,Student", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            ClearData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main m = new Main();
            m.ShowDialog();
            m.Close();
            this.Hide();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           // dataGridView1.Rows[e.RowIndex].Cells[0].Value = "Delete";

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int selectedid = 0;
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectedid = e.RowIndex;


        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                firstname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                lastname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                regno.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                contact.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                email.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                dob.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                con.Open();
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = con;
                sqlcommand.CommandText = "UPDATE dbo.Person SET FirstName = '" + firstname.Text + "', LastName = '" + lastname.Text + "', Contact = '" + contact.Text + "', Email = '" + email.Text + "',DateOfBirth = '" + dob.Text + "', Gender = '" + comboBox1.Text + "' WHERE Id = "+id;
                sqlcommand.CommandText = "UPDATE dbo.Student SET RegistrationNo = '" + regno.Text + "' where Id = "+ id;
                sqlcommand.ExecuteNonQuery();
                con.Close();

            }
            catch(Exception ex)
            {

            }
        }
    }
}
    

//select id from lookup where id = 'Male'