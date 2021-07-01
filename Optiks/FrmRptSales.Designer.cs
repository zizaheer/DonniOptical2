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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtPickerFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtPickerToDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkShowVoidOrder = new System.Windows.Forms.CheckBox();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewerOrder
            // 
            this.reportViewerOrder.LocalReport.ReportEmbeddedResource = "Optiks.RptSales.rdlc";
            this.reportViewerOrder.LocalReport.ReportPath = "RptSales.rdlc";
            this.reportViewerOrder.Location = new System.Drawing.Point(12, 89);
            this.reportViewerOrder.Name = "reportViewerOrder";
            this.reportViewerOrder.ServerReport.BearerToken = null;
            this.reportViewerOrder.Size = new System.Drawing.Size(812, 566);
            this.reportViewerOrder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "To";
            // 
            // dtPickerFromDate
            // 
            this.dtPickerFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickerFromDate.Location = new System.Drawing.Point(56, 23);
            this.dtPickerFromDate.Name = "dtPickerFromDate";
            this.dtPickerFromDate.Size = new System.Drawing.Size(110, 20);
            this.dtPickerFromDate.TabIndex = 5;
            // 
            // dtPickerToDate
            // 
            this.dtPickerToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickerToDate.Location = new System.Drawing.Point(223, 21);
            this.dtPickerToDate.Name = "dtPickerToDate";
            this.dtPickerToDate.Size = new System.Drawing.Size(110, 20);
            this.dtPickerToDate.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkShowVoidOrder);
            this.groupBox1.Controls.Add(this.btnShowReport);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtPickerToDate);
            this.groupBox1.Controls.Add(this.dtPickerFromDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(812, 56);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date range";
            // 
            // chkShowVoidOrder
            // 
            this.chkShowVoidOrder.AutoSize = true;
            this.chkShowVoidOrder.Checked = true;
            this.chkShowVoidOrder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowVoidOrder.Enabled = false;
            this.chkShowVoidOrder.Location = new System.Drawing.Point(403, 23);
            this.chkShowVoidOrder.Name = "chkShowVoidOrder";
            this.chkShowVoidOrder.Size = new System.Drawing.Size(149, 17);
            this.chkShowVoidOrder.TabIndex = 8;
            this.chkShowVoidOrder.Text = "Show VOID orders as well";
            this.chkShowVoidOrder.UseVisualStyleBackColor = true;
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(627, 20);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(172, 23);
            this.btnShowReport.TabIndex = 7;
            this.btnShowReport.Text = "Show Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // FrmRptSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 655);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reportViewerOrder);
            this.Name = "FrmRptSales";
            this.Text = "Order - Receipt";
            this.Load += new System.EventHandler(this.FrmRptOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtPickerFromDate;
        private System.Windows.Forms.DateTimePicker dtPickerToDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.CheckBox chkShowVoidOrder;
    }
}