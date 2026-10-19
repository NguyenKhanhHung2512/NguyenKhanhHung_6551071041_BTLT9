namespace Bai1
{
    partial class FormChiTieu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblNgayChi = new System.Windows.Forms.Label();
            this.dtpNgayChi = new System.Windows.Forms.DateTimePicker();
            this.lblLoaiChi = new System.Windows.Forms.Label();
            this.cboLoaiChi = new System.Windows.Forms.ComboBox();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.numSoTien = new System.Windows.Forms.NumericUpDown();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.lblTimNoiDung = new System.Windows.Forms.Label();
            this.txtTimNoiDung = new System.Windows.Forms.TextBox();
            this.lblLocLoaiChi = new System.Windows.Forms.Label();
            this.cboLocLoaiChi = new System.Windows.Forms.ComboBox();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnTim = new System.Windows.Forms.Button();
            this.dgvChiTieu = new System.Windows.Forms.DataGridView();
            this.lblTongChi = new System.Windows.Forms.Label();
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTien)).BeginInit();
            this.grpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTieu)).BeginInit();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.lblNgayChi);
            this.grpThongTin.Controls.Add(this.dtpNgayChi);
            this.grpThongTin.Controls.Add(this.lblLoaiChi);
            this.grpThongTin.Controls.Add(this.cboLoaiChi);
            this.grpThongTin.Controls.Add(this.lblNoiDung);
            this.grpThongTin.Controls.Add(this.txtNoiDung);
            this.grpThongTin.Controls.Add(this.lblSoTien);
            this.grpThongTin.Controls.Add(this.numSoTien);
            this.grpThongTin.Controls.Add(this.lblGhiChu);
            this.grpThongTin.Controls.Add(this.txtGhiChu);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(480, 150);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin khoản chi";
            // 
            // lblNgayChi
            // 
            this.lblNgayChi.AutoSize = true;
            this.lblNgayChi.Location = new System.Drawing.Point(12, 25);
            this.lblNgayChi.Name = "lblNgayChi";
            this.lblNgayChi.Size = new System.Drawing.Size(57, 15);
            this.lblNgayChi.TabIndex = 0;
            this.lblNgayChi.Text = "Ngày chi";
            // 
            // dtpNgayChi
            // 
            this.dtpNgayChi.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayChi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayChi.Location = new System.Drawing.Point(75, 22);
            this.dtpNgayChi.Name = "dtpNgayChi";
            this.dtpNgayChi.Size = new System.Drawing.Size(125, 23);
            this.dtpNgayChi.TabIndex = 1;
            // 
            // lblLoaiChi
            // 
            this.lblLoaiChi.AutoSize = true;
            this.lblLoaiChi.Location = new System.Drawing.Point(212, 25);
            this.lblLoaiChi.Name = "lblLoaiChi";
            this.lblLoaiChi.Size = new System.Drawing.Size(51, 15);
            this.lblLoaiChi.TabIndex = 2;
            this.lblLoaiChi.Text = "Loại chi:";
            // 
            // cboLoaiChi
            // 
            this.cboLoaiChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiChi.FormattingEnabled = true;
            this.cboLoaiChi.Location = new System.Drawing.Point(270, 22);
            this.cboLoaiChi.Name = "cboLoaiChi";
            this.cboLoaiChi.Size = new System.Drawing.Size(195, 23);
            this.cboLoaiChi.TabIndex = 3;
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Location = new System.Drawing.Point(12, 55);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(57, 15);
            this.lblNoiDung.TabIndex = 4;
            this.lblNoiDung.Text = "Nội dung";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(75, 52);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(125, 23);
            this.txtNoiDung.TabIndex = 5;
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Location = new System.Drawing.Point(212, 55);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(43, 15);
            this.lblSoTien.TabIndex = 6;
            this.lblSoTien.Text = "Số tiền";
            // 
            // numSoTien
            // 
            this.numSoTien.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numSoTien.Location = new System.Drawing.Point(270, 52);
            this.numSoTien.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            this.numSoTien.Name = "numSoTien";
            this.numSoTien.Size = new System.Drawing.Size(195, 23);
            this.numSoTien.TabIndex = 7;
            this.numSoTien.ThousandsSeparator = true;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(12, 85);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(48, 15);
            this.lblGhiChu.TabIndex = 8;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(75, 82);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGhiChu.Size = new System.Drawing.Size(390, 55);
            this.txtGhiChu.TabIndex = 9;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(87, 170);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(85, 30);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(182, 170);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(85, 30);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(277, 170);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(85, 30);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(372, 170);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(85, 30);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // grpTimKiem
            // 
            this.grpTimKiem.Controls.Add(this.lblTimNoiDung);
            this.grpTimKiem.Controls.Add(this.txtTimNoiDung);
            this.grpTimKiem.Controls.Add(this.lblLocLoaiChi);
            this.grpTimKiem.Controls.Add(this.cboLocLoaiChi);
            this.grpTimKiem.Controls.Add(this.lblTuNgay);
            this.grpTimKiem.Controls.Add(this.dtpTuNgay);
            this.grpTimKiem.Controls.Add(this.lblDenNgay);
            this.grpTimKiem.Controls.Add(this.dtpDenNgay);
            this.grpTimKiem.Controls.Add(this.btnTim);
            this.grpTimKiem.Location = new System.Drawing.Point(505, 12);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(325, 188);
            this.grpTimKiem.TabIndex = 5;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "Tìm kiếm";
            // 
            // lblTimNoiDung
            // 
            this.lblTimNoiDung.AutoSize = true;
            this.lblTimNoiDung.Location = new System.Drawing.Point(12, 25);
            this.lblTimNoiDung.Name = "lblTimNoiDung";
            this.lblTimNoiDung.Size = new System.Drawing.Size(57, 15);
            this.lblTimNoiDung.TabIndex = 0;
            this.lblTimNoiDung.Text = "Nội dung";
            // 
            // txtTimNoiDung
            // 
            this.txtTimNoiDung.Location = new System.Drawing.Point(75, 22);
            this.txtTimNoiDung.Name = "txtTimNoiDung";
            this.txtTimNoiDung.PlaceholderText = "Nhập nội dung...";
            this.txtTimNoiDung.Size = new System.Drawing.Size(235, 23);
            this.txtTimNoiDung.TabIndex = 1;
            this.txtTimNoiDung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimNoiDung_KeyDown);
            // 
            // lblLocLoaiChi
            // 
            this.lblLocLoaiChi.AutoSize = true;
            this.lblLocLoaiChi.Location = new System.Drawing.Point(12, 55);
            this.lblLocLoaiChi.Name = "lblLocLoaiChi";
            this.lblLocLoaiChi.Size = new System.Drawing.Size(48, 15);
            this.lblLocLoaiChi.TabIndex = 2;
            this.lblLocLoaiChi.Text = "Loại chi";
            // 
            // cboLocLoaiChi
            // 
            this.cboLocLoaiChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoaiChi.FormattingEnabled = true;
            this.cboLocLoaiChi.Location = new System.Drawing.Point(75, 52);
            this.cboLocLoaiChi.Name = "cboLocLoaiChi";
            this.cboLocLoaiChi.Size = new System.Drawing.Size(235, 23);
            this.cboLocLoaiChi.TabIndex = 3;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(12, 85);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(49, 15);
            this.lblTuNgay.TabIndex = 4;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(75, 82);
            this.dtpNgayChi.Size = new System.Drawing.Size(130, 23);
            this.dtpTuNgay.TabIndex = 5;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(12, 115);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(57, 15);
            this.lblDenNgay.TabIndex = 6;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(75, 112);
            this.dtpDenNgay.Size = new System.Drawing.Size(130, 23);
            this.dtpDenNgay.TabIndex = 7;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(220, 110);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(90, 27);
            this.btnTim.TabIndex = 8;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // dgvChiTieu
            // 
            this.dgvChiTieu.AllowUserToAddRows = false;
            this.dgvChiTieu.AllowUserToDeleteRows = false;
            this.dgvChiTieu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTieu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvChiTieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTieu.Location = new System.Drawing.Point(12, 212);
            this.dgvChiTieu.MultiSelect = false;
            this.dgvChiTieu.Name = "dgvChiTieu";
            this.dgvChiTieu.ReadOnly = true;
            this.dgvChiTieu.RowHeadersWidth = 35;
            this.dgvChiTieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTieu.Size = new System.Drawing.Size(818, 205);
            this.dgvChiTieu.TabIndex = 6;
            this.dgvChiTieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTieu_CellClick);
            // 
            // lblTongChi
            // 
            this.lblTongChi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongChi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTongChi.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTongChi.Location = new System.Drawing.Point(480, 422);
            this.lblTongChi.Name = "lblTongChi";
            this.lblTongChi.Size = new System.Drawing.Size(350, 30);
            this.lblTongChi.TabIndex = 7;
            this.lblTongChi.Text = "Tổng chi: 0 đ";
            this.lblTongChi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormChiTieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 458);
            this.Controls.Add(this.lblTongChi);
            this.Controls.Add(this.dgvChiTieu);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grpThongTin);
            this.MinimumSize = new System.Drawing.Size(858, 497);
            this.Name = "FormChiTieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sổ chi tiêu cá nhân";
            this.Load += new System.EventHandler(this.FormChiTieu_Load);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTien)).EndInit();
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblNgayChi;
        private System.Windows.Forms.DateTimePicker dtpNgayChi;
        private System.Windows.Forms.Label lblLoaiChi;
        private System.Windows.Forms.ComboBox cboLoaiChi;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.NumericUpDown numSoTien;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.Label lblTimNoiDung;
        private System.Windows.Forms.TextBox txtTimNoiDung;
        private System.Windows.Forms.Label lblLocLoaiChi;
        private System.Windows.Forms.ComboBox cboLocLoaiChi;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvChiTieu;
        private System.Windows.Forms.Label lblTongChi;
    }
}
