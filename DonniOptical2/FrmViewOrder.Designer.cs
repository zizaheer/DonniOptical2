namespace DonniOptical2
{
    partial class FrmViewOrder
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
            this.btnViewOrder = new System.Windows.Forms.Button();
            this.dtPickerFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtPickerToDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ddlFilterBy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.gvOrderList = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrderList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnViewOrder
            // 
            this.btnViewOrder.Location = new System.Drawing.Point(328, 27);
            this.btnViewOrder.Name = "btnViewOrder";
            this.btnViewOrder.Size = new System.Drawing.Size(75, 23);
            this.btnViewOrder.TabIndex = 0;
            this.btnViewOrder.Text = "View order";
            this.btnViewOrder.UseVisualStyleBackColor = true;
            this.btnViewOrder.Click += new System.EventHandler(this.btnViewOrder_Click);
            // 
            // dtPickerFromDate
            // 
            this.dtPickerFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtPickerFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerFromDate.Location = new System.Drawing.Point(44, 29);
            this.dtPickerFromDate.Name = "dtPickerFromDate";
            this.dtPickerFromDate.Size = new System.Drawing.Size(113, 20);
            this.dtPickerFromDate.TabIndex = 1;
            // 
            // dtPickerToDate
            // 
            this.dtPickerToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtPickerToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerToDate.Location = new System.Drawing.Point(193, 29);
            this.dtPickerToDate.Name = "dtPickerToDate";
            this.dtPickerToDate.Size = new System.Drawing.Size(113, 20);
            this.dtPickerToDate.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtPickerToDate);
            this.groupBox1.Controls.Add(this.btnViewOrder);
            this.groupBox1.Controls.Add(this.dtPickerFromDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 68);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "From";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFilterValue);
            this.groupBox2.Controls.Add(this.ddlFilterBy);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnFilter);
            this.groupBox2.Location = new System.Drawing.Point(454, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 68);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // ddlFilterBy
            // 
            this.ddlFilterBy.FormattingEnabled = true;
            this.ddlFilterBy.Items.AddRange(new object[] {
            "Order id",
            "Customer id",
            "Customer phone",
            "Customer first name",
            "Customer last name",
            "Customer email"});
            this.ddlFilterBy.Location = new System.Drawing.Point(40, 29);
            this.ddlFilterBy.Name = "ddlFilterBy";
            this.ddlFilterBy.Size = new System.Drawing.Size(132, 21);
            this.ddlFilterBy.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "By";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(359, 27);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 0;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // gvOrderList
            // 
            this.gvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvOrderList.Location = new System.Drawing.Point(14, 22);
            this.gvOrderList.Name = "gvOrderList";
            this.gvOrderList.Size = new System.Drawing.Size(862, 504);
            this.gvOrderList.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gvOrderList);
            this.groupBox3.Location = new System.Drawing.Point(12, 125);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(886, 538);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Orders";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(824, 672);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(178, 29);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(175, 20);
            this.txtFilterValue.TabIndex = 6;
            // 
            // FrmViewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 705);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmViewOrder";
            this.Text = "View order";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrderList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnViewOrder;
        private System.Windows.Forms.DateTimePicker dtPickerFromDate;
        private System.Windows.Forms.DateTimePicker dtPickerToDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox ddlFilterBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView gvOrderList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtFilterValue;
    }
}