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
        internal SqlConnection sqlConnection;
        internal SqlCommand sqlCommand;
        internal SqlDataAdapter dataAdapter;
        internal SqlDataReader dataReader;
        public Connection()
        {
            string connString = ConfigurationManager.ConnectionStrings["opticalconnection"].ConnectionString;
            sqlConnection = new SqlConnection(connString);
        }
    }


}
