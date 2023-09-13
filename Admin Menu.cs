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
    public partial class Form5 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;





        int givenAmount;
        string customerID;
        string companyRevenue;

        bool X = false;
        public Form5()
        {

            this.Text = "Admin Menu";
            InitializeComponent();
            this.button9.Visible = false;
            this.numericUpDown1.Text = "12000";
            this.numericUpDown1.Maximum = 100000;
            this.WindowState = FormWindowState.Maximized;
            this.panel1.Visible = false;
            this.BackgroundImage = Properties.Resources.OF4;
            this.panel1.BackgroundImage = Properties.Resources.pattern1;

            this.pictureBox1.Visible = false;

            this.label6.Visible = false;
            this.label7.Visible = false;
            this.label8.Visible = false;
            this.label9.Visible = false;
            this.label10.Visible = false;
            this.label11.Visible = false;
            this.label12.Visible = false;
            this.label13.Visible = false;
            this.label14.Visible = false;
            this.label15.Visible = false;
            this.label16.Visible = false;
            this.label17.Visible = false;
            this.label18.Visible = false;
            this.label19.Visible = false;
            this.label20.Visible = false;

            this.button11.Visible = false;
            this.button12.Visible = false;

            this.BindGridView3();

            SqlConnection conO = new SqlConnection(cs);

            string queryO = "update FinancialReport set TotalRevenue = TotalRevenue+(select sum(cast(wage as int)) + cast((select revenue from report) -83050 as int) from dealings WHERE  CustomerOK = 'true' and ManagerOK = 'true'),TotalCustomers = (select count(*) from logintable where usertype = 'Customer'),TotalManagers = (select count(*) from logintable where usertype = 'Manager'),TotalLaborers = (select count(*) from laborertable)";

            SqlCommand cmdO = new SqlCommand(queryO, conO);



            // cmd2.Parameters.AddWithValue("@Image", ImagemByte);



            conO.Open();
            int xO = cmdO.ExecuteNonQuery();
            conO.Close();
            conO.Dispose();
            cmdO.Dispose();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminHandlingManager f = new AdminHandlingManager();
            f.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.panel1.Visible = true;

            this.label1.Text = "Customer Balance";

            this.label3.Text = "Select a Customer";

            this.label2.Text = "New Balance : Tk. ";

            this.label4.Visible = false;
            this.label5.Visible = false;


            this.button7.Visible = false;
            this.button10.Visible = false;

            BindGridView3();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.X = true;
            this.panel1.Visible = true;
            this.button9.Visible = true;
            this.button7.Visible = false;
            this.button8.Visible = false;
            this.button10.Visible = false;

            this.label2.Visible = false;
            this.label4.Visible = false;
            this.label5.Visible = false;
            this.numericUpDown1.Visible = false;


            label1.Text = "Financial Report";

            label3.Text = "Report of The Company";

            this.BindGridView2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conM = new SqlConnection(cs);

            string queryM = "update loggedinuserinfo set username='',phonenumber='', location='', age='', pass='',id='',  Picture='';";

            SqlCommand cmdM = new SqlCommand(queryM, conM);



            // cmd2.Parameters.AddWithValue("@Image", ImagemByte);



            conM.Open();
            int xM = cmdM.ExecuteNonQuery();
            conM.Close();
            conM.Dispose();
            cmdM.Dispose();


            Form1 f = new Form1(); f.Show(); this.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        Image getPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);

            return Image.FromStream(ms);



        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.X = true;
            this.panel1.Visible = true;
            this.button7.Visible = true;
            this.button10.Visible = false;
            this.numericUpDown1.Text = "12000";
            this.label4.Visible = true;
            label1.Text = "Manager Salary";
            label5.Visible = true;

            this.BindGridView();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            label1.Text = "Admin Menu";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }


        private void BindGridView()
        {
            SqlConnection conL = new SqlConnection(cs);

            string queryL = "select     username 'Name',id 'ID', phonenumber 'Mobile',('Tk. '+balance  ) 'Balance'   from logintable  where usertype='Manager';";

            SqlDataAdapter sdL = new SqlDataAdapter(queryL, conL);

            DataTable dt = new DataTable();
            sdL.Fill(dt);

            dataGridView1.DataSource = dt;

            DataGridViewImageColumn dgvicL = new DataGridViewImageColumn();
            //dgvicL = (DataGridViewImageColumn)dataGridView1.Columns[0];
            dgvicL.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 100;


            dataGridView1.RowTemplate.Height = 70;

            this.dataGridView1.Font = new Font("Comic Sans MS", 14, FontStyle.Bold);

            SqlConnection conP = new SqlConnection(cs);

            string qryP = "select totalrevenue from financialreport;";

            SqlCommand scmdP = new SqlCommand(qryP, conP);





            conP.Open();

            SqlDataReader sdrP = scmdP.ExecuteReader();
            sdrP.Read();


            if (sdrP.HasRows == true)
            {
                this.companyRevenue = sdrP.GetValue(0).ToString();

                label5.Text = this.companyRevenue.ToString();


            }
            conP.Close();
            conP.Dispose();




        }


        private void BindGridView3()
        {
            SqlConnection conLL = new SqlConnection(cs);

            string queryLL = "select     username 'Name',id 'ID', phonenumber 'Mobile',('Tk. '+balance  ) 'Balance'   from logintable  where usertype='Customer';";

            SqlDataAdapter sdLL = new SqlDataAdapter(queryLL, conLL);

            DataTable dtLL = new DataTable();
            sdLL.Fill(dtLL);

            dataGridView1.DataSource = dtLL;

            DataGridViewImageColumn dgvicLL = new DataGridViewImageColumn();
            //dgvicL = (DataGridViewImageColumn)dataGridView1.Columns[0];
            dgvicLL.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 100;


            dataGridView1.RowTemplate.Height = 70;

            this.dataGridView1.Font = new Font("Comic Sans MS", 14, FontStyle.Bold);









        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection conM = new SqlConnection(cs);

            string queryM = "update logintable set balance= cast(cast(balance as int)+@Salary as varchar(50)) from logintable where UserType='Manager';";

            SqlCommand cmdM = new SqlCommand(queryM, conM);



            cmdM.Parameters.AddWithValue("@Salary", numericUpDown1.Text);



            conM.Open();
            int xM = cmdM.ExecuteNonQuery();
            conM.Close();
            cmdM.Dispose();




            SqlConnection conQ = new SqlConnection(cs);

            string queryQ = "update financialreport set totalrevenue =totalrevenue-@Salary*(select count(*) from logintable where usertype='Manager');";

            SqlCommand cmdQ = new SqlCommand(queryQ, conQ);



            cmdQ.Parameters.AddWithValue("@Salary", numericUpDown1.Text);



            conQ.Open();
            int xQ = cmdQ.ExecuteNonQuery();
            conQ.Close();
            cmdQ.Dispose();

            this.BindGridView();

            DialogResult dKK = MessageBox.Show("Salary Paid to All Managers", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.X = false;
            this.panel1.Visible = false;
            this.button9.Visible = false;
            this.button7.Visible = true;
            this.button8.Visible = true;
            this.label2.Visible = true;
            this.label4.Visible = true;
            this.label5.Visible = true;
            this.dataGridView1.Visible = true;
            this.numericUpDown1.Visible = true;
            this.button11.Visible = false;
            this.button12.Visible = false;

            this.pictureBox1.Visible = false;

            this.label6.Visible = false;
            this.label7.Visible = false;
            this.label8.Visible = false;
            this.label9.Visible = false;
            this.label10.Visible = false;
            this.label11.Visible = false;
            this.label12.Visible = false;
            this.label13.Visible = false;
            this.label14.Visible = false;
            this.label15.Visible = false;
            this.label16.Visible = false;
            this.label17.Visible = false;
            this.label18.Visible = false;
            this.label19.Visible = false;
            this.label20.Visible = false;
            this.label3.Text = "Managers and Their Accounts";
            this.label1.Text = "Admin Menu";
        }


        private void BindGridView2()
        {
            SqlConnection conQ = new SqlConnection(cs);

            string queryQ = "select totalrevenue 'Total Revenue (Taka)', totalcustomers 'Total Customers', totalmanagers 'Total Managers', totallaborers 'Total Laborers'  from financialreport;;";

            SqlDataAdapter sdLQ = new SqlDataAdapter(queryQ, conQ);

            DataTable dtQ = new DataTable();
            sdLQ.Fill(dtQ);

            dataGridView1.DataSource = dtQ;

            DataGridViewImageColumn dgvicLQ = new DataGridViewImageColumn();
            //dgvicL = (DataGridViewImageColumn)dataGridView1.Columns[0];
            dgvicLQ.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 100;


            dataGridView1.RowTemplate.Height = 70;

            this.dataGridView1.Font = new Font("Comic Sans MS", 14, FontStyle.Bold);







        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.X == false)
                { this.button10.Visible = true; }


                this.customerID = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();


















            }
            catch (System.InvalidCastException)
            {
                this.button10.Visible = false;

            }
            catch (System.ArgumentOutOfRangeException)
            {
                this.button10.Visible = false;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection conJJ = new SqlConnection(cs);

            string qryJJ = "update logintable set balance=@newBalance where id=@customerID;";

            SqlCommand scmdJ = new SqlCommand(qryJJ, conJJ);

            scmdJ.Parameters.AddWithValue("@newBalance", this.numericUpDown1.Text);

            scmdJ.Parameters.AddWithValue("@customerID", this.customerID);



            conJJ.Open();

            int xJJ = scmdJ.ExecuteNonQuery();

            conJJ.Close();
            conJJ.Dispose();
            scmdJ.Dispose();

            this.BindGridView3();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void button5_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;

            this.pictureBox1.Visible = true;

            this.button11.Visible = true;
            this.button12.Visible = true;



            this.label6.Visible = true;
            this.label7.Visible = true;
            this.label8.Visible = true;
            this.label9.Visible = true;
            this.label10.Visible = true;
            this.label11.Visible = true;
            this.label12.Visible = true;
            this.label13.Visible = true;
            this.label14.Visible = true;
            this.label15.Visible = true;
            this.label16.Visible = true;
            this.label17.Visible = true;
            this.label18.Visible = true;
            this.label19.Visible = true;
            this.label20.Visible = true;

            this.label3.Text = "Admin Information";

            this.numericUpDown1.Visible = false;

            this.button7.Visible = false;
            this.button8.Visible = false;
            this.button10.Visible = false;
            this.dataGridView1.Visible = false;

            this.label2.Visible = false;
            this.label4.Visible = false;
            this.label5.Visible = false;

            this.button9.Visible = true;

            SqlConnection conHH = new SqlConnection(cs);

            string qryHH = "select * from logintable where usertype='Admin';";

            SqlCommand scmdHH = new SqlCommand(qryHH, conHH);





            conHH.Open();

            SqlDataReader sdrHH = scmdHH.ExecuteReader();
            sdrHH.Read();


            if (sdrHH.HasRows == true)
            {

                label14.Text = sdrHH.GetString(0);
                label15.Text = sdrHH.GetString(1);
                label16.Text = (sdrHH.GetValue(2)).ToString() + " years"; ;
                label17.Text = sdrHH.GetString(3);
                label18.Text = sdrHH.GetString(4);
                label19.Text = sdrHH.GetString(6);
                label20.Text = sdrHH.GetString(7);

                this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                try { this.pictureBox1.Image = getPhoto((byte[])sdrHH.GetValue(5)); }

                catch (System.InvalidCastException) { this.pictureBox1.Image = Properties.Resources.Admin; }



                sdrHH.Close();

            }
            conHH.Close();
            conHH.Dispose();
            scmdHH.Dispose();



        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.Red;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.DarkSeaGreen;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.DarkSeaGreen;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.DarkSalmon;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkSalmon;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkSeaGreen;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.BackColor = Color.DarkSeaGreen;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.DarkSalmon;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {

            button3.BackColor = Color.DarkSalmon;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.DarkSeaGreen;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkSeaGreen;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkSalmon;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image File (All files) *.* | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd;


            string query;


            query = "update logintable set picture=@Picture where id= (select id from loggedinuserinfo);";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Picture", this.SavePhoto());
            con.Open();
            int xDF = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            DialogResult d = MessageBox.Show("Profile Picture Update Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); con.Close(); cmd.Dispose();
        }

        private byte[] SavePhoto()
        {

            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);

            return ms.GetBuffer();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            button9.BackColor = Color.Yellow;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = Color.SlateBlue;
        }

        private void button12_MouseHover(object sender, EventArgs e)
        {
            button12.BackColor = Color.Red;
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {
            button12.BackColor = Color.Coral;
        }

        private void button11_MouseHover(object sender, EventArgs e)
        {
            button11.BackColor = Color.Red;

        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            button11.BackColor = Color.CornflowerBlue;
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            button8.BackColor = Color.Yellow;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.Red;
        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
            button10.BackColor = Color.GreenYellow;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.BackColor = Color.SlateBlue;
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            button7.BackColor = Color.Yellow;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.GreenYellow;
        }
    }
}
