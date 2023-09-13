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
    
    public partial class ManagerConfirmingHiring : Form
    {
        private string laborerid;
        private string customerID;
        private string workDays, registrationFee, wage;


        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public ManagerConfirmingHiring()
        {


            this.WindowState = FormWindowState.Maximized;
             

            this.BackgroundImage = Properties.Resources.OF2;




            InitializeComponent();



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

            comboBox3.Text = "1";
            comboBox3.Items.Add("1");
            comboBox3.Items.Add("2");
            comboBox3.Items.Add("3");
            comboBox3.Items.Add("4");
            comboBox3.Items.Add("5");
            comboBox3.Items.Add("6");
            comboBox3.Items.Add("7");


            numericUpDown1.Maximum = 60000;
            numericUpDown2.Maximum = 60000;

            this.panel1.BackgroundImage = Properties.Resources.pattern1;


            button1.Visible = false;
            button4.Visible = false;
            BindGridView();

            try { panel2.Visible = false; }
            catch (System.NullReferenceException) { }

            this.Text = "Manager Confirming Hiring";
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
            this.workDays = comboBox3.Text;


            if (comboBox3.Text == "" || numericUpDown1.Text == "" || numericUpDown2.Text == "")
            {
                DialogResult d = MessageBox.Show("Fill Up All The Fields First", "Blank Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

            else
            {
                DialogResult d = MessageBox.Show("Confirm Conditions", "Conditions for hiring this laborer", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (d == DialogResult.OK)
                {



                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd;
                    string query = "insert into dealings values( @laborerID,@customerID, (select id from loggedinuserinfo), @workDays, @price, @wage, '', 'true','Started',(select count(*)+1 from dealings));";
                    cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@customerID", this.customerID);
                    cmd.Parameters.AddWithValue("@laborerID", this.laborerid);

                    cmd.Parameters.AddWithValue("@workDays", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@price", numericUpDown1.Text);
                    cmd.Parameters.AddWithValue("@wage", numericUpDown2.Text);





                    con.Open();
                    int x = cmd.ExecuteNonQuery();
                    con.Close();
                    cmd.Dispose();


                    // SqlConnection con2 = new SqlConnection(cs);
                    //  SqlCommand cmd2;
                    query = " update laborertable set hirerid='Pending' where id=@laborerID;";
                    cmd = new SqlCommand(query, con);


                    cmd.Parameters.AddWithValue("@laborerID", this.laborerid);







                    con.Open();
                    int x2 = cmd.ExecuteNonQuery();
                    con.Close();
                    cmd.Dispose();

                    this.panel2.Visible = false;

                    BindGridView();


                }

                else { Form6 f = new Form6(); f.Show(); this.Visible = false; }
            }

            this.panel2.Visible = false;
            this.button1.Visible = false;
            this.button4.Visible = false;
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
            Form7 f = new Form7(); f.Show(); this.Visible = false;
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

          
             
                query = "select laborername LABORER,id 'ID[Laborer]',(select username from logintable where id= potentialcustomerid) 'Applicant',potentialcustomerid 'ID[Applicant]', picture 'Picture[Laborer]' from laborertable IMAGE where      (potentialcustomerid!=null or potentialcustomerid!='') and  hirerid!='Pending';";

                  cmd = new SqlCommand(query, con);
                con.Open();
                
                con.Close();

            SqlConnection con2 = new SqlConnection(cs);
            con2.Open();

            SqlDataAdapter sda = new SqlDataAdapter(query, con2);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;

            DataGridViewImageColumn dgvic = new DataGridViewImageColumn();
            dgvic = (DataGridViewImageColumn)dataGridView1.Columns[4];
              dgvic.ImageLayout = DataGridViewImageCellLayout.Stretch;

             dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
             dataGridView1.RowTemplate.Height = 100;

            this.dataGridView1.Font = new Font("Comic Sans MS", 11, FontStyle.Bold);




            con2.Close();
            cmd.Dispose();


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
            try
            {
                button1.Visible = true;
                button4.Visible = true;

                panel2.Visible = true;
                 



                label9.Text = (dataGridView1.SelectedRows[0].Cells[0].Value).ToString();
                label8.Text = (dataGridView1.SelectedRows[0].Cells[2].Value).ToString();
                this.laborerid = (dataGridView1.SelectedRows[0].Cells[1].Value).ToString();


                this.customerID = (dataGridView1.SelectedRows[0].Cells[3].Value).ToString();

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd;
                string query = "select  job,(select username  from logintable where logintable.id= laborertable.potentialcustomerid and laborertable.hirerid!='Pending') ,(select id  from logintable where logintable.id= laborertable.potentialcustomerid and laborertable.hirerid!='Pending')  ,(select location  from logintable where logintable.id= laborertable.potentialcustomerid and laborertable.hirerid!='Pending'), (select picture 'Pic' from logintable where logintable.id= laborertable.potentialcustomerid and laborertable.hirerid!='Pending') from laborertable where  laborertable.id=@id and laborertable.hirerid!='Pending' ;";



                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", this.laborerid);

                con.Open();


                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows == true)
                {
                    dr.Read();



                    label13.Text = dr.GetString(0); //Job of the laborer
                    label8.Text = dr.GetString(1); //Customer's name
                    label11.Text = dr.GetString(3); //Location of Customer

                    try { if (dr.GetValue(4) != null) { pictureBox2.Image = getPhoto((byte[])dr.GetValue(4)); } }
                    catch (System.InvalidCastException) { pictureBox2.Image = Properties.Resources.NullPicture; }

                    dr.Close();

                }




                pictureBox1.Image = getPhoto((byte[])dataGridView1.SelectedRows[0].Cells[4].Value);

                con.Close();
                cmd.Dispose();
            }
            catch (System.InvalidCastException) { panel2.Visible = false; }
            catch (System.ArgumentOutOfRangeException) { panel2.Visible = false; }

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
            DialogResult d = MessageBox.Show("Cancel this deal with this Applicant?", "Cancelling Deal;", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (d == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmdx;
                string query = "insert into dealings values( @laborerID,@customerID, (select id from loggedinuserinfo), @workDays, @price, @wage, '', 'false','',(select count(*)+1 from dealings) );";
                cmdx = new SqlCommand(query, con);

                cmdx.Parameters.AddWithValue("@customerID", this.customerID);
                cmdx.Parameters.AddWithValue("@laborerID", this.laborerid);

                cmdx.Parameters.AddWithValue("@workDays", comboBox3.Text);
                cmdx.Parameters.AddWithValue("@price", numericUpDown1.Text);
                cmdx.Parameters.AddWithValue("@wage", numericUpDown2.Text);





                con.Open();
                int xx = cmdx.ExecuteNonQuery();
                con.Close();
                cmdx.Dispose();



                SqlConnection con2 = new SqlConnection(cs);
                SqlCommand cmd2;
                string query2 = "update laborertable set potentialcustomerid='' where id=@laborerID;";
                cmd2 = new SqlCommand(query2, con2);


                cmd2.Parameters.AddWithValue("@laborerID", this.laborerid);







                con2.Open();
                int x2 = cmd2.ExecuteNonQuery();
                con2.Close();
                cmd2.Dispose();
                this.panel2.Visible = false;
                BindGridView();
            }

            this.panel2.Visible = false;
            this.button1.Visible = false;
            this.button4.Visible = false;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Yellow;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.SlateBlue;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.Yellow;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.SlateBlue;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Yellow;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.SlateBlue;
        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
