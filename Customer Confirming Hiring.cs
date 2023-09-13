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
    
    public partial class CustomerConfirmingHiring : Form
    {
        private string laborerID;
        private string customerID;
        private string workDays, registrationFee, wage;
        private string customerBalance;


        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public CustomerConfirmingHiring()
        {
            InitializeComponent();

            button1.Visible = false;
            button4.Visible =false;


            this.WindowState = FormWindowState.Maximized;

            this.BackgroundImage = Properties.Resources.Bridge;

            panel2.BackgroundImage= Properties.Resources.pattern1;
            this.Text = "Customer Confirming Hiring";



            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd;
            string query = "select balance from logintable where id=(select id from loggedinuserinfo);";

         

            cmd = new SqlCommand(query, con);
            

            con.Open();


            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            if(dr.HasRows==true)
            {

                this.customerBalance=dr.GetValue(0).ToString();
                label9.Text = dr.GetString(0);
            }

            con.Close();
         



                //Name of the laborer



                BindGridView();

           


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

            this.customerBalance = (Convert.ToInt32(this.customerBalance) - Convert.ToInt32(label18.Text)).ToString();


            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd;


            string query;


            query = " update dealings set CustomerOK='true' where LaborerID=@laborerID and CustomerID=(select id from loggedinuserinfo) and ManagerOK='true' and CustomerOK='';";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@laborerID", this.laborerID);
            con.Open();
            int x = cmd.ExecuteNonQuery();
            con.Close();

            query = " update laborertable set hirerid=(select id from loggedinuserinfo), hiredtimes = hiredtimes+1, potentialcustomerid=''  where id=@laborerID and potentialcustomerid=(select id from loggedinuserinfo) and hirerid='Pending';";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@laborerID", this.laborerID);
            con.Open();
            int y = cmd.ExecuteNonQuery();
            con.Close();

            query = " update logintable set balance=@customerBalance where id=(select id from loggedinuserinfo);";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@customerBalance", this.customerBalance);
            con.Open();
            int z = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();



            if (x != 0 && y != 0)
            {
                DialogResult d = MessageBox.Show("Deal Confirmed", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (d == DialogResult.OK)
                {
                    BindGridView();

                }




            }


            button1.Visible = false;
            button4.Visible = false;
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
            Form6 f = new Form6(); f.Show(); this.Visible = false;
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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd;
           

            string query;


            query = "select laborername 'Name', id 'I.D.' , job 'Job' from laborertable where potentialcustomerid=(select id from loggedinuserinfo) and hirerid='Pending';";

                  cmd = new SqlCommand(query, con);
                con.Open();
                
                con.Close();
             

            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;

           

             dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
             dataGridView1.RowTemplate.Height = 70;

            this.dataGridView1.Font = new Font("Comic Sans MS", 11, FontStyle.Bold);


            con.Close();
            cmd.Dispose();




        }

        private void button4_Click(object sender, EventArgs e)
        {
             
            //comboBox1.Text = "";

            pictureBox1.Image = Properties.Resources.head;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            try
            {
                button1.Visible = true;
                button4.Visible = true;


                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd;
                string query = "select (select laborertable.laborername from laborertable where id=@laborerID), (select laborertable.id from laborertable where id=@laborerID) ,(select laborertable.rating   from laborertable where id=@laborerID)  ,(select laborertable.hiredtimes 'Experience' from laborertable where id=@laborerID)   ,(select laborertable.picture from laborertable where id=@laborerID), workdays, price, wage,(select laborertable.job from laborertable where id=@laborerID) from Dealings where Laborerid=@laborerID and CustomerID=(select id from loggedinuserinfo) and Status='Started'   and ManagerOK='true';";
                this.laborerID = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@laborerID", laborerID);

                con.Open();


                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows == true)
                {
                    dr.Read();



                    label9.Text = dr.GetString(0); //Name of the laborer
                    label13.Text = dr.GetString(8); //Job of the Laborer
                    label8.Text = dr.GetValue(2).ToString(); //Rating of the Laborer

                    label11.Text = dr.GetString(3); //Experience of the Laborer

                    label17.Text = dr.GetString(5); //Workdays of the Laborer

                    label18.Text = dr.GetString(6); //Hiring fee of the Laborer

                    label19.Text = dr.GetString(7); //Wage of the laborer

                    try { if (dr.GetValue(4) != null) { pictureBox1.Image = getPhoto((byte[])dr.GetValue(4)); } }
                    catch (System.InvalidCastException) { pictureBox1.Image = Properties.Resources.NullPicture; }

                    dr.Close();

                }






                con.Close();cmd.Dispose();
            }

            catch (System.InvalidCastException)
            {
                button1.Visible = false;
                button4.Visible = false;

                
            }
            catch (System.ArgumentOutOfRangeException)
            {
                button1.Visible = false;
                button4.Visible = false;
            }



        }

        Image getPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);

            return Image.FromStream(ms);



        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd;


            string query;


            query = " update dealings set CustomerOK='false' where LaborerID=@laborerID and CustomerID=(select id from loggedinuserinfo) and ManagerOK='true' and CustomerOK='';";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@laborerID", this.laborerID);
            con.Open();
            int x = cmd.ExecuteNonQuery();
            con.Close();

            query = " update laborertable set hirerid='', potentialcustomerid=''  where id=@laborerID and potentialcustomerid=(select id from loggedinuserinfo) and hirerid='Pending';";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@laborerID", this.laborerID);
            con.Open();
            int y = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();


            if (x != 0 && y != 0)
            {
                DialogResult d = MessageBox.Show("Deal Cancelled", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (d == DialogResult.OK)
                {
                    BindGridView();

                }




            }


            button1.Visible = false;
            button4.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Cornsilk;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.CornflowerBlue;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.Cornsilk;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.CornflowerBlue;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Cornsilk;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.CornflowerBlue;
        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
