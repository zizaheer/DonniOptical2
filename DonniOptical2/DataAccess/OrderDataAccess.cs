using DonniOptical2.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonniOptical2.DataAccess
{
    public class OrderDataAccess : Connection
    {
        public OrderDataAccess()
        {

        }

        public List<Order> GetOrderList()
        {
            List<Order> orderList = new List<Order>();

            try
            {
                sqlConnection.Open();

                DataTable dataTable = new DataTable();
                string query = "SELECT * FROM dbo.[Order]";
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        Order order = new Order();

                        order.Id = Convert.ToInt32(dr["Id"]);
                        order.CustomerId = Convert.ToInt32(dr["CustomerId"]);
                        order.DoctorName = dr["DoctorName"].ToString();
                        order.DoctorPhone = dr["DoctorPhone"].ToString();
                        order.DoctorClinicAddress = dr["DoctorClinicAddress"].ToString();
                        order.DoctorPrescriptionDate = Convert.ToDateTime(dr["DoctorPrescriptionDate"]);
                        order.PrescriptionSphereRight = dr["PrescriptionSphereRight"].ToString();
                        order.PrescriptionCylRight = dr["PrescriptionCylRight"].ToString();
                        order.PrescriptionAxisRight = dr["PrescriptionAxisRight"].ToString();
                        order.PrescriptionAddRight = dr["PrescriptionAddRight"].ToString();
                        order.PrescriptionPrismRight = dr["PrescriptionPrismRight"].ToString();
                        order.PrescriptionSphereLeft = dr["PrescriptionSphereLeft"].ToString();
                        order.PrescriptionCylLeft = dr["PrescriptionCylLeft"].ToString();
                        order.PrescriptionAxisLeft = dr["PrescriptionAxisLeft"].ToString();
                        order.PrescriptionAddLeft = dr["PrescriptionAddLeft"].ToString();
                        order.PrescriptionPrismLeft = dr["PrescriptionPrismLeft"].ToString();
                        order.FrameTotalPrice = Convert.ToDecimal(dr["FrameTotalPrice"]);
                        order.LensTotalPrice = Convert.ToDecimal(dr["LensTotalPrice"]);
                        order.OtherAdjustment = Convert.ToDecimal(dr["OtherAdjustment"]);
                        order.OrderTotal = Convert.ToDecimal(dr["OrderTotal"]);
                        order.HstAmount = Convert.ToDecimal(dr["HstAmount"]);
                        order.GrandTotal = Convert.ToDecimal(dr["GrandTotal"]);
                        order.PaidBy = dr["PaidBy"].ToString();
                        order.PaidAmount = Convert.ToDecimal(dr["PaidAmount"]);
                        order.BalanceDue = Convert.ToDecimal(dr["BalanceDue"]);
                        order.Remarks = dr["Remarks"].ToString();
                        order.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                        
                        orderList.Add(order);
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }

            finally
            {
                sqlConnection.Close();
            }

            return orderList;
        }
        public int GetMaxOrderId()
        {
            int orderId = 0;
            try
            {
                sqlConnection.Open();

                DataTable dataTable = new DataTable();
                string query = "SELECT MAX(Id) FROM dbo.[Order]";
                sqlCommand = new SqlCommand(query, sqlConnection);

                orderId = Convert.ToInt32(sqlCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                //
            }

            finally
            {
                sqlConnection.Close();
            }

            return orderId;
        }
        public Order GetOrderById(int id)
        {
            Order order = new Order();

            try
            {
                sqlConnection.Open();

                DataTable dataTable = new DataTable();
                string query = "SELECT * FROM dbo.[Order] WHERE Id = @Id";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    order.Id = Convert.ToInt32(dataReader["Id"]);
                    order.CustomerId = Convert.ToInt32(dataReader["CustomerId"]);
                    order.DoctorName = dataReader["DoctorName"].ToString();
                    order.DoctorPhone = dataReader["DoctorPhone"].ToString();
                    order.DoctorClinicAddress = dataReader["DoctorClinicAddress"].ToString();
                    order.DoctorPrescriptionDate = Convert.ToDateTime(dataReader["DoctorPrescriptionDate"]);
                    order.PrescriptionSphereRight = dataReader["PrescriptionSphereRight"].ToString();
                    order.PrescriptionCylRight = dataReader["PrescriptionCylRight"].ToString();
                    order.PrescriptionAxisRight = dataReader["PrescriptionAxisRight"].ToString();
                    order.PrescriptionAddRight = dataReader["PrescriptionAddRight"].ToString();
                    order.PrescriptionPrismRight = dataReader["PrescriptionPrismRight"].ToString();
                    order.PrescriptionSphereLeft = dataReader["PrescriptionSphereLeft"].ToString();
                    order.PrescriptionCylLeft = dataReader["PrescriptionCylLeft"].ToString();
                    order.PrescriptionAxisLeft = dataReader["PrescriptionAxisLeft"].ToString();
                    order.PrescriptionAddLeft = dataReader["PrescriptionAddLeft"].ToString();
                    order.PrescriptionPrismLeft = dataReader["PrescriptionPrismLeft"].ToString();
                    order.FrameTotalPrice = Convert.ToDecimal(dataReader["FrameTotalPrice"]);
                    order.LensTotalPrice = Convert.ToDecimal(dataReader["LensTotalPrice"]);
                    order.OtherAdjustment = Convert.ToDecimal(dataReader["OtherAdjustment"]);
                    order.OrderTotal = Convert.ToDecimal(dataReader["OrderTotal"]);
                    order.HstAmount = Convert.ToDecimal(dataReader["HstAmount"]);
                    order.GrandTotal = Convert.ToDecimal(dataReader["GrandTotal"]);
                    order.PaidBy = dataReader["PaidBy"].ToString();
                    order.PaidAmount = Convert.ToDecimal(dataReader["PaidAmount"]);
                    order.BalanceDue = Convert.ToDecimal(dataReader["BalanceDue"]);
                    order.Remarks = dataReader["Remarks"].ToString();
                    order.CreateDate = Convert.ToDateTime(dataReader["CreateDate"]);
                }
            }
            catch (Exception ex)
            {
                //
            }

            finally
            {
                sqlConnection.Close();
            }

            return order;
        }
        public int InsertNewOrder(Order order)
        {
            int orderId = 0;
            try
            {
                sqlConnection.Open();

                string query = "INSERT INTO dbo.[Order](CustomerId, DoctorName, DoctorPhone, DoctorClinicAddress, DoctorPrescriptionDate, PrescriptionSphereRight";
                query += ", PrescriptionCylRight, PrescriptionAxisRight, PrescriptionAddRight, PrescriptionPrismRight, PrescriptionSphereLeft";
                query += ", PrescriptionCylLeft, PrescriptionAxisLeft, PrescriptionAddLeft, PrescriptionPrismLeft, FrameTotalPrice";
                query += ", LensTotalPrice, OtherAdjustment, OrderTotal, HstAmount, GrandTotal, PaidBy, PaidAmount";
                query += ", BalanceDue, Remarks, CreateDate) VALUES(@CustomerId, @DoctorName, @DoctorPhone, @DoctorClinicAddress, @DoctorPrescriptionDate, @PrescriptionSphereRight";
                query += ", @PrescriptionCylRight, @PrescriptionAxisRight, @PrescriptionAddRight, @PrescriptionPrismRight, @PrescriptionSphereLeft";
                query += ", @PrescriptionCylLeft, @PrescriptionAxisLeft, @PrescriptionAddLeft, @PrescriptionPrismLeft, @FrameTotalPrice";
                query += ", @LensTotalPrice, @OtherAdjustment, @OrderTotal, @HstAmount, @GrandTotal, @PaidBy, @PaidAmount";
                query += ", @BalanceDue, @Remarks, @CreateDate); ";
                query += " SELECT CAST(scope_identity() AS INT) ";

                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                sqlCommand.Parameters.AddWithValue("@DoctorName", order.DoctorName);
                sqlCommand.Parameters.AddWithValue("@DoctorPhone", order.DoctorPhone);
                sqlCommand.Parameters.AddWithValue("@DoctorClinicAddress", order.DoctorClinicAddress);
                sqlCommand.Parameters.AddWithValue("@DoctorPrescriptionDate", order.DoctorPrescriptionDate);
                sqlCommand.Parameters.AddWithValue("@PrescriptionSphereRight", order.PrescriptionSphereRight);
                sqlCommand.Parameters.AddWithValue("@PrescriptionCylRight", order.PrescriptionCylRight);
                sqlCommand.Parameters.AddWithValue("@PrescriptionAxisRight", order.PrescriptionAxisRight);
                sqlCommand.Parameters.AddWithValue("@PrescriptionAddRight", order.PrescriptionAddRight);
                sqlCommand.Parameters.AddWithValue("@PrescriptionPrismRight", order.PrescriptionPrismRight);
                sqlCommand.Parameters.AddWithValue("@PrescriptionSphereLeft", order.PrescriptionSphereLeft);
                sqlCommand.Parameters.AddWithValue("@PrescriptionCylLeft", order.PrescriptionCylLeft);
                sqlCommand.Parameters.AddWithValue("@PrescriptionAxisLeft", order.PrescriptionAxisLeft);
                sqlCommand.Parameters.AddWithValue("@PrescriptionAddLeft", order.PrescriptionAddLeft);
                sqlCommand.Parameters.AddWithValue("@PrescriptionPrismLeft", order.PrescriptionPrismLeft);
                sqlCommand.Parameters.AddWithValue("@FrameTotalPrice", order.FrameTotalPrice);
                sqlCommand.Parameters.AddWithValue("@LensTotalPrice", order.LensTotalPrice);
                sqlCommand.Parameters.AddWithValue("@OtherAdjustment", order.OtherAdjustment);
                sqlCommand.Parameters.AddWithValue("@OrderTotal", order.OrderTotal);
                sqlCommand.Parameters.AddWithValue("@HstAmount", order.HstAmount);
                sqlCommand.Parameters.AddWithValue("@GrandTotal", order.GrandTotal);
                sqlCommand.Parameters.AddWithValue("@PaidBy", order.PaidBy);
                sqlCommand.Parameters.AddWithValue("@PaidAmount", order.PaidAmount);
                sqlCommand.Parameters.AddWithValue("@BalanceDue", order.BalanceDue);
                sqlCommand.Parameters.AddWithValue("@Remarks", order.Remarks);
                sqlCommand.Parameters.AddWithValue("@CreateDate", order.CreateDate);
                

                orderId = (int)sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //
            }

            finally
            {
                sqlConnection.Close();
            }

            return orderId;
        }
        public int UpdateExistingOrder(Order order)
        {
            int isUpdated = 0;
            try
            {
                sqlConnection.Open();

                string query = "UPDATE dbo.[Order] SET CustomerId = @CustomerId, DoctorName = @DoctorName, DoctorPhone = @DoctorPhone, DoctorClinicAddress = @DoctorClinicAddress";
                query += ", DoctorPrescriptionDate = @DoctorPrescriptionDate, PrescriptionSphereRight = @PrescriptionSphereRight, PrescriptionCylRight = @PrescriptionCylRight";
                query += ", PrescriptionAxisRight = @PrescriptionAxisRight, PrescriptionAddRight = @PrescriptionAddRight, PrescriptionPrismRight = @PrescriptionPrismRight";
                query += ", PrescriptionSphereLeft = @PrescriptionSphereLeft, PrescriptionCylLeft = @PrescriptionCylLeft, PrescriptionAxisLeft = @PrescriptionAxisLeft";
                query += ", PrescriptionAddLeft = @PrescriptionAddLeft, PrescriptionPrismLeft = @PrescriptionPrismLeft, FrameTotalPrice = @FrameTotalPrice";
                query += ", LensTotalPrice = @LensTotalPrice, OtherAdjustment = @OtherAdjustment, OrderTotal = @OrderTotal";
                query += ", HstAmount = @HstAmount, GrandTotal = @GrandTotal, PaidBy = @PaidBy, PaidAmount = @PaidAmount, BalanceDue = @BalanceDue";
                query += ", Remarks = @Remarks, CreateDate = @CreateDate";

                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                sqlCommand.Parameters.AddWithValue("@DoctorName", order.DoctorName);
                sqlCommand.Parameters.AddWithValue("@DoctorPhone", order.DoctorPhone);
                sqlCommand.Parameters.AddWithValue("@DoctorClinicAddress", order.DoctorClinicAddress);
                sqlCommand.Parameters.AddWithValue("@DoctorPrescriptionDate", order.DoctorPrescriptionDate);
                sqlCommand.Parameters.AddWithValue("@PrescriptionSphereRight", order.PrescriptionSphereRight);
                sqlCommand.Parameters.AddWithValue("@PrescriptionCylRight", order.PrescriptionCylRight);
                sqlCommand.Parameters.AddWithValue("@PrescriptionAxisRight", order.PrescriptionAxisRight);
                sqlCommand.Parameters.AddWithValue("@PrescriptionAddRight", order.PrescriptionAddRight);
                sqlCommand.Parameters.AddWithValue("@PrescriptionPrismRight", order.PrescriptionPrismRight);
                sqlCommand.Parameters.AddWithValue("@PrescriptionSphereLeft", order.PrescriptionSphereLeft);
                sqlCommand.Parameters.AddWithValue("@PrescriptionCylLeft", order.PrescriptionCylLeft);
                sqlCommand.Parameters.AddWithValue("@PrescriptionAxisLeft", order.PrescriptionAxisLeft);
                sqlCommand.Parameters.AddWithValue("@PrescriptionAddLeft", order.PrescriptionAddLeft);
                sqlCommand.Parameters.AddWithValue("@PrescriptionPrismLeft", order.PrescriptionPrismLeft);
                sqlCommand.Parameters.AddWithValue("@FrameTotalPrice", order.FrameTotalPrice);
                sqlCommand.Parameters.AddWithValue("@LensTotalPrice", order.LensTotalPrice);
                sqlCommand.Parameters.AddWithValue("@OtherAdjustment", order.OtherAdjustment);
                sqlCommand.Parameters.AddWithValue("@OrderTotal", order.OrderTotal);
                sqlCommand.Parameters.AddWithValue("@HstAmount", order.HstAmount);
                sqlCommand.Parameters.AddWithValue("@GrandTotal", order.GrandTotal);
                sqlCommand.Parameters.AddWithValue("@PaidBy", order.PaidBy);
                sqlCommand.Parameters.AddWithValue("@PaidAmount", order.PaidAmount);
                sqlCommand.Parameters.AddWithValue("@BalanceDue", order.BalanceDue);
                sqlCommand.Parameters.AddWithValue("@Remarks", order.Remarks);
                sqlCommand.Parameters.AddWithValue("@CreateDate", order.CreateDate);

                isUpdated = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //
            }

            finally
            {
                sqlConnection.Close();
            }

            return isUpdated;
        }
        public int DeleteExistingOrder(int id)
        {
            int result = 0;
            try
            {
                sqlConnection.Open();

                string query = "DELETE FROM dbo.[Order] WHERE Id = @Id";

                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", id);

                result = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //
            }

            finally
            {
                sqlConnection.Close();
            }

            return result;
        }
    }


}
