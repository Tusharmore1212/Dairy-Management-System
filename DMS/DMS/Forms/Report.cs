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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            
            
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
           
            
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cowfatrpt c = new cowfatrpt();
            
            c.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Feestockrpt f = new Feestockrpt();
          
            f.Show();
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            productstockrpt p = new productstockrpt();
            //this.Hide();
            p.Show();
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
            this.Hide();
            r.Show();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login_Form l = new Login_Form();
            this.Hide();
            l.Show();
            
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            collectionrpt c = new collectionrpt();
            c.Show();
        }
    }
}
