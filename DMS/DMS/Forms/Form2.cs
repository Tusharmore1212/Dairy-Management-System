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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\New folder\New folder\DMS\DMS\DMS\customer1.mdf;Integrated Security=True;User Instance=True");
     
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from customer";
            cmd.ExecuteNonQuery();
            DataSet1 dsa = new DataSet1();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dsa.DataTable1);
            CrystalReport4 cr = new CrystalReport4();
            cr.SetDataSource(dsa);
            crystalReportViewer1.ReportSource = cr;
            con.Close();
        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
