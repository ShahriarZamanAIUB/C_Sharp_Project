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
    
    public partial class LaborerRecruit : Form
    {
        string id;
         

        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public LaborerRecruit()
        {
            this.WindowState = FormWindowState.Maximized;

            


            InitializeComponent();
            this.Text = "Customer Selecting Laborers for Hiring";
            comboBox1.Text = "All";
            comboBox1.Items.Add("Security Guard");
            comboBox1.Items.Add("Houseworker");
            comboBox1.Items.Add("Welder");
            comboBox1.Items.Add("Mason");
            comboBox1.Items.Add("Factory Worker");
            comboBox1.Items.Add("Janitor");
            comboBox1.Items.Add("Porter");
            comboBox1.Items.Add("Mechanic");
            comboBox1.Items.Add("Electrician");
            comboBox1.Items.Add("Plumber");
            comboBox1.Items.Add("All");

            comboBox2.Text = "None";
            comboBox2.Items.Add("Rating");
            comboBox2.Items.Add("Age");
            comboBox2.Items.Add("Experience");
            comboBox2.Items.Add("None");

            button1.Visible = false;
            this.panel2.BackgroundImage = Properties.Resources.pattern3;
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
             DialogResult d = MessageBox.Show("Confirm Application", "?", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (d == DialogResult.OK)
            {
                try
                {
                    
                   


                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd;
                    string query = "update laborertable set potentialcustomerid=(select id from loggedinuserinfo) where id=@id ;";
                    cmd = new SqlCommand(query, con);


                    


                    cmd.Parameters.AddWithValue("@id", this.id);

                    con.Open();
                    int x = cmd.ExecuteNonQuery();
                    con.Close();
                    BindGridView();
                }
                catch (System.NullReferenceException) { DialogResult dS = MessageBox.Show("Invalid Selection", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); Form6 f = new Form6(); f.Show(); this.Visible = false; }

            }

            else { Form6 f = new Form6(); f.Show(); this.Visible = false; }  
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

            if (comboBox1.Text != "All" && comboBox2.Text != "None")
            {
                if (comboBox2.Text == "Experience") { query = "select laborername,id, age,rating, job,hiredtimes, picture from laborertable where job= '" + comboBox1.Text + "' and (hirerid=null or hirerid='') and  (potentialcustomerid=null or potentialcustomerid='') order by hiredtimes desc;"; }
                else { query = "select laborername, id, age,rating, job,hiredtimes, picture from laborertable where job= '" + comboBox1.Text + "' and (hirerid=null or hirerid='') or  (potentialcustomerid=null and potentialcustomerid='')  order by " + comboBox2.Text + " desc;"; }

                 cmd = new SqlCommand(query, con);

                


               


            }

            else if (comboBox1.Text != "All" && comboBox2.Text == "None") 
            {
                query = "select laborername, id, age,rating, job,hiredtimes, picture from laborertable where job= '" + comboBox1.Text+ "' and (hirerid=null or hirerid='') and  (potentialcustomerid=null or potentialcustomerid='');";

                cmd = new SqlCommand(query, con);

                 

                 
            }

            else if (comboBox1.Text == "All" && comboBox2.Text != "None")
            {  if (comboBox2.Text == "Experience") { query = "select laborername, id,age,rating, job,hiredtimes, picture from laborertable where (hirerid=null or hirerid='') and  (potentialcustomerid=null or potentialcustomerid='')  order by hiredtimes desc;"; }
                else { query = "select laborername, id, age,rating, job,hiredtimes, picture from laborertable  where  (hirerid=null or hirerid='') or  (potentialcustomerid=null and potentialcustomerid='') order by " + comboBox2.Text + " desc;"; }

                  cmd = new SqlCommand(query, con);

                 

                 
            }

            else 
            {
                query = "select laborername 'Name',id 'ID', age 'Age',rating 'Rating', job 'Job',hiredtimes 'Hired Times', picture 'Picture' from laborertable where   (hirerid=null or hirerid='') and  (potentialcustomerid=null or potentialcustomerid='');";

                  cmd = new SqlCommand(query, con);
                con.Open();
                
                con.Close();
            }

            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;

            DataGridViewImageColumn dgvic = new DataGridViewImageColumn();
            dgvic = (DataGridViewImageColumn)dataGridView1.Columns[6];
            dgvic.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 80;

            this.dataGridView1.Font = new Font("Comic Sans MS", 11, FontStyle.Bold);



            con.Close();



        }

        private void button4_Click(object sender, EventArgs e)
        {
             
            comboBox1.Text = "";

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
            try{
                button1.Visible = true;

                label9.Text = (dataGridView1.SelectedRows[0].Cells[0].Value).ToString();

                label10.Text = (dataGridView1.SelectedRows[0].Cells[2].Value).ToString();

                label14.Text = (dataGridView1.SelectedRows[0].Cells[3].Value).ToString() + " Out of 5";

                label13.Text = (dataGridView1.SelectedRows[0].Cells[4].Value).ToString();

                label12.Text = (dataGridView1.SelectedRows[0].Cells[5].Value).ToString()+ " hiring/hirings";

                this.id = (dataGridView1.SelectedRows[0].Cells[1].Value).ToString();
                if (this.id == null)
                { button1.Visible = false; }







                pictureBox1.Image = getPhoto((byte[])dataGridView1.SelectedRows[0].Cells[6].Value);


            }
            catch (System.InvalidCastException) { }
            catch (System.ArgumentOutOfRangeException) { pictureBox1.Image = Properties.Resources.head;  }
        }

        Image getPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);

            return Image.FromStream(ms);



        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.Orange;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            this.button2.BackColor = Color.Orange;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.SlateBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.button2.BackColor = Color.SlateBlue;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
