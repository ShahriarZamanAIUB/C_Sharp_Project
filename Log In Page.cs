using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApp5
{
    public partial class Form3 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form3()
        {
             
            InitializeComponent(); this.Text = "Log In";
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Properties.Resources.LG;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool CheckStatus = checkBox1.Checked;
            switch (CheckStatus)
            {

                case true: textBox2.UseSystemPasswordChar = false; break;

                case false: textBox2.UseSystemPasswordChar = true; break;


                default: break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")
            {
               

                SqlConnection con = new SqlConnection(cs);

                string query = "select usertype, pass,picture from logintable where username=@name and pass=@password;";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", textBox1.Text);

                cmd.Parameters.AddWithValue("@password", textBox2.Text);

                

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                 

                if ( dr.HasRows==true)
                {

                    DialogResult d = MessageBox.Show("Log In Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (d == DialogResult.OK)

                        dr.Read();
                    string UserType = dr.GetString(0);
                    string Password = dr.GetString(1);
                    dr.Close();

                    





                    SqlConnection con2 = new SqlConnection(cs);

                    string query2 = "update loggedinuserinfo set username=@Name,phonenumber=(select phonenumber from logintable where username=@Name), location=(select location from logintable where username=@Name), age=(select age from logintable where username=@Name), pass=@Password,id=(select id from logintable where username=@Name),  Picture=(select Picture from logintable where username=@Name)  ;";

                    SqlCommand cmd2 = new SqlCommand(query2, con2);

                    cmd2.Parameters.AddWithValue("@Name", textBox1.Text);

                    cmd2.Parameters.AddWithValue("@Password", Password);

                    // cmd2.Parameters.AddWithValue("@Image", ImagemByte);



                    con2.Open();
                    int y = cmd2.ExecuteNonQuery();
                    con2.Close();
                    con2.Dispose();







                    if (UserType == "Admin")
                            { Form5 f = new Form5(); f.Show(); this.Visible = false; }

                            else if (UserType == "Manager")
                            { Form7 f = new Form7(); f.Show(); this.Visible = false; }

                            else  if(UserType == "Customer") { Form6 f = new Form6(); f.Show(); this.Visible = false; }



                         



                    
                     
















                }

                else { MessageBox.Show("Log In Failed", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                con.Close();
                con.Dispose();

            }

            

            else { MessageBox.Show("Enter the fields first", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); }



        }
        public string ExecuteQuery(string query, SqlCommand cmd)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            object i = cmd.ExecuteScalar();
            return i.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(); f.Show(); this.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.CornflowerBlue;

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.CornflowerBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
        }
    }
}
