using Optiks.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optiks
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
                MessageBox.Show("No order found with your seleted date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var orderList = orderManager.GetOrdersByCustomerPhone(filterValue);
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
                var orderList = orderManager.GetOrdersByCustomerFirstName(filterValue);
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
                var orderList = orderManager.GetOrdersByLastName(filterValue);
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
                var orderList = orderManager.GetOrdersByEmail(filterValue);
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

        private void gvOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int orderId = 0;
            var row = gvOrderList.CurrentRow;

            orderId = Convert.ToInt32(row.Cells["OrderId"].Value);
            OpenOrderForm(orderId);
        }

        private void OpenOrderForm(int orderId) {
            if (orderId > 0)
            {

                bool isFormOpened = false;

                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Name == "FrmOrder")
                    {
                        ((FrmOrder)frm).rdoFindOrder.Checked = true;
                        ((FrmOrder)frm).ddlFindBy.SelectedIndex = 0;
                        ((FrmOrder)frm).txtFindByValue.Text = orderId.ToString();
                        ((FrmOrder)frm).PrepareForUpdateEntry(orderId); 
                        frm.BringToFront();
                        
                        isFormOpened = true;
                    }
                }

                if (isFormOpened == false)
                {
                    FrmOrder orderForm = new FrmOrder();
                    orderForm.MdiParent = FrmMain.ActiveForm;
                    orderForm.Location = new Point(5, 5);

                    orderForm.rdoFindOrder.Checked = true;
                    orderForm.ddlFindBy.SelectedIndex = 0;
                    orderForm.txtFindByValue.Text = orderId.ToString();
                    orderForm.PrepareForUpdateEntry(orderId);
                    orderForm.Show();
                }
            }

        }
    }
}
