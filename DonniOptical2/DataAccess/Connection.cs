using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;

namespace DonniOptical2.DataAccess
{
    public class Connection
    {

        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataAdapter dataAdapter;
        public Connection()
        {
            string connString = ConfigurationManager.ConnectionStrings["opticalconnection"].ConnectionString;
            sqlConnection = new SqlConnection(connString);
        }

        private void OpenConnection()
        {
            sqlConnection.Open();
        }

        public void CloseConnection()
        {
            if (sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }


        public DataTable GetDataTable(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                OpenConnection();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }





    }


}
