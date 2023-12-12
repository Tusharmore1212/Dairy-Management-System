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
    public partial class FeedStock : Form
    {
        public FeedStock()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\New folder\New folder\DMS\DMS\DMS\customer1.mdf;Integrated Security=True;User Instance=True");

        private void button7_Click(object sender, EventArgs e)
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox2.Focus();
            textBox5.Clear();

            getid();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from FeedStock";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MINI.DataSource = ds.Tables[0];
            con.Close();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            //    try
            //    {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            string query = "insert into  FeedStock values('" + textBox1.Text + "',N'" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            // db.ExecuteSqlQuery("inset into AccountTbl values('"+AccNumTb.Text+"','"+AccNameTb.Text+"','"+FaNameTb.Text+"','"+dobdate.Value.Date+"','"+PhoneTb.Text+"','"+AddressTb.Text+"','"+educationtb.SelectedItem.ToString()+"','"+occupationTb.Text+"','"+pinTb.Text+"');
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("data saved");
            con.Close();
            populate();
            textBox2.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
     
            textBox5.Clear();
            textBox1.Clear();
            textBox1.Focus();
            getid();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Enter Values");
            //}
        }

        private void button9_Click(object sender, EventArgs e)
        {

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                string Que = "update FeedStock set CattleFeed= '" + comboBox1.Text + "',Quantity='" + textBox2.Text + "',selling_Rate='" + textBox4.Text + "',Total='" + textBox5.Text + "' where id =" + textBox1.Text + "";
                SqlCommand ckd = new SqlCommand(Que, con);
                ckd.ExecuteNonQuery();
                con.Close();
                populate();
                textBox1.Clear();
                textBox2.Clear();
                
                textBox4.Clear();
                textBox5.Clear();
                textBox1.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Valid Data");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string que = "delete from FeedStock where id = " + textBox1.Text + "";
                SqlCommand cmd = new SqlCommand(que, con);
                cmd.ExecuteNonQuery();
                con.Close();
                populate();
                textBox1.Clear();
                textBox2.Clear();
             //   textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

                textBox2.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Valid Data");
            }
        }
        void GridDataDis1()
        {
            try
            {
                textBox1.Text = MINI.SelectedRows[0].Cells["id"].Value.ToString();
                comboBox1.Text = MINI.SelectedRows[0].Cells["CattleFeed"].Value.ToString();
                textBox2.Text = MINI.SelectedRows[0].Cells["Quantity"].Value.ToString();
               // textBox3.Text = MINI.SelectedRows[0].Cells["Company_Rate"].Value.ToString();

                textBox4.Text = MINI.SelectedRows[0].Cells["Sellig_Rate"].Value.ToString();
                textBox5.Text = MINI.SelectedRows[0].Cells["Total"].Value.ToString();




            }
            catch { }
        }
        private void MINI_MouseClick(object sender, MouseEventArgs e)
        {
            GridDataDis1();
        }

        private void FeedStock_Load(object sender, EventArgs e)
        {
            populate();
            getid();
        }
        int id;
        void getid()
        {
            int a;
            textBox2.Focus();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            SqlDataAdapter sda = new SqlDataAdapter("select max(id) from FeedStock", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            try
            {
                id = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                a = 0;
            }

            con.Close();
            a = id + 1;
            textBox1.Text = Convert.ToString(a);


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double totalrate;
                totalrate = (double.Parse(textBox2.Text) * double.Parse(textBox4.Text));
                textBox5.Text = Convert.ToString(totalrate);
            }
            catch (Exception)
            {
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            try
            {
                double totalrate;
                totalrate = (double.Parse(textBox2.Text) * double.Parse(textBox4.Text));
                textBox5.Text = Convert.ToString(totalrate);
            }
            catch (Exception)
            {
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Feeds c = new Feeds();
            c.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login_Form C = new Login_Form();
            this.Hide();
            C.Show();
        }

        private void FeedStock_Load_1(object sender, EventArgs e)
        {
            populate();
            getid();
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            fSupdate();
            try
            {
                double totalrate;
                totalrate = (double.Parse(textBox2.Text) * double.Parse(textBox4.Text));
                textBox5.Text = Convert.ToString(totalrate);

            }
            catch (Exception)
            {
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            string query = "insert into  FeedStock values('" + textBox1.Text + "',N'" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Value.Date + "')";
            // db.ExecuteSqlQuery("inset into AccountTbl values('"+AccNumTb.Text+"','"+AccNameTb.Text+"','"+FaNameTb.Text+"','"+dobdate.Value.Date+"','"+PhoneTb.Text+"','"+AddressTb.Text+"','"+educationtb.SelectedItem.ToString()+"','"+occupationTb.Text+"','"+pinTb.Text+"');
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("data saved");
            con.Close();
           
            populate();
            textBox2.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Clear();
            textBox1.Focus();
            getid();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Enter Values");

        }

        private void button9_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                string Que = "update FeedStock set CattleFeed= N'" + comboBox1.Text + "',Quantity='" + textBox2.Text + "',Sellig_Rate='" + textBox4.Text + "',Total='" + textBox5.Text + "' where id =" + textBox1.Text + "";
                SqlCommand ckd = new SqlCommand(Que, con);
                ckd.ExecuteNonQuery();
                con.Close();
                populate();
                textBox1.Clear();
                textBox2.Clear();

                textBox4.Clear();
                textBox5.Clear();
                textBox1.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Valid Data");
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string que = "delete from FeedStock where id = " + textBox1.Text + "";
                SqlCommand cmd = new SqlCommand(que, con);
                cmd.ExecuteNonQuery();
                con.Close();
                populate();
                textBox1.Clear();
                textBox2.Clear();
                //textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

                textBox2.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Valid Data");
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox2.Focus();
            textBox5.Clear();

            getid();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

            try
            {
                double totalrate;
                totalrate = (double.Parse(textBox2.Text) * double.Parse(textBox4.Text));
                textBox5.Text = Convert.ToString(totalrate);
            }
            catch (Exception)
            {
            }
        }

        private void MINI_MouseClick_1(object sender, MouseEventArgs e)
        {
            GridDataDis1();
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Products n = new Products();
            this.Hide();
            n.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Report r = new Report();
            this.Show();
            r.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Feeds f = new Feeds();
            this.Hide();
            f.Show();
        }
        int q;
        void fSupdate()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlDataAdapter sda = new SqlDataAdapter("select Quantity from cfs where Cattle_Feed_Name = N'" + comboBox1.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                q = Convert.ToInt32(dt.Rows[0][0].ToString());
                con.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("error1");

            }
            int quant;


            try
            {
                quant = q + Convert.ToInt32(textBox2.Text);
                string quantt = Convert.ToString(quant);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                string Que = "update cfs set Quantity='" + quantt + "' Cattle_Feed_Name = N'" + comboBox1.Text + "'";
                SqlCommand ckd = new SqlCommand(Que, con);
                ckd.ExecuteNonQuery();
                con.Close();
                populate();

            }
            catch (Exception)
            {
                //MessageBox.Show("Enter Valid Data");
            }
        }
    }
}
