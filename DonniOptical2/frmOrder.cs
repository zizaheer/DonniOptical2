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
using System.Windows.Forms;

namespace DonniOptical2
{
    public partial class frmOrder : Form
    {
        CustomerManager customerManager = new CustomerManager();
        OrderManager orderManager = new OrderManager();
        decimal hstAmount = 0;
        int[] orderFound;
        public frmOrder()
        {
            InitializeComponent();
        }

        #region Private Events

        private void frmOrder_Load(object sender, EventArgs e)
        {
            orderManager = new OrderManager();
            ddlPaidBy.DataSource = orderManager.GetPaymentMethods();
            ddlPaidBy.ValueMember = "PaymentMethodName";
            ddlPaidBy.DisplayMember = "PaymentMethodName";

            hstAmount = orderManager.GetHstAmount();
            lblHstAmnt.Text = "(" + hstAmount.ToString("0.00") + "%)";
            PrepareOrderDetailGridview();
            txtCustomerNo.Focus();
        }

        private void rdoNewOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNewOrder.Checked)
            {
                ClearFindByGroupBox();
                txtOrderNo.Text = "Auto";
                txtOrderNo.Enabled = false;
                txtOrderDate.Text = "dd-mmm-yyyy";

                gbFindBy.Enabled = false;
                PrepareForNewEntry();
            }
        }

        private void rdoFindOrder_CheckedChanged(object sender, EventArgs e)
        {
            ClearFindByGroupBox();
            txtOrderNo.Text = "";
            txtOrderDate.Text = "dd-mmm-yyyy";
            gbFindBy.Enabled = true;
            txtFindByValue.Focus();
        }

        private void btnFindOrder_Click(object sender, EventArgs e)
        {
            int orderId = 0;
            lblNoOfOrdersFound.Text = "0";
            
            if (ddlFindBy.SelectedIndex == 0)
            {
                int.TryParse(txtFindByValue.Text, out orderId);
                if (orderId > 0)
                {
                    PrepareForUpdateEntry(orderId);
                }
                else
                {
                    orderFound = Array.Empty<int>();
                    MessageBox.Show("Please enter a valid order id.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (ddlFindBy.SelectedIndex == 1)
            {
                string custPhone = txtFindByValue.Text;

                if (custPhone.Trim().Length > 0)
                {
                    var orderList = orderManager.GetOrdersByCustomerPhone(custPhone).Select(c => c.OrderId).Distinct().ToArray();
                    if (orderList.Length > 0)
                    {
                        lblNoOfOrdersFound.Text = orderList.Length.ToString();
                        orderFound = orderList;
                        PrepareForUpdateEntry(orderFound[0]);
                    }
                    else
                    {
                        orderFound = Array.Empty<int>();
                        MessageBox.Show("No order found with your search criteria.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Please enter valid customer phone number.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (ddlFindBy.SelectedIndex == 2)
            {
                string custFirstName = txtFindByValue.Text;

                if (custFirstName.Trim().Length > 0)
                {
                    var orderList = orderManager.GetOrdersByCustomerFirstName(custFirstName).Select(c => c.OrderId).Distinct().ToArray();
                    if (orderList.Length > 0)
                    {
                        lblNoOfOrdersFound.Text = orderList.Length.ToString();
                        orderFound = orderList;
                        PrepareForUpdateEntry(orderFound[0]);
                    }
                    else
                    {
                        orderFound = Array.Empty<int>();
                        MessageBox.Show("No order found with your search criteria.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Please enter valid customer first name.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (ddlFindBy.SelectedIndex == 3)
            {
                string custLastName = txtFindByValue.Text;

                if (custLastName.Trim().Length > 0)
                {
                    var orderList = orderManager.GetOrdersByCustomerFirstName(custLastName).Select(c => c.OrderId).Distinct().ToArray();
                    if (orderList.Length > 0)
                    {
                        lblNoOfOrdersFound.Text = orderList.Length.ToString();
                        orderFound = orderList;
                        PrepareForUpdateEntry(orderFound[0]);
                    }
                    else
                    {
                        orderFound = Array.Empty<int>();
                        MessageBox.Show("No order found with your search criteria.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Please enter valid customer last name.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }




        }

        private void lnkPreviousOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (orderFound.Length > 0)
            {
                int orderNo = Convert.ToInt32(txtOrderNo.Text);
                int index = 0;
                if (orderNo > 0)
                {
                    index = Array.IndexOf(orderFound, orderNo);
                    index--;
                }

                if (index >= 0)
                {
                    PrepareForUpdateEntry(orderFound[index]);
                }

            }
        }
        
        private void lnkNextOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (orderFound.Length > 0)
            {
                int orderNo = Convert.ToInt32(txtOrderNo.Text);
                int index = 0;
                if (orderNo > 0)
                {
                    index = Array.IndexOf(orderFound, orderNo);
                    index++;
                }

                if (index < orderFound.Length)
                {
                    PrepareForUpdateEntry(orderFound[index]);
                }
            }
        }

        private void btnCloseOrder_Click(object sender, EventArgs e)
        {
            this.Close();
            //if(txtOrderTotalAmnt.Text)
        }

        private void btnFindCustomerForOrder_Click(object sender, EventArgs e)
        {
            int custId = 0;
            if (txtCustomerNo.Text.Trim() != string.Empty)
            {
                if (int.TryParse(txtCustomerNo.Text, out custId))
                {
                    if (custId > 0)
                    {
                        GetCustomerInformation(Convert.ToInt32(txtCustomerNo.Text.Trim()));
                    }
                }
            }
        }

        private void txtCustomerNo_TextChanged(object sender, EventArgs e)
        {
            int custId = 0;
            if (txtCustomerNo.Text.Trim() != string.Empty)
            {
                if (int.TryParse(txtCustomerNo.Text, out custId))
                {
                    if (custId > 0)
                    {
                        GetCustomerInformation(Convert.ToInt32(txtCustomerNo.Text.Trim()));
                    }
                }
            }
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            try
            {
                int orderId = 0;

                if (gvOrderItemList.Rows.Count < 1)
                {
                    MessageBox.Show("The order list is empty. Please add some item in the order.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Convert.ToDecimal(txtGrandTotal.Text) <= 0)
                {
                    MessageBox.Show("Order total must be a valid amount to place the order.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Order orderInfo = new Order();
                orderInfo.Id = txtOrderNo.Text != "" && txtOrderNo.Text != "Auto" ? Convert.ToInt32(txtOrderNo.Text) : 0;
                orderInfo.CustomerId = Convert.ToInt32(txtCustomerNo.Text);
                orderInfo.DoctorName = txtDoctorName.Text;
                orderInfo.DoctorPhone = txtDoctorPhone.Text;
                orderInfo.DoctorClinicAddress = txtDoctorClinicAddress.Text;
                orderInfo.DoctorPrescriptionDate = Convert.ToDateTime(txtPrescriptionDate.Text);
                orderInfo.PrescriptionSphereRight = txtPrescriptionSphereRight.Text;
                orderInfo.PrescriptionCylRight = txtPrescriptionCylRight.Text;
                orderInfo.PrescriptionAxisRight = txtPrescriptionAxisRight.Text;
                orderInfo.PrescriptionAddRight = txtPrescriptionAddRight.Text;
                orderInfo.PrescriptionPrismRight = txtPrescriptionPrismRight.Text;
                orderInfo.PrescriptionSphereLeft = txtPrescriptionSphereLeft.Text;
                orderInfo.PrescriptionCylLeft = txtPrescriptionCylLeft.Text;
                orderInfo.PrescriptionAxisLeft = txtPrescriptionAxisLeft.Text;
                orderInfo.PrescriptionAddLeft = txtPrescriptionAddLeft.Text;
                orderInfo.PrescriptionPrismLeft = txtPrescriptionPrismLeft.Text;
                orderInfo.FrameTotalPrice = Convert.ToDecimal(txtFrameTotalPrice.Text);
                orderInfo.LensTotalPrice = Convert.ToDecimal(txtLensTotalPrice.Text);
                orderInfo.OtherAdjustment = Convert.ToDecimal(txtOtherTotal.Text);
                orderInfo.OrderTotal = Convert.ToDecimal(txtOrderTotalAmnt.Text);
                orderInfo.HstAmount = Convert.ToDecimal(txtHSTAmnt.Text);
                orderInfo.GrandTotal = Convert.ToDecimal(txtGrandTotal.Text);
                orderInfo.PaidBy = ddlPaidBy.SelectedValue.ToString();
                orderInfo.PaidAmount = Convert.ToDecimal(txtDepositAmnt.Text);
                orderInfo.BalanceDue = Convert.ToDecimal(txtBalanceAmnt.Text);
                orderInfo.Remarks = txtRemarks.Text;
                orderInfo.CreateDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy"));

                List<OrderDetail> orderDetailList = new List<OrderDetail>();

                foreach (DataGridViewRow row in gvOrderItemList.Rows)
                {
                    OrderDetail orderDetail = new OrderDetail();

                    orderDetail.OrderId = orderInfo.Id;

                    orderDetail.TrayNumber = row.Cells["TRAY#"].Value.ToString();

                    orderDetail.ModifiedSphereRight = row.Cells["SPH_R"].Value.ToString();
                    orderDetail.ModifiedCylRight = row.Cells["CYL_R"].Value.ToString();
                    orderDetail.ModifiedAxisRight = row.Cells["AXIS_R"].Value.ToString();
                    orderDetail.ModifiedAddRight = row.Cells["ADD_R"].Value.ToString();
                    orderDetail.ModifiedPrismRight = row.Cells["PRISM_R"].Value.ToString();

                    orderDetail.ModifiedSphereLeft = row.Cells["SPH_L"].Value.ToString();
                    orderDetail.ModifiedCylLeft = row.Cells["CYL_L"].Value.ToString();
                    orderDetail.ModifiedAxisLeft = row.Cells["AXIS_L"].Value.ToString();
                    orderDetail.ModifiedAddLeft = row.Cells["ADD_L"].Value.ToString();
                    orderDetail.ModifiedPrismLeft = row.Cells["PRISM_L"].Value.ToString();

                    orderDetail.MeasurementFpdRight = row.Cells["FPD_R"].Value.ToString();
                    orderDetail.MeasurementNrPdRight = row.Cells["NR.PD_R"].Value.ToString();
                    orderDetail.MeasurementOcRight = row.Cells["OC_R"].Value.ToString();
                    orderDetail.MeasurementSegRight = row.Cells["SEG_R"].Value.ToString();
                    orderDetail.MeasurementBlSizeRight = row.Cells["BL.SIZE_R"].Value.ToString();

                    orderDetail.MeasurementFpdLeft = row.Cells["FPD_L"].Value.ToString();
                    orderDetail.MeasurementNrPdLeft = row.Cells["NR.PD_L"].Value.ToString();
                    orderDetail.MeasurementOcLeft = row.Cells["OC_L"].Value.ToString();
                    orderDetail.MeasurementSegLeft = row.Cells["SEG_L"].Value.ToString();
                    orderDetail.MeasurementBlSizeLeft = row.Cells["BL.SIZE_L"].Value.ToString();

                    orderDetail.MeasurementA = row.Cells["MSRMNT_A"].Value.ToString();
                    orderDetail.MeasurementB = row.Cells["MSRMNT_B"].Value.ToString();
                    orderDetail.MeasurementED = row.Cells["MSRMNT_ED"].Value.ToString();
                    orderDetail.MeasurementDBL = row.Cells["MSRMNT_DBL"].Value.ToString();

                    orderDetail.FrameCode = row.Cells["FRM_CODE"].Value.ToString();
                    orderDetail.FrameColor = row.Cells["FRM_COLOR"].Value.ToString();
                    orderDetail.FrameUnitPrice = Convert.ToDecimal(row.Cells["FRM_UNT_PRICE"].Value);
                    orderDetail.FrameQuantity = Convert.ToInt32(row.Cells["FRM_QTY"].Value);
                    orderDetail.LeftLensDescription = row.Cells["LL_DESC"].Value.ToString();
                    orderDetail.LeftLensUnitPrice = Convert.ToDecimal(row.Cells["LL_UNT_PRICE"].Value);
                    orderDetail.LeftLensQuantity = Convert.ToInt32(row.Cells["LL_QTY"].Value);
                    orderDetail.RightLensDescription = row.Cells["RL_DESC"].Value.ToString();
                    orderDetail.RightLensUnitPrice = Convert.ToDecimal(row.Cells["RL_UNT_PRICE"].Value);
                    orderDetail.RightLensQuantity = Convert.ToInt32(row.Cells["RL_QTY"].Value);

                    orderDetail.OtherItemDescription = row.Cells["OTHR_DESC"].Value.ToString();
                    orderDetail.OtherItemUnitPrice = Convert.ToDecimal(row.Cells["OTHR_UNT_PRICE"].Value);
                    orderDetail.OtherItemQuantity = Convert.ToInt32(row.Cells["OTHR_QTY"].Value);

                    orderDetailList.Add(orderDetail);
                }

                orderId = AddNewOrder(orderInfo, orderDetailList);

                if (orderId > 0)
                {
                    //PrepareForUpdateEntry(orderId);
                    PrepareForNewEntry();
                    DialogResult dr = MessageBox.Show("The order saved successfully. Do you want to print receipt?", "Successful", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes)
                    {
                        customerManager = new CustomerManager();
                        var custInfo = customerManager.GetCustomerById(orderInfo.CustomerId);

                        frmPrintReceipt frmPrintReceipt = new frmPrintReceipt();
                        frmPrintReceipt.lblOrderNoValue.Text = orderId.ToString().PadLeft(8, '0');
                        frmPrintReceipt.lblOrderDate.Text = orderInfo.CreateDate.ToString("dd-MMM-yyyy");

                        frmPrintReceipt.lblCustomerNoValue.Text = orderInfo.CustomerId.ToString().PadLeft(6, '0');
                        frmPrintReceipt.lblCustomerName.Text = custInfo.FirstName + " " + custInfo.LastName;
                        frmPrintReceipt.lblCustomerAddress.Text = custInfo.Address;
                        frmPrintReceipt.lblCity.Text = custInfo.City;
                        frmPrintReceipt.lblPostCode.Text = custInfo.Postcode;
                        frmPrintReceipt.lblCustomerPhone.Text = custInfo.Telephone;

                        frmPrintReceipt.lblFrameTotalPrice.Text = Convert.ToString(orderInfo.FrameTotalPrice);
                        frmPrintReceipt.lblLensTotalPrice.Text = Convert.ToString(orderInfo.LensTotalPrice);
                        frmPrintReceipt.lblAdjustment.Text = Convert.ToString(orderInfo.OtherAdjustment);
                        frmPrintReceipt.lblSubtotal.Text = Convert.ToString(orderInfo.OrderTotal);
                        frmPrintReceipt.lblHstAmount.Text = Convert.ToString(orderInfo.HstAmount);
                        frmPrintReceipt.lblGrandTotal.Text = Convert.ToString(orderInfo.GrandTotal);
                        frmPrintReceipt.lblDepositAmount.Text = Convert.ToString(orderInfo.PaidAmount);
                        frmPrintReceipt.lblBalanceDue.Text = Convert.ToString(orderInfo.BalanceDue);

                        //frmPrintReceipt.lblRemarks.Text = orderInfo.Remarks;

                        var allPrinters = System.Drawing.Printing.PrinterSettings.InstalledPrinters;
                        int index = 0;
                        foreach (var printer in allPrinters)
                        {
                            frmPrintReceipt.ddlPrinterList.Items.Insert(index, printer.ToString());
                            index++;
                        }

                        frmPrintReceipt.ShowDialog();

                    }




                }

            }
            catch (Exception ex)
            {

            }
        }

        private void btnAddToOrderItemList_Click(object sender, EventArgs e)
        {

            if (!ValidateEntry())
            {
                return;
            }

            OrderDetail orderDetail = new OrderDetail();

            orderDetail.Id = 0;
            orderDetail.TrayNumber = txtTrayNumber.Text;
            orderDetail.ModifiedSphereRight = txtModifiedSphereRight.Text;
            orderDetail.ModifiedCylRight = txtModifiedCylRight.Text;
            orderDetail.ModifiedAxisRight = txtModifiedAxisRight.Text;
            orderDetail.ModifiedAddRight = txtModifiedAddRight.Text;
            orderDetail.ModifiedPrismRight = txtModifiedPrismRight.Text;

            orderDetail.ModifiedSphereLeft = txtModifiedSphereLeft.Text;
            orderDetail.ModifiedCylLeft = txtModifiedCylLeft.Text;
            orderDetail.ModifiedAxisLeft = txtModifiedAxisLeft.Text;
            orderDetail.ModifiedAddLeft = txtModifiedAddLeft.Text;
            orderDetail.ModifiedPrismLeft = txtModifiedPrismLeft.Text;

            orderDetail.MeasurementFpdRight = txtMeasurementFpdRight.Text;
            orderDetail.MeasurementNrPdRight = txtMeasurementNrPdRight.Text;
            orderDetail.MeasurementOcRight = txtMeasurementOcRight.Text;
            orderDetail.MeasurementSegRight = txtMeasurementSegRight.Text;
            orderDetail.MeasurementBlSizeRight = txtMeasurementBlSizeRight.Text;

            orderDetail.MeasurementFpdLeft = txtMeasurementFpdLeft.Text;
            orderDetail.MeasurementNrPdLeft = txtMeasurementNrPdLeft.Text;
            orderDetail.MeasurementOcLeft = txtMeasurementOcLeft.Text;
            orderDetail.MeasurementSegLeft = txtMeasurementSegLeft.Text;
            orderDetail.MeasurementBlSizeLeft = txtMeasurementBlSizeLeft.Text;

            orderDetail.MeasurementA = txtMeasurementA.Text;
            orderDetail.MeasurementB = txtMeasurementB.Text;
            orderDetail.MeasurementED = txtMeasurementEd.Text;
            orderDetail.MeasurementDBL = txtMeasurementDbl.Text;

            orderDetail.FrameCode = txtFrameCode.Text;
            orderDetail.FrameColor = txtFrameColor.Text;
            orderDetail.FrameUnitPrice = Convert.ToDecimal(txtFrameUnitPrice.Text);
            orderDetail.FrameQuantity = Convert.ToInt32(txtFrameQuantity.Text);
            orderDetail.LeftLensDescription = txtLeftLensDescription.Text;
            orderDetail.LeftLensUnitPrice = Convert.ToDecimal(txtLeftLensUnitPrice.Text);
            orderDetail.LeftLensQuantity = Convert.ToInt32(txtLeftLensQuantity.Text);
            orderDetail.RightLensDescription = txtRightLensDescription.Text;
            orderDetail.RightLensUnitPrice = Convert.ToDecimal(txtRightLensUnitPrice.Text);
            orderDetail.RightLensQuantity = Convert.ToInt32(txtRightLensQuantity.Text);

            orderDetail.OtherItemDescription = txtOtherDescription.Text;
            orderDetail.OtherItemUnitPrice = Convert.ToDecimal(txtOtherItemUnitPrice.Text);
            orderDetail.OtherItemQuantity = Convert.ToInt32(txtOtherItemQuantity.Text);


            if (txtSerialNo.Text != string.Empty)
            {
                foreach (DataGridViewRow row in gvOrderItemList.Rows)
                {
                    if (row.Cells["SL#"].Value.ToString() == txtSerialNo.Text)
                    {
                        int selectedIndex = row.Cells["SL#"].RowIndex;
                        DialogResult result = MessageBox.Show("This item already exist in the item list. Do you want to update?", "Warning", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            gvOrderItemList.Rows.RemoveAt(selectedIndex);
                        }
                    }
                }
            }


            FillOrderDetailGridview(orderDetail);
            ClearOrderDetailTextboxes();
            CalculateOrderTotal();
        }

        private void btnRemoveFromOrderItemList_Click(object sender, EventArgs e)
        {
            int selectedIndex = gvOrderItemList.CurrentCell.RowIndex;
            if (selectedIndex > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure to remove this order from the list?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    gvOrderItemList.Rows.RemoveAt(selectedIndex);
                    ClearOrderDetailTextboxes();
                    RefreshSerial();
                    CalculateOrderTotal();
                }
            }
        }

        private void txtPrescriptionSphereRight_Leave(object sender, EventArgs e)
        {
            txtModifiedSphereRight.Text = txtPrescriptionSphereRight.Text;
        }

        private void txtPrescriptionCylRight_Leave(object sender, EventArgs e)
        {
            txtModifiedCylRight.Text = txtPrescriptionCylRight.Text;
        }

        private void txtPrescriptionAxisRight_Leave(object sender, EventArgs e)
        {
            txtModifiedAxisRight.Text = txtPrescriptionAxisRight.Text;
        }

        private void txtPrescriptionAddRight_Leave(object sender, EventArgs e)
        {
            txtModifiedAddRight.Text = txtPrescriptionAddRight.Text;
        }

        private void txtPrescriptionPrismRight_Leave(object sender, EventArgs e)
        {
            txtModifiedPrismRight.Text = txtPrescriptionPrismRight.Text;
        }

        private void txtPrescriptionSphereLeft_Leave(object sender, EventArgs e)
        {
            txtModifiedSphereLeft.Text = txtPrescriptionSphereLeft.Text;
        }

        private void txtPrescriptionCylLeft_Leave(object sender, EventArgs e)
        {
            txtModifiedCylLeft.Text = txtPrescriptionCylLeft.Text;
        }
        private void txtPrescriptionAxisLeft_Leave(object sender, EventArgs e)
        {
            txtModifiedAxisLeft.Text = txtPrescriptionAxisLeft.Text;
        }
        private void txtPrescriptionAddLeft_Leave(object sender, EventArgs e)
        {
            txtModifiedAddLeft.Text = txtPrescriptionAddLeft.Text;
        }
        private void txtPrescriptionPrismLeft_Leave(object sender, EventArgs e)
        {
            txtModifiedPrismLeft.Text = txtPrescriptionPrismLeft.Text;
        }
        private void txtFrameQuantity_Enter(object sender, EventArgs e)
        {
            int qtyOut;
            if (int.TryParse(txtFrameQuantity.Text, out qtyOut))
            {
                if (qtyOut < 1)
                {
                    txtFrameQuantity.Text = "";
                }
            }
        }
        private void txtFrameQuantity_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFrameQuantity.Text))
            {
                txtFrameQuantity.Text = "0";
            }
        }
        private void txtFrameUnitPrice_Enter(object sender, EventArgs e)
        {
            decimal unitPrice;
            if (decimal.TryParse(txtFrameUnitPrice.Text, out unitPrice))
            {
                if (unitPrice > 0)
                {

                }
                else
                {
                    txtFrameUnitPrice.Text = "";
                }
            }
        }
        private void txtFrameUnitPrice_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFrameUnitPrice.Text))
            {
                txtFrameUnitPrice.Text = "0.0";
            }
        }
        private void txtLeftLensQuantity_Enter(object sender, EventArgs e)
        {
            int qtyOut;
            if (int.TryParse(txtLeftLensQuantity.Text, out qtyOut))
            {
                if (qtyOut < 1)
                {
                    txtLeftLensQuantity.Text = "";
                }
            }
        }
        private void txtLeftLensQuantity_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLeftLensQuantity.Text))
            {
                txtLeftLensQuantity.Text = "0";
            }
        }
        private void txtLeftLensUnitPrice_Enter(object sender, EventArgs e)
        {
            decimal unitPrice;
            if (decimal.TryParse(txtLeftLensUnitPrice.Text, out unitPrice))
            {
                if (unitPrice > 0)
                {

                }
                else
                {
                    txtLeftLensUnitPrice.Text = "";
                }
            }
        }
        private void txtLeftLensUnitPrice_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLeftLensUnitPrice.Text))
            {
                txtLeftLensUnitPrice.Text = "0.0";
            }
        }
        private void txtRightLensQuantity_Enter(object sender, EventArgs e)
        {
            int qtyOut;
            if (int.TryParse(txtRightLensQuantity.Text, out qtyOut))
            {
                if (qtyOut < 1)
                {
                    txtRightLensQuantity.Text = "";
                }
            }
        }
        private void txtRightLensQuantity_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRightLensQuantity.Text))
            {
                txtRightLensQuantity.Text = "0";
            }
        }
        private void txtRightLensUnitPrice_Enter(object sender, EventArgs e)
        {
            decimal unitPrice;
            if (decimal.TryParse(txtRightLensUnitPrice.Text, out unitPrice))
            {
                if (unitPrice > 0)
                {

                }
                else
                {
                    txtRightLensUnitPrice.Text = "";
                }
            }
        }
        private void txtRightLensUnitPrice_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRightLensUnitPrice.Text))
            {
                txtRightLensUnitPrice.Text = "0.0";
            }
        }
        private void txtOtherItemQuantity_Enter(object sender, EventArgs e)
        {
            int qtyOut;
            if (int.TryParse(txtOtherItemQuantity.Text, out qtyOut))
            {
                if (qtyOut < 1)
                {
                    txtOtherItemQuantity.Text = "";
                }
            }
        }
        private void txtOtherItemQuantity_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOtherItemQuantity.Text))
            {
                txtOtherItemQuantity.Text = "0";
            }
        }
        private void txtOtherItemUnitPrice_Enter(object sender, EventArgs e)
        {
            decimal unitPrice;
            if (decimal.TryParse(txtOtherItemUnitPrice.Text, out unitPrice))
            {
                if (unitPrice > 0)
                {

                }
                else
                {
                    txtOtherItemUnitPrice.Text = "";
                }
            }
        }
        private void txtOtherItemUnitPrice_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOtherItemUnitPrice.Text))
            {
                txtOtherItemUnitPrice.Text = "0.0";
            }
        }

        private void txtDiscountAmnt_Enter(object sender, EventArgs e)
        {
            decimal amount;
            if (decimal.TryParse(txtDiscountAmnt.Text, out amount))
            {
                if (amount > 0)
                {

                }
                else
                {
                    txtDiscountAmnt.Text = "";
                }
            }
        }
        private void txtDiscountAmnt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDiscountAmnt.Text))
            {
                txtDiscountAmnt.Text = "0.00";
            }
            CalculateOrderTotal();
        }
        private void txtDiscountAmnt_TextChanged(object sender, EventArgs e)
        {
            CalculateOrderTotal();
        }
        
        private void chkApplyHst_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOrderTotal();
        }
        private void txtDepositAmnt_Enter(object sender, EventArgs e)
        {
            decimal amount;
            if (decimal.TryParse(txtDepositAmnt.Text, out amount))
            {
                if (amount > 0)
                {

                }
                else
                {
                    txtDepositAmnt.Text = "";
                }
            }
        }
        private void txtDepositAmnt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDepositAmnt.Text))
            {
                txtDepositAmnt.Text = "0.00";
            }

            CalcualteDepositAndBalanceAmnt();
        }
        private void txtDepositAmnt_TextChanged(object sender, EventArgs e)
        {
            CalcualteDepositAndBalanceAmnt();
        }

        private void gvOrderItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = gvOrderItemList.CurrentRow;
            ShowOrderItemDetail(selectedRow);
        }
        private void gvOrderItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = gvOrderItemList.CurrentRow;
            ShowOrderItemDetail(selectedRow);
        }
        private void btnClearItemTextboxes_Click(object sender, EventArgs e)
        {
            ClearOrderDetailTextboxes();
        }


        #endregion

        #region Private Methods

        private int AddNewOrder(Order order, List<OrderDetail> orderDetail)
        {
            int orderId;
            orderManager = new OrderManager();

            orderId = orderManager.InsertNewOrder(order, orderDetail);

            return orderId;
        }
        private int UpdateOrder(Order order, List<OrderDetail> orderDetail)
        {
            int orderId = 0;
            orderManager = new OrderManager();

            var result = orderManager.UpdateExistingOrder(order, orderDetail);
            if (result > 0)
            {
                orderId = order.Id;
            }

            return orderId;
        }
        private bool ValidateEntry()
        {
            try
            {
                int frmQty = 0;
                decimal frmPrice = 0;

                int llensQty = 0;
                decimal llensPrice = 0;

                int rlensQty = 0;
                decimal rlensPrice = 0;

                int otherQty = 0;
                decimal otherPrice = 0;

                int custId = 0;

                int.TryParse(txtCustomerNo.Text, out custId);

                if (custId <= 0)
                {
                    MessageBox.Show("Please enter a valid customer id.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCustomerNo.Focus();
                    return false;
                }
                if (txtCustomerFirstName.Text.Trim().Length < 1)
                {
                    MessageBox.Show("Please enter a valid customer or update the customer with valid first name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCustomerNo.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtDoctorName.Text.Trim()))
                {
                    MessageBox.Show("Please enter doctor name. ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDoctorName.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtPrescriptionDate.Text.Trim()))
                {
                    MessageBox.Show("Please enter prescription date. ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrescriptionDate.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtGrandTotal.Text.Trim()))
                {
                    MessageBox.Show("Grand total cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGrandTotal.Focus();
                    return false;
                }

                decimal.TryParse(txtFrameUnitPrice.Text, out frmPrice);
                decimal.TryParse(txtLeftLensUnitPrice.Text, out llensPrice);
                decimal.TryParse(txtRightLensUnitPrice.Text, out rlensPrice);
                decimal.TryParse(txtOtherItemUnitPrice.Text, out otherPrice);
                int.TryParse(txtFrameQuantity.Text, out frmQty);
                int.TryParse(txtLeftLensQuantity.Text, out llensQty);
                int.TryParse(txtRightLensQuantity.Text, out rlensQty);
                int.TryParse(txtOtherItemQuantity.Text, out otherQty);

                if (frmPrice <= 0 && llensPrice <= 0 && rlensPrice <= 0 && otherPrice<=0)
                {
                    MessageBox.Show("Add item price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFrameUnitPrice.Focus();
                    return false;
                }

                if (frmQty <= 0)
                {
                    if (frmPrice > 0)
                    {
                        MessageBox.Show("Please enter frame quantity.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtFrameQuantity.Focus();
                        return false;
                    }
                }
                if (frmQty > 0)
                {
                    if (frmPrice <= 0)
                    {
                        MessageBox.Show("Please enter frame price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtFrameUnitPrice.Focus();
                        return false;
                    }
                }

                if (llensQty <= 0)
                {
                    if (llensPrice > 0)
                    {
                        MessageBox.Show("Please enter left lens quantity.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLeftLensQuantity.Focus();
                        return false;
                    }
                }
                if (llensQty > 0)
                {
                    if (llensPrice <= 0)
                    {
                        MessageBox.Show("Please enter left lens price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLeftLensUnitPrice.Focus();
                        return false;
                    }
                }

                if (rlensQty <= 0)
                {
                    if (rlensPrice > 0)
                    {
                        MessageBox.Show("Please enter right lens quantity.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtRightLensQuantity.Focus();
                        return false;
                    }
                }
                if (rlensQty > 0)
                {
                    if (rlensPrice <= 0)
                    {
                        MessageBox.Show("Please enter right lens price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtRightLensUnitPrice.Focus();
                        return false;
                    }
                }

                if (otherQty <= 0)
                {
                    if (otherPrice > 0)
                    {
                        MessageBox.Show("Please enter other item quantity.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtOtherItemQuantity.Focus();
                        return false;
                    }
                }
                if (otherQty > 0)
                {
                    if (otherPrice <= 0)
                    {
                        MessageBox.Show("Please enter other item price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtOtherItemUnitPrice.Focus();
                        return false;
                    }
                }

                if (txtTrayNumber.Text.Trim() == string.Empty) {
                    MessageBox.Show("Please enter tray number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTrayNumber.Focus();
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
        private void CalculateOrderTotal()
        {
            int frameQty;
            decimal frameUnitPrice;
            decimal totalFramePrice = 0;

            int leftLensQty;
            int rightLensQty;
            decimal leftLensUnitPrice;
            decimal rightLensUnitPrice;
            decimal totalLensPrice = 0;

            int otherItemQuantity = 0;
            decimal otherUnitPrice = 0;
            decimal otherTotalPrice = 0;

            decimal orderTotalAmount = 0;
            decimal grandTotalAmount = 0;
            decimal discountAmount = 0;

            foreach (DataGridViewRow row in gvOrderItemList.Rows)
            {
                var frmQty = row.Cells["FRM_QTY"].Value.ToString();
                var frmPrice = row.Cells["FRM_UNT_PRICE"].Value.ToString();
                if (int.TryParse(frmQty, out frameQty) && decimal.TryParse(frmPrice, out frameUnitPrice))
                {
                    totalFramePrice += frameQty * frameUnitPrice;
                }

                var llensQty = row.Cells["LL_QTY"].Value.ToString();
                var llensPrice = row.Cells["LL_UNT_PRICE"].Value.ToString();
                if (int.TryParse(llensQty, out leftLensQty) && decimal.TryParse(llensPrice, out leftLensUnitPrice))
                {
                    totalLensPrice += leftLensQty * leftLensUnitPrice;
                }

                var rlensQty = row.Cells["RL_QTY"].Value.ToString();
                var rlensPrice = row.Cells["RL_UNT_PRICE"].Value.ToString();
                if (int.TryParse(rlensQty, out rightLensQty) && decimal.TryParse(rlensPrice, out rightLensUnitPrice))
                {
                    totalLensPrice += rightLensQty * rightLensUnitPrice;
                }

                var otherQty = row.Cells["OTHR_QTY"].Value.ToString();
                var otherPrice = row.Cells["OTHR_UNT_PRICE"].Value.ToString();
                if (int.TryParse(otherQty, out otherItemQuantity) && decimal.TryParse(otherPrice, out otherUnitPrice))
                {
                    otherTotalPrice += otherItemQuantity * otherUnitPrice;
                }
            }

            txtFrameTotalPrice.Text = totalFramePrice.ToString("0.00");
            txtLensTotalPrice.Text = totalLensPrice.ToString("0.00");
            txtOtherTotal.Text = otherTotalPrice.ToString("0.00");

            orderTotalAmount = totalFramePrice + totalLensPrice + otherTotalPrice;

            if (decimal.TryParse(txtDiscountAmnt.Text, out discountAmount))
            {
                if (discountAmount > 0)
                {
                    orderTotalAmount = orderTotalAmount - discountAmount;
                }
            }

            txtOrderTotalAmnt.Text = orderTotalAmount.ToString("0.00");

            if (chkApplyHst.Checked)
            {
                var hstTotal = 0m;
                hstTotal = orderTotalAmount * hstAmount / 100;
                txtHSTAmnt.Text = hstTotal.ToString("0.00");
            }
            else
            {
                txtHSTAmnt.Text = "0.00";
            }

            grandTotalAmount = Convert.ToDecimal(txtOrderTotalAmnt.Text) + Convert.ToDecimal(txtHSTAmnt.Text);

            txtGrandTotal.Text = grandTotalAmount.ToString("0.00");

            CalcualteDepositAndBalanceAmnt();
        }
        private void CalcualteDepositAndBalanceAmnt()
        {
            decimal depositAmount = 0;
            decimal balanceAmount = 0;

            if (decimal.TryParse(txtDepositAmnt.Text, out depositAmount))
            {
                if (depositAmount > 0)
                {
                    balanceAmount = Convert.ToDecimal(txtGrandTotal.Text) - depositAmount;
                }
            }

            txtBalanceAmnt.Text = balanceAmount.ToString("0.00");
        }
        private void RefreshSerial()
        {
            int sl = 0;
            foreach (DataGridViewRow drow in gvOrderItemList.Rows)
            {
                drow.Cells["SL#"].Value = sl + 1;
                sl++;
            }

        }
        private void ClearFindByGroupBox()
        {
            ddlFindBy.SelectedIndex = 0;
            txtFindByValue.Text = "";
            lblNoOfOrdersFound.Text = "0";
        }
        private void ClearOrderDetailTextboxes()
        {
            txtSerialNo.Text = "";
            txtTrayNumber.Text = "";
            txtModifiedSphereRight.Text = "";
            txtModifiedCylRight.Text = "";
            txtModifiedAxisRight.Text = "";
            txtModifiedAddRight.Text = "";
            txtModifiedPrismRight.Text = "";

            txtModifiedSphereLeft.Text = "";
            txtModifiedCylLeft.Text = "";
            txtModifiedAxisLeft.Text = "";
            txtModifiedAddLeft.Text = "";
            txtModifiedPrismLeft.Text = "";

            txtMeasurementFpdRight.Text = "";
            txtMeasurementNrPdRight.Text = "";
            txtMeasurementOcRight.Text = "";
            txtMeasurementSegRight.Text = "";
            txtMeasurementBlSizeRight.Text = "";

            txtMeasurementFpdLeft.Text = "";
            txtMeasurementNrPdLeft.Text = "";
            txtMeasurementOcLeft.Text = "";
            txtMeasurementSegLeft.Text = "";
            txtMeasurementBlSizeLeft.Text = "";

            txtMeasurementA.Text = "";
            txtMeasurementB.Text = "";
            txtMeasurementEd.Text = "";
            txtMeasurementDbl.Text = "";

            txtFrameCode.Text = "";
            txtFrameColor.Text = "";
            txtFrameUnitPrice.Text = "0.0";
            txtFrameQuantity.Text = "0";
            txtLeftLensDescription.Text = "";
            txtLeftLensUnitPrice.Text = "0.0";
            txtLeftLensQuantity.Text = "0";
            txtRightLensDescription.Text = "";
            txtRightLensUnitPrice.Text = "0.0";
            txtRightLensQuantity.Text = "0";

            txtOtherDescription.Text = "";
            txtOtherItemUnitPrice.Text = "0.0";
            txtOtherItemQuantity.Text = "0";

        }
        private void GetCustomerInformation(int customerId)
        {
            customerManager = new CustomerManager();
            var custinfo = customerManager.GetCustomerById(customerId);
            if (custinfo != null)
            {
                txtCustomerFirstName.Text = custinfo.FirstName;
                txtCustomerLastName.Text = custinfo.LastName;
                txtCustomerEmail.Text = custinfo.Email;
                txtCustomerPhone.Text = custinfo.Telephone;
                txtCustomerAddress.Text = custinfo.Address + ", " + custinfo.City + ", " + custinfo.Postcode;
            }

        }
        private void PrepareOrderDetailGridview()
        {
            gvOrderItemList.DataSource = null;
            gvOrderItemList.Rows.Clear();

            gvOrderItemList.ColumnCount = 40;
            gvOrderItemList.ColumnHeadersVisible = true;

            gvOrderItemList.Columns[0].Name = "SL#";
            gvOrderItemList.Columns[1].Name = "TRAY#";
            gvOrderItemList.Columns[2].Name = "SPH_R";
            gvOrderItemList.Columns[3].Name = "CYL_R";
            gvOrderItemList.Columns[4].Name = "AXIS_R";
            gvOrderItemList.Columns[5].Name = "ADD_R";
            gvOrderItemList.Columns[6].Name = "PRISM_R";
            gvOrderItemList.Columns[7].Name = "SPH_L";
            gvOrderItemList.Columns[8].Name = "CYL_L";
            gvOrderItemList.Columns[9].Name = "AXIS_L";
            gvOrderItemList.Columns[10].Name = "ADD_L";
            gvOrderItemList.Columns[11].Name = "PRISM_L";

            gvOrderItemList.Columns[12].Name = "FPD_R";
            gvOrderItemList.Columns[13].Name = "NR.PD_R";
            gvOrderItemList.Columns[14].Name = "OC_R";
            gvOrderItemList.Columns[15].Name = "SEG_R";
            gvOrderItemList.Columns[16].Name = "BL.SIZE_R";

            gvOrderItemList.Columns[17].Name = "FPD_L";
            gvOrderItemList.Columns[18].Name = "NR.PD_L";
            gvOrderItemList.Columns[19].Name = "OC_L";
            gvOrderItemList.Columns[20].Name = "SEG_L";
            gvOrderItemList.Columns[21].Name = "BL.SIZE_L";
            gvOrderItemList.Columns[22].Name = "MSRMNT_A";
            gvOrderItemList.Columns[23].Name = "MSRMNT_B";
            gvOrderItemList.Columns[24].Name = "MSRMNT_ED";
            gvOrderItemList.Columns[25].Name = "MSRMNT_DBL";

            gvOrderItemList.Columns[26].Name = "FRM_CODE";
            gvOrderItemList.Columns[27].Name = "FRM_COLOR";
            gvOrderItemList.Columns[28].Name = "FRM_UNT_PRICE";
            gvOrderItemList.Columns[29].Name = "FRM_QTY";
            gvOrderItemList.Columns[30].Name = "LL_DESC";
            gvOrderItemList.Columns[31].Name = "LL_UNT_PRICE";
            gvOrderItemList.Columns[32].Name = "LL_QTY";
            gvOrderItemList.Columns[33].Name = "RL_DESC";
            gvOrderItemList.Columns[34].Name = "RL_UNT_PRICE";
            gvOrderItemList.Columns[35].Name = "RL_QTY";

            gvOrderItemList.Columns[36].Name = "OTHR_DESC";
            gvOrderItemList.Columns[37].Name = "OTHR_UNT_PRICE";
            gvOrderItemList.Columns[38].Name = "OTHR_QTY";


            gvOrderItemList.Columns[39].Name = "ITEM_ID";
            gvOrderItemList.Columns[39].Visible = false;
        }
        private void PrepareForNewEntry()
        {
            rdoNewOrder.Checked = true;

            foreach (Control control in Controls)
            {
                foreach (TextBox tb in control.Controls.OfType<TextBox>())
                {
                    tb.Text = string.Empty;
                }
            }

            txtOrderNo.Text = "Auto";
            txtOrderDate.Text = "dd-mmm-yyyy";
            txtFrameQuantity.Text = "0";
            txtFrameUnitPrice.Text = "0.0";
            txtLeftLensQuantity.Text = "0";
            txtLeftLensUnitPrice.Text = "0.0";
            txtRightLensQuantity.Text = "0";
            txtRightLensUnitPrice.Text = "0.0";
            txtFrameTotalPrice.Text = "";
            txtLensTotalPrice.Text = "0.00";
            txtOtherTotal.Text = "0.00";
            txtOrderTotalAmnt.Text = "0.00";
            txtHSTAmnt.Text = "0.00";
            txtGrandTotal.Text = "0.00";
            txtDepositAmnt.Text = "0.00";
            txtBalanceAmnt.Text = "0.00";

            PrepareOrderDetailGridview();
        }
        private void PrepareForUpdateEntry(int orderId)
        {
            rdoFindOrder.Checked = true;
            gbFindBy.Enabled = true;
            Order orderInfo = new Order();
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            orderManager = new OrderManager();

            orderInfo = orderManager.GetOrderById(orderId);

            if (orderInfo != null && orderInfo.Id > 0)
            {
                txtOrderNo.Text = orderInfo.Id.ToString().PadLeft(8, '0');
                txtCustomerNo.Text = orderInfo.CustomerId.ToString();
                txtDoctorName.Text = orderInfo.DoctorName;
                txtDoctorPhone.Text = orderInfo.DoctorPhone;
                txtDoctorClinicAddress.Text = orderInfo.DoctorClinicAddress;
                txtPrescriptionDate.Text = ((DateTime)orderInfo.DoctorPrescriptionDate).ToString("dd-MMM-yyyy");
                txtPrescriptionSphereRight.Text = orderInfo.PrescriptionSphereRight;
                txtPrescriptionCylRight.Text = orderInfo.PrescriptionCylRight;
                txtPrescriptionAxisRight.Text = orderInfo.PrescriptionAxisRight;
                txtPrescriptionAddRight.Text = orderInfo.PrescriptionAddRight;
                txtPrescriptionPrismRight.Text = orderInfo.PrescriptionPrismRight;
                txtPrescriptionSphereLeft.Text = orderInfo.PrescriptionSphereLeft;
                txtPrescriptionCylLeft.Text = orderInfo.PrescriptionCylLeft;
                txtPrescriptionAxisLeft.Text = orderInfo.PrescriptionAxisLeft;
                txtPrescriptionAddLeft.Text = orderInfo.PrescriptionAddLeft;
                txtPrescriptionPrismLeft.Text = orderInfo.PrescriptionPrismLeft;
                txtFrameTotalPrice.Text = ((decimal)orderInfo.FrameTotalPrice).ToString("0.00");
                txtLensTotalPrice.Text = ((decimal)orderInfo.LensTotalPrice).ToString("0.00");
                txtOtherTotal.Text = ((decimal)orderInfo.OtherAdjustment).ToString("0.00");
                txtOrderTotalAmnt.Text = orderInfo.OrderTotal.ToString("0.00");
                txtHSTAmnt.Text = ((decimal)orderInfo.HstAmount).ToString("0.00");
                txtGrandTotal.Text = orderInfo.GrandTotal.ToString("0.00");
                ddlPaidBy.SelectedItem = orderInfo.PaidBy;
                txtDepositAmnt.Text = ((decimal)orderInfo.PaidAmount).ToString("0.00");
                txtBalanceAmnt.Text = ((decimal)orderInfo.BalanceDue).ToString("0.00");
                txtRemarks.Text = orderInfo.Remarks;
                txtOrderDate.Text = orderInfo.CreateDate.ToString("dd-MMM-yyyy");

                orderDetails = orderManager.GetOrderDetailListByOrderId(orderInfo.Id);

                if (orderDetails.Count > 0)
                {
                    PrepareOrderDetailGridview();
                    foreach (var orderDetail in orderDetails)
                    {
                        FillOrderDetailGridview(orderDetail);
                    }
                    gvOrderItemList.Rows[0].Selected = true;
                    ShowOrderItemDetail(gvOrderItemList.Rows[0]);
                }

            }
            else
            {
                MessageBox.Show("No order found with the order id you entered.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void FillOrderDetailGridview(OrderDetail orderDetail)
        {
            if (orderDetail != null)
            {
                gvOrderItemList.Rows.Add(0, orderDetail.TrayNumber, orderDetail.ModifiedSphereRight, orderDetail.ModifiedCylRight, orderDetail.ModifiedAxisRight
                    , orderDetail.ModifiedAddRight, orderDetail.ModifiedPrismRight, orderDetail.ModifiedSphereLeft
                    , orderDetail.ModifiedCylLeft, orderDetail.ModifiedAxisLeft, orderDetail.ModifiedAddLeft
                    , orderDetail.ModifiedPrismLeft, orderDetail.MeasurementFpdRight, orderDetail.MeasurementNrPdRight
                    , orderDetail.MeasurementOcRight, orderDetail.MeasurementSegRight, orderDetail.MeasurementBlSizeRight
                    , orderDetail.MeasurementFpdLeft, orderDetail.MeasurementNrPdLeft, orderDetail.MeasurementOcLeft
                    , orderDetail.MeasurementSegLeft, orderDetail.MeasurementBlSizeLeft, orderDetail.MeasurementA
                    , orderDetail.MeasurementB, orderDetail.MeasurementED, orderDetail.MeasurementDBL, orderDetail.FrameCode
                    , orderDetail.FrameColor, orderDetail.FrameUnitPrice, orderDetail.FrameQuantity, orderDetail.LeftLensDescription
                    , orderDetail.LeftLensUnitPrice, orderDetail.LeftLensQuantity, orderDetail.RightLensDescription
                    , orderDetail.RightLensUnitPrice, orderDetail.RightLensQuantity, orderDetail.OtherItemDescription
                    , orderDetail.OtherItemUnitPrice, orderDetail.OtherItemQuantity, orderDetail.Id
                    );

                RefreshSerial();
            }
        }
        private void ShowOrderItemDetail(DataGridViewRow row)
        {
            txtSerialNo.Text = row.Cells["SL#"].Value.ToString();
            txtTrayNumber.Text = row.Cells["TRAY#"].Value.ToString();
            txtModifiedSphereRight.Text = row.Cells["SPH_R"].Value.ToString();
            txtModifiedCylRight.Text = row.Cells["CYL_R"].Value.ToString();
            txtModifiedAxisRight.Text = row.Cells["AXIS_R"].Value.ToString();
            txtModifiedAddRight.Text = row.Cells["ADD_R"].Value.ToString();
            txtModifiedPrismRight.Text = row.Cells["PRISM_R"].Value.ToString();

            txtModifiedSphereLeft.Text = row.Cells["SPH_L"].Value.ToString();
            txtModifiedCylLeft.Text = row.Cells["CYL_L"].Value.ToString();
            txtModifiedAxisLeft.Text = row.Cells["AXIS_L"].Value.ToString();
            txtModifiedAddLeft.Text = row.Cells["ADD_L"].Value.ToString();
            txtModifiedPrismLeft.Text = row.Cells["PRISM_L"].Value.ToString();

            txtMeasurementFpdRight.Text = row.Cells["FPD_R"].Value.ToString();
            txtMeasurementNrPdRight.Text = row.Cells["NR.PD_R"].Value.ToString();
            txtMeasurementOcRight.Text = row.Cells["OC_R"].Value.ToString();
            txtMeasurementSegRight.Text = row.Cells["SEG_R"].Value.ToString();
            txtMeasurementBlSizeRight.Text = row.Cells["BL.SIZE_R"].Value.ToString();

            txtMeasurementFpdLeft.Text = row.Cells["FPD_L"].Value.ToString();
            txtMeasurementNrPdLeft.Text = row.Cells["NR.PD_L"].Value.ToString();
            txtMeasurementOcLeft.Text = row.Cells["OC_L"].Value.ToString();
            txtMeasurementSegLeft.Text = row.Cells["SEG_L"].Value.ToString();
            txtMeasurementBlSizeLeft.Text = row.Cells["BL.SIZE_L"].Value.ToString();

            txtMeasurementA.Text = row.Cells["MSRMNT_A"].Value.ToString();
            txtMeasurementB.Text = row.Cells["MSRMNT_B"].Value.ToString();
            txtMeasurementEd.Text = row.Cells["MSRMNT_ED"].Value.ToString();
            txtMeasurementDbl.Text = row.Cells["MSRMNT_DBL"].Value.ToString();

            txtFrameCode.Text = row.Cells["FRM_CODE"].Value.ToString();
            txtFrameColor.Text = row.Cells["FRM_COLOR"].Value.ToString();
            txtFrameUnitPrice.Text = row.Cells["FRM_UNT_PRICE"].Value.ToString();
            txtFrameQuantity.Text = row.Cells["FRM_QTY"].Value.ToString();

            txtLeftLensDescription.Text = row.Cells["LL_DESC"].Value.ToString();
            txtLeftLensUnitPrice.Text = row.Cells["LL_UNT_PRICE"].Value.ToString();
            txtLeftLensQuantity.Text = row.Cells["LL_QTY"].Value.ToString();

            txtRightLensDescription.Text = row.Cells["RL_DESC"].Value.ToString();
            txtRightLensUnitPrice.Text = row.Cells["RL_UNT_PRICE"].Value.ToString();
            txtRightLensQuantity.Text = row.Cells["RL_QTY"].Value.ToString();

            txtOtherDescription.Text = row.Cells["OTHR_DESC"].Value.ToString();
            txtOtherItemUnitPrice.Text = row.Cells["OTHR_UNT_PRICE"].Value.ToString();
            txtOtherItemQuantity.Text = row.Cells["OTHR_QTY"].Value.ToString();
        }





        #endregion

       
    }
}
