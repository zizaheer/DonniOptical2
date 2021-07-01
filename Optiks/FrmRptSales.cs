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
    public partial class FrmRptSales : Form
    {
        public FrmRptSales()
        {
            InitializeComponent();
        }

        public int orderId;
        public int customerId;
        private void FrmRptOrder_Load(object sender, EventArgs e)
        {
            dtPickerFromDate.Value = DateTime.Now.AddDays(-7);
            dtPickerToDate.Value = DateTime.Now;

            

        }

        private void LoadReport(DateTime fromDate, DateTime toDate) {

            LocalReport localReport = reportViewerOrder.LocalReport;
            localReport.ReportPath = "RptSales.rdlc";
            localReport.DataSources.Clear();

            ReportParameter[] reportParameters = new ReportParameter[2];
            reportParameters[0] = new ReportParameter("fromDate", dtPickerFromDate.Value.ToString());
            reportParameters[1] = new ReportParameter("toDate", dtPickerToDate.Value.ToString());
            localReport.SetParameters(reportParameters);

            //// Create a report data source   
            DataSet ds = new DataSet();
            ReportDataSource rptSource = new ReportDataSource();

            ds = new DataSet();
            ds.Tables.Add(GetOrdersForSalesReport(fromDate, toDate));
            rptSource = new ReportDataSource();
            rptSource.Name = "SalesReportDataSet";
            rptSource.Value = ds.Tables["OrderCustomer"];
            localReport.DataSources.Add(rptSource);

            ds = new DataSet();
            ds.Tables.Add(GetVoidOrders(fromDate, toDate));
            rptSource = new ReportDataSource();
            rptSource.Name = "VoidOrderDataSet";
            rptSource.Value = ds.Tables["VoidOrder"];
            localReport.DataSources.Add(rptSource);

            // Refresh the report  
            PageSettings ps = new PageSettings();
            ps.Landscape = false;
            ps.PaperSize = new PaperSize("Letter", 850, 1100);
            ps.Margins = new Margins(50, 50, 50, 50);
            reportViewerOrder.SetPageSettings(ps);
            reportViewerOrder.RefreshReport();

            

            localReport.Refresh();

        }

        private DataTable GetOrdersForSalesReport(DateTime fromDate, DateTime toDate)
        {
            OrderManager orderManager = new OrderManager();
            return orderManager.GetOrdersForSalesReport(fromDate, toDate);
        }

        private DataTable GetVoidOrders(DateTime fromDate, DateTime toDate)
        {
            OrderManager orderManager = new OrderManager();
            return orderManager.GetVoidOrders(fromDate, toDate);
        }

        private DataTable GetOrderDetailByOrderId(int orderId)
        {
            DataTable dt = new DataTable();
            OrderManager orderManager = new OrderManager();
            dt = orderManager.GetOrderDetailDataTableByOrderId(orderId);

            return dt;

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

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            DateTime fromDate;
            DateTime toDate;
            string fromDateString = dtPickerFromDate.Text;
            string toDateString = dtPickerToDate.Text;

            DateTime.TryParse(fromDateString, out fromDate);
            DateTime.TryParse(toDateString, out toDate);

            LoadReport(fromDate, toDate);
        }
    }
}
