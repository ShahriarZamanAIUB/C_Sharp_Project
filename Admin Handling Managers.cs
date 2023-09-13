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

    public partial class AdminHandlingManager : Form
    {
        string managerID;
        string managerPassword;
        string managerBalance;


        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public AdminHandlingManager()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.Text = "Admin Managing Managers";


            comboBox1.Items.Add("Dhaka");
            comboBox1.Items.Add("Khulna");
            comboBox1.Items.Add("Rangpur");
            comboBox1.Items.Add("Rajshahi");
            comboBox1.Items.Add("Sylhet");
            comboBox1.Items.Add("Chittagong");
            comboBox1.Items.Add("Barsihal");
            comboBox1.Items.Add("Mymensingh");


            button5.Visible = false;
            button6.Visible = false;


            numericUpDown1.Minimum = 18;

           // numericUpDown2.Minimum = 0;

             
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


            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox2.Text == textBox4.Text && numericUpDown1.Text != "" && comboBox1.Text != "" && X == false)
            {
                SqlConnection conn = new SqlConnection(cs);

                string qry = "SELECT TOP 1 id FROM logintable where UserType='Manager'  ORDER BY id desc;";

                SqlCommand scmd = new SqlCommand(qry, conn);





                conn.Open();

                SqlDataReader sdr = scmd.ExecuteReader();
                sdr.Read();


                if (sdr.HasRows == true)
                {
                    this.managerID = sdr.GetString(0);

                    this.managerID = (Convert.ToInt32(this.managerID.Trim(new Char[] { 'M' })) + 1).ToString() + 'M';
                }
                conn.Close();
                scmd.Dispose();


                SqlConnection conF = new SqlConnection(cs);

                string queryF = "insert into logintable values(@name, @id, @age, @phoneNumber, @location, @picture, @password,'50000','Manager');";

                SqlCommand cmdF = new SqlCommand(queryF, conF);

                cmdF.Parameters.AddWithValue("@name", textBox1.Text);

                cmdF.Parameters.AddWithValue("@id", this.managerID);


                cmdF.Parameters.AddWithValue("@age", numericUpDown1.Text);

                cmdF.Parameters.AddWithValue("@phoneNumber", textBox3.Text);

                cmdF.Parameters.AddWithValue("@location", comboBox1.Text);

                cmdF.Parameters.AddWithValue("@picture", SavePhoto());

                cmdF.Parameters.AddWithValue("@password", textBox2.Text);




                conF.Open();


                int xF = cmdF.ExecuteNonQuery();


                if (xF != 0)
                {
                    DialogResult d = MessageBox.Show("Manager Registration Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    if (d == DialogResult.OK)
                    {
                        textBox1.Text = "";
                        numericUpDown1.Text = "";
                        textBox3.Text = "";
                        comboBox1.Text = "";

                        pictureBox1.Image = Properties.Resources.head;
                        BindGridView();
                        // Form5 f = new Form5(); f.Show(); this.Visible = false;

                    }


                }

                else
                {
                    DialogResult d = MessageBox.Show("Manager Registration Unuccessful", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (d == DialogResult.OK)
                    {
                        textBox1.Text = "";
                        numericUpDown1.Text = "";
                        textBox3.Text = "";
                        comboBox1.Text = "";

                        pictureBox1.Image = Properties.Resources.head;

                        //  Form5 f = new Form5(); f.Show(); this.Visible = false;

                    }


                }

                conF.Close();
                cmdF.Dispose();



            }

            

            else if (X == true)
            { MessageBox.Show("This Username Already Belongs to Another Manager", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); textBox1.Text = ""; }


            else { MessageBox.Show("Please Enter All the Fields Properly", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); }




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
            Form5 f = new Form5(); f.Show(); this.Visible = false;
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

            button3.Text = "Change Image";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }



        void BindGridView()
        {
            SqlConnection conG = new SqlConnection(cs);

            string queryG = "select username 'Manager Name', id 'Manager ID', age 'Manager Age', phoneNumber  'Mobile', location 'Location' , picture   from logintable  where usertype='Manager';";

            SqlDataAdapter sda = new SqlDataAdapter(queryG, conG);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;

            DataGridViewImageColumn dgvic = new DataGridViewImageColumn();
            dgvic = (DataGridViewImageColumn)dataGridView1.Columns[5];
            dgvic.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 70;

            this.dataGridView1.Font = new Font("Comic Sans MS", 11, FontStyle.Bold);







        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";

            numericUpDown1.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";

            button1.Visible = true;
            button5.Visible = false;
            label6.Visible = false;
            button3.Text = "Insert Image";
            label9.Text = "Re-Enter Password :";



            pictureBox1.Image = Properties.Resources.head;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string customerBalance;
            
                label2.Text = "Modifying Manager";
                panel1.BackColor = Color.Tan;


                button6.Visible = true;


                button5.Visible = true;
                label6.Visible = true;
                numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);

                button5.Visible = true;

                button1.Visible = false;

                label9.Text = "     Balance : Tk. ";


                button3.Text = "Update Image";


                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                this.managerID = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                SqlConnection conH = new SqlConnection(cs);

                string qryH = "select pass from logintable where usertype='Manager' and id=@managerID;";

                SqlCommand scmdH = new SqlCommand(qryH, conH);

                scmdH.Parameters.AddWithValue("@managerID", this.managerID);



                conH.Open();

                SqlDataReader sdrH = scmdH.ExecuteReader();
                sdrH.Read();


                if (sdrH.HasRows == true)
                {

                    this.managerPassword = sdrH.GetString(0);
                    textBox2.Text = sdrH.GetString(0);



                    sdrH.Close();

                }
                conH.Close();
                scmdH.Dispose();




                SqlConnection conJ = new SqlConnection(cs);

                string qryJ = "select balance from logintable where usertype='Manager' and id=@managerID;";

                SqlCommand scmdJ = new SqlCommand(qryJ, conJ);

                scmdJ.Parameters.AddWithValue("@managerID", this.managerID);



                conJ.Open();

                SqlDataReader sdrJ = scmdJ.ExecuteReader();
                sdrJ.Read();


                if (sdrJ.HasRows == true)
                {

                    this.managerBalance = sdrJ.GetString(0);
                    textBox4.Text = sdrJ.GetString(0);

                    




                   sdrJ.Close();

                }
                conJ.Close();
                scmdJ.Dispose();








                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

                pictureBox1.Image = getPhoto((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);


            }
            catch (System.InvalidCastException)
            {
                panel1.BackColor = Color.PowderBlue;
                label2.Text = "Manager Registration";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                numericUpDown1.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
                label6.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button1.Visible = true;
                button3.Text = "Insert Image";
                label9.Text = "Re-Enter Password :";
                pictureBox1.Image = Properties.Resources.head;

              

            }
            catch (System.ArgumentOutOfRangeException)
            {
                panel1.BackColor = Color.PowderBlue;
                label2.Text = "Manager Registration";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                numericUpDown1.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
                label6.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button1.Visible = true;
                button3.Text = "Insert Image";
                label9.Text = "Re-Enter Password :";
                pictureBox1.Image = Properties.Resources.head;


            }
        }

        Image getPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);

            return Image.FromStream(ms);



        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool Xx = false;
            bool F = false;

            SqlConnection connW = new SqlConnection(cs);

            string qryW = "select username from logintable where username=@n and id!=@ID;";

            SqlCommand scmdW = new SqlCommand(qryW, connW);


            scmdW.Parameters.AddWithValue("@n", textBox1.Text);
            scmdW.Parameters.AddWithValue("@ID", this.managerID);


            connW.Open();

            SqlDataReader sdrW = scmdW.ExecuteReader();
            sdrW.Read();


            if (sdrW.HasRows == true)
            {
                F = true;


            }
            connW.Close();
            scmdW.Dispose();


            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && numericUpDown1.Text != "" && comboBox1.Text != "" && F == false)
            {

                try { int textNumber = Convert.ToInt32(textBox4.Text); }
                catch (System.FormatException)
                {
                    Xx = true;
                    DialogResult dI = MessageBox.Show("Only Set a Numeric Value for The Balance", "Incorrect Format", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (dI == DialogResult.OK)
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox4.Text = "";
                        numericUpDown1.Text = "";
                        textBox3.Text = "";
                        comboBox1.Text = "";


                        pictureBox1.Image = Properties.Resources.head;
                        BindGridView();
                    }





                }
                if (Xx == false)
                {
                    SqlConnection conI = new SqlConnection(cs);

                    string queryI = "update logintable set username=@name ,age= @age,pass=@pass, balance=@balance, phonenumber=@phoneNumber, location=@location,  picture=@picture where id=@id and usertype='Manager';";

                    SqlCommand cmdI = new SqlCommand(queryI, conI);

                    cmdI.Parameters.AddWithValue("@name", textBox1.Text);

                    cmdI.Parameters.AddWithValue("@id", this.managerID);


                    cmdI.Parameters.AddWithValue("@pass", textBox2.Text);

                    cmdI.Parameters.AddWithValue("@balance", textBox4.Text);




                    cmdI.Parameters.AddWithValue("@age", numericUpDown1.Text);

                    cmdI.Parameters.AddWithValue("@phoneNumber", textBox3.Text);

                    cmdI.Parameters.AddWithValue("@location", comboBox1.Text);

                    if (pictureBox1.Image != Properties.Resources.head) { cmdI.Parameters.AddWithValue("@picture", SavePhoto()); }
                    else { cmdI.Parameters.AddWithValue("@picture", null); }




                    conI.Open();


                    int xI = cmdI.ExecuteNonQuery();


                    if (xI != 0)
                    {
                        DialogResult dI = MessageBox.Show("Update Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (dI == DialogResult.OK)
                        {
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox4.Text = "";
                            numericUpDown1.Text = "";
                            textBox3.Text = "";
                            comboBox1.Text = "";


                            pictureBox1.Image = Properties.Resources.head;
                            BindGridView();
                            // Form5 f = new Form5(); f.Show(); this.Visible = false;

                        }


                    }

                    else
                    {
                        DialogResult dJ = MessageBox.Show("Update Unuccessful", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (dJ == DialogResult.OK)
                        {
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox4.Text = "";
                            numericUpDown1.Text = "";
                            textBox3.Text = "";
                            comboBox1.Text = "";

                            pictureBox1.Image = Properties.Resources.head;

                            //  Form5 f = new Form5(); f.Show(); this.Visible = false;

                        }
                    }

                    conI.Close();
                    cmdI.Dispose();

                    button5.Visible = false;
                    button3.Text = "Insert Image";
                }

                else
                {
                    DialogResult dJ = MessageBox.Show("Fill Up All the Fields First", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            else if (F == true)
            { MessageBox.Show("This Username Already Belongs to Another Manager", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); textBox1.Text = ""; }


        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && numericUpDown1.Text != "" && comboBox1.Text != "")
            {
                DialogResult dKK = MessageBox.Show("Delete this Manager's Account???", "Delete?", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.managerID = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                if (dKK == DialogResult.OK)
                {

                    SqlConnection conK = new SqlConnection(cs);

                    string queryK = "delete from logintable where usertype='Manager' and id=@managerID;";

                    SqlCommand cmdK = new SqlCommand(queryK, conK);



                    cmdK.Parameters.AddWithValue("@managerID", this.managerID);







                    conK.Open();


                    int xK = cmdK.ExecuteNonQuery();


                    if (xK != 0)
                    {
                        DialogResult dK = MessageBox.Show("Manager Account Deletion Successful", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        this.BindGridView();



                    }

                    else if (xK != 0)
                    {
                        DialogResult dK = MessageBox.Show("Manager Account Deletion Failed", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        this.BindGridView();



                    }
                }





            }

            else
            {
                DialogResult dK = MessageBox.Show("Select a Manager first", "Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);


                this.BindGridView();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DockChanged(object sender, EventArgs e)
        {

        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.GreenYellow;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.GreenYellow;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Orange;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Orange;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.GreenYellow;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Orange;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.GreenYellow;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Orange;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.BackColor = Color.GreenYellow;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.Orange;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.GreenYellow;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Orange;
        }
    }
}
