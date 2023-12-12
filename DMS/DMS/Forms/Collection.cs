using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
namespace DMS.Forms
{
    public partial class Collection : Form
    {
        public Collection()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\New folder\New folder\DMS\DMS\DMS\customer1.mdf;Integrated Security=True;User Instance=True");
 
        string bal, type1;
        
        private void button8_Click(object sender, EventArgs e)
        {
            add();
            daily d = new daily();
            d.Show();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from collect";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MINI.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Collection_Load(object sender, EventArgs e)
        {
            populate();
        }
       
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                SqlDataAdapter sa = new SqlDataAdapter("select max(id) from customer", con);
                DataTable dat = new DataTable();
                sa.Fill(dat);
                id = Convert.ToInt32(dat.Rows[0][0].ToString());
                con.Close();

                if (id >= Convert.ToInt32(textBox2.Text))
                {

                    try
                    {
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("select name from customer where id = " + textBox2.Text + "", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        bal = dt.Rows[0][0].ToString();
                        textBox3.Text = bal;

                        SqlDataAdapter sdk = new SqlDataAdapter("select type from customer where id = " + textBox2.Text + "", con);
                        DataTable dj = new DataTable();
                        sdk.Fill(dj);
                        type1 = dj.Rows[0][0].ToString();
                        textBox4.Text = type1;
                        con.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("error");

                    }
                }
                else
                {
                    MessageBox.Show("Invalid id");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Values");
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

                string que = "delete from collect where id = " + textBox2.Text + "and date ='" + td.Value + "'";
                SqlCommand cmd = new SqlCommand(que, con);
                cmd.ExecuteNonQuery();
                con.Close();
                populate();
                textBox9.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
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
                textBox2.Text = MINI.SelectedRows[0].Cells["id"].Value.ToString();
                textBox3.Text = MINI.SelectedRows[0].Cells["name"].Value.ToString();
                //texttypeid.Text = dataGridView1.SelectedRows[0].Cells["typeid"].Value.ToString();
                textBox4.Text = MINI.SelectedRows[0].Cells["typ"].Value.ToString();
                comboBox1.Text = MINI.SelectedRows[0].Cells["timezone"].Value.ToString();
                textBox5.Text = MINI.SelectedRows[0].Cells["ltr"].Value.ToString();
                //texttypeid.Text = dataGridView1.SelectedRows[0].Cells["typeid"].Value.ToString();
                textBox7.Text = MINI.SelectedRows[0].Cells["snf"].Value.ToString();
                textBox6.Text = MINI.SelectedRows[0].Cells["fat"].Value.ToString();
                textBox8.Text = MINI.SelectedRows[0].Cells["rate"].Value.ToString();
                textBox9.Text = MINI.SelectedRows[0].Cells["totalrate"].Value.ToString();
                td.Text = MINI.SelectedRows[0].Cells["dob"].Value.ToString();



            }
            catch { }
        }



        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Que = "update collect set name= N'" + textBox3.Text + "',typ =N'" + textBox4.Text + "',date='" + td.Value.Date + "',ltr='" + textBox5.Text + "' where id =" + textBox2.Text + "";
                SqlCommand ckd = new SqlCommand(Que, con);
                ckd.ExecuteNonQuery();
                con.Close();
                populate();
                textBox9.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox2.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Valid Data");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Customer a = new Add_Customer();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fat f = new Fat();
            f.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MINI_MouseClick(object sender, MouseEventArgs e)
        {
            GridDataDis1();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double totalrate;
                totalrate = (double.Parse(textBox5.Text) * double.Parse(textBox8.Text));
                textBox9.Text = Convert.ToString(totalrate);
            }
            catch (Exception)
            { 
            }
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
                    
           
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        //    int fatrate;
        //    con.Open();

        //    SqlDataAdapter sda = new SqlDataAdapter("select Rate from CowFatRate where Fat = '" + textBox6.Text + "' and snf='" + textBox7.Text + "'", con);
        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    fatrate = Convert.ToInt32(dt.Rows[0][0].ToString());
        //    textBox8.Text = Convert.ToString(fatrate);
        //    con.Close();
            try
            {
                double fatrate;
                if (textBox4.Text == "म्हैस ")
                {
                    con.Open();
                    try
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select Rate from BufFat where Fat = N'" + textBox6.Text + "' and snf = N'" + textBox7.Text + "'", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        fatrate = Convert.ToDouble(dt.Rows[0][0].ToString());
                        textBox8.Text = Convert.ToString(fatrate);
                    }
                    catch (Exception)
                    {

                    }
                    con.Close();

                }
                else
                {


                    try
                    {
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("select Rate from CowFatRate where Fat = '" + textBox6.Text + "' and snf = '" + textBox7.Text + "'", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        fatrate = Convert.ToDouble(dt.Rows[0][0].ToString());
                        textBox8.Text = Convert.ToString(fatrate);
                        con.Close();

                    }
                    catch (Exception)
                    {
                        //   MessageBox.Show("error");
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Enter Valid Data3");
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox9.Clear();
  
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox2.Focus();
        }
        public static string cid, ctime;
        void add()
        {
            try
            {
                con.Open();
                string query = "insert into collect values('" + textBox2.Text + "',N'" + textBox3.Text + "',N'" + textBox4.Text + "','" + td.Value.Date + "',N'" + comboBox1.Text + "'," + textBox5.Text + ",'" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";
                // db.ExecuteSqlQuery("inset into AccountTbl values('"+AccNumTb.Text+"','"+AccNameTb.Text+"','"+FaNameTb.Text+"','"+dobdate.Value.Date+"','"+PhoneTb.Text+"','"+AddressTb.Text+"','"+educationtb.SelectedItem.ToString()+"','"+occupationTb.Text+"','"+pinTb.Text+"');
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("data collectded");
                con.Close();
                populate();
                cid = textBox2.Text;
                ctime = comboBox1.Text;
                
                textBox9.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox2.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Values");
            }
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

        private void button12_Click(object sender, EventArgs e)
        {
            
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            try
            {
                double totalrate;
                totalrate = (double.Parse(textBox5.Text) * double.Parse(textBox8.Text));
                textBox9.Text = Convert.ToString(totalrate);
            }
            catch (Exception)
            {
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            Feeds c = new Feeds();
            c.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
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
    }
}
