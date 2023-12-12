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
    public partial class Add_Customer : Form
    {
        public Add_Customer()
        {
            InitializeComponent();

        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\New folder\New folder\DMS\DMS\DMS\customer1.mdf;Integrated Security=True;User Instance=True");
        int id;
        private void Add_Customer_Load(object sender, EventArgs e)
        {
            populate();
            getid();
          
        }
        private void populate()
        {
            con.Open();
            string query = "select * from customer";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MINI.DataSource = ds.Tables[0];
            con.Close();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into customer values(N'" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + comboBox1.Text + "','" + jd.Value.Date + "',N'" + textBox4.Text + "')";
                // db.ExecuteSqlQuery("inset into AccountTbl values('"+AccNumTb.Text+"','"+AccNameTb.Text+"','"+FaNameTb.Text+"','"+dobdate.Value.Date+"','"+PhoneTb.Text+"','"+AddressTb.Text+"','"+educationtb.SelectedItem.ToString()+"','"+occupationTb.Text+"','"+pinTb.Text+"');
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Account Created Successfully");
                con.Close();
                populate();
            }
            catch (Exception)
            {
                MessageBox.Show("duplicate id");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Que = "update customer set name= N'" + textBox2.Text + "',type =N'" + comboBox1.Text + "',date='" + jd.Value.Date + "',mobile=N'" + textBox4.Text + "' where id =N'" + textBox1.Text + "'";
                SqlCommand ckd = new SqlCommand(Que, con);
                ckd.ExecuteNonQuery();
                con.Close();
                populate();
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

                con.Open();
                string que = "delete from customer where id = N'" + textBox1.Text + "'";
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
        void GridDataDis1()
        {
            try
            {
                textBox1.Text = MINI.SelectedRows[0].Cells["id"].Value.ToString();
                textBox2.Text = MINI.SelectedRows[0].Cells["name"].Value.ToString();
                //texttypeid.Text = dataGridView1.SelectedRows[0].Cells["typeid"].Value.ToString();
                comboBox1.Text = MINI.SelectedRows[0].Cells["type"].Value.ToString();
                textBox4.Text = MINI.SelectedRows[0].Cells["mobile"].Value.ToString();
                jd.Text = MINI.SelectedRows[0].Cells["dob"].Value.ToString();



            }
            catch { }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox2.Focus();
            getid();
            
        }

        private void MINI_MouseClick(object sender, MouseEventArgs e)
        {
            GridDataDis1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Collection c = new Collection();
            c.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fat f = new Fat();
            this.Hide();
            f.Show();
        }
        void getid()
        {
            int a;
            textBox2.Focus();

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataAdapter sda = new SqlDataAdapter("select max(id) from customer", con);
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

        private void button4_Click(object sender, EventArgs e)
        {
            records r = new records();
            r.Show();
            this.Hide();
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

        private void button11_Click(object sender, EventArgs e)
        {
            Feeds c = new Feeds();
            c.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Products n = new Products();
            this.Hide();
            n.Show();
        }
    }
}
