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
    public partial class FrmMain : Form
    {

        public FrmMain()
        {
            InitializeComponent();
        }



        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            SetBackgroundColorForChildForm();
        }

        private void SetBackgroundColorForChildForm()
        {
            foreach (Control control in this.Controls)
            {
                if ((control) is MdiClient)
                {
                    control.BackColor = System.Drawing.SystemColors.ActiveCaption;
                }
            }
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isFormOpened = false;

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "FrmOrder")
                {
                    frm.BringToFront();
                    isFormOpened = true;
                }
            }

            if (isFormOpened == false)
            {
                FrmOrder orderForm = new FrmOrder();
                orderForm.MdiParent = this;
                orderForm.Location = new Point(5, 5);
                orderForm.Show();
            }
        }
        private void orderToolStripButton_Click(object sender, EventArgs e)
        {
            bool isFormOpened = false;

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "FrmOrder")
                {
                    frm.BringToFront();
                    isFormOpened = true;
                }
            }

            if (isFormOpened == false)
            {
                FrmOrder orderForm = new FrmOrder();
                orderForm.MdiParent = this;
                orderForm.Location = new Point(5, 5);
                orderForm.Show();
            }
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isFormOpened = false;

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "FrmCustomer")
                {
                    frm.BringToFront();
                    isFormOpened = true;
                }
            }

            if (isFormOpened == false)
            {
                FrmCustomer customerForm = new FrmCustomer();
                customerForm.MdiParent = this;
                customerForm.Location = new Point(5, 5);
                customerForm.Show();
            }
        }
        private void customerToolStripButton_Click(object sender, EventArgs e)
        {
            bool isFormOpened = false;

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "FrmCustomer")
                {
                    frm.BringToFront();
                    isFormOpened = true;
                }
            }

            if (isFormOpened == false)
            {
                FrmCustomer customerForm = new FrmCustomer();
                customerForm.MdiParent = this;
                customerForm.Location = new Point(5, 5);
                customerForm.Show();
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            //FrmRptOrderDetail rptOrderDetail = new FrmRptOrderDetail();
            FrmRptSales rptOrderDetail = new FrmRptSales();
            rptOrderDetail.MdiParent = this;
            rptOrderDetail.Location = new Point(5, 5);
            rptOrderDetail.Show();
        }

        private void toolStripButtonFind_Click(object sender, EventArgs e)
        {
            FrmViewOrder viewOrder = new FrmViewOrder();
            viewOrder.MdiParent = this;
            viewOrder.Location = new Point(5, 5);
            viewOrder.Show();
        }
    }
}
