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
    public partial class cowfatrpt : Form
    {
        public cowfatrpt()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\New folder\New folder\DMS\DMS\DMS\customer1.mdf;Integrated Security=True;User Instance=True");
     
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void cowfatrpt_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from CowFATRate";
            cmd.ExecuteNonQuery();
            DataSet3 dsa = new DataSet3();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dsa.DataTable1);
            CrystalReport3 cr = new CrystalReport3();
            cr.SetDataSource(dsa);
            crystalReportViewer1.ReportSource = cr;
            con.Close();
        }
    }
}
