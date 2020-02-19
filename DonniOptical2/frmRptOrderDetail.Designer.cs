namespace DonniOptical2
{
    partial class frmRptOrderDetail
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
            this.rptViewerOrderDetail = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptViewerOrderDetail
            // 
            this.rptViewerOrderDetail.LocalReport.ReportEmbeddedResource = "DonniOptical2.orderDetailReport.rdlc";
            this.rptViewerOrderDetail.Location = new System.Drawing.Point(12, 12);
            this.rptViewerOrderDetail.Name = "rptViewerOrderDetail";
            this.rptViewerOrderDetail.ServerReport.BearerToken = null;
            this.rptViewerOrderDetail.Size = new System.Drawing.Size(871, 620);
            this.rptViewerOrderDetail.TabIndex = 0;
            // 
            // frmRptOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 644);
            this.Controls.Add(this.rptViewerOrderDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRptOrderDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "rptOrderDetail";
            this.Load += new System.EventHandler(this.frmRptOrderDetail_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptViewerOrderDetail;
    }
}