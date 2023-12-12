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
    public partial class showproduct : Form
    {
        public showproduct()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\New folder\New folder\DMS\DMS\DMS\customer1.mdf;Integrated Security=True;User Instance=True");
  
        private void newproduct_Load(object sender, EventArgs e)
        {
            populate();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from product_stock ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MINI.DataSource = ds.Tables[0];
            con.Close();
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Products p = new Products();
            this.Hide();
            p.Show();
        }

    }
}
