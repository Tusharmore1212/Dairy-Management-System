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
    public partial class newpro : Form
    {
        public newpro()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\New folder\New folder\DMS\DMS\DMS\customer1.mdf;Integrated Security=True;User Instance=True");

        private void newpro_Load(object sender, EventArgs e)
        {
            getid();
            populate();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into newproduct values('" + textBox2.Text + "',N'" + textBox3.Text + "','" + textBox5.Text + "')";
                // db.ExecuteSqlQuery("inset into AccountTbl values('"+AccNumTb.Text+"','"+AccNameTb.Text+"','"+FaNameTb.Text+"','"+dobdate.Value.Date+"','"+PhoneTb.Text+"','"+AddressTb.Text+"','"+educationtb.SelectedItem.ToString()+"','"+occupationTb.Text+"','"+pinTb.Text+"');
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Saved");
                con.Close();
                populate();
                textBox5.Clear();
                textBox2.Focus();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Enter values");
            }
            try
            {
                con.Open();
                string queryy = "insert into product_stock values('" + textBox2.Text + "',N'" + textBox3.Text + "','" + textBox5.Text + "')";
                // db.ExecuteSqlQuery("inset into AccountTbl values('"+AccNumTb.Text+"','"+AccNameTb.Text+"','"+FaNameTb.Text+"','"+dobdate.Value.Date+"','"+PhoneTb.Text+"','"+AddressTb.Text+"','"+educationtb.SelectedItem.ToString()+"','"+occupationTb.Text+"','"+pinTb.Text+"');
                SqlCommand ckd = new SqlCommand(queryy, con);
                ckd.ExecuteNonQuery();

    
                con.Close();
                

                textBox3.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter values");
            }
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

            SqlDataAdapter sda = new SqlDataAdapter("select max(Product_id) from newproduct ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            try
            {
                id = Convert.ToInt32(dt.Rows[0][0].ToString());
                a = id + 1;
            }
            catch (Exception ex)
            {
                a = 101;
            }

            con.Close();
            
            textBox2.Text = Convert.ToString(a);


        }
        private void populate()
        {
            con.Open();
            string query = "select * from newproduct";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MINI.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                string que = "delete from newproduct where Product_id = " + textBox2.Text + "";
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

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Customer c = new Add_Customer();
            this.Hide();
            c.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Collection c = new Collection();
            this.Hide();
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fat f = new Fat();
            this.Hide();
            f.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Feeds f = new Feeds();
            this.Hide();
            f.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            records r = new records();
            this.Hide();
            r.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Products p = new Products();
            this.Hide();
            p.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Report r = new Report();
            this.Show();
            r.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox5.Clear();
            getid();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                string Que = "update newproduct set Product_Rate= '" + textBox5.Text + "'where Product_id ='" + textBox2.Text + "' and Size ='" + textBox3.Text + "'";
                SqlCommand ckd = new SqlCommand(Que, con);
                ckd.ExecuteNonQuery();
                con.Close();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                textBox2.Focus();
                populate();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Values");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Products p = new Products();
            this.Hide();
            p.Show();
        }
    }
}
