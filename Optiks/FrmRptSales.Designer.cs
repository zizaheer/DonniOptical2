namespace Optiks
{
    partial class FrmRptSales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewerOrder = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerOrder
            // 
            this.reportViewerOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerOrder.LocalReport.ReportEmbeddedResource = "Optiks.RptSales.rdlc";
            this.reportViewerOrder.Location = new System.Drawing.Point(0, 0);
            this.reportViewerOrder.Name = "reportViewerOrder";
            this.reportViewerOrder.ServerReport.BearerToken = null;
            this.reportViewerOrder.Size = new System.Drawing.Size(836, 655);
            this.reportViewerOrder.TabIndex = 0;
            // 
            // FrmRptSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 655);
            this.Controls.Add(this.reportViewerOrder);
            this.Name = "FrmRptSales";
            this.Text = "Order - Receipt";
            this.Load += new System.EventHandler(this.FrmRptOrder_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerOrder;
    }
}