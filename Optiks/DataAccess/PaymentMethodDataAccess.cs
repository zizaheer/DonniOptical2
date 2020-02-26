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
    public class PaymentMethodDataAccess : Connection
    {

        public PaymentMethodDataAccess()
        {

        }

        public List<PaymentMethod> GetPaymentMethodList()
        {
            List<PaymentMethod> paymentMethodList = new List<PaymentMethod>();

            try
            {
                sqlConnection.Open();

                DataTable dataTable = new DataTable();
                string query = "SELECT * FROM PaymentMethod";
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);
                
                if (dataTable.Rows.Count > 0) {
                    foreach (DataRow dr in dataTable.Rows) {
                        PaymentMethod paymentMethod = new PaymentMethod();
                        paymentMethod.Id = Convert.ToInt32(dr["Id"]);
                        paymentMethod.PaymentMethodName= (dr["PaymentMethodName"]).ToString();

                        paymentMethodList.Add(paymentMethod);
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

            return paymentMethodList;
        }

    }
}
