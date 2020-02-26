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
    public partial class FrmOrderDetailReport : Form
    {
        public FrmOrderDetailReport()
        {
            InitializeComponent();
        }

        private void FrmOrderDetailReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DinnoOpticalDataSet.Order' table. You can move, or remove it, as needed.
            //OrderTableAdapter.Adapter.GetFillParameters();
            //this.OrderTableAdapter.Fill(this.DinnoOpticalDataSet.Order, 1);
            //this.OrderTableAdapter.FillDetailByOrderId(this.DinnoOpticalDataSet.Order, 1);
            this.OrderBindingSource.DataSource = GetOrderByOrderId(3);

            //this.reportViewerOrderDetail.RefreshReport();
            // Set the processing mode for the ReportViewer to Local  
            //reportViewerOrderDetail.ProcessingMode = ProcessingMode.Local;

            //LocalReport localReport = reportViewerOrderDetail.LocalReport;

            //localReport.ReportPath = "orderDetailReport.rdlc";

            //DataSet dataset = new DataSet("SalesOrderDetail");

            //string salesOrderNumber = "1";

            //// Get the sales order data  
            //GetSalesOrderData(salesOrderNumber, ref dataset);

            //// Create a report data source for the sales order data  
            //ReportDataSource dsSalesOrder = new ReportDataSource();
            //dsSalesOrder.Name = "SalesOrder";
            //dsSalesOrder.Value = dataset.Tables["SalesOrder"];

            //localReport.DataSources.Add(dsSalesOrder);

            //// Get the sales order detail data  
            //GetSalesOrderDetailData(salesOrderNumber, ref dataset);

            //// Create a report data source for the sales order detail   
            //// data  
            //ReportDataSource dsSalesOrderDetail = new ReportDataSource();
            //dsSalesOrderDetail.Name = "SalesOrderDetail";
            //dsSalesOrderDetail.Value = dataset.Tables["SalesOrderDetail"];

            //localReport.DataSources.Add(dsSalesOrderDetail);

            // Refresh the report  
            PageSettings ps = new PageSettings();
            ps.Landscape = false;
            ps.PaperSize = new PaperSize("Letter", 850, 1100);
            reportViewerOrderDetail.SetPageSettings(ps);
            reportViewerOrderDetail.RefreshReport();
        }

        private void GetSalesOrderData(string salesOrderNumber, ref DataSet dsSalesOrder)
        {

            OrderManager orderManager = new OrderManager();
            var order = orderManager.GetSingleOrderById(Convert.ToInt32(salesOrderNumber));

            dsSalesOrder.Tables.Add(order);

            //salesOrderAdapter.Fill(dsSalesOrder, "SalesOrder");
        }

        private void GetSalesOrderDetailData(string salesOrderNumber, ref DataSet dsSalesOrder)
        {
            OrderManager orderManager = new OrderManager();
            var orderDetail = orderManager.GetOrderDetailDataTableByOrderId(Convert.ToInt32(salesOrderNumber));

            dsSalesOrder.Tables.Add(orderDetail);

            //salesOrderDetailAdapter.Fill(dsSalesOrder,
            //        "SalesOrderDetail");

        }

        private Order GetOrderByOrderId(int orderId) {
            OrderManager orderManager = new OrderManager();
            var order = orderManager.GetOrderById(orderId);

            return order;
        }


    }
}
