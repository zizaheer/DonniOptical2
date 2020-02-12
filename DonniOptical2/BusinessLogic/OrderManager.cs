using DonniOptical2.DataAccess;
using DonniOptical2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DonniOptical2.BusinessLogic
{
    public class OrderManager
    {
        OrderDataAccess dataAccess;
        OrderDetailDataAccess dataDetailAccess;
        public OrderManager()
        {
            dataAccess = new OrderDataAccess();
            dataDetailAccess = new OrderDetailDataAccess();
        }

        public List<Order> GetOrders()
        {

            List<Order> orderList = new List<Order>();
            try
            {
                orderList = dataAccess.GetOrderList();

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
                order = dataAccess.GetOrderById(id);
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
                    orderId = dataAccess.InsertNewOrder(order);
                    if (orderId > 0)
                    {
                        foreach (var orderDetail in orderDetails)
                        {
                            orderDetail.OrderId = orderId;
                            isDetailInserted = InsertNewOrderDetail(orderDetail);
                        }

                        if (isDetailInserted > 0) {
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
                        dataAccess.UpdateExistingOrder(order);
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

                result = dataAccess.DeleteExistingOrder(orderId);
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
    }
}
