using Optiks.BusinessLogic;
using Optiks.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optiks
{
    public partial class FrmRptOrder : Form
    {
        public FrmRptOrder()
        {
            InitializeComponent();
        }

        public int orderId;
        public int customerId;
        private void FrmRptOrder_Load(object sender, EventArgs e)
        {

            LocalReport localReport = reportViewerOrder.LocalReport;
            localReport.ReportPath = "RptOrder.rdlc";
            localReport.DataSources.Clear();

            //// Create a report data source   
            DataSet ds = new DataSet();
            DataTable dtCustomer = new DataTable();
            dtCustomer = GetCustomerById(customerId);
            ds.Tables.Add(dtCustomer);
            ReportDataSource rptSource = new ReportDataSource();
            rptSource.Name = "DataSetCustomer";
            rptSource.Value = ds.Tables["Customer"];
            localReport.DataSources.Add(rptSource);


            ds = new DataSet();
            DataTable dtOrder = new DataTable();
            dtOrder = GetOrderById(orderId);
            ds.Tables.Add(dtOrder);
            rptSource = new ReportDataSource();
            rptSource.Name = "DataSetOrder";
            rptSource.Value = ds.Tables["Order"];
            localReport.DataSources.Add(rptSource);


            ds = new DataSet();
            DataTable dtOrderDetail = new DataTable();
            dtOrderDetail = GetOrderDetailByOrderId(orderId);
            ds.Tables.Add(dtOrderDetail);
            rptSource = new ReportDataSource();
            rptSource.Name = "DataSetOrderDetail";
            rptSource.Value = ds.Tables["OrderDetail"];
            localReport.DataSources.Add(rptSource);


            // Refresh the report  
            PageSettings ps = new PageSettings();
            ps.Landscape = false;
            ps.PaperSize = new PaperSize("Letter", 850, 1100);
            ps.Margins = new Margins(50,50,50,50);
            reportViewerOrder.SetPageSettings(ps);
            reportViewerOrder.RefreshReport();

            localReport.Refresh();
        }

        private DataTable GetCustomerById(int custId)
        {
            DataTable dt = new DataTable();
            CustomerManager customerManager = new CustomerManager();
            dt = customerManager.GetCustomerDataTableById(custId);

            return dt;
        }

        private DataTable GetOrderById(int orderId)
        {
            DataTable dt = new DataTable();
            OrderManager orderManager = new OrderManager();
            dt = orderManager.GetSingleOrderById(orderId);

            return dt;

        }

        private DataTable GetOrderDetailByOrderId(int orderId)
        {
            DataTable dt = new DataTable();
            OrderManager orderManager = new OrderManager();
            dt = orderManager.GetOrderDetailDataTableByOrderId(orderId);

            return dt;

        }

    }
}
