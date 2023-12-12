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
    public partial class Fat : Form
    {
        public Fat()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CowFat c = new CowFat();
            c.Show();
            this.Hide();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            BufFatRate b = new BufFatRate();
            b.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Collection c = new Collection();
            c.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Customer a = new Add_Customer();
            a.Show();
            this.Hide();
        }

        private void Fat_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

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
    }
}
