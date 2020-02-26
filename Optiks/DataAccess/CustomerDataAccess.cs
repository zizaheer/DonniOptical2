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
    public class CustomerDataAccess : Connection
    {

        public CustomerDataAccess()
        {

        }

        public List<Customer> GetCustomerList()
        {
            List<Customer> customerList = new List<Customer>();

            try
            {
                sqlConnection.Open();

                DataTable dataTable = new DataTable();
                string query = "SELECT * FROM Customer";
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);
                
                if (dataTable.Rows.Count > 0) {
                    foreach (DataRow dr in dataTable.Rows) {
                        Customer customer = new Customer();
                        customer.Id = Convert.ToInt32(dr["Id"]);
                        customer.FirstName = (dr["FirstName"]).ToString();
                        customer.LastName = (dr["LastName"]).ToString();
                        customer.Telephone = (dr["Telephone"]).ToString();
                        customer.Email = (dr["Email"]).ToString();
                        customer.Address = (dr["Address"]).ToString();
                        customer.Postcode = (dr["Postcode"]).ToString();
                        customer.City = (dr["City"]).ToString();

                        customerList.Add(customer);
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

            return customerList;
        }

        public DataTable GetCustomerDataTable()
        {
            DataTable dt = new DataTable();

            try
            {
                sqlConnection.Open();

                DataTable dataTable = new DataTable();
                string query = "SELECT * FROM Customer";
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

            return dt;
        }
        public Customer GetCustomerById(int id)
        {
            Customer customer = new Customer();

            try
            {
                sqlConnection.Open();

                DataTable dataTable = new DataTable();
                string query = "SELECT * FROM Customer WHERE Id = @Id";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read()) {
                    customer.Id = Convert.ToInt32(dataReader["Id"]);
                    customer.FirstName = Convert.ToString(dataReader["FirstName"]);
                    customer.LastName = dataReader["LastName"].ToString();
                    customer.Telephone = dataReader["Telephone"].ToString();
                    customer.Email = dataReader["Email"].ToString();
                    customer.Address = dataReader["Address"].ToString();
                    customer.Postcode = dataReader["Postcode"].ToString();
                    customer.City = dataReader["City"].ToString();
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

            return customer;
        }

        public DataTable GetCustomerDataTableById(int id)
        {
            DataTable dt = new DataTable();

            try
            {
                sqlConnection.Open();

                DataTable dataTable = new DataTable();
                string query = "SELECT * FROM Customer WHERE Id = @Id";
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

            return dt;
        }

        public int GetMaxCustomerId()
        {
            int orderId = 0;
            try
            {
                sqlConnection.Open();

                DataTable dataTable = new DataTable();
                string query = "SELECT MAX(Id) FROM Customer";
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

        public int InsertNewCustomer(Customer customer)
        {
            int customerId = 0;
            try
            {
                sqlConnection.Open();
                
                string query = "INSERT INTO Customer(FirstName, LastName, Address, City, Postcode, Telephone";
                query += ", Email) VALUES(@FirstName, @LastName, @Address, @City, @Postcode, @Telephone, @Email); ";
                query += " SELECT CAST(scope_identity() AS INT) ";
                
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@FirstName", customer.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", customer.LastName);
                sqlCommand.Parameters.AddWithValue("@Address", customer.Address);
                sqlCommand.Parameters.AddWithValue("@City", customer.City);
                sqlCommand.Parameters.AddWithValue("@Postcode", customer.Postcode);
                sqlCommand.Parameters.AddWithValue("@Telephone", customer.Telephone);
                sqlCommand.Parameters.AddWithValue("@Email", customer.Email);

                customerId = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //
            }

            finally
            {
                sqlConnection.Close();
            }

            return customerId;
        }

        public int UpdateExistingCustomer(Customer customer)
        {
            int isUpdated = 0;
            try
            {
                sqlConnection.Open();

                string query = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Address = @Address";
                query += ", City = @City, Postcode = @Postcode, Telephone = @Telephone, Email = @Email WHERE Id = @Id";

                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", customer.Id);
                sqlCommand.Parameters.AddWithValue("@FirstName", customer.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", customer.LastName);
                sqlCommand.Parameters.AddWithValue("@Address", customer.Address);
                sqlCommand.Parameters.AddWithValue("@City", customer.City);
                sqlCommand.Parameters.AddWithValue("@Postcode", customer.Postcode);
                sqlCommand.Parameters.AddWithValue("@Telephone", customer.Telephone);
                sqlCommand.Parameters.AddWithValue("@Email", customer.Email);

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

        public int DeleteExistingCustomer(int id)
        {
            int result = 0;
            try
            {
                sqlConnection.Open();

                string query = "DELETE FROM Customer WHERE Id = @Id";

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
