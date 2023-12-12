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
    public partial class daily : Form
    {
        public daily()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\New folder\New folder\DMS\DMS\DMS\customer1.mdf;Integrated Security=True;User Instance=True");
     
        private void daily_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from collect  where date= '" + DateTime.Now.ToString() + "'and id ='" + Collection.cid + "'and timezone=  N'" + Collection.ctime + "'";
            cmd.ExecuteNonQuery();
            DataSet7 dsa = new DataSet7();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dsa.DataTable1);
            dailyrpt cr = new dailyrpt();
            cr.SetDataSource(dsa);
            crystalReportViewer1.ReportSource = cr;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
