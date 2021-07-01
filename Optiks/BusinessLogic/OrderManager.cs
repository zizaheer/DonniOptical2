using Optiks.DataAccess;
using Optiks.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Optiks.BusinessLogic
{
    public class OrderManager
    {
        OrderDataAccess orderDataAccess;
        CustomerDataAccess customerDataAccess;
        OrderDetailDataAccess dataDetailAccess;
        public OrderManager()
        {
            orderDataAccess = new OrderDataAccess();
            customerDataAccess = new CustomerDataAccess();
            dataDetailAccess = new OrderDetailDataAccess();
        }

        public List<Order> GetOrders()
        {

            List<Order> orderList = new List<Order>();
            try
            {
                orderList = orderDataAccess.GetOrderList();

            }
            catch (Exception ex)
            {
                //
            }

            return orderList;

        }


        public Order GetOrderById(int id)
        {

            Order order = new Order();
            try
            {
                order = orderDataAccess.GetOrderById(id);
            }
            catch (Exception ex)
            {
                //
            }

            return order;

        }

        public int InsertNewOrder(Order order, List<OrderDetail> orderDetails)
        {
            int orderId = 0;
            int isDetailInserted = 0;
            try
            {
                using (var scope = new TransactionScope())
                {
                    order.Id = orderDataAccess.GetMaxOrderId() + 1;
                    orderId = orderDataAccess.InsertNewOrder(order);
                    if (orderId > 0)
                    {
                        foreach (var orderDetail in orderDetails)
                        {
                            orderDetail.OrderId = orderId;
                            isDetailInserted = InsertNewOrderDetail(orderDetail);
                        }

                        if (isDetailInserted > 0)
                        {
                            scope.Complete();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }

            return orderId;
        }

        public int UpdateExistingOrder(Order order, List<OrderDetail> orderDetails)
        {
            int orderId = 0;
            int isDetailInserted = 0;
            try
            {
                using (var scope = new TransactionScope())
                {
                    DeleteOrderDetailByOrderId(order.Id);
                    foreach (var orderDetail in orderDetails)
                    {
                        orderDetail.OrderId = order.Id;
                        isDetailInserted = InsertNewOrderDetail(orderDetail);
                    }

                    if (isDetailInserted > 0)
                    {
                        orderDataAccess.UpdateExistingOrder(order);
                        scope.Complete();
                        orderId = order.Id;
                    }
                }
            }

            catch (Exception ex)
            {
                //
            }

            return orderId;
        }

        public int DeleteExistingOrder(int orderId)
        {
            int result = 0;
            try
            {
                var orderDetail = dataDetailAccess.GetOrderDetailListByOrderId(orderId);
                if (orderDetail.Count > 0)
                {
                    dataDetailAccess = new OrderDetailDataAccess();
                    dataDetailAccess.DeleteOrderDetailByOrderId(orderId);
                }

                result = orderDataAccess.DeleteExistingOrder(orderId);
            }
            catch (Exception ex)
            {
                //
            }

            return result;
        }

        public int VoidExistingOrder(int orderId, string remarks)
        {
            int result = 0;
            try
            {
                result = orderDataAccess.VoidExistingOrder(orderId, remarks);
            }
            catch (Exception ex)
            {
                //
            }

            return result;
        }

        public int UnvoidExistingOrder(int orderId, string remarks)
        {
            int result = 0;
            try
            {
                result = orderDataAccess.UnvoidExistingOrder(orderId, remarks);
            }
            catch (Exception ex)
            {
                //
            }

            return result;
        }

        public List<OrderDetail> GetOrderDetailList()
        {
            List<OrderDetail> orderDetailList = new List<OrderDetail>();

            try
            {
                orderDetailList = dataDetailAccess.GetOrderDetailList();
            }
            catch (Exception ex)
            {
                //
            }

            return orderDetailList;
        }

        public List<OrderDetail> GetOrderDetailListByOrderId(int orderId)
        {
            List<OrderDetail> orderDetailList = new List<OrderDetail>();

            try
            {
                orderDetailList = dataDetailAccess.GetOrderDetailListByOrderId(orderId);
            }
            catch (Exception ex)
            {
                //
            }

            return orderDetailList;
        }

        public int InsertNewOrderDetail(OrderDetail orderDetail)
        {
            int result = 0;
            try
            {
                orderDetail.Id = dataDetailAccess.GetMaxOrderDetailId() + 1;
                result = dataDetailAccess.InsertNewOrderDetail(orderDetail);
            }
            catch (Exception ex)
            {
                //
            }

            return result;
        }

        public int UpdateExistingOrderDetail(OrderDetail orderDetail)
        {
            int result = 0;
            try
            {
                result = dataDetailAccess.UpdateExistingOrderDetail(orderDetail);
            }
            catch (Exception ex)
            {
                //
            }

            return result;
        }

        public int DeleteExistingOrderDetail(int id)
        {
            int result = 0;
            try
            {
                result = dataDetailAccess.DeleteExistingOrderDetail(id);
            }
            catch (Exception ex)
            {
                //
            }

            return result;
        }

        public int DeleteOrderDetailByOrderId(int orderId)
        {
            int result = 0;
            try
            {
                result = dataDetailAccess.DeleteOrderDetailByOrderId(orderId);
            }
            catch (Exception ex)
            {
                //
            }

            return result;
        }

        public List<PaymentMethod> GetPaymentMethods()
        {
            PaymentMethodDataAccess paymentMethodDataAccess = new PaymentMethodDataAccess();
            return paymentMethodDataAccess.GetPaymentMethodList();
        }

        public decimal GetHstAmount()
        {
            ConfigurationDataAccess config = new ConfigurationDataAccess();
            return config.GetHstAmount();
        }

        public List<ViewOrder> GetOrdersByOrderId(int orderId)
        {
            var orderList = orderDataAccess.GetViewOrderList();
            orderList = orderList.Where(c => c.OrderId == orderId).ToList();

            return orderList;
        }
        public List<ViewOrder> GetOrdersByCustomerId(int customerId)
        {
            var orderList = orderDataAccess.GetViewOrderList();
            orderList = orderList.Where(c => c.CustomerId == customerId).ToList();

            return orderList;
        }
        public List<ViewOrder> GetOrdersByDate(DateTime fromDate, DateTime toDate)
        {

            var orderList = orderDataAccess.GetViewOrderList();
            orderList = orderList.Where(c => c.OrderDate >= fromDate && c.OrderDate <= toDate).ToList();

            return orderList;

        }
        public List<ViewOrder> GetOrdersByCustomerFirstName(string customerFirstName)
        {
            var orderList = orderDataAccess.GetViewOrderList();
            orderList = orderList.Where(c => string.Equals(c.FirstName, customerFirstName, StringComparison.OrdinalIgnoreCase)).ToList();

            return orderList;
        }
        public List<ViewOrder> GetOrdersByDateAndFirstName(DateTime fromDate, DateTime toDate, string customerFirstName)
        {
            var orderList = orderDataAccess.GetViewOrderList();
            orderList = orderList.Where(c => c.OrderDate >= fromDate && c.OrderDate <= toDate && string.Equals(c.FirstName, customerFirstName, StringComparison.OrdinalIgnoreCase)).ToList();

            return orderList;

        }
        public List<ViewOrder> GetOrdersByCustomerLastName(string customerLastName)
        {
            var orderList = orderDataAccess.GetViewOrderList();
            orderList = orderList.Where(c => string.Equals(c.LastName, customerLastName, StringComparison.OrdinalIgnoreCase)).ToList();

            return orderList;

        }
        public List<ViewOrder> GetOrdersByDateAndLastName(DateTime fromDate, DateTime toDate, string customerLastName)
        {
            var orderList = orderDataAccess.GetViewOrderList();
            orderList = orderList.Where(c => c.OrderDate >= fromDate && c.OrderDate <= toDate && string.Equals(c.LastName, customerLastName, StringComparison.OrdinalIgnoreCase)).ToList();

            return orderList;

        }
        public List<ViewOrder> GetOrdersByCustomerPhone(string customerPhone)
        {
            var orderList = orderDataAccess.GetViewOrderList();
            orderList = orderList.Where(c => string.Equals(c.Telephone.Replace("-", ""), customerPhone.Replace("-", ""), StringComparison.OrdinalIgnoreCase)).ToList();

            return orderList;
        }
        public List<ViewOrder> GetOrdersByDateAndPhoneNumber(DateTime fromDate, DateTime toDate, string customerPhone)
        {
            var orderList = orderDataAccess.GetViewOrderList();
            orderList = orderList.Where(c => c.OrderDate >= fromDate && c.OrderDate <= toDate && string.Equals(c.Telephone.Replace("-", ""), customerPhone.Replace("-", ""), StringComparison.OrdinalIgnoreCase)).ToList();

            return orderList;

        }
        public List<ViewOrder> GetOrdersByEmail(string customerEmail)
        {
            var orderList = orderDataAccess.GetViewOrderList();
            orderList = orderList.Where(c => string.Equals(c.Email, customerEmail, StringComparison.OrdinalIgnoreCase)).ToList();

            return orderList;

        }
        public List<ViewOrder> GetOrdersByDateAndEmail(DateTime fromDate, DateTime toDate, string customerEmail)
        {
            var orderList = orderDataAccess.GetViewOrderList();
            orderList = orderList.Where(c => c.OrderDate >= fromDate && c.OrderDate <= toDate && string.Equals(c.Email, customerEmail, StringComparison.OrdinalIgnoreCase)).ToList();

            return orderList;

        }
        public DataTable GetOrderDataTable()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = orderDataAccess.GetOrderDataTable();
            }
            catch (Exception ex)
            {
                //
            }

            return dt;
        }
        public DataTable GetSingleOrderById(int orderId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = orderDataAccess.GetSingleOrderById(orderId);
            }
            catch (Exception ex)
            {
                //
            }

            return dt;
        }
        public DataTable GetOrdersForSalesReport(DateTime fromDate, DateTime toDate)
        {
            DataTable dtOrderData = new DataTable();
            dtOrderData.TableName = "OrderCustomer";

            dtOrderData.Columns.Add("CreateDate");
            dtOrderData.Columns.Add("Id");
            dtOrderData.Columns.Add("FirstName");
            dtOrderData.Columns.Add("LastName");
            dtOrderData.Columns.Add("CustomerId");
            dtOrderData.Columns.Add("GrandTotal");
            dtOrderData.Columns.Add("HstAmount");
            dtOrderData.Columns.Add("PaidAmount");
            dtOrderData.Columns.Add("BalanceDue");

            try
            {
                var orders = orderDataAccess.GetCompleteOrders(fromDate, toDate);
                for (int i = 0; i < orders.Rows.Count; i++)
                {
                    DataRow dr = dtOrderData.NewRow();
                    dr["CreateDate"] = orders.Rows[i]["CreateDate"];
                    dr["Id"] = orders.Rows[i]["Id"];
                    dr["CustomerId"] = orders.Rows[i]["CustomerId"];

                    var customerInfo = customerDataAccess.GetCustomerById(Convert.ToInt32(dr["CustomerId"]));
                    if (customerInfo != null)
                    {
                        dr["FirstName"] = customerInfo.FirstName;
                        dr["LastName"] = customerInfo.LastName;
                    }

                    dr["GrandTotal"] = orders.Rows[i]["GrandTotal"];
                    dr["HstAmount"] = orders.Rows[i]["HstAmount"];
                    dr["PaidAmount"] = orders.Rows[i]["PaidAmount"];
                    dr["BalanceDue"] = orders.Rows[i]["BalanceDue"];

                    dtOrderData.Rows.Add(dr);
                }

            }
            catch (Exception ex)
            {
                //
            }

            return dtOrderData;
        }

        public DataTable GetVoidOrders(DateTime fromDate, DateTime toDate)
        {
            DataTable dtOrderData = new DataTable();
            dtOrderData.TableName = "VoidOrder";

            dtOrderData.Columns.Add("CreateDate");
            dtOrderData.Columns.Add("Id");
            dtOrderData.Columns.Add("FirstName");
            dtOrderData.Columns.Add("LastName");
            dtOrderData.Columns.Add("CustomerId");
            dtOrderData.Columns.Add("GrandTotal");
            dtOrderData.Columns.Add("HstAmount");
            dtOrderData.Columns.Add("PaidAmount");
            dtOrderData.Columns.Add("BalanceDue");
            dtOrderData.Columns.Add("VoidDate");
            dtOrderData.Columns.Add("Remarks");

            try
            {
                var orders = orderDataAccess.GetVoidOrders(fromDate, toDate);
                for (int i = 0; i < orders.Rows.Count; i++)
                {
                    DataRow dr = dtOrderData.NewRow();
                    dr["CreateDate"] = orders.Rows[i]["CreateDate"];
                    dr["Id"] = orders.Rows[i]["Id"];
                    dr["CustomerId"] = orders.Rows[i]["CustomerId"];

                    var customerInfo = customerDataAccess.GetCustomerById(Convert.ToInt32(dr["CustomerId"]));
                    if (customerInfo != null)
                    {
                        dr["FirstName"] = customerInfo.FirstName;
                        dr["LastName"] = customerInfo.LastName;
                    }

                    dr["GrandTotal"] = orders.Rows[i]["GrandTotal"];
                    dr["HstAmount"] = orders.Rows[i]["HstAmount"];
                    dr["PaidAmount"] = orders.Rows[i]["PaidAmount"];
                    dr["BalanceDue"] = orders.Rows[i]["BalanceDue"];
                    dr["VoidDate"] = orders.Rows[i]["VoidDate"];
                    dr["Remarks"] = orders.Rows[i]["Remarks"];

                    dtOrderData.Rows.Add(dr);
                }

            }
            catch (Exception ex)
            {
                //
            }

            return dtOrderData;
        }
        public DataTable GetOrderDetailDataTableByOrderId(int orderId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = dataDetailAccess.GetOrderDetailDataTableByOrderId(orderId);
            }
            catch (Exception ex)
            {
                //
            }

            return dt;
        }
    }
}
