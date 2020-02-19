using DonniOptical2.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonniOptical2
{
    public partial class FrmViewOrder : Form
    {
        OrderManager orderManager;
        public FrmViewOrder()
        {
            InitializeComponent();
            orderManager = new OrderManager();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            var orderList = orderManager.GetOrdersByDate(Convert.ToDateTime(dtPickerFromDate.Text), Convert.ToDateTime(dtPickerToDate.Text));
            if (orderList.Count > 0)
            {
                gvOrderList.DataSource = orderList;
            }
            else
            {
                MessageBox.Show("No order found with your seleted date range. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            int index = ddlFilterBy.SelectedIndex;
            int id = 0;

            DateTime fromDate = Convert.ToDateTime(dtPickerFromDate.Text);
            DateTime toDate = Convert.ToDateTime(dtPickerToDate.Text);

            string filterValue = txtFilterValue.Text;

            if (index == 0)
            {
                if (int.TryParse(txtFilterValue.Text, out id))
                {
                    if (id > 0)
                    {
                        var orderList = orderManager.GetOrdersByOrderId(id);
                        if (orderList.Count > 0)
                        {
                            gvOrderList.DataSource = orderList;
                        }
                        else
                        {
                            MessageBox.Show("No order found with your supplied value. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtFilterValue.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Enter a valid order id. ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFilterValue.Focus();
                    return;
                }
            }

            if (index == 1)
            {
                if (int.TryParse(txtFilterValue.Text, out id))
                {
                    if (id > 0)
                    {
                        var orderList = orderManager.GetOrdersByCustomerId(id);
                        if (orderList.Count > 0)
                        {
                            gvOrderList.DataSource = orderList;
                        }
                        else
                        {
                            MessageBox.Show("No order found with your supplied value. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtFilterValue.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Enter a valid customer id. ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFilterValue.Focus();
                    return;
                }
            }

            if (index == 2)
            {
                var orderList = orderManager.GetOrdersByDateAndPhoneNumber(fromDate, toDate, filterValue);
                if (orderList.Count > 0)
                {
                    gvOrderList.DataSource = orderList;
                }
                else
                {
                    MessageBox.Show("No order found with your supplied value. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFilterValue.Focus();
                    return;
                }
            }

            if (index == 3)
            {
                var orderList = orderManager.GetOrdersByDateAndFirstName(fromDate, toDate, filterValue);
                if (orderList.Count > 0)
                {
                    gvOrderList.DataSource = orderList;
                }
                else
                {
                    MessageBox.Show("No order found with your supplied value. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFilterValue.Focus();
                    return;
                }
            }

            if (index == 4)
            {
                var orderList = orderManager.GetOrdersByDateAndLastName(fromDate, toDate, filterValue);
                if (orderList.Count > 0)
                {
                    gvOrderList.DataSource = orderList;
                }
                else
                {
                    MessageBox.Show("No order found with your supplied value. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFilterValue.Focus();
                    return;
                }
            }

            if (index == 5)
            {
                var orderList = orderManager.GetOrdersByDateAndEmail(fromDate, toDate, filterValue);
                if (orderList.Count > 0)
                {
                    gvOrderList.DataSource = orderList;
                }
                else
                {
                    MessageBox.Show("No order found with your supplied value. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFilterValue.Focus();
                    return;
                }
            }
        }
    }
}
