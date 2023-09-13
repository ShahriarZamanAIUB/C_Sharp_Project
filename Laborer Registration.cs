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

    public partial class LaborerRegistration : Form
    {
        string id;
        int laborerAge;


        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public LaborerRegistration()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
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

            button5.Visible = false;
            numericUpDown1.Minimum = 18;

            this.Text = "Laborer Registration";
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



            if (textBox1.Text != "" && textBox3.Text != "" && comboBox1.Text != "" && pictureBox1.Image != Properties.Resources.head)
            {
                SqlConnection conn = new SqlConnection(cs);

                string qry = "SELECT TOP 1 id FROM laborertable  ORDER BY id desc;";

                SqlCommand scmd = new SqlCommand(qry, conn);





                conn.Open();

                SqlDataReader sdr = scmd.ExecuteReader();
                sdr.Read();


                if (sdr.HasRows == true)
                {
                    id = sdr.GetString(0);

                    this.id = (Convert.ToInt32(id.Trim(new Char[] { 'L' })) + 1).ToString() + 'L';
                }
                conn.Close();
                scmd.Dispose();


                SqlConnection con = new SqlConnection(cs);

                string query = "insert into laborertable values(@name, @id, @age, @phoneNumber, @job,'','0', @picture,'0','','5000');";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", textBox1.Text);

                cmd.Parameters.AddWithValue("@id", id);


                cmd.Parameters.AddWithValue("@age", numericUpDown1.Text);

                cmd.Parameters.AddWithValue("@phoneNumber", textBox3.Text);

                cmd.Parameters.AddWithValue("@job", comboBox1.Text);

                cmd.Parameters.AddWithValue("@picture", SavePhoto());




                con.Open();


                int x = cmd.ExecuteNonQuery();


                if (x != 0)
                {
                    DialogResult d = MessageBox.Show("Laborer Registration Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    DialogResult d = MessageBox.Show("Laborer Registration Unuccessful", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                con.Close();
                cmd.Dispose();



            }

            /* else if (Convert.ToInt32(numericUpDown1.Text) < 18 && textBox1.Text != "" && textBox3.Text != "" && comboBox1.Text != "" && pictureBox1.Image != Properties.Resources.head)
             {
                 DialogResult d = MessageBox.Show("Cannot Register, the person is below the allowed age", "Underaged Candidate", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 if (d == DialogResult.OK)
                 {
                     pictureBox1.Image = Properties.Resources.head;
                     textBox1.Text = "";
                     textBox3.Text = "";
                     numericUpDown1.Text = "18";
                     comboBox1.Text = "";





                 }


             } */
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
            SqlConnection con = new SqlConnection(cs);

            string query = "select laborername 'Name', id 'I.D.', age 'Age', phoneNumber 'Mobile', job 'Job', picture 'Picture' from laborertable  ;";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);

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
            numericUpDown1.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";

            button1.Visible = true;
            button5.Visible = false;
            label6.Visible = false;
            button3.Text = "Insert Image";



            pictureBox1.Image = Properties.Resources.head;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                button5.Visible = true;
                label6.Visible = true;
                label3.Visible = false;
                numericUpDown1.Visible = false;

                this.id = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();



                button5.Visible = true;

                button1.Visible = false;


                button3.Text = "Update Image";


                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

                pictureBox1.Image = getPhoto((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);





            }
            catch (System.InvalidCastException)
            {
                pictureBox1.Image = Properties.Resources.head;

                numericUpDown1.Visible = true;
                textBox1.Text = "";
                numericUpDown1.Text = "18";
                textBox3.Text = "";
                comboBox1.Text = "";
                button3.Text = "Insert Image";
                label3.Visible = true;
                label6.Visible = false;
                button5.Visible = false;
                button1.Visible = true;

                BindGridView();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                pictureBox1.Image = Properties.Resources.head;

                numericUpDown1.Visible = true;
                textBox1.Text = "";
                numericUpDown1.Text = "18";
                textBox3.Text = "";
                comboBox1.Text = "";
                label3.Visible = true;
                label6.Visible = false;
                button5.Visible = false;
                button1.Visible = true;
                BindGridView();


            }











        }

        Image getPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);

            return Image.FromStream(ms);



        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "" && comboBox1.Text != "" && pictureBox1.Image != Properties.Resources.head)
            {



                SqlConnection con = new SqlConnection(cs);

                string query = "update laborertable set laborername=@name  , phonenumber=@phoneNumber, job=@job,  picture=@picture where id=@id;";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", textBox1.Text);

                cmd.Parameters.AddWithValue("@id", id);




                // cmd.Parameters.AddWithValue("@age", this.numericUpDown1.Text);

                cmd.Parameters.AddWithValue("@phoneNumber", textBox3.Text);

                cmd.Parameters.AddWithValue("@job", comboBox1.Text);

                cmd.Parameters.AddWithValue("@picture", SavePhoto());




                con.Open();


                int x = cmd.ExecuteNonQuery();


                if (x != 0)
                {
                    DialogResult d = MessageBox.Show("Update Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    DialogResult d = MessageBox.Show("Update Unuccessful", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                con.Close();
                cmd.Dispose();

                button5.Visible = false;
                button3.Text = "Insert Image";
            }
            else { MessageBox.Show("Please Enter All the Fields Properly", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.HotPink;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.SlateBlue;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.HotPink;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.SlateBlue;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.HotPink;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.SlateBlue;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.HotPink;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.SlateBlue;
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
