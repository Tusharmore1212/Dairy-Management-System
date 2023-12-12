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
    public partial class hh : Form
    {
        public hh()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\New folder\New folder\DMS\DMS\DMS\customer1.mdf;Integrated Security=True;User Instance=True");

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Enter Values");

            }
            else
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    string query = "insert into  FeedSales values('" + textBox1.Text + "','" + textBox2.Text + "',N'" + textBox3.Text + "',N'" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Value.Date + "')";
                    // db.ExecuteSqlQuery("inset into AccountTbl values('"+AccNumTb.Text+"','"+AccNameTb.Text+"','"+FaNameTb.Text+"','"+dobdate.Value.Date+"','"+PhoneTb.Text+"','"+AddressTb.Text+"','"+educationtb.SelectedItem.ToString()+"','"+occupationTb.Text+"','"+pinTb.Text+"');
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("data saved");
                    con.Close();
                    populate();
                    textBox1.Focus();
                    textBox2.Clear();
                    textBox1.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox3.Clear();
                    getid();
                }
                catch (Exception)
                {
                    //                    MessageBox.Show("Error in Add");
                }

            }
        }
        private void populate()
        {
            con.Open();
            string query = "select * from FP where invoice_id = '"+textBox1.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MINI.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox2.Focus();
            textBox5.Clear();
            textBox6.Clear();
            getid();
        }
        int id;
        void getid()
        {
            int a;
            textBox1.Focus();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            SqlDataAdapter sda = new SqlDataAdapter("select max(invoice_id) from FeedSales", con);
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

        private void button9_Click(object sender, EventArgs e)
        {
            
        }
        void GridDataDis1()
        {
            try
            {
                textBox1.Text = MINI.SelectedRows[0].Cells["invoice_id"].Value.ToString();
                //textBox2.Text = MINI.SelectedRows[0].Cells["contact"].Value.ToString();
                //textBox3.Text = MINI.SelectedRows[0].Cells["CustomerName"].Value.ToString();
                comboBox1.Text = MINI.SelectedRows[0].Cells["cattle_feed_name"].Value.ToString();
                textBox4.Text = MINI.SelectedRows[0].Cells["Quantity"].Value.ToString();
                textBox5.Text = MINI.SelectedRows[0].Cells["rate"].Value.ToString();
                textBox6.Text = MINI.SelectedRows[0].Cells["total"].Value.ToString();

                //texttypeid.Text = dataGridView1.SelectedRows[0].Cells["typeid"].Value.ToString();




            }
            catch { }
        }
        private void button10_Click(object sender, EventArgs e)
        {

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                string que = "delete FeedSales where id = '" + textBox1.Text + "'and dat ='" + dateTimePicker1.Value + "'";
                SqlCommand cmd = new SqlCommand(que, con);
                cmd.ExecuteNonQuery();
                con.Close();
                populate();
                textBox1.Clear();
                //textBox2.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                textBox2.Focus();
                textBox5.Clear();
                textBox6.Clear();

                textBox1.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Error in delete");
            }
        }

        private void Cattle_Feed_Load(object sender, EventArgs e)
        {
            populate();
            getid();
        }

        private void MINI_MouseClick(object sender, MouseEventArgs e)
        {
            GridDataDis1();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        string bal;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlDataAdapter sda = new SqlDataAdapter("select name from customer where id = " + textBox2.Text + "", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                bal = dt.Rows[0][0].ToString();
                textBox3.Text = bal;
                con.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("error1");

            }


        }
        string rate;
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sellig_Rate from FeedStock where CattleFeed= '" + comboBox1.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rate = dt.Rows[0][0].ToString();
                textBox5.Text = rate;

                con.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("error2");

            }
            try
            {
                double totalrate;
                totalrate = (double.Parse(textBox4.Text) * double.Parse(textBox5.Text));
                textBox6.Text = Convert.ToString(totalrate);
            }
            catch (Exception)
            {
            }
         

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double totalrate;
                totalrate = (double.Parse(textBox4.Text) * double.Parse(textBox5.Text));
                textBox6.Text = Convert.ToString(totalrate);
            }
            catch (Exception)
            {
            }
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
                    quant = q - Convert.ToInt32(textBox4.Text);
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
   
        private void button11_Click(object sender, EventArgs e)
        {
            Feeds c = new Feeds();
            c.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login_Form l = new Login_Form();
            this.Hide();
            l.Show();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                string que = "delete FP where invoice_id = '" + textBox1.Text + "'and cattle_feed_name =N'"+comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(que, con);
                cmd.ExecuteNonQuery();
                con.Close();
                populate();
                textBox1.Clear();
                //textBox2.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                textBox2.Focus();
                textBox5.Clear();
                textBox6.Clear();

                textBox1.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Error in delete");
            }
      
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sellig_Rate from FeedStock where CattleFeed= N'" + comboBox1.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rate = dt.Rows[0][0].ToString();
                textBox5.Text = rate;

                con.Close();
            }
            catch (Exception)
            {
                //    //MessageBox.Show("error2");

            }
            try
            {
                double totalrate;
                totalrate = (double.Parse(textBox4.Text) * double.Parse(textBox5.Text));
                textBox6.Text = Convert.ToString(totalrate);
            }
            catch (Exception)
            {
            }
            

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Enter Values");

            }
            else
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    string query = "insert into  FP values('" + textBox1.Text + "',N'" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                    // db.ExecuteSqlQuery("inset into AccountTbl values('"+AccNumTb.Text+"','"+AccNameTb.Text+"','"+FaNameTb.Text+"','"+dobdate.Value.Date+"','"+PhoneTb.Text+"','"+AddressTb.Text+"','"+educationtb.SelectedItem.ToString()+"','"+occupationTb.Text+"','"+pinTb.Text+"');
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    fSupdate();
                    MessageBox.Show("data saved");
                    con.Close();
                    populate();

                    textBox1.Focus();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    
                }
                catch (Exception)
                {
                    //                    MessageBox.Show("Error in Add");
                }
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlDataAdapter daa = new SqlDataAdapter("select sum(total) from FP  where invoice_id ='" + textBox1.Text + "'", con);
                DataTable dkk = new DataTable();
                daa.Fill(dkk);
                label.Text = dkk.Rows[0][0].ToString();
                con.Close();
                getid();
            }
        }

        private void MINI_MouseClick_1(object sender, MouseEventArgs e)
        {
            GridDataDis1();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Que = "update FeedSales set CattleFeed =N'" + comboBox1.Text + "',Quantity = '" + textBox4.Text + "',Rate= '" + textBox5.Text + "',Total = '" + textBox6.Text + "' where id='" + textBox1.Text + "'  ";
                SqlCommand ckd = new SqlCommand(Que, con);
                ckd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("updated");
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                textBox2.Focus();
                textBox5.Clear();
                textBox6.Clear();
                //textBox1.Clear();
                //textBox2.Clear();
                textBox1.Focus();

                populate();
                //  MessageBox.Show("Error in update");
            }
            catch (Exception)
            {
                //MessageBox.Show("Error in update");
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox2.Focus();
            textBox5.Clear();
            textBox6.Clear();
            getid();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Feeds f = new Feeds();
            this.Hide();
            f.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    string query = "insert into  FeedSales values('" + textBox1.Text + "',N'" + textBox3.Text + "','" + dateTimePicker1.Value.Date + "','" + textBox2.Text + "')";
                    // db.ExecuteSqlQuery("inset into AccountTbl values('"+AccNumTb.Text+"','"+AccNameTb.Text+"','"+FaNameTb.Text+"','"+dobdate.Value.Date+"','"+PhoneTb.Text+"','"+AddressTb.Text+"','"+educationtb.SelectedItem.ToString()+"','"+occupationTb.Text+"','"+pinTb.Text+"');
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("data saved");
                    con.Close();
                    populate();
                    textBox1.Focus();
                    textBox2.Clear();
                    textBox1.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox3.Clear();
                    getid();
                }
                catch (Exception)
                {
                    //                 
                }
            
        }

        private void label_Click(object sender, EventArgs e)
        {

        }
    }
}