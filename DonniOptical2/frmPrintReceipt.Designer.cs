namespace DonniOptical2
{
    partial class frmPrintReceipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintReceipt));
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOrderNoValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCustomerNoValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblCustomerAddress = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblPostCode = new System.Windows.Forms.Label();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblFrameTotalPrice = new System.Windows.Forms.Label();
            this.lblLensTotalPrice = new System.Windows.Forms.Label();
            this.lblDiscountAmnt = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblHstAmount = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblDepositAmount = new System.Windows.Forms.Label();
            this.lblBalanceDue = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.ddlPrinterList = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.lblOtherAmount = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order/Receipt #:";
            // 
            // lblOrderNoValue
            // 
            this.lblOrderNoValue.AutoSize = true;
            this.lblOrderNoValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNoValue.Location = new System.Drawing.Point(519, 177);
            this.lblOrderNoValue.Name = "lblOrderNoValue";
            this.lblOrderNoValue.Size = new System.Drawing.Size(63, 13);
            this.lblOrderNoValue.TabIndex = 1;
            this.lblOrderNoValue.Text = "00000000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Customer #:";
            // 
            // lblCustomerNoValue
            // 
            this.lblCustomerNoValue.AutoSize = true;
            this.lblCustomerNoValue.Location = new System.Drawing.Point(108, 177);
            this.lblCustomerNoValue.Name = "lblCustomerNoValue";
            this.lblCustomerNoValue.Size = new System.Drawing.Size(55, 13);
            this.lblCustomerNoValue.TabIndex = 3;
            this.lblCustomerNoValue.Text = "00000000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Customer name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Address:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(108, 196);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(35, 13);
            this.lblCustomerName.TabIndex = 6;
            this.lblCustomerName.Text = "Name";
            // 
            // lblCustomerAddress
            // 
            this.lblCustomerAddress.AutoSize = true;
            this.lblCustomerAddress.Location = new System.Drawing.Point(108, 215);
            this.lblCustomerAddress.Name = "lblCustomerAddress";
            this.lblCustomerAddress.Size = new System.Drawing.Size(45, 13);
            this.lblCustomerAddress.TabIndex = 7;
            this.lblCustomerAddress.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(648, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "ORDER RECEIPT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(652, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Date:";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDate.Location = new System.Drawing.Point(695, 177);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(80, 13);
            this.lblOrderDate.TabIndex = 9;
            this.lblOrderDate.Text = "dd-mmm-yyyy";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(108, 234);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 10;
            this.lblCity.Text = "City";
            // 
            // lblPostCode
            // 
            this.lblPostCode.AutoSize = true;
            this.lblPostCode.Location = new System.Drawing.Point(108, 257);
            this.lblPostCode.Name = "lblPostCode";
            this.lblPostCode.Size = new System.Drawing.Size(52, 13);
            this.lblPostCode.TabIndex = 11;
            this.lblPostCode.Text = "Postcode";
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Location = new System.Drawing.Point(108, 278);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(38, 13);
            this.lblCustomerPhone.TabIndex = 12;
            this.lblCustomerPhone.Text = "Phone";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(565, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Frame price:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(565, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Lens price:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(565, 273);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Discount (-):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(565, 294);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Subtotal:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(565, 315);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "HST:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(565, 348);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Total:";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label14.Location = new System.Drawing.Point(13, 128);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(790, 2);
            this.label14.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(134, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(123, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "147 Clarence St, Unit 33";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(134, 38);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 13);
            this.label17.TabIndex = 12;
            this.label17.Text = "Brampton, ON, L6W 1T2";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(134, 59);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(94, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "Tel: 905-497-4600";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(134, 80);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(153, 13);
            this.label19.TabIndex = 14;
            this.label19.Text = "Email: dinnooptical@gmail.com";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(13, 149);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 17);
            this.label20.TabIndex = 15;
            this.label20.Text = "Customer";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(419, 149);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 17);
            this.label21.TabIndex = 16;
            this.label21.Text = "Order";
            // 
            // label22
            // 
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label22.Location = new System.Drawing.Point(422, 196);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(380, 2);
            this.label22.TabIndex = 17;
            // 
            // lblFrameTotalPrice
            // 
            this.lblFrameTotalPrice.AutoSize = true;
            this.lblFrameTotalPrice.Location = new System.Drawing.Point(736, 215);
            this.lblFrameTotalPrice.Name = "lblFrameTotalPrice";
            this.lblFrameTotalPrice.Size = new System.Drawing.Size(28, 13);
            this.lblFrameTotalPrice.TabIndex = 20;
            this.lblFrameTotalPrice.Text = "0.00";
            this.lblFrameTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLensTotalPrice
            // 
            this.lblLensTotalPrice.AutoSize = true;
            this.lblLensTotalPrice.Location = new System.Drawing.Point(736, 236);
            this.lblLensTotalPrice.Name = "lblLensTotalPrice";
            this.lblLensTotalPrice.Size = new System.Drawing.Size(28, 13);
            this.lblLensTotalPrice.TabIndex = 21;
            this.lblLensTotalPrice.Text = "0.00";
            // 
            // lblDiscountAmnt
            // 
            this.lblDiscountAmnt.AutoSize = true;
            this.lblDiscountAmnt.Location = new System.Drawing.Point(736, 273);
            this.lblDiscountAmnt.Name = "lblDiscountAmnt";
            this.lblDiscountAmnt.Size = new System.Drawing.Size(28, 13);
            this.lblDiscountAmnt.TabIndex = 22;
            this.lblDiscountAmnt.Text = "0.00";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(736, 294);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(28, 13);
            this.lblSubtotal.TabIndex = 23;
            this.lblSubtotal.Text = "0.00";
            // 
            // lblHstAmount
            // 
            this.lblHstAmount.AutoSize = true;
            this.lblHstAmount.Location = new System.Drawing.Point(736, 315);
            this.lblHstAmount.Name = "lblHstAmount";
            this.lblHstAmount.Size = new System.Drawing.Size(28, 13);
            this.lblHstAmount.TabIndex = 24;
            this.lblHstAmount.Text = "0.00";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.Location = new System.Drawing.Point(736, 348);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(32, 13);
            this.lblGrandTotal.TabIndex = 25;
            this.lblGrandTotal.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(565, 371);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Deposit:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(565, 391);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(49, 13);
            this.label23.TabIndex = 27;
            this.label23.Text = "Balance:";
            // 
            // lblDepositAmount
            // 
            this.lblDepositAmount.AutoSize = true;
            this.lblDepositAmount.Location = new System.Drawing.Point(736, 371);
            this.lblDepositAmount.Name = "lblDepositAmount";
            this.lblDepositAmount.Size = new System.Drawing.Size(28, 13);
            this.lblDepositAmount.TabIndex = 28;
            this.lblDepositAmount.Text = "0.00";
            // 
            // lblBalanceDue
            // 
            this.lblBalanceDue.AutoSize = true;
            this.lblBalanceDue.Location = new System.Drawing.Point(736, 391);
            this.lblBalanceDue.Name = "lblBalanceDue";
            this.lblBalanceDue.Size = new System.Drawing.Size(28, 13);
            this.lblBalanceDue.TabIndex = 29;
            this.lblBalanceDue.Text = "0.00";
            // 
            // label24
            // 
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label24.Location = new System.Drawing.Point(422, 337);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(380, 2);
            this.label24.TabIndex = 30;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.White;
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label25.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label25.Location = new System.Drawing.Point(12, 474);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(790, 2);
            this.label25.TabIndex = 31;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(18, 433);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(255, 13);
            this.label26.TabIndex = 32;
            this.label26.Text = "Cashier ......................................................................";
            // 
            // ddlPrinterList
            // 
            this.ddlPrinterList.FormattingEnabled = true;
            this.ddlPrinterList.Location = new System.Drawing.Point(522, 489);
            this.ddlPrinterList.Name = "ddlPrinterList";
            this.ddlPrinterList.Size = new System.Drawing.Size(241, 21);
            this.ddlPrinterList.TabIndex = 35;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(717, 215);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(13, 13);
            this.label28.TabIndex = 36;
            this.label28.Text = "$";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(717, 236);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(13, 13);
            this.label29.TabIndex = 37;
            this.label29.Text = "$";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(717, 273);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(13, 13);
            this.label30.TabIndex = 38;
            this.label30.Text = "$";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(717, 294);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(13, 13);
            this.label31.TabIndex = 39;
            this.label31.Text = "$";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(717, 315);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(13, 13);
            this.label32.TabIndex = 40;
            this.label32.Text = "$";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(717, 348);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(13, 13);
            this.label33.TabIndex = 41;
            this.label33.Text = "$";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(717, 371);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(13, 13);
            this.label34.TabIndex = 42;
            this.label34.Text = "$";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(717, 391);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(13, 13);
            this.label35.TabIndex = 43;
            this.label35.Text = "$";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DonniOptical2.Properties.Resources.dinno_logo;
            this.pictureBox1.InitialImage = global::DonniOptical2.Properties.Resources.dinno_logo;
            this.pictureBox1.Location = new System.Drawing.Point(13, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::DonniOptical2.Properties.Resources.printer;
            this.btnPrint.Location = new System.Drawing.Point(769, 489);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(34, 23);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(717, 255);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 13);
            this.label15.TabIndex = 47;
            this.label15.Text = "$";
            // 
            // lblOtherAmount
            // 
            this.lblOtherAmount.AutoSize = true;
            this.lblOtherAmount.Location = new System.Drawing.Point(736, 255);
            this.lblOtherAmount.Name = "lblOtherAmount";
            this.lblOtherAmount.Size = new System.Drawing.Size(28, 13);
            this.lblOtherAmount.TabIndex = 46;
            this.lblOtherAmount.Text = "0.00";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(565, 253);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(36, 13);
            this.label36.TabIndex = 45;
            this.label36.Text = "Other:";
            // 
            // frmPrintReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(815, 523);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblOtherAmount);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.ddlPrinterList);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.lblBalanceDue);
            this.Controls.Add(this.lblDepositAmount);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.lblHstAmount);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblDiscountAmnt);
            this.Controls.Add(this.lblLensTotalPrice);
            this.Controls.Add(this.lblFrameTotalPrice);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCustomerAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCustomerPhone);
            this.Controls.Add(this.lblPostCode);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblCustomerNoValue);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lblOrderNoValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPrint);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrintReceipt";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print receipt";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblOrderNoValue;
        public System.Windows.Forms.Label lblCustomerNoValue;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblCustomerName;
        public System.Windows.Forms.Label lblCustomerAddress;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblCity;
        public System.Windows.Forms.Label lblPostCode;
        public System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        public System.Windows.Forms.Label lblOrderDate;
        public System.Windows.Forms.Label lblFrameTotalPrice;
        public System.Windows.Forms.Label lblLensTotalPrice;
        public System.Windows.Forms.Label lblDiscountAmnt;
        public System.Windows.Forms.Label lblSubtotal;
        public System.Windows.Forms.Label lblHstAmount;
        public System.Windows.Forms.Label lblGrandTotal;
        public System.Windows.Forms.Label lblDepositAmount;
        public System.Windows.Forms.Label lblBalanceDue;
        public System.Windows.Forms.ComboBox ddlPrinterList;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label lblOtherAmount;
        private System.Windows.Forms.Label label36;
    }
}