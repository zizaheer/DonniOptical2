using Optiks.DataAccess;
using Optiks.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiks.BusinessLogic
{

    public class CustomerManager
    {
        CustomerDataAccess dataAccess;

        public CustomerManager()
        {
            dataAccess = new CustomerDataAccess();
        }



        public List<Customer> GetCustomers()
        {

            List<Customer> customerList = new List<Customer>();
            try
            {
                customerList = dataAccess.GetCustomerList();

            }
            catch (Exception ex)
            {
                //
            }

            return customerList;

        }

        public DataTable GetCustomerDataTable()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = dataAccess.GetCustomerDataTable();
            }
            catch (Exception ex)
            {
                //
            }

            return dt;

        }
        public DataTable GetCustomerDataTableById(int custId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = dataAccess.GetCustomerDataTableById(custId);
                dt.TableName = "Customer";
            }
            catch (Exception ex)
            {
                //
            }

            return dt;

        }

        public Customer GetCustomerById(int id)
        {

            Customer customer = new Customer();
            try
            {
                customer = dataAccess.GetCustomerById(id);
            }
            catch (Exception ex)
            {
                //
            }

            return customer;

        }

        public int InsertNewCustomer(Customer customer)
        {
            int result = 0;
            try
            {
                result = dataAccess.InsertNewCustomer(customer);
            }
            catch (Exception ex)
            {
                //
            }

            return result;
        }

        public int UpdateExistingCustomer(Customer customer)
        {
            int result = 0;
            try
            {
                result = dataAccess.UpdateExistingCustomer(customer);
            }
            catch (Exception ex)
            {
                //
            }

            return result;
        }

        public int DeleteExistingCustomer(int customerId)
        {
            int result = 0;
            try
            {
                result = dataAccess.DeleteExistingCustomer(customerId);
            }
            catch (Exception ex)
            {
                //
            }

            return result;
        }

        public List<Customer> GetCustomersByPhone(string customerPhone)
        {
            var customerList = dataAccess.GetCustomerList();
            customerList = customerList.Where(c => string.Equals(c.Telephone, customerPhone, StringComparison.OrdinalIgnoreCase)).ToList();

            return customerList;
        }
        public List<Customer> GetCustomersByFirstName(string customerFirstName)
        {
            var customerList = dataAccess.GetCustomerList();
            customerList = customerList.Where(c => string.Equals(c.FirstName, customerFirstName, StringComparison.OrdinalIgnoreCase)).ToList();

            return customerList;
        }

        public List<Customer> GetCustomersByLastName(string customerLastName)
        {
            var customerList = dataAccess.GetCustomerList();
            customerList = customerList.Where(c => string.Equals(c.LastName, customerLastName, StringComparison.OrdinalIgnoreCase)).ToList();

            return customerList;
        }

        public List<Customer> GetCustomersByFullName(string customerFullName)
        {
            var customerList = dataAccess.GetCustomerList();
            customerList = customerList.Where(c => string.Equals(c.FirstName + c.LastName, customerFullName, StringComparison.OrdinalIgnoreCase)).ToList();

            return customerList;
        }

    }
}
