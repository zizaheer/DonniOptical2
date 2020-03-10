using Optiks.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiks.DataAccess
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
                        order.OtherTotal = Convert.ToDecimal(dr["OtherTotal"]);
                        order.DiscountAmount = Convert.ToDecimal(dr["DiscountAmount"]);
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

        public DataTable GetOrderDataTable()
        {
            DataTable dataTable = new DataTable("Order");

            try
            {
                sqlConnection.Open();
                string query = "SELECT * FROM dbo.[Order]";
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                //
            }

            finally
            {
                sqlConnection.Close();
            }

            return dataTable;
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
                    order.OtherTotal = Convert.ToDecimal(dataReader["OtherTotal"]);
                    order.DiscountAmount = Convert.ToDecimal(dataReader["DiscountAmount"]);
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

        public DataTable GetSingleOrderById(int id)
        {
            DataTable dataTable = new DataTable("Order");

            try
            {
                sqlConnection.Open();
                string query = "SELECT * FROM dbo.[Order] WHERE Id = @Id";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                //
            }

            finally
            {
                sqlConnection.Close();
            }

            return dataTable;
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
                query += ", LensTotalPrice, OtherTotal, DiscountAmount, OrderTotal, HstAmount, GrandTotal, PaidBy, PaidAmount";
                query += ", BalanceDue, Remarks, CreateDate) VALUES(@CustomerId, @DoctorName, @DoctorPhone, @DoctorClinicAddress, @DoctorPrescriptionDate, @PrescriptionSphereRight";
                query += ", @PrescriptionCylRight, @PrescriptionAxisRight, @PrescriptionAddRight, @PrescriptionPrismRight, @PrescriptionSphereLeft";
                query += ", @PrescriptionCylLeft, @PrescriptionAxisLeft, @PrescriptionAddLeft, @PrescriptionPrismLeft, @FrameTotalPrice";
                query += ", @LensTotalPrice, @OtherTotal, @DiscountAmount, @OrderTotal, @HstAmount, @GrandTotal, @PaidBy, @PaidAmount";
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
                sqlCommand.Parameters.AddWithValue("@OtherTotal", order.OtherTotal);
                sqlCommand.Parameters.AddWithValue("@DiscountAmount", order.DiscountAmount);
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
                query += ", LensTotalPrice = @LensTotalPrice, OtherTotal = @OtherTotal, DiscountAmount = @DiscountAmount, OrderTotal = @OrderTotal";
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
                sqlCommand.Parameters.AddWithValue("@OtherTotal", order.OtherTotal);
                sqlCommand.Parameters.AddWithValue("@DiscountAmount", order.DiscountAmount);
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

        public List<ViewOrder> GetViewOrderList() {

            List<ViewOrder> viewOrders = new List<ViewOrder>();
            try
            {
                sqlConnection.Open();

                DataTable dataTable = new DataTable();
                string query = "SELECT O.Id AS OrderId, O.CustomerId, C.FirstName, C.LastName, C.Address, C.City, C.Postcode, C.Telephone";
                
                query += ", C.Email, O.CreateDate AS OrderDate, O.DoctorName, O.DoctorPhone, O.DoctorClinicAddress, O.DoctorPrescriptionDate";
                query += ", O.PrescriptionSphereRight, O.PrescriptionSphereLeft, O.PrescriptionCylRight, O.PrescriptionCylLeft";
                query += ", O.PrescriptionAxisRight, O.PrescriptionAxisLeft, O.PrescriptionAddRight, O.PrescriptionAddLeft";
                query += ", O.PrescriptionPrismRight, O.PrescriptionPrismLeft, O.FrameTotalPrice, O.LensTotalPrice, O.OtherTotal, O.DiscountAmount";
                query += ", O.OrderTotal, O.HstAmount, O.GrandTotal, O.PaidBy, O.PaidAmount, O.BalanceDue, O.Remarks";
                //query += ", D.TrayNumber, D.ModifiedSphereRight, D.ModifiedSphereLeft, D.ModifiedCylRight, D.ModifiedCylLeft, D.ModifiedAxisRight";
                //query += ", D.ModifiedAxisLeft, D.ModifiedAddRight, D.ModifiedAddLeft, D.ModifiedPrismRight, D.ModifiedPrismLeft";
                //query += ", D.MeasurementFpdRight, D.MeasurementFpdLeft, D.MeasurementNrPdRight, D.MeasurementNrPdLeft";
                //query += ", D.MeasurementOcRight, D.MeasurementOcLeft, D.MeasurementSegRight, D.MeasurementSegLeft, D.MeasurementBlSizeRight";
                //query += ", D.MeasurementBlSizeLeft, D.MeasurementA, D.MeasurementB, D.MeasurementED, D.MeasurementDBL, D.FrameCode";
                //query += ", D.FrameColor, D.FrameUnitPrice, D.FrameQuantity, D.LeftLensDescription, D.LeftLensQuantity, D.LeftLensUnitPrice";
                //query += ", D.RightLensDescription, D.RightLensQuantity, D.RightLensUnitPrice, D.OtherItemDescription, D.OtherItemUnitPrice, D.OtherItemQuantity";
                query += " FROM [Order] O  ";
                //query += " INNER JOIN OrderDetail D ON D.OrderId = O.Id ";
                query += " INNER JOIN Customer C ON C.Id = O.CustomerId ";

                sqlCommand = new SqlCommand(query, sqlConnection);
                dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        ViewOrder order = new ViewOrder();

                        //order.ItemId = Convert.ToInt32(dr["ItemId"]);
                        order.OrderId = Convert.ToInt32(dr["OrderId"]);
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
                        order.OtherTotal = Convert.ToDecimal(dr["OtherTotal"]);
                        order.DiscountAmount = Convert.ToDecimal(dr["DiscountAmount"]);
                        order.OrderTotal = Convert.ToDecimal(dr["OrderTotal"]);
                        order.HstAmount = Convert.ToDecimal(dr["HstAmount"]);
                        order.GrandTotal = Convert.ToDecimal(dr["GrandTotal"]);
                        order.PaidBy = dr["PaidBy"].ToString();
                        order.PaidAmount = Convert.ToDecimal(dr["PaidAmount"]);
                        order.BalanceDue = Convert.ToDecimal(dr["BalanceDue"]);
                        order.Remarks = dr["Remarks"].ToString();
                        order.OrderDate = Convert.ToDateTime(dr["OrderDate"]);

                        order.CustomerId = Convert.ToInt32(dr["CustomerId"]);
                        order.FirstName = (dr["FirstName"]).ToString();
                        order.LastName = (dr["LastName"]).ToString();
                        order.Telephone = (dr["Telephone"]).ToString();
                        order.Email = (dr["Email"]).ToString();
                        order.Address = (dr["Address"]).ToString();
                        order.Postcode = (dr["Postcode"]).ToString();
                        order.City = (dr["City"]).ToString();

                        //order.TrayNumber = dr["TrayNumber"].ToString();
                        //order.ModifiedSphereRight = dr["ModifiedSphereRight"].ToString();
                        //order.ModifiedCylRight = dr["ModifiedCylRight"].ToString();
                        //order.ModifiedAxisRight = dr["ModifiedAxisRight"].ToString();
                        //order.ModifiedAddRight = dr["ModifiedAddRight"].ToString();
                        //order.ModifiedPrismRight = dr["ModifiedPrismRight"].ToString();
                        //order.ModifiedSphereLeft = dr["ModifiedSphereLeft"].ToString();
                        //order.ModifiedCylLeft = dr["ModifiedCylLeft"].ToString();
                        //order.ModifiedAxisLeft = dr["ModifiedAxisLeft"].ToString();
                        //order.ModifiedAddLeft = dr["ModifiedAddLeft"].ToString();
                        //order.ModifiedPrismLeft = dr["ModifiedPrismLeft"].ToString();
                        //order.MeasurementFpdRight = dr["MeasurementFpdRight"].ToString();
                        //order.MeasurementNrPdRight = dr["MeasurementNrPdRight"].ToString();
                        //order.MeasurementOcRight = dr["MeasurementOcRight"].ToString();
                        //order.MeasurementSegRight = dr["MeasurementSegRight"].ToString();
                        //order.MeasurementBlSizeRight = dr["MeasurementBlSizeRight"].ToString();
                        //order.MeasurementFpdLeft = dr["MeasurementFpdLeft"].ToString();
                        //order.MeasurementNrPdLeft = dr["MeasurementNrPdLeft"].ToString();
                        //order.MeasurementOcLeft = dr["MeasurementOcLeft"].ToString();
                        //order.MeasurementSegLeft = dr["MeasurementSegLeft"].ToString();
                        //order.MeasurementBlSizeLeft = dr["MeasurementBlSizeLeft"].ToString();
                        //order.MeasurementA = dr["MeasurementA"].ToString();
                        //order.MeasurementB = dr["MeasurementB"].ToString();
                        //order.MeasurementED = dr["MeasurementED"].ToString();
                        //order.MeasurementDBL = dr["MeasurementDBL"].ToString();
                        //order.FrameCode = dr["FrameCode"].ToString();
                        //order.FrameColor = dr["FrameColor"].ToString();
                        //order.FrameUnitPrice = Convert.ToDecimal(dr["FrameUnitPrice"]);
                        //order.FrameQuantity = Convert.ToInt16(dr["FrameQuantity"]);
                        //order.LeftLensDescription = dr["LeftLensDescription"].ToString();
                        //order.LeftLensUnitPrice = Convert.ToDecimal(dr["LeftLensUnitPrice"]);
                        //order.LeftLensQuantity = Convert.ToInt16(dr["LeftLensQuantity"]);
                        //order.RightLensDescription = dr["RightLensDescription"].ToString();
                        //order.RightLensUnitPrice = Convert.ToDecimal(dr["RightLensUnitPrice"]);
                        //order.RightLensQuantity = Convert.ToInt16(dr["RightLensQuantity"]);
                        //order.OtherItemDescription = dr["OtherItemDescription"].ToString();
                        //order.OtherItemUnitPrice = Convert.ToDecimal(dr["OtherItemUnitPrice"]);
                        //order.OtherItemQuantity = Convert.ToInt16(dr["OtherItemQuantity"]);

                        viewOrders.Add(order);
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

            return viewOrders;
        }


    }


}
