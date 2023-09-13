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
    
    public partial class Registration : Form
    {
        string id;
        string usercount, registrationrevenue;

        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Registration()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            comboBox1.Items.Add("Dhaka");
            comboBox1.Items.Add("Khulna");
            comboBox1.Items.Add("Mymensingh");
            comboBox1.Items.Add("Sylhet");
            comboBox1.Items.Add("Rajshahi");
            comboBox1.Items.Add("Rangpur");
            comboBox1.Items.Add("Barishal");
            comboBox1.Items.Add("Chittagong");


            this.Text = "Customer Registration";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private byte[] SavePhoto()
        {

            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms,pictureBox1.Image.RawFormat);

            return ms.GetBuffer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool X = false;


            SqlConnection connW = new SqlConnection(cs);

            string qryW = "select username from logintable where username=@n;";

            SqlCommand scmdW = new SqlCommand(qryW, connW);


            scmdW.Parameters.AddWithValue("@n", textBox1.Text);


            connW.Open();

            SqlDataReader sdrW = scmdW.ExecuteReader();
            sdrW.Read();


            if (sdrW.HasRows == true)
            {
                X = true;


            }
            connW.Close();
            scmdW.Dispose();


            if (textBox1.Text != "" && textBox3.Text != "" && textBox5.Text != "" && textBox6.Text != "" && X == false)
            {
                SqlConnection conn = new SqlConnection(cs);

                string qry = "SELECT TOP 1 id FROM logintable  ORDER BY id desc;";

                SqlCommand scmd = new SqlCommand(qry, conn);





                conn.Open();

                SqlDataReader sdr = scmd.ExecuteReader();
                sdr.Read();


                if (sdr.HasRows == true)
                {
                    id = sdr.GetString(0);

                    this.id = (Convert.ToInt32(id.Trim(new Char[] { 'C' })) + 1).ToString() + 'C';
                }
                conn.Close();


                SqlConnection con = new SqlConnection(cs);

                string query = "insert into logintable values(@name, @id, @age, @phoneNumber, @location, @picture, @pass,'20000','Customer')";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", textBox1.Text);

                cmd.Parameters.AddWithValue("@id", id);


                cmd.Parameters.AddWithValue("@age", numericUpDown1.Text);

                cmd.Parameters.AddWithValue("@phoneNumber", textBox3.Text);

                cmd.Parameters.AddWithValue("@location", comboBox1.Text);

                cmd.Parameters.AddWithValue("@picture", SavePhoto());

                cmd.Parameters.AddWithValue("@pass", textBox5.Text);


                con.Open();


                int x = cmd.ExecuteNonQuery();


                if (x != 0)
                {
                    DialogResult d = MessageBox.Show("Registration Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (d == DialogResult.OK)
                    {
                        SqlConnection con2 = new SqlConnection(cs);

                        string query2 = "update loggedinuserinfo set username=@name, pass=@password, age=@age, location=@location, phonenumber=@phonenumber, id=@id, picture=(select Picture from logintable where username=@name);";

                        SqlCommand cmd2 = new SqlCommand(query2, con2);

                        cmd2.Parameters.AddWithValue("@name", textBox1.Text);

                        cmd2.Parameters.AddWithValue("@password", textBox5.Text);

                        cmd2.Parameters.AddWithValue("@id", id);

                        cmd2.Parameters.AddWithValue("@age", numericUpDown1.Text);

                        cmd2.Parameters.AddWithValue("@location", comboBox1.Text);

                        cmd2.Parameters.AddWithValue("@phoneNumber", textBox3.Text);



                        con2.Open();
                        int x2 = cmd2.ExecuteNonQuery();
                        con2.Close();
                        cmd2.Dispose();

                        //dr.Close();




                        SqlConnection connection = new SqlConnection(cs);

                        string Query = "select customercount,  revenue from report;";

                        SqlCommand command = new SqlCommand(Query, connection);





                        connection.Open();

                        SqlDataReader datareader = command.ExecuteReader();
                        datareader.Read();


                        if (datareader.HasRows == true)
                        {
                            usercount = datareader.GetString(0);

                            usercount = (Convert.ToInt32(usercount) + 1).ToString();

                            registrationrevenue = datareader.GetString(1);

                            registrationrevenue = (Convert.ToInt32(registrationrevenue) + 5000).ToString();


                        }
                        connection.Close();

                        SqlConnection conx = new SqlConnection(cs);

                        string queryx = "update report set  customercount=@usercount, revenue=@registrationrevenue;";



                        SqlCommand cmdx = new SqlCommand(queryx, conx);

                        cmdx.Parameters.AddWithValue("@usercount", usercount);
                        cmdx.Parameters.AddWithValue("@registrationrevenue", registrationrevenue);



                        // cmd2.Parameters.AddWithValue("@Image", ImagemByte);



                        conx.Open();
                        int xx = cmdx.ExecuteNonQuery();
                        conx.Close();
                        cmdx.Dispose();


                        Form6 f = new Form6(); f.Show(); this.Visible = false;

                    }

                    con.Close();


                }

                else { MessageBox.Show("Registration Unuccessful", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                con.Close();
                cmd.Dispose();



            }

            else if (X == true)
            { MessageBox.Show("This Username Already Belongs to Another User", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); textBox1.Text = ""; }

            else { MessageBox.Show("Fill Up All The Fields Properly", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);   }









        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool CheckStatus = checkBox1.Checked;
            switch (CheckStatus)
            {

                case true: textBox5.UseSystemPasswordChar = false; textBox6.UseSystemPasswordChar = false;  break;

                case false: textBox5.UseSystemPasswordChar = true; textBox6.UseSystemPasswordChar = true; break;


                default: break;

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(); f.Show(); this.Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image File (All files) *.* | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.CornflowerBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.CornflowerBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.CornflowerBlue;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
