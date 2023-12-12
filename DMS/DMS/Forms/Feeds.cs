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
    public partial class Feeds : Form
    {
        public Feeds()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FeedStock c = new FeedStock();
            c.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            hh c = new hh();
            c.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ViewStock c = new ViewStock();
            c.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Customer c = new Add_Customer();
            c.Show();
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
            Fat c = new Fat();
            c.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Feeds c = new Feeds();
            c.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            records c = new records();
            c.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login_Form l = new Login_Form();
            this.Hide();
            l.Show();
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
            r.Show();
            this.Show();
        }

    }
}
