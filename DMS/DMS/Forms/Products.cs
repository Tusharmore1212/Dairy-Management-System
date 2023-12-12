using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMS.Forms
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            add_product n = new add_product();
            this.Hide();
            n.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            product_sales p = new product_sales();
            this.Hide();
            p.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Customer n = new Add_Customer();
            this.Hide();
            n.Show();
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

        private void button8_Click(object sender, EventArgs e)
        {
            showproduct v = new showproduct();
            this.Hide();
            v.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            newpro n = new newpro();
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
