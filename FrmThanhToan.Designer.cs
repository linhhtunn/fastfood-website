namespace MenuKhachHang
{
    partial class FrmThanhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThanhToan));
            this.lblTitle = new System.Windows.Forms.Label();
            this.grbCustomer = new System.Windows.Forms.GroupBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboQuan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbOrder = new System.Windows.Forms.GroupBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTongText = new System.Windows.Forms.Label();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.grbPayment = new System.Windows.Forms.GroupBox();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.rdoTienMat = new System.Windows.Forms.RadioButton();
            this.rdoChuyenKhoan = new System.Windows.Forms.RadioButton();
            this.btnXong = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.grbCustomer.SuspendLayout();
            this.grbOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.grbPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(476, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(191, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thanh toán";
            // 
            // grbCustomer
            // 
            this.grbCustomer.Controls.Add(this.txtDiaChi);
            this.grbCustomer.Controls.Add(this.label4);
            this.grbCustomer.Controls.Add(this.cboQuan);
            this.grbCustomer.Controls.Add(this.label3);
            this.grbCustomer.Controls.Add(this.txtPhone);
            this.grbCustomer.Controls.Add(this.label2);
            this.grbCustomer.Controls.Add(this.txtHoTen);
            this.grbCustomer.Controls.Add(this.label1);
            this.grbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCustomer.Location = new System.Drawing.Point(31, 86);
            this.grbCustomer.Name = "grbCustomer";
            this.grbCustomer.Size = new System.Drawing.Size(492, 395);
            this.grbCustomer.TabIndex = 1;
            this.grbCustomer.TabStop = false;
            this.grbCustomer.Text = "Thông tin khách hàng";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(21, 337);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(264, 35);
            this.txtDiaChi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Địa chỉ :";
            // 
            // cboQuan
            // 
            this.cboQuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuan.FormattingEnabled = true;
            this.cboQuan.Items.AddRange(new object[] {
            "Ba Đình",
            "Cầu Giấy",
            "Đống Đa",
            "Hai Bà Trưng",
            "Hà Đông",
            "Hoàng Mai",
            "Hoàn Kiếm",
            "Long Biên"});
            this.cboQuan.Location = new System.Drawing.Point(20, 250);
            this.cboQuan.Name = "cboQuan";
            this.cboQuan.Size = new System.Drawing.Size(264, 37);
            this.cboQuan.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Chọn quận :";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(20, 162);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(264, 35);
            this.txtPhone.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số điện thoại :";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(20, 83);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(264, 35);
            this.txtHoTen.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ và tên : ";
            // 
            // grbOrder
            // 
            this.grbOrder.Controls.Add(this.label5);
            this.grbOrder.Controls.Add(this.lblTongTien);
            this.grbOrder.Controls.Add(this.lblTongText);
            this.grbOrder.Controls.Add(this.dgvOrder);
            this.grbOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbOrder.Location = new System.Drawing.Point(563, 86);
            this.grbOrder.Name = "grbOrder";
            this.grbOrder.Size = new System.Drawing.Size(563, 452);
            this.grbOrder.TabIndex = 2;
            this.grbOrder.TabStop = false;
            this.grbOrder.Enter += new System.EventHandler(this.grbOrder_Enter);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Location = new System.Drawing.Point(393, 392);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(66, 29);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = "Tiền";
            // 
            // lblTongText
            // 
            this.lblTongText.AutoSize = true;
            this.lblTongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongText.Location = new System.Drawing.Point(88, 392);
            this.lblTongText.Name = "lblTongText";
            this.lblTongText.Size = new System.Drawing.Size(124, 29);
            this.lblTongText.TabIndex = 1;
            this.lblTongText.Text = "Tổng tiền";
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AllowUserToDeleteRows = false;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvOrder.Location = new System.Drawing.Point(9, 37);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.ReadOnly = true;
            this.dgvOrder.RowHeadersVisible = false;
            this.dgvOrder.RowHeadersWidth = 62;
            this.dgvOrder.RowTemplate.Height = 28;
            this.dgvOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrder.Size = new System.Drawing.Size(548, 325);
            this.dgvOrder.TabIndex = 0;
            // 
            // grbPayment
            // 
            this.grbPayment.Controls.Add(this.picQR);
            this.grbPayment.Controls.Add(this.rdoTienMat);
            this.grbPayment.Controls.Add(this.rdoChuyenKhoan);
            this.grbPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPayment.Location = new System.Drawing.Point(31, 487);
            this.grbPayment.Name = "grbPayment";
            this.grbPayment.Size = new System.Drawing.Size(492, 209);
            this.grbPayment.TabIndex = 3;
            this.grbPayment.TabStop = false;
            this.grbPayment.Text = "Phương thức thanh toán";
            // 
            // picQR
            // 
            this.picQR.Image = ((System.Drawing.Image)(resources.GetObject("picQR.Image")));
            this.picQR.Location = new System.Drawing.Point(295, 34);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(141, 143);
            this.picQR.TabIndex = 2;
            this.picQR.TabStop = false;
            // 
            // rdoTienMat
            // 
            this.rdoTienMat.AutoSize = true;
            this.rdoTienMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTienMat.Location = new System.Drawing.Point(20, 148);
            this.rdoTienMat.Name = "rdoTienMat";
            this.rdoTienMat.Size = new System.Drawing.Size(259, 29);
            this.rdoTienMat.TabIndex = 1;
            this.rdoTienMat.TabStop = true;
            this.rdoTienMat.Text = "Thanh toán bằng tiền mặt";
            this.rdoTienMat.UseVisualStyleBackColor = true;
            this.rdoTienMat.Click += new System.EventHandler(this.rdoTienMat_CheckedChanged);
            // 
            // rdoChuyenKhoan
            // 
            this.rdoChuyenKhoan.AutoSize = true;
            this.rdoChuyenKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoChuyenKhoan.Location = new System.Drawing.Point(20, 63);
            this.rdoChuyenKhoan.Name = "rdoChuyenKhoan";
            this.rdoChuyenKhoan.Size = new System.Drawing.Size(170, 29);
            this.rdoChuyenKhoan.TabIndex = 0;
            this.rdoChuyenKhoan.TabStop = true;
            this.rdoChuyenKhoan.Text = "Chuyển khoản ";
            this.rdoChuyenKhoan.UseVisualStyleBackColor = true;
            this.rdoChuyenKhoan.Click += new System.EventHandler(this.rdoChuyenKhoan_CheckedChanged);
            // 
            // btnXong
            // 
            this.btnXong.BackColor = System.Drawing.Color.DarkOrange;
            this.btnXong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXong.Location = new System.Drawing.Point(766, 594);
            this.btnXong.Name = "btnXong";
            this.btnXong.Size = new System.Drawing.Size(220, 70);
            this.btnXong.TabIndex = 4;
            this.btnXong.Text = "Xong";
            this.btnXong.UseVisualStyleBackColor = false;
            this.btnXong.Click += new System.EventHandler(this.btnXong_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(238, 29);
            this.label5.TabIndex = 5;
            this.label5.Text = "Thông tin đơn hàng";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // FrmThanhToan
            // 
            this.AcceptButton = this.btnXong;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 708);
            this.Controls.Add(this.btnXong);
            this.Controls.Add(this.grbPayment);
            this.Controls.Add(this.grbOrder);
            this.Controls.Add(this.grbCustomer);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.FrmThanhToan_Load);
            this.grbCustomer.ResumeLayout(false);
            this.grbCustomer.PerformLayout();
            this.grbOrder.ResumeLayout(false);
            this.grbOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.grbPayment.ResumeLayout(false);
            this.grbPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grbCustomer;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboQuan;
        private System.Windows.Forms.GroupBox grbOrder;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblTongText;
        private System.Windows.Forms.GroupBox grbPayment;
        private System.Windows.Forms.RadioButton rdoTienMat;
        private System.Windows.Forms.RadioButton rdoChuyenKhoan;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Button btnXong;
        private System.Windows.Forms.Label label5;
    }
}