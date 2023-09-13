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
     
    public partial class Form7 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form7()
        {
            
            InitializeComponent();
            this.Text = "Manager Menu";
            panel1.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Properties.Resources.OF1;

            this.numericUpDown1.Maximum = 50000;
            this.panel2.Visible = false;
            this.panel2.BackgroundImage = Properties.Resources.ImperialPattern;
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con2 = new SqlConnection(cs);

            string query2 = "update loggedinuserinfo set username='',phonenumber='', location='', age='', pass='',id='',  Picture='';";

            SqlCommand cmd2 = new SqlCommand(query2, con2);



            // cmd2.Parameters.AddWithValue("@Image", ImagemByte);



            con2.Open();
            int x = cmd2.ExecuteNonQuery();
            con2.Close();
            con2.Dispose();
            cmd2.Dispose();



            Form1 f = new Form1(); f.Show(); this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {


              
                LaborerRegistration f = new LaborerRegistration();

                f.Show();
                this.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd;


            string query;



            query = "select laborername LABORER,id 'ID[Laborer]',(select username from logintable where id= potentialcustomerid) 'Applicant',potentialcustomerid 'ID[Applicant]', picture 'Picture[Laborer]' from laborertable IMAGE where      (potentialcustomerid!=null or potentialcustomerid!='') and  hirerid!='Pending';";

            cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();


            if (dr.HasRows == false)
            { DialogResult d = MessageBox.Show("Customers are yet to apply for Laborers", "Not Now", MessageBoxButtons.OK, MessageBoxIcon.Information); }







            else
            {
                con.Close(); ManagerConfirmingHiring f = new ManagerConfirmingHiring();

                f.Show(); this.Visible = false;
            }

            con.Close();

            con.Dispose();
            cmd.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
                if (numericUpDown1.Text != "" && Convert.ToInt32(numericUpDown1.Text) <= Convert.ToInt32(label3.Text) && Convert.ToInt32(numericUpDown1.Text)>=0 )
                {


                label3.Text = (  (  Convert.ToInt32(label3.Text)  - Convert.ToInt32(numericUpDown1.Text)   ) ).ToString();

                    SqlConnection conMM = new SqlConnection(cs);

                    string queryMM = "update logintable set balance= @newBalance   from logintable where UserType='Manager' and id=(select id from loggedinuserinfo );";

                    SqlCommand cmdMM = new SqlCommand(queryMM, conMM);



                    cmdMM.Parameters.AddWithValue("@newBalance ", label3.Text);



                    conMM.Open();
                    int xMM = cmdMM.ExecuteNonQuery();
                    conMM.Close();

                conMM.Dispose();
                cmdMM.Dispose();


                DialogResult dQ = MessageBox.Show("Withdrew Salary Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.ShowBalance();


                }

            else if(Convert.ToInt32(label3.Text)==0) { DialogResult d = MessageBox.Show("Your Balance is 0", "Not Now", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { DialogResult d = MessageBox.Show("Enter a Proper Value First", "Not Now", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            


          /*  catch (System.Data.SqlClient.SqlException)
            {
                DialogResult dQ = MessageBox.Show("Please Try Again", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form7 f = new Form7(); f.Show(); this.Visible = false;

            } */

           

        }

        private void button3_Click(object sender, EventArgs e)
        {


            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            panel1.Visible = true;
            panel2.Visible = false;
            button7.Visible = false;

            this.ShowBalance();

            label1.Text = "Salary Withdrawal";
        }


        private void ShowBalance()
        {
            SqlConnection conHHH = new SqlConnection(cs);

            string qryHHH = "select balance from logintable where usertype='Manager' and id=(select id from loggedinuserinfo);";

            SqlCommand scmdHHH = new SqlCommand(qryHHH, conHHH);





            conHHH.Open();

            int xHHH = scmdHHH.ExecuteNonQuery();

            SqlDataReader sdrHHH = scmdHHH.ExecuteReader();

            sdrHHH.Read();


            if (sdrHHH.HasRows == true)
            {

                label3.Text = sdrHHH.GetString(0);





            }

            sdrHHH.Close();
            conHHH.Close();
            conHHH.Dispose();
            scmdHHH.Dispose();

        }





        private void button6_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            panel1.Visible = false;
            button7.Visible = true;

            label1.Text = "Manager Menu";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.Yellow;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.CornflowerBlue;

        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.BackColor = Color.Yellow;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.CornflowerBlue;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.Red;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.PaleGoldenrod;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.Orange;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.DeepSkyBlue;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Orange;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.DeepSkyBlue;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.DeepSkyBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Orange;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = true;


            SqlConnection conHH = new SqlConnection(cs);

            string qryHH = "select * from logintable where usertype='Manager' and id=(select id from loggedinuserinfo);";

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

                catch (System.InvalidCastException) { this.pictureBox1.Image = Properties.Resources.head; }



                sdrHH.Close();

            }
            conHH.Close();
            conHH.Dispose();
            scmdHH.Dispose();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        Image getPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);

            return Image.FromStream(ms);



        }
        private void button9_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = false;
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            button9.BackColor = Color.GreenYellow;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = Color.SlateBlue;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            button7.BackColor = Color.DeepSkyBlue;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.Orange;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image File (All files) *.* | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);

            }
        }

        private byte[] SavePhoto()
        {

            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);

            return ms.GetBuffer();
        }

        private void button8_Click(object sender, EventArgs e)
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

        private void button10_MouseHover(object sender, EventArgs e)
        {
            button10.BackColor = Color.Yellow;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.BackColor = Color.Coral;
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            button8.BackColor = Color.Yellow;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.CornflowerBlue;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
