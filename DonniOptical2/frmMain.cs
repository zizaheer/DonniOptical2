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
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }



        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmMain_Load(object sender, EventArgs e)
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
                if (frm.Name == "frmOrder")
                {
                    frm.BringToFront();
                    isFormOpened = true;
                }
            }

            if (isFormOpened == false)
            {
                frmOrder orderForm = new frmOrder();
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
                if (frm.Name == "frmOrder")
                {
                    frm.BringToFront();
                    isFormOpened = true;
                }
            }

            if (isFormOpened == false)
            {
                frmOrder orderForm = new frmOrder();
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
                if (frm.Name == "frmCustomer")
                {
                    frm.BringToFront();
                    isFormOpened = true;
                }
            }

            if (isFormOpened == false)
            {
                frmCustomer customerForm = new frmCustomer();
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
                if (frm.Name == "frmCustomer")
                {
                    frm.BringToFront();
                    isFormOpened = true;
                }
            }

            if (isFormOpened == false)
            {
                frmCustomer customerForm = new frmCustomer();
                customerForm.MdiParent = this;
                customerForm.Location = new Point(5, 5);
                customerForm.Show();
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            frmRptOrderDetail frmRptOrderDetail = new frmRptOrderDetail();
            frmRptOrderDetail.MdiParent = this;
            frmRptOrderDetail.Location = new Point(5, 5);
            frmRptOrderDetail.Show();
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
