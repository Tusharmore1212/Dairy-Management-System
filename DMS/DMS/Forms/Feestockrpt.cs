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
    public partial class Feestockrpt : Form
    {
        public Feestockrpt()
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

        private void Feestockrpt_Load(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from FeedStock";
            cmd.ExecuteNonQuery();
            DataSet4 dsa = new DataSet4();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dsa.DataTable1);
            CrystalReport5 cr = new CrystalReport5();
            cr.SetDataSource(dsa);
            crystalReportViewer1.ReportSource = cr;
            con.Close();
        }
    }
}
