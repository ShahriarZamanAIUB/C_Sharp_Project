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

    public partial class CustomerManagingLaborers : Form
    {
        string id;
        string laborerID;
        string customerBalance;
        string laborerWage;
        string laborerBalance;
        string laborerRating;


        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public CustomerManagingLaborers()
        {
            this.WindowState = FormWindowState.Maximized;

             

             



            InitializeComponent();

            this.panel1.BackgroundImage=Properties.Resources.pattern3;

            this.Text = "Customer Managing Their Hired Laborers";

            this.numericUpDown1.Maximum = 5;
            this.numericUpDown1.Minimum = 0;

            this.panel3.Visible = false;
            this.panel3.BackgroundImage = Properties.Resources.ImperialPattern;

            this.panel2.Visible = false;

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd;
            string query = "select balance from logintable where id=(select id from loggedinuserinfo);";

            this.panel2.BackgroundImage = Properties.Resources.Orange;

            cmd = new SqlCommand(query, con);


            con.Open();


            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            if (dr.HasRows == true)
            {

                this.customerBalance = dr.GetValue(0).ToString();
                label8.Text = dr.GetString(0);
            }

            con.Close();
            con.Dispose();
            cmd.Dispose();


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
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);

            return ms.GetBuffer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = true;

            this.panel2.Visible = false;
            this.label4.Visible = false;

            this.dataGridView1.Visible = false;

            

            this.label2.Text = "         Dismissal         ";



            DialogResult d = MessageBox.Show("Confirm?", "Are you sure?", MessageBoxButtons.OK, MessageBoxIcon.Information);

 
            BindGridView();



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

            


            query = "select laborername,id, job, picture from laborertable where    hirerid=(select id from loggedinuserinfo) and  (potentialcustomerid=null or potentialcustomerid='');";

            cmd = new SqlCommand(query, con);
            con.Open();

            con.Close();

            cmd.Dispose();

            SqlConnection con2 = new SqlConnection(cs);
            con2.Open();

            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;

            DataGridViewImageColumn dgvic = new DataGridViewImageColumn();
            dgvic = (DataGridViewImageColumn)dataGridView1.Columns[3];
            dgvic.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 80;

            this.dataGridView1.Font = new Font("Comic Sans MS", 11, FontStyle.Bold);



            con2.Close();
            con2.Dispose();



        }

        private void button4_Click(object sender, EventArgs e)
        {

            

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

               // this.panel3.Visible = true;
                this.panel2.Visible = true;
                label9.Text = (dataGridView1.SelectedRows[0].Cells[0].Value).ToString();

                this.laborerID = (dataGridView1.SelectedRows[0].Cells[1].Value).ToString();

                //label10.Text = (dataGridView1.SelectedRows[0].Cells[2].Value).ToString();

                // label14.Text = (dataGridView1.SelectedRows[0].Cells[3].Value).ToString() + " Out of 5";

                label13.Text = (dataGridView1.SelectedRows[0].Cells[2].Value).ToString();

                // label12.Text = (dataGridView1.SelectedRows[0].Cells[5].Value).ToString();









                pictureBox1.Image = getPhoto((byte[])dataGridView1.SelectedRows[0].Cells[3].Value);


                SqlConnection conD = new SqlConnection(cs);
                SqlCommand cmdD;
                string queryD = "select  (select wage 'Wage' from dealings where dealings.LaborerID=laborertable.id and dealings.customerid=laborertable.hirerid and dealings.status='Started' and (CustomerOK='true' and ManagerOK='true')),laborertable.balance  from laborertable where laborertable.hirerid=(select id from loggedinuserinfo) and laborertable.id=@laborerID;";



                cmdD = new SqlCommand(queryD, conD);

                cmdD.Parameters.AddWithValue("@laborerID", this.laborerID);


                conD.Open();


                SqlDataReader drD = cmdD.ExecuteReader();
                drD.Read();

                if (drD.HasRows == true)
                {

                    this.customerBalance = drD.GetValue(0).ToString();
                    label12.Text = drD.GetString(0);
                    this.laborerBalance = drD.GetString(1);
                    this.laborerWage = label12.Text;
                }

                conD.Close();
                conD.Dispose();
                cmdD.Dispose();


                SqlConnection conx = new SqlConnection(cs);
                SqlCommand cmdx;
                string queryx = "select balance from laborertable where id=@laborerID;";

                cmdx = new SqlCommand(queryx, conx);

                cmdx.Parameters.AddWithValue("@laborerID", this.laborerID);






                conx.Open();


                SqlDataReader drx = cmdx.ExecuteReader();
                drx.Read();

                if (drx.HasRows == true)
                {

                    this.laborerBalance = drx.GetValue(0).ToString();

                }

                conx.Close();
                conx.Dispose();
                cmdx.Dispose();


            }
            catch (System.InvalidCastException) { }
            catch (System.ArgumentOutOfRangeException) {   pictureBox1.Image = Properties.Resources.head; }
        }

        Image getPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);

            return Image.FromStream(ms);



        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.customerBalance = label8.Text;



            if (this.customerBalance != "0")
            {

                DialogResult d = MessageBox.Show("Pay Wage To Laborer???", "Wages", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (d == DialogResult.OK)
                {
                    try
                    {
                        this.customerBalance = (Convert.ToInt32(label8.Text) - Convert.ToInt32(label12.Text)).ToString();
                        this.laborerBalance = (Convert.ToInt32(this.laborerBalance) + Convert.ToInt32(label12.Text)).ToString();

                        label8.Text = this.customerBalance;

                        this.customerBalance = label8.Text;

                        SqlConnection conA = new SqlConnection(cs);
                        SqlCommand cmdA;
                        string queryA = "update logintable set balance=@customerBalance where id=(select id from loggedinuserinfo)";



                        cmdA = new SqlCommand(queryA, conA);

                        cmdA.Parameters.AddWithValue("@customerBalance", this.customerBalance);


                        conA.Open();
                        


                        int x = cmdA.ExecuteNonQuery();

                        conA.Close();
                        conA.Dispose();
                        cmdA.Dispose();



                        SqlConnection conE = new SqlConnection(cs);
                        SqlCommand cmdE;
                        string queryE = "update laborertable set balance=@laborerBalance where id=@laborerID";



                        cmdE = new SqlCommand(queryE, conE);

                        cmdE.Parameters.AddWithValue("@laborerBalance", this.laborerBalance);

                        cmdE.Parameters.AddWithValue("@laborerID", this.laborerID);


                        conE.Open();


                        int xE = cmdE.ExecuteNonQuery();

                        conE.Close();
                        conE.Dispose();
                        cmdE.Dispose();




                        DialogResult dd = MessageBox.Show("Wage Payment Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (InvalidCastException) { DialogResult dd = MessageBox.Show("Invalid Selection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                    catch (System.FormatException) { DialogResult dd = MessageBox.Show("Invalid Selection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.laborerRating = numericUpDown1.Text;
                this.panel2.Visible = false;
                this.dataGridView1.Visible = false;


                SqlConnection conB = new SqlConnection(cs);
                SqlCommand cmdB;
                string queryB = "update laborertable set rating=@laborerRating,hirerid='' where id=@laborerID and hirerid=(select id from loggedinuserinfo);";



                cmdB = new SqlCommand(queryB, conB);

                cmdB.Parameters.AddWithValue("@laborerRating", this.laborerRating);

                cmdB.Parameters.AddWithValue("@laborerID", this.laborerID);


                conB.Open();
                int xB = cmdB.ExecuteNonQuery();

                conB.Close();
                conB.Dispose();
                cmdB.Dispose();


                SqlConnection conC = new SqlConnection(cs);
                SqlCommand cmdC;
                string queryC = "update dealings set  status='Finished 'where laborerid=@laborerID and customerid=(select id from loggedinuserinfo) and Status='Started';";



                cmdC = new SqlCommand(queryC, conC);



                cmdC.Parameters.AddWithValue("@laborerID", this.laborerID);


                conC.Open();


                int r = cmdC.ExecuteNonQuery();



                conC.Close();
                conC.Dispose();
                cmdC.Dispose();



                this.panel3.Visible = false;

          

                this.dataGridView1.Visible = true;


                this.label2.Text = "Your Hired Laborers";

                this.label12.Text = ".........";



                BindGridView();
            }
            catch (System.ArgumentOutOfRangeException) { DialogResult dd = MessageBox.Show("Hire Some Laborers First", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            catch (System.Data.SqlClient.SqlException) { DialogResult dd = MessageBox.Show("Invalid Selection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information); Form6 f = new Form6(); f.Show(); this.Visible = false; }

            catch (InvalidCastException) { DialogResult dd = MessageBox.Show("Invalid Selection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information); Form6 f = new Form6(); f.Show(); this.Visible = false; }

            catch (System.FormatException) { DialogResult dd = MessageBox.Show("Invalid Selection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information); Form6 f = new Form6(); f.Show(); this.Visible = false; }

            
        }
    
        private void button6_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = false;

            this.panel2.Visible = false;

            this.dataGridView1.Visible = true;
            this.label4.Visible = true;

           
            this.label2.Text = "Your Hired Laborers";
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Yellow;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.Yellow;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.SpringGreen;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.HotPink;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.SlateBlue;

        }
    }
}
