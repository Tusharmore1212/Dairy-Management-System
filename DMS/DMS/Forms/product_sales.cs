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
    public partial class product_sales : Form
    {
        public product_sales()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\New folder\New folder\DMS\DMS\DMS\customer1.mdf;Integrated Security=True;User Instance=True");

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        public static string fnum;
        private void button8_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                string query = "insert into product_sales values('" + textBox1.Text + "',N'" + textBox7.Text + "','" + dateTimePicker1.Value.Date + "','"+textBox8.Text+"')";
                // db.ExecuteSqlQuery("inset into AccountTbl values('"+AccNumTb.Text+"','"+AccNameTb.Text+"','"+FaNameTb.Text+"','"+dobdate.Value.Date+"','"+PhoneTb.Text+"','"+AddressTb.Text+"','"+educationtb.SelectedItem.ToString()+"','"+occupationTb.Text+"','"+pinTb.Text+"');
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Saved");
                con.Close();
                populate();
                fnum = textBox1.Text;
                //textBox1.Clear();

                //  textBox3.Clear();
                product_salesrpt c = new product_salesrpt();
                
                c.Show();
                textBox1.Focus();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Enter values");
            }
            getid();
            textBox7.Clear();
            textBox8.Clear();
            populate();
        }
        private void populate()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            string query = "select * from IP where invoice_id = '"+textBox1.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MINI.DataSource = ds.Tables[0];
            con.Close();
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

            SqlDataAdapter sda = new SqlDataAdapter("select max(invoice_id) from product_sales  ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            try
            {
                id = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                a = 1;
            }

            con.Close();
            a = id + 1;
            textBox1.Text = Convert.ToString(a);


        }

        private void product_sales_Load(object sender, EventArgs e)
        {
            getid();
            populate();
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
                SqlDataAdapter sda = new SqlDataAdapter("select Product_Name from product_stock where id = " + textBox2.Text + "", con);
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
        string q;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlDataAdapter sda = new SqlDataAdapter("select Rate from Add_product where Product_id = '" + textBox2.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                q = dt.Rows[0][0].ToString();
                textBox5.Text = q;
                con.Close();
            //}
            //catch (Exception)
            //{
            //    //MessageBox.Show("error1");

            //}
        }
         void GridDataDis1()
        {
            try
            {
                textBox1.Text = MINI.SelectedRows[0].Cells["invoice_id"].Value.ToString();
         
                textBox2.Text = MINI.SelectedRows[0].Cells["product_id"].Value.ToString();
                textBox3.Text = MINI.SelectedRows[0].Cells["product_Name"].Value.ToString();

                textBox4.Text = MINI.SelectedRows[0].Cells["quantity"].Value.ToString();
                textBox5.Text = MINI.SelectedRows[0].Cells["rate"].Value.ToString();
                textBox6.Text = MINI.SelectedRows[0].Cells["total"].Value.ToString();
                




            }
            catch { }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        int total1;
        int qq;
        void fSupdate()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlDataAdapter sda = new SqlDataAdapter("select Product_Quan from product_stock where id = '" + textBox2.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                qq = Convert.ToInt32(dt.Rows[0][0].ToString());

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("error1");

            }
            try
            {
                
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlDataAdapter daa = new SqlDataAdapter("select quantity from IP  where invoice_id ='" + textBox1.Text + "' and product_id = '"+textBox2.Text+"'", con);
                DataTable dkk = new DataTable();
                daa.Fill(dkk);
                total1 = Convert.ToInt32(dkk.Rows[0][0].ToString());
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("erro2");
            }
            int quant;

            quant = qq - total1;
            string quantt = Convert.ToString(quant);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                string Que = "update product_stock set Product_Quan='" + quantt + "' where id ='" + textBox2.Text + "'";
                SqlCommand ckd = new SqlCommand(Que, con);
                ckd.ExecuteNonQuery();
                con.Close();
                populate();

            }
            catch (Exception)
            {
                MessageBox.Show("Enter Valid Data");
            }
        //    textBox1.Clear();
        //    textBox2.Clear();
        //    textBox6.Clear();
        //    textBox3.Clear();
        //    textBox5.Clear();
        //    textBox4.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox6.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox4.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //try
            //{

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                string que = "delete from IP where invoice_id = '" + textBox1.Text + "' and product_id = '"+textBox2.Text+"'";
                SqlCommand cmd = new SqlCommand(que, con);
                cmd.ExecuteNonQuery();
                con.Close();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                populate();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Enter Valid data");
            //}
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            SqlDataAdapter sda = new SqlDataAdapter("select Rate from Add_product where Product_id = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            q = dt.Rows[0][0].ToString();
            textBox5.Text = q;
            con.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("error1");

            }
           
        }

        private void MINI_MouseClick(object sender, MouseEventArgs e)
        {
            GridDataDis1();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Products n = new Products();
            this.Hide();
            n.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login_Form l = new Login_Form();
            this.Hide();
            l.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Report r = new Report();
            this.Show();
            r.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Products p = new Products();
            this.Hide();
            p.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into IP values('" + textBox1.Text + "','" + textBox2.Text + "',N'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                // db.ExecuteSqlQuery("inset into AccountTbl values('"+AccNumTb.Text+"','"+AccNameTb.Text+"','"+FaNameTb.Text+"','"+dobdate.Value.Date+"','"+PhoneTb.Text+"','"+AddressTb.Text+"','"+educationtb.SelectedItem.ToString()+"','"+occupationTb.Text+"','"+pinTb.Text+"');
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Saved");
                con.Close();
                populate();
                //textBox1.Clear();

                //  textBox3.Clear();
                fSupdate();
                textBox1.Focus();

            }
            catch (Exception)
            {
                MessageBox.Show("Enter values");
            }
            

            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            //try
            //{
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
                SqlDataAdapter daa = new SqlDataAdapter("select sum(total) from IP  where invoice_id ='" + textBox1.Text + "'", con);
                DataTable dkk = new DataTable();
                daa.Fill(dkk);
                label.Text = dkk.Rows[0][0].ToString();
                con.Close();
            //}
            //catch (Exception)
            //{

            //}
               
        }

        private void button13_Click(object sender, EventArgs e)
        {
            product_salesrpt c = new product_salesrpt();
            c.Show();
        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Feeds f = new Feeds();
            this.Hide();
            f.Show();
        }
    }
}