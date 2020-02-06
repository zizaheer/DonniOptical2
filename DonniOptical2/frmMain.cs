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
    }
}
