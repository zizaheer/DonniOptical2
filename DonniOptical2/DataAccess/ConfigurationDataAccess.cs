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
    public class ConfigurationDataAccess : Connection
    {

        public ConfigurationDataAccess()
        {

        }

        public decimal GetHstAmount()
        {
            decimal hstAmount = 0;
            try
            {
                sqlConnection.Open();

                DataTable dataTable = new DataTable();
                string query = "SELECT HstAmnt FROM Configuration";
                sqlCommand = new SqlCommand(query, sqlConnection);
                hstAmount = Convert.ToDecimal(sqlCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                //
            }

            finally
            {
                sqlConnection.Close();
            }

            return hstAmount;
        }

    }
}
