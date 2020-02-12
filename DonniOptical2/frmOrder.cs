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
            int custId = 0;

            if (ddlFindBy.SelectedIndex == 0)
            {
                int.TryParse(txtFindByValue.Text, out orderId);
                if (orderId > 0)
                {
                    PrepareForUpdateEntry(orderId);
                }
                else
                {
                    MessageBox.Show("Please enter a valid order id.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                orderInfo.OtherAdjustment = Convert.ToDecimal(txtOtherAdjustmentAmnt.Text);
                orderInfo.OrderTotal = Convert.ToDecimal(txtOrderTotalAmnt.Text);
                orderInfo.HstAmount = Convert.ToDecimal(txtHSTAmnt.Text);
                orderInfo.GrandTotal = Convert.ToDecimal(txtGrandTotal.Text);
                orderInfo.PaidBy = ddlPaidBy.SelectedValue.ToString();
                orderInfo.PaidAmount = Convert.ToDecimal(txtDepositAmnt.Text);
                orderInfo.BalanceDue = Convert.ToDecimal(txtBalanceAmnt.Text);
                orderInfo.Remarks = txtRemarks.Text;
                orderInfo.CreateDate = DateTime.Now;

                List<OrderDetail> orderDetailList = new List<OrderDetail>();

                foreach (DataGridViewRow row in gvOrderItemList.Rows)
                {
                    OrderDetail orderDetail = new OrderDetail();

                    orderDetail.OrderId = orderInfo.Id;
                    orderDetail.ModifiedSphereRight = row.Cells[1].Value.ToString();
                    orderDetail.ModifiedCylRight = row.Cells[2].Value.ToString();
                    orderDetail.ModifiedAxisRight = row.Cells[3].Value.ToString();
                    orderDetail.ModifiedAddRight = row.Cells[4].Value.ToString();
                    orderDetail.ModifiedPrismRight = row.Cells[5].Value.ToString();

                    orderDetail.ModifiedSphereLeft = row.Cells[6].Value.ToString();
                    orderDetail.ModifiedCylLeft = row.Cells[7].Value.ToString();
                    orderDetail.ModifiedAxisLeft = row.Cells[8].Value.ToString();
                    orderDetail.ModifiedAddLeft = row.Cells[9].Value.ToString();
                    orderDetail.ModifiedPrismLeft = row.Cells[10].Value.ToString();

                    orderDetail.MeasurementFpdRight = row.Cells[11].Value.ToString();
                    orderDetail.MeasurementNrPdRight = row.Cells[12].Value.ToString();
                    orderDetail.MeasurementOcRight = row.Cells[13].Value.ToString();
                    orderDetail.MeasurementSegRight = row.Cells[14].Value.ToString();
                    orderDetail.MeasurementBlSizeRight = row.Cells[15].Value.ToString();

                    orderDetail.MeasurementFpdLeft = row.Cells[16].Value.ToString();
                    orderDetail.MeasurementNrPdLeft = row.Cells[17].Value.ToString();
                    orderDetail.MeasurementOcLeft = row.Cells[18].Value.ToString();
                    orderDetail.MeasurementSegLeft = row.Cells[19].Value.ToString();
                    orderDetail.MeasurementBlSizeLeft = row.Cells[20].Value.ToString();

                    orderDetail.MeasurementA = row.Cells[21].Value.ToString();
                    orderDetail.MeasurementB = row.Cells[22].Value.ToString();
                    orderDetail.MeasurementED = row.Cells[23].Value.ToString();
                    orderDetail.MeasurementDBL = row.Cells[24].Value.ToString();

                    orderDetail.FrameCode = row.Cells[25].Value.ToString();
                    orderDetail.FrameColor = row.Cells[26].Value.ToString();
                    orderDetail.FrameUnitPrice = Convert.ToDecimal(row.Cells[27].Value);
                    orderDetail.FrameQuantity = Convert.ToInt32(row.Cells[28].Value);
                    orderDetail.LeftLensDescription = row.Cells[29].Value.ToString();
                    orderDetail.LeftLensUnitPrice = Convert.ToDecimal(row.Cells[30].Value);
                    orderDetail.LeftLensQuantity = Convert.ToInt32(row.Cells[31].Value);
                    orderDetail.RightLensDescription = row.Cells[32].Value.ToString();
                    orderDetail.RightLensUnitPrice = Convert.ToDecimal(row.Cells[33].Value);
                    orderDetail.RightLensQuantity = Convert.ToInt32(row.Cells[34].Value);

                    orderDetailList.Add(orderDetail);
                }

                orderId = AddNewOrder(orderInfo, orderDetailList);

                if (orderId > 0)
                {
                    PrepareForUpdateEntry(orderId);
                    MessageBox.Show("The order saved successfully. ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            ClearOrderDetail();
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

        private void txtFrameQuantity_TextChanged(object sender, EventArgs e)
        {
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

        private void txtFrameUnitPrice_TextChanged(object sender, EventArgs e)
        {
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
        private void txtLeftLensQuantity_TextChanged(object sender, EventArgs e)
        {
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
        private void txtLeftLensUnitPrice_TextChanged(object sender, EventArgs e)
        {
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
        private void txtRightLensQuantity_TextChanged(object sender, EventArgs e)
        {
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
        private void txtRightLensUnitPrice_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtOtherAdjustmentAmnt_Enter(object sender, EventArgs e)
        {
            decimal amount;
            if (decimal.TryParse(txtOtherAdjustmentAmnt.Text, out amount))
            {
                if (amount > 0)
                {

                }
                else
                {
                    txtOtherAdjustmentAmnt.Text = "";
                }
            }
        }

        private void txtOtherAdjustmentAmnt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOtherAdjustmentAmnt.Text))
            {
                txtOtherAdjustmentAmnt.Text = "0.00";
            }
            CalculateOrderTotal();
        }

        private void txtOtherAdjustmentAmnt_TextChanged(object sender, EventArgs e)
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
                int.TryParse(txtFrameQuantity.Text, out frmQty);
                int.TryParse(txtLeftLensQuantity.Text, out llensQty);
                int.TryParse(txtRightLensQuantity.Text, out rlensQty);

                if (frmPrice <= 0 && llensPrice <= 0 && rlensPrice <= 0)
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
            decimal leftLensUnitPrice;

            int rightLensQty;
            decimal rightLensUnitPrice;
            decimal totalLensPrice = 0;

            decimal orderTotalAmount = 0;
            decimal grandTotalAmount = 0;
            decimal otherAdjustment = 0;

            foreach (DataGridViewRow row in gvOrderItemList.Rows)
            {
                var frmQty = row.Cells[28].Value.ToString();
                var frmPrice = row.Cells[27].Value.ToString();
                if (int.TryParse(frmQty, out frameQty) && decimal.TryParse(frmPrice, out frameUnitPrice))
                {
                    totalFramePrice += frameQty * frameUnitPrice;
                }

                var llensQty = row.Cells[31].Value.ToString();
                var llensPrice = row.Cells[30].Value.ToString();
                if (int.TryParse(llensQty, out leftLensQty) && decimal.TryParse(llensPrice, out leftLensUnitPrice))
                {
                    totalLensPrice += leftLensQty * leftLensUnitPrice;
                }

                var rlensQty = row.Cells[34].Value.ToString();
                var rlensPrice = row.Cells[33].Value.ToString();
                if (int.TryParse(rlensQty, out rightLensQty) && decimal.TryParse(rlensPrice, out rightLensUnitPrice))
                {
                    totalLensPrice += rightLensQty * rightLensUnitPrice;
                }
            }

            txtFrameTotalPrice.Text = totalFramePrice.ToString("0.00");
            txtLensTotalPrice.Text = totalLensPrice.ToString("0.00");

            orderTotalAmount = totalFramePrice + totalLensPrice;

            if (decimal.TryParse(txtOtherAdjustmentAmnt.Text, out otherAdjustment))
            {
                if (otherAdjustment > 0)
                {
                    orderTotalAmount = orderTotalAmount + ((-1) * otherAdjustment);
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
                drow.Cells[0].Value = sl + 1;
                sl++;
            }

        }
        private void ClearFindByGroupBox()
        {
            ddlFindBy.SelectedIndex = 0;
            txtFindByValue.Text = "";
            lblNoOfOrdersFound.Text = "0";
        }

        private void ClearOrderDetail()
        {

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

            gvOrderItemList.ColumnCount = 35;
            gvOrderItemList.ColumnHeadersVisible = true;

            gvOrderItemList.Columns[0].Name = "SL#";
            gvOrderItemList.Columns[1].Name = "SPH_R";
            gvOrderItemList.Columns[2].Name = "CYL_R";
            gvOrderItemList.Columns[3].Name = "AXIS_R";
            gvOrderItemList.Columns[4].Name = "ADD_R";
            gvOrderItemList.Columns[5].Name = "PRISM_R";
            gvOrderItemList.Columns[6].Name = "SPH_L";
            gvOrderItemList.Columns[7].Name = "CYL_L";
            gvOrderItemList.Columns[8].Name = "AXIS_L";
            gvOrderItemList.Columns[9].Name = "ADD_L";
            gvOrderItemList.Columns[10].Name = "PRISM_L";

            gvOrderItemList.Columns[11].Name = "FPD_R";
            gvOrderItemList.Columns[12].Name = "NR.PD_R";
            gvOrderItemList.Columns[13].Name = "OC_R";
            gvOrderItemList.Columns[14].Name = "SEG_R";
            gvOrderItemList.Columns[15].Name = "BL.SIZE_R";

            gvOrderItemList.Columns[16].Name = "FPD_L";
            gvOrderItemList.Columns[17].Name = "NR.PD_L";
            gvOrderItemList.Columns[18].Name = "OC_L";
            gvOrderItemList.Columns[19].Name = "SEG_L";
            gvOrderItemList.Columns[20].Name = "BL.SIZE_L";
            gvOrderItemList.Columns[21].Name = "MSRMNT_A";
            gvOrderItemList.Columns[22].Name = "MSRMNT_B";
            gvOrderItemList.Columns[23].Name = "MSRMNT_ED";
            gvOrderItemList.Columns[24].Name = "MSRMNT_DBL";

            gvOrderItemList.Columns[25].Name = "Frame Code";
            gvOrderItemList.Columns[26].Name = "Color";
            gvOrderItemList.Columns[27].Name = "Frm Unit price";
            gvOrderItemList.Columns[28].Name = "Frm Qty";
            gvOrderItemList.Columns[29].Name = "Left lens";
            gvOrderItemList.Columns[30].Name = "LL Unit price";
            gvOrderItemList.Columns[31].Name = "LL Qty";
            gvOrderItemList.Columns[32].Name = "Right lens";
            gvOrderItemList.Columns[33].Name = "RL unit price";
            gvOrderItemList.Columns[34].Name = "RL Qty";
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
            txtOtherAdjustmentAmnt.Text = "0.00";
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
                txtOtherAdjustmentAmnt.Text = ((decimal)orderInfo.OtherAdjustment).ToString("0.00");
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
                gvOrderItemList.Rows.Add(0, orderDetail.ModifiedSphereRight, orderDetail.ModifiedCylRight, orderDetail.ModifiedAxisRight
                    , orderDetail.ModifiedAddRight, orderDetail.ModifiedPrismRight, orderDetail.ModifiedSphereLeft
                    , orderDetail.ModifiedCylLeft, orderDetail.ModifiedAxisLeft, orderDetail.ModifiedAddLeft
                    , orderDetail.ModifiedPrismLeft, orderDetail.MeasurementFpdRight, orderDetail.MeasurementNrPdRight
                    , orderDetail.MeasurementOcRight, orderDetail.MeasurementSegRight, orderDetail.MeasurementBlSizeRight
                    , orderDetail.MeasurementFpdLeft, orderDetail.MeasurementNrPdLeft, orderDetail.MeasurementOcLeft
                    , orderDetail.MeasurementSegLeft, orderDetail.MeasurementBlSizeLeft, orderDetail.MeasurementA
                    , orderDetail.MeasurementB, orderDetail.MeasurementED, orderDetail.MeasurementDBL, orderDetail.FrameCode
                    , orderDetail.FrameColor, orderDetail.FrameUnitPrice, orderDetail.FrameQuantity, orderDetail.LeftLensDescription
                    , orderDetail.LeftLensUnitPrice, orderDetail.LeftLensQuantity, orderDetail.RightLensDescription
                    , orderDetail.RightLensUnitPrice, orderDetail.RightLensQuantity
                    );

                RefreshSerial();
            }
        }

        #endregion

    }
}
