﻿namespace Optiks
{
    partial class FrmRptOrderDetail
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
            this.reportViewerOrderDetail = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerOrderDetail
            // 
            this.reportViewerOrderDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerOrderDetail.LocalReport.ReportEmbeddedResource = "Optiks.RptOrderDetail.rdlc";
            this.reportViewerOrderDetail.Location = new System.Drawing.Point(0, 0);
            this.reportViewerOrderDetail.Name = "reportViewerOrderDetail";
            this.reportViewerOrderDetail.ServerReport.BearerToken = null;
            this.reportViewerOrderDetail.Size = new System.Drawing.Size(836, 655);
            this.reportViewerOrderDetail.TabIndex = 0;
            // 
            // FrmRptOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 655);
            this.Controls.Add(this.reportViewerOrderDetail);
            this.Name = "FrmRptOrderDetail";
            this.Text = "Order Detail Report";
            this.Load += new System.EventHandler(this.FrmOrderDetailReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerOrderDetail;
    }
}