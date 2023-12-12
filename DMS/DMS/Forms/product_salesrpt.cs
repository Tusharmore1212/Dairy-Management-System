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
    public partial class product_salesrpt : Form
    {
        public product_salesrpt()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\New folder\New folder\DMS\DMS\DMS\customer1.mdf;Integrated Security=True;User Instance=True");
     
        private void product_salesrpt_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from product_sales inner join IP on product_sales.invoice_id = IP.invoice_id where product_sales.invoice_id = '"+product_sales.fnum+"'";
            cmd.ExecuteNonQuery();
            psd dsa = new psd();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dsa.DataTable1);
            prdrpt cr = new prdrpt();
            cr.SetDataSource(dsa);
            crystalReportViewer1.ReportSource = cr;
            con.Close();
        }
    }
}
