using DonniOptical2.BusinessLogic;
using DonniOptical2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace DonniOptical2
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            LoadCustomerGrid();
            PrepareForNewEntry();
        }

        private void rdoNewCustomer_CheckedChanged(object sender, EventArgs e)
        {
            ClearFindByGroupBox();
            txtCustomerNo.Text = "";
            gbFindBy.Enabled = false;
            PrepareForNewEntry();
        }

        private void rdoFindCustomer_CheckedChanged(object sender, EventArgs e)
        {
            ClearFindByGroupBox();
            gbFindBy.Enabled = true;
            txtFindByValue.Focus();
        }

        private void ClearFindByGroupBox()
        {

            ddlFindBy.SelectedIndex = 0;
            txtFindByValue.Text = "";
            lblNoOfCustomersFound.Text = "0";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                int customerId = 0;

                if (!ValidateEntry())
                {
                    return;
                }

                Customer customerInfo = new Customer();
                customerInfo.Id = txtCustomerNo.Text != "" ? Convert.ToInt32(txtCustomerNo.Text) : 0;
                customerInfo.FirstName = txtCustomerFirstName.Text;
                customerInfo.LastName = txtCustomerLastName.Text;
                customerInfo.Email = txtCustomerEmail.Text;
                customerInfo.Telephone = txtCustomerPhone.Text;
                customerInfo.Address = txtCustomerAddress.Text;
                customerInfo.City = txtCustomerCity.Text;
                customerInfo.Postcode = txtCustomerPostcode.Text;

                using (var scope = new TransactionScope())
                {
                    if (customerInfo.Id > 0)
                    {
                        customerId = UpdateCustomer(customerInfo);
                    }
                    else
                    {
                        customerId = AddNewCustomer(customerInfo);
                    }

                    if (customerId > 0) {
                        scope.Complete();
                        rdoFindCustomer.Checked = true;
                        gbFindBy.Enabled = true;
                        txtCustomerNo.Text = customerId.ToString();
                    }
                }

                LoadCustomerGrid();
            }
            catch (Exception ex)
            {

            }
        }


        private int AddNewCustomer(Customer customer)
        {
            int customerId = 0;
            CustomerManager customerManager = new CustomerManager();

            customerId = customerManager.InsertNewCustomer(customer);
            
            return customerId;
        }
        private int UpdateCustomer(Customer customer)
        {
            int customerId = 0;
            CustomerManager customerManager = new CustomerManager();

            var result = customerManager.UpdateExistingCustomer(customer);
            if (result > 0)
            {
                customerManager = new CustomerManager();
                customerId = customer.Id;
            }

            return customerId;
        }
        private bool ValidateEntry()
        {
            try
            {
                if (string.IsNullOrEmpty(txtCustomerFirstName.Text.Trim()))
                {
                    MessageBox.Show("Please enter first name");
                    txtCustomerFirstName.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtCustomerPhone.Text.Trim()))
                {
                    MessageBox.Show("Please enter last name");
                    txtCustomerLastName.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtCustomerAddress.Text.Trim()))
                {
                    MessageBox.Show("Please enter address");
                    txtCustomerAddress.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
                //
            }
        }

        private void gvCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rdoFindCustomer.Checked = true;
            gbFindBy.Enabled = true;

            txtCustomerNo.Text = gvCustomerList.CurrentRow.Cells["Id"].Value.ToString();
            txtCustomerFirstName.Text = gvCustomerList.CurrentRow.Cells["FirstName"].Value.ToString();
            txtCustomerLastName.Text = gvCustomerList.CurrentRow.Cells["LastName"].Value.ToString();
            txtCustomerAddress.Text = gvCustomerList.CurrentRow.Cells["Address"].Value.ToString();
            txtCustomerPhone.Text = gvCustomerList.CurrentRow.Cells["Telephone"].Value.ToString();
            txtCustomerCity.Text = gvCustomerList.CurrentRow.Cells["City"].Value.ToString();
            txtCustomerPostcode.Text = gvCustomerList.CurrentRow.Cells["Postcode"].Value.ToString();
            txtCustomerEmail.Text = gvCustomerList.CurrentRow.Cells["Email"].Value.ToString();
        }

        private void LoadCustomerGrid() {
            CustomerManager customerManager = new CustomerManager();
            var customerList = customerManager.GetCustomers();
            gvCustomerList.DataSource = customerList;
        }

        private void PrepareForNewEntry()
        {
            foreach (Control control in Controls)
            {
                foreach (TextBox tb in control.Controls.OfType<TextBox>())
                {
                    tb.Text = string.Empty;
                }
            }
        }

    }
}
