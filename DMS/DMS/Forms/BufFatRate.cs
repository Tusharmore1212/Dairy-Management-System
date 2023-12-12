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
    public partial class BufFatRate : Form
    {
        public BufFatRate()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\New folder\New folder\DMS\DMS\DMS\customer1.mdf;Integrated Security=True;User Instance=True");
 
        string bal;

        private void BufFatRate_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into BufFat values('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "')";
                // db.ExecuteSqlQuery("inset into AccountTbl values('"+AccNumTb.Text+"','"+AccNameTb.Text+"','"+FaNameTb.Text+"','"+dobdate.Value.Date+"','"+PhoneTb.Text+"','"+AddressTb.Text+"','"+educationtb.SelectedItem.ToString()+"','"+occupationTb.Text+"','"+pinTb.Text+"');
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Saved");
                con.Close();
                populate();
                //textBox1.Clear();
                textBox2.Clear();
                //  textBox3.Clear();
                textBox1.Focus();
                getid();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter values");
            }
        }

          private void populate()
        {
            con.Open();
            string query = "select * from BufFat";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MINI.DataSource = ds.Tables[0];
            con.Close();
        }

          private void button9_Click(object sender, EventArgs e)
          {
              try
              {
                  con.Open();
                  string Que = "update BufFat set rate= '" + textBox2.Text + "'where Fat =" + textBox1.Text + "and snf= '" + textBox3.Text + "'";
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

          private void button10_Click(object sender, EventArgs e)
          {
              try
              {
                  con.Open();
                  string que = "delete BufFat where Fat = " + textBox1.Text + " and snf= '" + textBox3.Text + "'";
                  SqlCommand cmd = new SqlCommand(que, con);
                  cmd.ExecuteNonQuery();
                  con.Close();
                  populate();
                  textBox1.Clear();
                  textBox2.Clear();
                  textBox3.Clear();
                  textBox1.Focus();
              }
              catch (Exception)
              {
                  MessageBox.Show("Enter Values");
              }
          }

          private void button7_Click(object sender, EventArgs e)
          {
              try
              {
                  con.Open();
                  SqlDataAdapter sda = new SqlDataAdapter("select Rate from BufFat where Fat = '" + textBox1.Text + "' and snf='" + textBox3.Text + "'", con);
                  DataTable dt = new DataTable();
                  sda.Fill(dt);
                  bal = dt.Rows[0][0].ToString();
                  textBox2.Text = bal;
                  con.Close();
              }
              catch( Exception)
              {
                  MessageBox.Show("Enter Values");
              }
          }
          void GridDataDis1()
          {
              try
              {
                  textBox1.Text = MINI.SelectedRows[0].Cells["Fat"].Value.ToString();
                  textBox2.Text = MINI.SelectedRows[0].Cells["Rate"].Value.ToString();
                  textBox3.Text = MINI.SelectedRows[0].Cells["snf"].Value.ToString();
                  //texttypeid.Text = dataGridView1.SelectedRows[0].Cells["typeid"].Value.ToString();




              }
              catch { }
          }

          private void MINI_MouseClick(object sender, MouseEventArgs e)
          {
              GridDataDis1();
          }

          private void button1_Click(object sender, EventArgs e)
          {
              Add_Customer a = new Add_Customer();
              a.Show();
              this.Hide();
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
              f.Show();
              this.Hide();
          }

          private void button4_Click(object sender, EventArgs e)
          {
              records r = new records();
              r.Show();
              this.Hide();
          }
          double id;
          private void pictureBox1_Click(object sender, EventArgs e)
          {

              Login_Form l = new Login_Form();
              this.Hide();
              l.Show();
          }
          void getid()
          {
              double a;
              textBox2.Focus();

              try
              {
                  id = Convert.ToDouble(textBox3.Text);
              }
              catch (Exception ex)
              {
                  a = 0;
              }
              a = id + 0.1;
              textBox3.Text = Convert.ToString(a);


          }

          private void textBox2_TextChanged(object sender, EventArgs e)
          {

          }

          private void button11_Click(object sender, EventArgs e)
          {
              Feeds c = new Feeds();
              c.Show();
              this.Hide();
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
              Fat f = new Fat();
              this.Hide();
              f.Show();
          }
    }
}
