namespace DonniOptical2
{
    partial class FrmCustomer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNoOfCustomersFound = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.lnkNextCustomer = new System.Windows.Forms.LinkLabel();
            this.lnkPreviousCustomer = new System.Windows.Forms.LinkLabel();
            this.lblCustomerFoundText = new System.Windows.Forms.Label();
            this.btnFindCustomer = new System.Windows.Forms.Button();
            this.txtCustomerEmail = new System.Windows.Forms.TextBox();
            this.ddlFindBy = new System.Windows.Forms.ComboBox();
            this.label85 = new System.Windows.Forms.Label();
            this.rdoFindCustomer = new System.Windows.Forms.RadioButton();
            this.rdoNewCustomer = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCustomerAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFindCustomerById = new System.Windows.Forms.Button();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerLastName = new System.Windows.Forms.TextBox();
            this.txtFindByValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomerNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerFirstName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCustomerPostcode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCustomerCity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSaveCustomer = new System.Windows.Forms.Button();
            this.gbFindCustomer = new System.Windows.Forms.GroupBox();
            this.gbFindBy = new System.Windows.Forms.GroupBox();
            this.gvCustomerList = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbFindCustomer.SuspendLayout();
            this.gbFindBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomerList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNoOfCustomersFound
            // 
            this.lblNoOfCustomersFound.AutoSize = true;
            this.lblNoOfCustomersFound.Location = new System.Drawing.Point(461, 22);
            this.lblNoOfCustomersFound.Name = "lblNoOfCustomersFound";
            this.lblNoOfCustomersFound.Size = new System.Drawing.Size(13, 13);
            this.lblNoOfCustomersFound.TabIndex = 7;
            this.lblNoOfCustomersFound.Text = "0";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(419, 21);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(9, 13);
            this.label82.TabIndex = 5;
            this.label82.Text = "|";
            // 
            // lnkNextCustomer
            // 
            this.lnkNextCustomer.AutoSize = true;
            this.lnkNextCustomer.Location = new System.Drawing.Point(427, 21);
            this.lnkNextCustomer.Name = "lnkNextCustomer";
            this.lnkNextCustomer.Size = new System.Drawing.Size(29, 13);
            this.lnkNextCustomer.TabIndex = 6;
            this.lnkNextCustomer.TabStop = true;
            this.lnkNextCustomer.Text = "Next";
            this.lnkNextCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNextCustomer_LinkClicked);
            // 
            // lnkPreviousCustomer
            // 
            this.lnkPreviousCustomer.AutoSize = true;
            this.lnkPreviousCustomer.Location = new System.Drawing.Point(371, 21);
            this.lnkPreviousCustomer.Name = "lnkPreviousCustomer";
            this.lnkPreviousCustomer.Size = new System.Drawing.Size(48, 13);
            this.lnkPreviousCustomer.TabIndex = 4;
            this.lnkPreviousCustomer.TabStop = true;
            this.lnkPreviousCustomer.Text = "Previous";
            this.lnkPreviousCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPreviousCustomer_LinkClicked);
            // 
            // lblCustomerFoundText
            // 
            this.lblCustomerFoundText.AutoSize = true;
            this.lblCustomerFoundText.Location = new System.Drawing.Point(477, 21);
            this.lblCustomerFoundText.Name = "lblCustomerFoundText";
            this.lblCustomerFoundText.Size = new System.Drawing.Size(80, 13);
            this.lblCustomerFoundText.TabIndex = 0;
            this.lblCustomerFoundText.Text = "customer found";
            // 
            // btnFindCustomer
            // 
            this.btnFindCustomer.Location = new System.Drawing.Point(313, 17);
            this.btnFindCustomer.Name = "btnFindCustomer";
            this.btnFindCustomer.Size = new System.Drawing.Size(52, 22);
            this.btnFindCustomer.TabIndex = 3;
            this.btnFindCustomer.Text = "Find";
            this.btnFindCustomer.UseVisualStyleBackColor = true;
            this.btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // txtCustomerEmail
            // 
            this.txtCustomerEmail.Location = new System.Drawing.Point(449, 73);
            this.txtCustomerEmail.MaxLength = 150;
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.Size = new System.Drawing.Size(232, 20);
            this.txtCustomerEmail.TabIndex = 10;
            // 
            // ddlFindBy
            // 
            this.ddlFindBy.FormattingEnabled = true;
            this.ddlFindBy.Items.AddRange(new object[] {
            "Customer first name",
            "Customer phone",
            "Customer last name",
            "Customer full name"});
            this.ddlFindBy.Location = new System.Drawing.Point(27, 18);
            this.ddlFindBy.Name = "ddlFindBy";
            this.ddlFindBy.Size = new System.Drawing.Size(108, 21);
            this.ddlFindBy.TabIndex = 1;
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(6, 21);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(19, 13);
            this.label85.TabIndex = 0;
            this.label85.Text = "By";
            // 
            // rdoFindCustomer
            // 
            this.rdoFindCustomer.AutoSize = true;
            this.rdoFindCustomer.Location = new System.Drawing.Point(65, 20);
            this.rdoFindCustomer.Name = "rdoFindCustomer";
            this.rdoFindCustomer.Size = new System.Drawing.Size(45, 17);
            this.rdoFindCustomer.TabIndex = 1;
            this.rdoFindCustomer.Text = "Find";
            this.rdoFindCustomer.UseVisualStyleBackColor = true;
            this.rdoFindCustomer.CheckedChanged += new System.EventHandler(this.rdoFindCustomer_CheckedChanged);
            // 
            // rdoNewCustomer
            // 
            this.rdoNewCustomer.AutoSize = true;
            this.rdoNewCustomer.Checked = true;
            this.rdoNewCustomer.Location = new System.Drawing.Point(9, 20);
            this.rdoNewCustomer.Name = "rdoNewCustomer";
            this.rdoNewCustomer.Size = new System.Drawing.Size(47, 17);
            this.rdoNewCustomer.TabIndex = 0;
            this.rdoNewCustomer.TabStop = true;
            this.rdoNewCustomer.Text = "New";
            this.rdoNewCustomer.UseVisualStyleBackColor = true;
            this.rdoNewCustomer.CheckedChanged += new System.EventHandler(this.rdoNewCustomer_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(389, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Email";
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.Location = new System.Drawing.Point(80, 99);
            this.txtCustomerAddress.MaxLength = 200;
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.Size = new System.Drawing.Size(601, 20);
            this.txtCustomerAddress.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Address";
            // 
            // btnFindCustomerById
            // 
            this.btnFindCustomerById.BackgroundImage = global::DonniOptical2.Properties.Resources.magnifier;
            this.btnFindCustomerById.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFindCustomerById.Enabled = false;
            this.btnFindCustomerById.Location = new System.Drawing.Point(216, 21);
            this.btnFindCustomerById.Name = "btnFindCustomerById";
            this.btnFindCustomerById.Size = new System.Drawing.Size(24, 23);
            this.btnFindCustomerById.TabIndex = 2;
            this.btnFindCustomerById.UseVisualStyleBackColor = true;
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Location = new System.Drawing.Point(80, 73);
            this.txtCustomerPhone.MaxLength = 20;
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(241, 20);
            this.txtCustomerPhone.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Phone no.";
            // 
            // txtCustomerLastName
            // 
            this.txtCustomerLastName.Location = new System.Drawing.Point(449, 47);
            this.txtCustomerLastName.MaxLength = 50;
            this.txtCustomerLastName.Name = "txtCustomerLastName";
            this.txtCustomerLastName.Size = new System.Drawing.Size(232, 20);
            this.txtCustomerLastName.TabIndex = 6;
            // 
            // txtFindByValue
            // 
            this.txtFindByValue.Location = new System.Drawing.Point(139, 18);
            this.txtFindByValue.MaxLength = 50;
            this.txtFindByValue.Name = "txtFindByValue";
            this.txtFindByValue.Size = new System.Drawing.Size(168, 20);
            this.txtFindByValue.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer no.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(389, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Last name";
            // 
            // txtCustomerNo
            // 
            this.txtCustomerNo.Enabled = false;
            this.txtCustomerNo.Location = new System.Drawing.Point(80, 22);
            this.txtCustomerNo.MaxLength = 10;
            this.txtCustomerNo.Name = "txtCustomerNo";
            this.txtCustomerNo.Size = new System.Drawing.Size(133, 20);
            this.txtCustomerNo.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "First name";
            // 
            // txtCustomerFirstName
            // 
            this.txtCustomerFirstName.Location = new System.Drawing.Point(80, 47);
            this.txtCustomerFirstName.MaxLength = 50;
            this.txtCustomerFirstName.Name = "txtCustomerFirstName";
            this.txtCustomerFirstName.Size = new System.Drawing.Size(241, 20);
            this.txtCustomerFirstName.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(638, 576);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 275;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCustomerPostcode);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtCustomerCity);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCustomerEmail);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCustomerAddress);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnFindCustomerById);
            this.groupBox1.Controls.Add(this.txtCustomerPhone);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCustomerLastName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCustomerNo);
            this.groupBox1.Controls.Add(this.txtCustomerFirstName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(11, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(695, 165);
            this.groupBox1.TabIndex = 263;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer info";
            // 
            // txtCustomerPostcode
            // 
            this.txtCustomerPostcode.Location = new System.Drawing.Point(447, 125);
            this.txtCustomerPostcode.MaxLength = 20;
            this.txtCustomerPostcode.Name = "txtCustomerPostcode";
            this.txtCustomerPostcode.Size = new System.Drawing.Size(233, 20);
            this.txtCustomerPostcode.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(389, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Postcode";
            // 
            // txtCustomerCity
            // 
            this.txtCustomerCity.Location = new System.Drawing.Point(80, 125);
            this.txtCustomerCity.MaxLength = 50;
            this.txtCustomerCity.Name = "txtCustomerCity";
            this.txtCustomerCity.Size = new System.Drawing.Size(241, 20);
            this.txtCustomerCity.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "City";
            // 
            // btnSaveCustomer
            // 
            this.btnSaveCustomer.Location = new System.Drawing.Point(460, 576);
            this.btnSaveCustomer.Name = "btnSaveCustomer";
            this.btnSaveCustomer.Size = new System.Drawing.Size(169, 25);
            this.btnSaveCustomer.TabIndex = 274;
            this.btnSaveCustomer.Text = "Save";
            this.btnSaveCustomer.UseVisualStyleBackColor = true;
            this.btnSaveCustomer.Click += new System.EventHandler(this.btnSaveCustomer_Click);
            // 
            // gbFindCustomer
            // 
            this.gbFindCustomer.Controls.Add(this.rdoFindCustomer);
            this.gbFindCustomer.Controls.Add(this.rdoNewCustomer);
            this.gbFindCustomer.Location = new System.Drawing.Point(12, 12);
            this.gbFindCustomer.Name = "gbFindCustomer";
            this.gbFindCustomer.Size = new System.Drawing.Size(124, 50);
            this.gbFindCustomer.TabIndex = 261;
            this.gbFindCustomer.TabStop = false;
            this.gbFindCustomer.Text = "Customer";
            // 
            // gbFindBy
            // 
            this.gbFindBy.Controls.Add(this.lblNoOfCustomersFound);
            this.gbFindBy.Controls.Add(this.label82);
            this.gbFindBy.Controls.Add(this.lnkNextCustomer);
            this.gbFindBy.Controls.Add(this.lnkPreviousCustomer);
            this.gbFindBy.Controls.Add(this.lblCustomerFoundText);
            this.gbFindBy.Controls.Add(this.btnFindCustomer);
            this.gbFindBy.Controls.Add(this.txtFindByValue);
            this.gbFindBy.Controls.Add(this.ddlFindBy);
            this.gbFindBy.Controls.Add(this.label85);
            this.gbFindBy.Enabled = false;
            this.gbFindBy.Location = new System.Drawing.Point(146, 12);
            this.gbFindBy.Name = "gbFindBy";
            this.gbFindBy.Size = new System.Drawing.Size(560, 50);
            this.gbFindBy.TabIndex = 262;
            this.gbFindBy.TabStop = false;
            this.gbFindBy.Text = "Find";
            // 
            // gvCustomerList
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCustomerList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvCustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCustomerList.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvCustomerList.Location = new System.Drawing.Point(12, 19);
            this.gvCustomerList.Name = "gvCustomerList";
            this.gvCustomerList.Size = new System.Drawing.Size(669, 242);
            this.gvCustomerList.TabIndex = 0;
            this.gvCustomerList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCustomerList_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvCustomerList);
            this.groupBox2.Location = new System.Drawing.Point(11, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(695, 273);
            this.groupBox2.TabIndex = 272;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer list";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(8, 562);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(705, 2);
            this.label2.TabIndex = 276;
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Location = new System.Drawing.Point(8, 576);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(105, 25);
            this.btnPlaceOrder.TabIndex = 277;
            this.btnPlaceOrder.Text = "Place order";
            this.btnPlaceOrder.UseVisualStyleBackColor = true;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // FrmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(721, 610);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveCustomer);
            this.Controls.Add(this.gbFindCustomer);
            this.Controls.Add(this.gbFindBy);
            this.MaximizeBox = false;
            this.Name = "FrmCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.FrmCustomer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbFindCustomer.ResumeLayout(false);
            this.gbFindCustomer.PerformLayout();
            this.gbFindBy.ResumeLayout(false);
            this.gbFindBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomerList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNoOfCustomersFound;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.LinkLabel lnkNextCustomer;
        private System.Windows.Forms.LinkLabel lnkPreviousCustomer;
        private System.Windows.Forms.Label lblCustomerFoundText;
        private System.Windows.Forms.Button btnFindCustomer;
        private System.Windows.Forms.TextBox txtCustomerEmail;
        private System.Windows.Forms.ComboBox ddlFindBy;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.RadioButton rdoFindCustomer;
        private System.Windows.Forms.RadioButton rdoNewCustomer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCustomerAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFindCustomerById;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerLastName;
        private System.Windows.Forms.TextBox txtFindByValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomerNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerFirstName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCustomerPostcode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCustomerCity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSaveCustomer;
        private System.Windows.Forms.GroupBox gbFindCustomer;
        private System.Windows.Forms.GroupBox gbFindBy;
        private System.Windows.Forms.DataGridView gvCustomerList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPlaceOrder;
    }
}