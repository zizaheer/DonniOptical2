using DonniOptical2.BusinessLogic;
using DonniOptical2.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonniOptical2
{
    public partial class FrmRptOrderDetail : Form
    {
        OrderManager orderManager;
        public FrmRptOrderDetail()
        {
            InitializeComponent();
            orderManager = new OrderManager();
        }



        private void FrmRptOrderDetail_Load(object sender, EventArgs e)
        {
            try
            {
                rptViewerOrderDetail = new ReportViewer();

                rptViewerOrderDetail.ProcessingMode = ProcessingMode.Local;

                LocalReport localReport = rptViewerOrderDetail.LocalReport;

                rptViewerOrderDetail.LocalReport.ReportPath = "orderDetailReport.rdlc";

                List<Order> orderList = new List<Order>();
                orderList = orderManager.GetOrders();


                ReportDataSource rptDataSource = new ReportDataSource("", GetOrders());

                rptViewerOrderDetail.LocalReport.DataSources.Clear();
                rptViewerOrderDetail.LocalReport.DataSources.Add(rptDataSource);
                rptViewerOrderDetail.RefreshReport();
            }
            catch (Exception ex)
            {

            }
        }

        private DataTable GetOrders()
        {
            SqlConnection sqlConnection;
            SqlCommand sqlCommand;
            SqlDataAdapter dataAdapter;

            string connString = ConfigurationManager.ConnectionStrings["opticalconnection"].ConnectionString;
            sqlConnection = new SqlConnection(connString);

            DataTable dt = new DataTable();

            sqlCommand = new SqlCommand("SELECT * FROM [Order]", sqlConnection);
            dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dt);

            return dt;
        }






    }
}
