using DonniOptical2.DataAccess;
using DonniOptical2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonniOptical2.BusinessLogic
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


    }
}
