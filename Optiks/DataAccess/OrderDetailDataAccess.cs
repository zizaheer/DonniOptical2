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
    public class OrderDetailDataAccess : Connection
    {
        public OrderDetailDataAccess()
        {

        }

        public List<OrderDetail> GetOrderDetailList()
        {
            List<OrderDetail> orderDetailList = new List<OrderDetail>();

            try
            {
                sqlConnection.Open();

                DataTable dataTable = new DataTable();
                string query = "SELECT * FROM OrderDetail";
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        OrderDetail orderDetail = new OrderDetail();

                        orderDetail.Id = Convert.ToInt32(dr["Id"]);
                        orderDetail.OrderId = Convert.ToInt32(dr["OrderId"]);
                        orderDetail.TrayNumber = dr["TrayNumber"].ToString();
                        orderDetail.ModifiedSphereRight = dr["ModifiedSphereRight"].ToString();
                        orderDetail.ModifiedCylRight = dr["ModifiedCylRight"].ToString();
                        orderDetail.ModifiedAxisRight = dr["ModifiedAxisRight"].ToString();
                        orderDetail.ModifiedAddRight = dr["ModifiedAddRight"].ToString();
                        orderDetail.ModifiedPrismRight = dr["ModifiedPrismRight"].ToString();
                        orderDetail.ModifiedSphereLeft = dr["ModifiedSphereLeft"].ToString();
                        orderDetail.ModifiedCylLeft = dr["ModifiedCylLeft"].ToString();
                        orderDetail.ModifiedAxisLeft = dr["ModifiedAxisLeft"].ToString();
                        orderDetail.ModifiedAddLeft = dr["ModifiedAddLeft"].ToString();
                        orderDetail.ModifiedPrismLeft = dr["ModifiedPrismLeft"].ToString();
                        orderDetail.MeasurementFpdRight = dr["MeasurementFpdRight"].ToString();
                        orderDetail.MeasurementNrPdRight = dr["MeasurementNrPdRight"].ToString();
                        orderDetail.MeasurementOcRight = dr["MeasurementOcRight"].ToString();
                        orderDetail.MeasurementSegRight = dr["MeasurementSegRight"].ToString();
                        orderDetail.MeasurementBlSizeRight = dr["MeasurementBlSizeRight"].ToString();
                        orderDetail.MeasurementFpdLeft = dr["MeasurementFpdLeft"].ToString();
                        orderDetail.MeasurementNrPdLeft = dr["MeasurementNrPdLeft"].ToString();
                        orderDetail.MeasurementOcLeft = dr["MeasurementOcLeft"].ToString();
                        orderDetail.MeasurementSegLeft = dr["MeasurementSegLeft"].ToString();
                        orderDetail.MeasurementBlSizeLeft = dr["MeasurementBlSizeLeft"].ToString();
                        orderDetail.MeasurementA = dr["MeasurementA"].ToString();
                        orderDetail.MeasurementB = dr["MeasurementB"].ToString();
                        orderDetail.MeasurementED = dr["MeasurementED"].ToString();
                        orderDetail.MeasurementDBL = dr["MeasurementDBL"].ToString();
                        orderDetail.FrameCode = dr["FrameCode"].ToString();
                        orderDetail.FrameColor = dr["FrameColor"].ToString();
                        orderDetail.FrameUnitPrice = Convert.ToDecimal(dr["FrameUnitPrice"]);
                        orderDetail.FrameQuantity = Convert.ToInt16(dr["FrameQuantity"]);
                        orderDetail.LeftLensDescription = dr["LeftLensDescription"].ToString();
                        orderDetail.LeftLensUnitPrice = Convert.ToDecimal(dr["LeftLensUnitPrice"]);
                        orderDetail.LeftLensQuantity = Convert.ToInt16(dr["LeftLensQuantity"]);
                        orderDetail.RightLensDescription = dr["RightLensDescription"].ToString();
                        orderDetail.RightLensUnitPrice = Convert.ToDecimal(dr["RightLensUnitPrice"]);
                        orderDetail.RightLensQuantity = Convert.ToInt16(dr["RightLensQuantity"]);

                        orderDetail.OtherItemDescription = dr["OtherItemDescription"].ToString();
                        orderDetail.OtherItemUnitPrice = Convert.ToDecimal(dr["OtherItemUnitPrice"]);
                        orderDetail.OtherItemQuantity = Convert.ToInt16(dr["OtherItemQuantity"]);

                        orderDetailList.Add(orderDetail);
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

            return orderDetailList;
        }

        public List<OrderDetail> GetOrderDetailListByOrderId(int orderId)
        {
            List<OrderDetail> orderDetailList = new List<OrderDetail>();

            try
            {
                sqlConnection.Open();

                DataTable dataTable = new DataTable();
                string query = "SELECT * FROM OrderDetail WHERE OrderId = @OrderId";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@OrderId", orderId);
                dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        OrderDetail orderDetail = new OrderDetail();

                        orderDetail.Id = Convert.ToInt32(dr["Id"]);
                        orderDetail.OrderId = Convert.ToInt32(dr["OrderId"]);
                        orderDetail.TrayNumber = dr["TrayNumber"].ToString();
                        orderDetail.ModifiedSphereRight = dr["ModifiedSphereRight"].ToString();
                        orderDetail.ModifiedCylRight = dr["ModifiedCylRight"].ToString();
                        orderDetail.ModifiedAxisRight = dr["ModifiedAxisRight"].ToString();
                        orderDetail.ModifiedAddRight = dr["ModifiedAddRight"].ToString();
                        orderDetail.ModifiedPrismRight = dr["ModifiedPrismRight"].ToString();
                        orderDetail.ModifiedSphereLeft = dr["ModifiedSphereLeft"].ToString();
                        orderDetail.ModifiedCylLeft = dr["ModifiedCylLeft"].ToString();
                        orderDetail.ModifiedAxisLeft = dr["ModifiedAxisLeft"].ToString();
                        orderDetail.ModifiedAddLeft = dr["ModifiedAddLeft"].ToString();
                        orderDetail.ModifiedPrismLeft = dr["ModifiedPrismLeft"].ToString();
                        orderDetail.MeasurementFpdRight = dr["MeasurementFpdRight"].ToString();
                        orderDetail.MeasurementNrPdRight = dr["MeasurementNrPdRight"].ToString();
                        orderDetail.MeasurementOcRight = dr["MeasurementOcRight"].ToString();
                        orderDetail.MeasurementSegRight = dr["MeasurementSegRight"].ToString();
                        orderDetail.MeasurementBlSizeRight = dr["MeasurementBlSizeRight"].ToString();
                        orderDetail.MeasurementFpdLeft = dr["MeasurementFpdLeft"].ToString();
                        orderDetail.MeasurementNrPdLeft = dr["MeasurementNrPdLeft"].ToString();
                        orderDetail.MeasurementOcLeft = dr["MeasurementOcLeft"].ToString();
                        orderDetail.MeasurementSegLeft = dr["MeasurementSegLeft"].ToString();
                        orderDetail.MeasurementBlSizeLeft = dr["MeasurementBlSizeLeft"].ToString();
                        orderDetail.MeasurementA = dr["MeasurementA"].ToString();
                        orderDetail.MeasurementB = dr["MeasurementB"].ToString();
                        orderDetail.MeasurementED = dr["MeasurementED"].ToString();
                        orderDetail.MeasurementDBL = dr["MeasurementDBL"].ToString();
                        orderDetail.FrameCode = dr["FrameCode"].ToString();
                        orderDetail.FrameColor = dr["FrameColor"].ToString();
                        orderDetail.FrameUnitPrice = Convert.ToDecimal(dr["FrameUnitPrice"]);
                        orderDetail.FrameQuantity = Convert.ToInt16(dr["FrameQuantity"]);
                        orderDetail.LeftLensDescription = dr["LeftLensDescription"].ToString();
                        orderDetail.LeftLensUnitPrice = Convert.ToDecimal(dr["LeftLensUnitPrice"]);
                        orderDetail.LeftLensQuantity = Convert.ToInt16(dr["LeftLensQuantity"]);
                        orderDetail.RightLensDescription = dr["RightLensDescription"].ToString();
                        orderDetail.RightLensUnitPrice = Convert.ToDecimal(dr["RightLensUnitPrice"]);
                        orderDetail.RightLensQuantity = Convert.ToInt16(dr["RightLensQuantity"]);

                        orderDetail.OtherItemDescription = dr["OtherItemDescription"].ToString();
                        orderDetail.OtherItemUnitPrice = Convert.ToDecimal(dr["OtherItemUnitPrice"]);
                        orderDetail.OtherItemQuantity = Convert.ToInt16(dr["OtherItemQuantity"]);

                        orderDetailList.Add(orderDetail);
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

            return orderDetailList;
        }

        public DataTable GetOrderDetailDataTableByOrderId(int orderId)
        {
            DataTable dataTable = new DataTable("OrderDetail");

            try
            {
                sqlConnection.Open();

                string query = "SELECT * FROM OrderDetail WHERE OrderId = @OrderId";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@OrderId", orderId);
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
        public int InsertNewOrderDetail(OrderDetail orderDetail)
        {
            int result = 0;
            try
            {
                sqlConnection.Open();

                string query = "INSERT INTO OrderDetail(OrderId, TrayNumber, ModifiedSphereRight, ModifiedCylRight, ModifiedAxisRight, ModifiedAddRight, ModifiedPrismRight";
                query += ", ModifiedSphereLeft, ModifiedCylLeft, ModifiedAxisLeft, ModifiedAddLeft, ModifiedPrismLeft, MeasurementFpdRight";
                query += ", MeasurementNrPdRight, MeasurementOcRight, MeasurementSegRight, MeasurementBlSizeRight, MeasurementFpdLeft";
                query += ", MeasurementNrPdLeft, MeasurementOcLeft, MeasurementSegLeft, MeasurementBlSizeLeft, MeasurementA, MeasurementB";
                query += ", MeasurementED, MeasurementDBL, FrameCode, FrameColor, FrameUnitPrice, FrameQuantity, LeftLensDescription";
                query += ", LeftLensUnitPrice, LeftLensQuantity, RightLensDescription, RightLensUnitPrice, RightLensQuantity";
                query += ", OtherItemDescription, OtherItemUnitPrice, OtherItemQuantity) VALUES(@OrderId, @TrayNumber";

                query += ", @ModifiedSphereRight, @ModifiedCylRight, @ModifiedAxisRight, @ModifiedAddRight, @ModifiedPrismRight";
                query += ", @ModifiedSphereLeft, @ModifiedCylLeft, @ModifiedAxisLeft, @ModifiedAddLeft, @ModifiedPrismLeft, @MeasurementFpdRight";
                query += ", @MeasurementNrPdRight, @MeasurementOcRight, @MeasurementSegRight, @MeasurementBlSizeRight, @MeasurementFpdLeft";
                query += ", @MeasurementNrPdLeft, @MeasurementOcLeft, @MeasurementSegLeft, @MeasurementBlSizeLeft, @MeasurementA, @MeasurementB";
                query += ", @MeasurementED, @MeasurementDBL, @FrameCode, @FrameColor, @FrameUnitPrice, @FrameQuantity, @LeftLensDescription";
                query += ", @LeftLensUnitPrice, @LeftLensQuantity, @RightLensDescription, @RightLensUnitPrice, @RightLensQuantity";
                query += ", @OtherItemDescription, @OtherItemUnitPrice, @OtherItemQuantity)";
               
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@OrderId", orderDetail.OrderId);
                sqlCommand.Parameters.AddWithValue("@TrayNumber", orderDetail.TrayNumber);
                sqlCommand.Parameters.AddWithValue("@ModifiedSphereRight", orderDetail.ModifiedSphereRight);
                sqlCommand.Parameters.AddWithValue("@ModifiedCylRight", orderDetail.ModifiedCylRight);
                sqlCommand.Parameters.AddWithValue("@ModifiedAxisRight", orderDetail.ModifiedAxisRight);

                sqlCommand.Parameters.AddWithValue("@ModifiedAddRight", orderDetail.ModifiedAddRight);
                sqlCommand.Parameters.AddWithValue("@ModifiedPrismRight", orderDetail.ModifiedPrismRight);
                sqlCommand.Parameters.AddWithValue("@ModifiedSphereLeft", orderDetail.ModifiedSphereLeft);
                sqlCommand.Parameters.AddWithValue("@ModifiedCylLeft", orderDetail.ModifiedCylLeft);
                sqlCommand.Parameters.AddWithValue("@ModifiedAxisLeft", orderDetail.ModifiedAxisLeft);
                sqlCommand.Parameters.AddWithValue("@ModifiedAddLeft", orderDetail.ModifiedAddLeft);
                sqlCommand.Parameters.AddWithValue("@ModifiedPrismLeft", orderDetail.ModifiedPrismLeft);

                sqlCommand.Parameters.AddWithValue("@MeasurementFpdRight", orderDetail.MeasurementFpdRight);
                sqlCommand.Parameters.AddWithValue("@MeasurementNrPdRight", orderDetail.MeasurementNrPdRight);
                sqlCommand.Parameters.AddWithValue("@MeasurementOcRight", orderDetail.MeasurementOcRight);
                sqlCommand.Parameters.AddWithValue("@MeasurementSegRight", orderDetail.MeasurementSegRight);
                sqlCommand.Parameters.AddWithValue("@MeasurementBlSizeRight", orderDetail.MeasurementBlSizeRight);
                sqlCommand.Parameters.AddWithValue("@MeasurementFpdLeft", orderDetail.MeasurementFpdLeft);
                sqlCommand.Parameters.AddWithValue("@MeasurementNrPdLeft", orderDetail.MeasurementNrPdLeft);
                sqlCommand.Parameters.AddWithValue("@MeasurementOcLeft", orderDetail.MeasurementOcLeft);
                sqlCommand.Parameters.AddWithValue("@MeasurementSegLeft", orderDetail.MeasurementSegLeft);
                sqlCommand.Parameters.AddWithValue("@MeasurementBlSizeLeft", orderDetail.MeasurementBlSizeLeft);
                sqlCommand.Parameters.AddWithValue("@MeasurementA", orderDetail.MeasurementA);
                sqlCommand.Parameters.AddWithValue("@MeasurementB", orderDetail.MeasurementB);
                sqlCommand.Parameters.AddWithValue("@MeasurementED", orderDetail.MeasurementED);
                sqlCommand.Parameters.AddWithValue("@MeasurementDBL", orderDetail.MeasurementDBL);
                sqlCommand.Parameters.AddWithValue("@FrameCode", orderDetail.FrameCode);
                sqlCommand.Parameters.AddWithValue("@FrameColor", orderDetail.FrameColor);

                sqlCommand.Parameters.AddWithValue("@FrameUnitPrice", orderDetail.FrameUnitPrice);
                sqlCommand.Parameters.AddWithValue("@FrameQuantity", orderDetail.FrameQuantity);
                sqlCommand.Parameters.AddWithValue("@LeftLensDescription", orderDetail.LeftLensDescription);
                sqlCommand.Parameters.AddWithValue("@LeftLensUnitPrice", orderDetail.LeftLensUnitPrice);
                sqlCommand.Parameters.AddWithValue("@LeftLensQuantity", orderDetail.LeftLensQuantity);
                sqlCommand.Parameters.AddWithValue("@RightLensDescription", orderDetail.RightLensDescription);
                sqlCommand.Parameters.AddWithValue("@RightLensUnitPrice", orderDetail.RightLensUnitPrice);
                sqlCommand.Parameters.AddWithValue("@RightLensQuantity", orderDetail.RightLensQuantity);

                sqlCommand.Parameters.AddWithValue("@OtherItemDescription", orderDetail.OtherItemDescription);
                sqlCommand.Parameters.AddWithValue("@OtherItemUnitPrice", orderDetail.OtherItemUnitPrice);
                sqlCommand.Parameters.AddWithValue("@OtherItemQuantity", orderDetail.OtherItemQuantity);

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

        public int UpdateExistingOrderDetail(OrderDetail orderDetail)
        {
            int result = 0;
            try
            {
                sqlConnection.Open();

                string query = "UPDATE OrderDetail SET OrderId = @OrderId, TrayNumber = @TrayNumber ModifiedSphereRight = @ModifiedSphereRight, ModifiedCylRight = @ModifiedCylRight, ModifiedAxisRight = @ModifiedAxisRight";
                query += ", ModifiedAddRight = @ModifiedAddRight, ModifiedPrismRight = @ModifiedPrismRight, ModifiedSphereLeft = @ModifiedSphereLeft";
                query += ", ModifiedCylLeft = @ModifiedCylLeft, ModifiedAxisLeft = @ModifiedAxisLeft, ModifiedAddLeft = @ModifiedAddLeft";
                query += ", ModifiedPrismLeft = @ModifiedPrismLeft, MeasurementFpdRight = @MeasurementFpdRight, MeasurementNrPdRight = @MeasurementNrPdRight";
                query += ", MeasurementOcRight = @MeasurementOcRight, MeasurementSegRight = @MeasurementSegRight, MeasurementBlSizeRight = @MeasurementBlSizeRight";
                query += ", MeasurementFpdLeft = @MeasurementFpdLeft, MeasurementNrPdLeft = @MeasurementNrPdLeft, MeasurementOcLeft = @MeasurementOcLeft";
                query += ", MeasurementSegLeft = @MeasurementSegLeft, MeasurementBlSizeLeft = @MeasurementBlSizeLeft, MeasurementA = @MeasurementA, MeasurementB = @MeasurementB, MeasurementED = @MeasurementED";
                query += ", MeasurementDBL = @MeasurementDBL, FrameCode = @FrameCode, FrameColor = @FrameColor, FrameUnitPrice = @FrameUnitPrice, FrameQuantity = @FrameQuantity";
                query += ", LeftLensDescription = @LeftLensDescription, LeftLensUnitPrice = @LeftLensUnitPrice, LeftLensQuantity = @LeftLensQuantity, RightLensDescription = @RightLensDescription, RightLensUnitPrice = @RightLensUnitPrice";
                query += ", RightLensQuantity = @RightLensQuantity, OtherItemDescription = @OtherItemDescription, OtherItemUnitPrice = @OtherItemUnitPrice, OtherItemQuantity = @OtherItemQuantity";

                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@OrderId", orderDetail.OrderId);
                sqlCommand.Parameters.AddWithValue("@TrayNumber", orderDetail.TrayNumber);
                sqlCommand.Parameters.AddWithValue("@ModifiedSphereRight", orderDetail.ModifiedSphereRight);
                sqlCommand.Parameters.AddWithValue("@ModifiedCylRight", orderDetail.ModifiedCylRight);
                sqlCommand.Parameters.AddWithValue("@ModifiedAxisRight", orderDetail.ModifiedAxisRight);

                sqlCommand.Parameters.AddWithValue("@ModifiedAddRight", orderDetail.ModifiedAddRight);
                sqlCommand.Parameters.AddWithValue("@ModifiedPrismRight", orderDetail.ModifiedPrismRight);
                sqlCommand.Parameters.AddWithValue("@ModifiedSphereLeft", orderDetail.ModifiedSphereLeft);
                sqlCommand.Parameters.AddWithValue("@ModifiedCylLeft", orderDetail.ModifiedCylLeft);
                sqlCommand.Parameters.AddWithValue("@ModifiedAxisLeft", orderDetail.ModifiedAxisLeft);
                sqlCommand.Parameters.AddWithValue("@ModifiedAddLeft", orderDetail.ModifiedAddLeft);
                sqlCommand.Parameters.AddWithValue("@ModifiedPrismLeft", orderDetail.ModifiedPrismLeft);

                sqlCommand.Parameters.AddWithValue("@MeasurementFpdRight", orderDetail.MeasurementFpdRight);
                sqlCommand.Parameters.AddWithValue("@MeasurementNrPdRight", orderDetail.MeasurementNrPdRight);
                sqlCommand.Parameters.AddWithValue("@MeasurementOcRight", orderDetail.MeasurementOcRight);
                sqlCommand.Parameters.AddWithValue("@MeasurementSegRight", orderDetail.MeasurementSegRight);
                sqlCommand.Parameters.AddWithValue("@MeasurementBlSizeRight", orderDetail.MeasurementBlSizeRight);
                sqlCommand.Parameters.AddWithValue("@MeasurementFpdLeft", orderDetail.MeasurementFpdLeft);
                sqlCommand.Parameters.AddWithValue("@MeasurementNrPdLeft", orderDetail.MeasurementNrPdLeft);
                sqlCommand.Parameters.AddWithValue("@MeasurementOcLeft", orderDetail.MeasurementOcLeft);
                sqlCommand.Parameters.AddWithValue("@MeasurementSegLeft", orderDetail.MeasurementSegLeft);
                sqlCommand.Parameters.AddWithValue("@MeasurementBlSizeLeft", orderDetail.MeasurementBlSizeLeft);
                sqlCommand.Parameters.AddWithValue("@MeasurementA", orderDetail.MeasurementA);
                sqlCommand.Parameters.AddWithValue("@MeasurementB", orderDetail.MeasurementB);
                sqlCommand.Parameters.AddWithValue("@MeasurementED", orderDetail.MeasurementED);
                sqlCommand.Parameters.AddWithValue("@MeasurementDBL", orderDetail.MeasurementDBL);
                sqlCommand.Parameters.AddWithValue("@FrameCode", orderDetail.FrameCode);
                sqlCommand.Parameters.AddWithValue("@FrameColor", orderDetail.FrameColor);

                sqlCommand.Parameters.AddWithValue("@FrameUnitPrice", orderDetail.FrameUnitPrice);
                sqlCommand.Parameters.AddWithValue("@FrameQuantity", orderDetail.FrameQuantity);
                sqlCommand.Parameters.AddWithValue("@LeftLensDescription", orderDetail.LeftLensDescription);
                sqlCommand.Parameters.AddWithValue("@LeftLensUnitPrice", orderDetail.LeftLensUnitPrice);
                sqlCommand.Parameters.AddWithValue("@LeftLensQuantity", orderDetail.LeftLensQuantity);
                sqlCommand.Parameters.AddWithValue("@RightLensDescription", orderDetail.RightLensDescription);
                sqlCommand.Parameters.AddWithValue("@RightLensUnitPrice", orderDetail.RightLensUnitPrice);
                sqlCommand.Parameters.AddWithValue("@RightLensQuantity", orderDetail.RightLensQuantity);

                sqlCommand.Parameters.AddWithValue("@OtherItemDescription", orderDetail.OtherItemDescription);
                sqlCommand.Parameters.AddWithValue("@OtherItemUnitPrice", orderDetail.OtherItemUnitPrice);
                sqlCommand.Parameters.AddWithValue("@OtherItemQuantity", orderDetail.OtherItemQuantity);

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

        public int DeleteExistingOrderDetail(int id)
        {
            int result = 0;
            try
            {
                sqlConnection.Open();

                string query = "DELETE FROM OrderDetail WHERE Id = @Id";

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
        public int DeleteOrderDetailByOrderId(int orderId)
        {
            int result = 0;
            try
            {
                sqlConnection.Open();

                string query = "DELETE FROM OrderDetail WHERE OrderId = @OrderId";

                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@OrderId", orderId);

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
