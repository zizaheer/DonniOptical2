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
        CustomerManager customerManager;
        int[] customerFound;
        public frmCustomer()
        {
            InitializeComponent();
            customerManager = new CustomerManager();
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

                    if (customerId > 0)
                    {
                        scope.Complete();
                        rdoFindCustomer.Checked = true;
                        gbFindBy.Enabled = true;
                        txtCustomerNo.Text = customerId.ToString();
                        MessageBox.Show("Customer saved successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            ShowCustomerInformation(gvCustomerList.CurrentRow);
        }

        private void LoadCustomerGrid()
        {
            CustomerManager customerManager = new CustomerManager();
            var customerList = customerManager.GetCustomers();
            gvCustomerList.DataSource = customerList;
        }

        private void PrepareForNewEntry()
        {
            gbFindBy.Enabled = false;
            foreach (Control control in Controls)
            {
                foreach (TextBox tb in control.Controls.OfType<TextBox>())
                {
                    tb.Text = string.Empty;
                }
            }
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            lblNoOfCustomersFound.Text = "0";
            string suppliedValue = txtFindByValue.Text;

            if (suppliedValue.Length < 1) {
                MessageBox.Show("Please enter value to search.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFindByValue.Focus();
                return;
            }

            if (ddlFindBy.SelectedIndex == 0)
            {
                if (suppliedValue.Trim().Length > 0)
                {
                    var customerList = customerManager.GetCustomersByFirstName(suppliedValue).Select(c => c.Id).Distinct().ToArray();
                    if (customerList.Length > 0)
                    {
                        lblNoOfCustomersFound.Text = customerList.Length.ToString();
                        customerFound = customerList;
                        ShowCustomerInformation(customerFound[0]);
                    }
                    else
                    {
                        customerFound = Array.Empty<int>();
                        MessageBox.Show("No customer found with your search criteria.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter valid customer first name.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
            if (ddlFindBy.SelectedIndex == 1)
            {
                if (suppliedValue.Trim().Length > 0)
                {
                    var customerList = customerManager.GetCustomersByPhone(suppliedValue).Select(c => c.Id).Distinct().ToArray();
                    if (customerList.Length > 0)
                    {
                        lblNoOfCustomersFound.Text = customerList.Length.ToString();
                        customerFound = customerList;
                        ShowCustomerInformation(customerFound[0]);
                    }
                    else
                    {
                        customerFound = Array.Empty<int>();
                        MessageBox.Show("No customer found with your search criteria.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter valid customer phone number.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (ddlFindBy.SelectedIndex == 2)
            {
                if (suppliedValue.Trim().Length > 0)
                {
                    var customerList = customerManager.GetCustomersByLastName(suppliedValue).Select(c => c.Id).Distinct().ToArray();
                    if (customerList.Length > 0)
                    {
                        lblNoOfCustomersFound.Text = customerList.Length.ToString();
                        customerFound = customerList;
                        ShowCustomerInformation(customerFound[0]);
                    }
                    else
                    {
                        customerFound = Array.Empty<int>();
                        MessageBox.Show("No customer found with your search criteria.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter valid customer last name.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (ddlFindBy.SelectedIndex == 3)
            {
                if (suppliedValue.Trim().Length > 0)
                {
                    var customerList = customerManager.GetCustomersByFullName(suppliedValue).Select(c => c.Id).Distinct().ToArray();
                    if (customerList.Length > 0)
                    {
                        lblNoOfCustomersFound.Text = customerList.Length.ToString();
                        customerFound = customerList;
                        ShowCustomerInformation(customerFound[0]);
                    }
                    else
                    {
                        customerFound = Array.Empty<int>();
                        MessageBox.Show("No customer found with your search criteria.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter valid customer name.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


        }

        private void ShowCustomerInformation(DataGridViewRow row)
        {

            txtCustomerNo.Text = row.Cells["Id"].Value.ToString();
            txtCustomerFirstName.Text = row.Cells["FirstName"].Value.ToString();
            txtCustomerLastName.Text = row.Cells["LastName"].Value.ToString();
            txtCustomerAddress.Text = row.Cells["Address"].Value.ToString();
            txtCustomerPhone.Text = row.Cells["Telephone"].Value.ToString();
            txtCustomerCity.Text = row.Cells["City"].Value.ToString();
            txtCustomerPostcode.Text = row.Cells["Postcode"].Value.ToString();
            txtCustomerEmail.Text = row.Cells["Email"].Value.ToString();
        }

        private void ShowCustomerInformation(int customerId)
        {
            var custInfo = customerManager.GetCustomerById(customerId);
            if (custInfo != null)
            {
                txtCustomerNo.Text = custInfo.Id.ToString();
                txtCustomerFirstName.Text = custInfo.FirstName;
                txtCustomerLastName.Text = custInfo.LastName;
                txtCustomerAddress.Text = custInfo.Address;
                txtCustomerPhone.Text = custInfo.Telephone;
                txtCustomerCity.Text = custInfo.City;
                txtCustomerPostcode.Text = custInfo.Postcode;
                txtCustomerEmail.Text = custInfo.Email;
            }
        }


        private void lnkNextCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (customerFound.Length > 0)
            {
                int custNo = Convert.ToInt32(txtCustomerNo.Text);
                int index = 0;
                if (custNo > 0)
                {
                    index = Array.IndexOf(customerFound, custNo);
                    index++;
                }

                if (index < customerFound.Length)
                {
                    ShowCustomerInformation(customerFound[index]);
                }
            }
        }

        private void lnkPreviousCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (customerFound.Length > 0)
            {
                int custNo = Convert.ToInt32(txtCustomerNo.Text);
                int index = 0;
                if (custNo > 0)
                {
                    index = Array.IndexOf(customerFound, custNo);
                    index--;
                }

                if (index >= 0)
                {
                    ShowCustomerInformation(customerFound[index]);
                }

            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            bool isFormOpened = false;

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "frmOrder")
                {
                    frm.BringToFront();
                    isFormOpened = true;
                }
            }

            if (isFormOpened == false)
            {
                frmOrder orderForm = new frmOrder();
                orderForm.MdiParent = frmMain.ActiveForm;
                orderForm.Location = new Point(5, 5);
                orderForm.Show();
            }
        }
    }
}
