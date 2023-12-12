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
    public partial class bill : Form
    {
        public bill()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\New folder\New folder\DMS\DMS\DMS\customer1.mdf;Integrated Security=True;User Instance=True");
     
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void bill_Load(object sender, EventArgs e)
        {
            //con.Open();
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select * from collect  where date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'and id ='" + textBox1.Text + "' ";
            //cmd.ExecuteNonQuery();
            //d dsa = new d();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dsa.DataTable1);
            //CrystalReport7 cr = new CrystalReport7();
            //cr.SetDataSource(dsa);
            //crystalReportViewer1.ReportSource = cr;
            //con.Close();
        }
    }
}
