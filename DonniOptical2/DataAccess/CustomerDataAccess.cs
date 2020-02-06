using DonniOptical2.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonniOptical2.DataAccess
{
    public class CustomerDataAccess
    {
        SqlConnection connection;
        public CustomerDataAccess() {
            Connection conn = new Connection();
            connection = conn.OpenConnection();
        }

        public Customer GetCustomerList() {

            string query = "SELECT * FROM Customer";
            

        }




    }
}
