using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DMS.Forms
{
    public partial class records : Form
    {
        public records()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\New folder\New folder\DMS\DMS\DMS\customer1.mdf;Integrated Security=True;User Instance=True");
        public static string idd,d1,d2;
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //con.Open();
                //DateTime dtdate1 = DateTime.Parse(dateTimePicker1.Text);
                //DateTime dtdate2 = DateTime.Parse(dateTimePicker2.Text);
                //string query = "select * from collect where date1 between #" +dtdate1.ToString("mm/dd/yyyy")+ " # and " +dtdate2.ToString("mm/dd/yyyy")+"",con;
                //con.close
                DataTable dt = new DataTable();
                con.Open();
                string sql = "select * from collect  where date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'and id ='" + textBox1.Text + "' ";
                SqlDataAdapter sd = new SqlDataAdapter(sql, con);

                //sd.SelectCommand.Parameters.AddWithValue("@date1", dateTimePicker1.Value);
                //sd.SelectCommand.Parameters.AddWithValue("@date2", dateTimePicker2.Value);
                sd.Fill(dt);
                con.Close();
                MINI.DataSource = dt;
                

            }
            catch (Exception)
            {
                MessageBox.Show("Enter Valid Data");
            }
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select sum(ltr) from collect  where date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'and id ='" + textBox1.Text + "'", con);
                DataTable dk = new DataTable();
                da.Fill(dk);
                dudh.Text = dk.Rows[0][0].ToString();
                con.Close();
            }
            catch(Exception)
            {

            }
            try
            {
                con.Open();
                SqlDataAdapter daa = new SqlDataAdapter("select sum(totalrate) from collect  where date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'and id ='" + textBox1.Text + "'", con);
                DataTable dkk = new DataTable();
                daa.Fill(dkk);
                money.Text = dkk.Rows[0][0].ToString();
                con.Close();
            }
            catch (Exception)
            {

            }
        }

    
        private void records_Load(object sender, EventArgs e)
        {
           
        }

       

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void MINI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Add_Customer a = new Add_Customer();
            a.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Collection c = new Collection();
            c.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Fat f = new Fat();
            f.Show();
            this.Hide();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           
        }

        private void records_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Login_Form l = new Login_Form();
            this.Hide();
            l.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Feeds c = new Feeds();
            c.Show();
            this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Products p = new Products();
            this.Hide();
            p.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Report r = new Report();
            this.Show();
            r.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
