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
    public partial class add_product : Form
    {
        public add_product()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\New folder\New folder\DMS\DMS\DMS\customer1.mdf;Integrated Security=True;User Instance=True");

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into Add_product values('" + textBox1.Text + "','" + textBox2.Text + "',N'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Value.Date + "')";
                // db.ExecuteSqlQuery("inset into AccountTbl values('"+AccNumTb.Text+"','"+AccNameTb.Text+"','"+FaNameTb.Text+"','"+dobdate.Value.Date+"','"+PhoneTb.Text+"','"+AddressTb.Text+"','"+educationtb.SelectedItem.ToString()+"','"+occupationTb.Text+"','"+pinTb.Text+"');
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Saved");
                con.Close();
                populate();
                //textBox1.Clear();
         
                //  textBox3.Clear();
                textBox1.Focus();
                getid();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter values");
            }
            fSupdate();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from Add_product";
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
            textBox2.Focus();

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataAdapter sda = new SqlDataAdapter("select max(id) from Add_product ", con);
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

        private void add_product_Load(object sender, EventArgs e)
        {
            getid();
            populate();
        }
        void GridDataDis1()
        {
            try
            {
                textBox1.Text = MINI.SelectedRows[0].Cells["id"].Value.ToString();
                textBox2.Text = MINI.SelectedRows[0].Cells["Product_id"].Value.ToString();
                //texttypeid.Text = dataGridView1.SelectedRows[0].Cells["typeid"].Value.ToString();
                textBox3.Text = MINI.SelectedRows[0].Cells["Product_Name"].Value.ToString();
                textBox4.Text = MINI.SelectedRows[0].Cells["Size"].Value.ToString();
                textBox5.Text = MINI.SelectedRows[0].Cells["Rate"].Value.ToString();
                textBox6.Text = MINI.SelectedRows[0].Cells["Total_Amount"].Value.ToString();
                //comboBox1.Text = MINI.SelectedRows[0].Cells["Measer_In"].Value.ToString();
             


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
                string que = "delete from Add_product where id = " + textBox1.Text + "";
                SqlCommand cmd = new SqlCommand(que, con);
                cmd.ExecuteNonQuery();
                con.Close();
                populate();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Valid data");
            }
        }

        private void MINI_MouseClick(object sender, MouseEventArgs e)
        {
            GridDataDis1();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                string Que = "update product_stock set Product_Quan= '" + textBox4.Text + "'where id ='" + textBox1.Text + "' and Size ='" + textBox3.Text + "'";
                SqlCommand ckd = new SqlCommand(Que, con);
                ckd.ExecuteNonQuery();
                con.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
                populate();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Values");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            getid();
        }

        private void label3_Click(object sender, EventArgs e)
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
        int q;
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
                q = Convert.ToInt32(dt.Rows[0][0].ToString());
               
                con.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("error1");

            }
            int quant;

            quant = q + Convert.ToInt32(textBox4.Text);
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
                //MessageBox.Show("Enter Valid Data");
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox6.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox4.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Products n = new Products();
            this.Hide();
            n.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Report r = new Report();
            this.Show();
            r.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MINI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login_Form l = new Login_Form();
            this.Hide();
            l.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        string qq;
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlDataAdapter sda = new SqlDataAdapter("select Product_Rate from newproduct where Product_id = '" + textBox2.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                qq = dt.Rows[0][0].ToString();
                textBox5.Text = qq;
                con.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("error1");

            }
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Products p = new Products();
            this.Hide();
            p.Show();
        }
   

    }
}
