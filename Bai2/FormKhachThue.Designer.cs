namespace Bai2
{
    partial class FormKhachThue
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
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.pnlGioiTinh = new System.Windows.Forms.Panel();
            this.radNam = new System.Windows.Forms.RadioButton();
            this.radNu = new System.Windows.Forms.RadioButton();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.lblTinhThanh = new System.Windows.Forms.Label();
            this.cboTinhThanh = new System.Windows.Forms.ComboBox();
            this.lblPhuongXa = new System.Windows.Forms.Label();
            this.cboPhuongXa = new System.Windows.Forms.ComboBox();
            this.chkTamTru = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlTimKiem = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocPhong = new System.Windows.Forms.Label();
            this.cboLocPhong = new System.Windows.Forms.ComboBox();
            this.lblLocTinh = new System.Windows.Forms.Label();
            this.cboLocTinh = new System.Windows.Forms.ComboBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnBoLoc = new System.Windows.Forms.Button();
            this.dgvKhachThue = new System.Windows.Forms.DataGridView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnGayLoiThu = new System.Windows.Forms.Button();
            this.grpThongTin.SuspendLayout();
            this.pnlGioiTinh.SuspendLayout();
            this.pnlTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachThue)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.lblHoTen);
            this.grpThongTin.Controls.Add(this.txtHoTen);
            this.grpThongTin.Controls.Add(this.pnlGioiTinh);
            this.grpThongTin.Controls.Add(this.lblNgaySinh);
            this.grpThongTin.Controls.Add(this.dtpNgaySinh);
            this.grpThongTin.Controls.Add(this.lblSoDienThoai);
            this.grpThongTin.Controls.Add(this.txtSoDienThoai);
            this.grpThongTin.Controls.Add(this.lblPhong);
            this.grpThongTin.Controls.Add(this.cboPhong);
            this.grpThongTin.Controls.Add(this.lblTinhThanh);
            this.grpThongTin.Controls.Add(this.cboTinhThanh);
            this.grpThongTin.Controls.Add(this.lblPhuongXa);
            this.grpThongTin.Controls.Add(this.cboPhuongXa);
            this.grpThongTin.Controls.Add(this.chkTamTru);
            this.grpThongTin.Controls.Add(this.btnThem);
            this.grpThongTin.Controls.Add(this.btnSua);
            this.grpThongTin.Controls.Add(this.btnXoa);
            this.grpThongTin.Controls.Add(this.btnLamMoi);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(360, 395);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin khách thuê";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(12, 28);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(43, 15);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(105, 25);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(240, 23);
            this.txtHoTen.TabIndex = 1;
            // 
            // pnlGioiTinh
            // 
            this.pnlGioiTinh.Controls.Add(this.radNam);
            this.pnlGioiTinh.Controls.Add(this.radNu);
            this.pnlGioiTinh.Location = new System.Drawing.Point(105, 54);
            this.pnlGioiTinh.Name = "pnlGioiTinh";
            this.pnlGioiTinh.Size = new System.Drawing.Size(240, 26);
            this.pnlGioiTinh.TabIndex = 2;
            // 
            // radNam
            // 
            this.radNam.AutoSize = true;
            this.radNam.Checked = true;
            this.radNam.Location = new System.Drawing.Point(3, 3);
            this.radNam.Name = "radNam";
            this.radNam.Size = new System.Drawing.Size(51, 19);
            this.radNam.TabIndex = 0;
            this.radNam.TabStop = true;
            this.radNam.Text = "Nam";
            this.radNam.UseVisualStyleBackColor = true;
            // 
            // radNu
            // 
            this.radNu.AutoSize = true;
            this.radNu.Location = new System.Drawing.Point(85, 3);
            this.radNu.Name = "radNu";
            this.radNu.Size = new System.Drawing.Size(41, 19);
            this.radNu.TabIndex = 1;
            this.radNu.Text = "Nữ";
            this.radNu.UseVisualStyleBackColor = true;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(12, 89);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(60, 15);
            this.lblNgaySinh.TabIndex = 3;
            this.lblNgaySinh.Text = "Ngày sinh";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(105, 86);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(140, 23);
            this.dtpNgaySinh.TabIndex = 4;
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Location = new System.Drawing.Point(12, 122);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(76, 15);
            this.lblSoDienThoai.TabIndex = 5;
            this.lblSoDienThoai.Text = "Số điện thoại";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(105, 119);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(240, 23);
            this.txtSoDienThoai.TabIndex = 6;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(12, 155);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(42, 15);
            this.lblPhong.TabIndex = 7;
            this.lblPhong.Text = "Phòng";
            // 
            // cboPhong
            // 
            this.cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhong.FormattingEnabled = true;
            this.cboPhong.Location = new System.Drawing.Point(105, 152);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(240, 23);
            this.cboPhong.TabIndex = 8;
            // 
            // lblTinhThanh
            // 
            this.lblTinhThanh.AutoSize = true;
            this.lblTinhThanh.Location = new System.Drawing.Point(12, 188);
            this.lblTinhThanh.Name = "lblTinhThanh";
            this.lblTinhThanh.Size = new System.Drawing.Size(65, 15);
            this.lblTinhThanh.TabIndex = 9;
            this.lblTinhThanh.Text = "Tỉnh/Thành";
            // 
            // cboTinhThanh
            // 
            this.cboTinhThanh.FormattingEnabled = true;
            this.cboTinhThanh.Location = new System.Drawing.Point(105, 185);
            this.cboTinhThanh.Name = "cboTinhThanh";
            this.cboTinhThanh.Size = new System.Drawing.Size(240, 23);
            this.cboTinhThanh.TabIndex = 10;
            this.cboTinhThanh.SelectedIndexChanged += new System.EventHandler(this.cboTinhThanh_SelectedIndexChanged);
            // 
            // lblPhuongXa
            // 
            this.lblPhuongXa.AutoSize = true;
            this.lblPhuongXa.Location = new System.Drawing.Point(12, 221);
            this.lblPhuongXa.Name = "lblPhuongXa";
            this.lblPhuongXa.Size = new System.Drawing.Size(66, 15);
            this.lblPhuongXa.TabIndex = 11;
            this.lblPhuongXa.Text = "Phường/Xã";
            // 
            // cboPhuongXa
            // 
            this.cboPhuongXa.FormattingEnabled = true;
            this.cboPhuongXa.Location = new System.Drawing.Point(105, 218);
            this.cboPhuongXa.Name = "cboPhuongXa";
            this.cboPhuongXa.Size = new System.Drawing.Size(240, 23);
            this.cboPhuongXa.TabIndex = 12;
            // 
            // chkTamTru
            // 
            this.chkTamTru.AutoSize = true;
            this.chkTamTru.Location = new System.Drawing.Point(105, 252);
            this.chkTamTru.Name = "chkTamTru";
            this.chkTamTru.Size = new System.Drawing.Size(133, 19);
            this.chkTamTru.TabIndex = 13;
            this.chkTamTru.Text = "Đã đăng ký tạm trú";
            this.chkTamTru.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 290);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 30);
            this.btnThem.TabIndex = 14;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(97, 290);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 30);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(182, 290);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(267, 290);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(78, 30);
            this.btnLamMoi.TabIndex = 17;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // pnlTimKiem
            // 
            this.pnlTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTimKiem.Controls.Add(this.txtTimKiem);
            this.pnlTimKiem.Controls.Add(this.lblLocPhong);
            this.pnlTimKiem.Controls.Add(this.cboLocPhong);
            this.pnlTimKiem.Controls.Add(this.lblLocTinh);
            this.pnlTimKiem.Controls.Add(this.cboLocTinh);
            this.pnlTimKiem.Controls.Add(this.btnTim);
            this.pnlTimKiem.Controls.Add(this.btnBoLoc);
            this.pnlTimKiem.Location = new System.Drawing.Point(385, 12);
            this.pnlTimKiem.Name = "pnlTimKiem";
            this.pnlTimKiem.Size = new System.Drawing.Size(535, 65);
            this.pnlTimKiem.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(3, 7);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Tìm theo họ tên hoặc SĐT...";
            this.txtTimKiem.Size = new System.Drawing.Size(185, 23);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // lblLocPhong
            // 
            this.lblLocPhong.AutoSize = true;
            this.lblLocPhong.Location = new System.Drawing.Point(195, 10);
            this.lblLocPhong.Name = "lblLocPhong";
            this.lblLocPhong.Size = new System.Drawing.Size(45, 15);
            this.lblLocPhong.TabIndex = 1;
            this.lblLocPhong.Text = "Phòng:";
            // 
            // cboLocPhong
            // 
            this.cboLocPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocPhong.FormattingEnabled = true;
            this.cboLocPhong.Location = new System.Drawing.Point(245, 7);
            this.cboLocPhong.Name = "cboLocPhong";
            this.cboLocPhong.Size = new System.Drawing.Size(100, 23);
            this.cboLocPhong.TabIndex = 2;
            this.cboLocPhong.SelectedIndexChanged += new System.EventHandler(this.cboLocPhong_SelectedIndexChanged);
            // 
            // lblLocTinh
            // 
            this.lblLocTinh.AutoSize = true;
            this.lblLocTinh.Location = new System.Drawing.Point(3, 38);
            this.lblLocTinh.Name = "lblLocTinh";
            this.lblLocTinh.Size = new System.Drawing.Size(33, 15);
            this.lblLocTinh.TabIndex = 3;
            this.lblLocTinh.Text = "Tỉnh:";
            // 
            // cboLocTinh
            // 
            this.cboLocTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTinh.FormattingEnabled = true;
            this.cboLocTinh.Location = new System.Drawing.Point(40, 35);
            this.cboLocTinh.Name = "cboLocTinh";
            this.cboLocTinh.Size = new System.Drawing.Size(148, 23);
            this.cboLocTinh.TabIndex = 4;
            this.cboLocTinh.SelectedIndexChanged += new System.EventHandler(this.cboLocTinh_SelectedIndexChanged);
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(355, 6);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 25);
            this.btnTim.TabIndex = 5;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnBoLoc
            // 
            this.btnBoLoc.Location = new System.Drawing.Point(436, 6);
            this.btnBoLoc.Name = "btnBoLoc";
            this.btnBoLoc.Size = new System.Drawing.Size(75, 25);
            this.btnBoLoc.TabIndex = 6;
            this.btnBoLoc.Text = "Bỏ lọc";
            this.btnBoLoc.UseVisualStyleBackColor = true;
            this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click);
            // 
            // dgvKhachThue
            // 
            this.dgvKhachThue.AllowUserToAddRows = false;
            this.dgvKhachThue.AllowUserToDeleteRows = false;
            this.dgvKhachThue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKhachThue.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvKhachThue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachThue.Location = new System.Drawing.Point(385, 83);
            this.dgvKhachThue.MultiSelect = false;
            this.dgvKhachThue.Name = "dgvKhachThue";
            this.dgvKhachThue.ReadOnly = true;
            this.dgvKhachThue.RowHeadersWidth = 35;
            this.dgvKhachThue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhachThue.Size = new System.Drawing.Size(535, 324);
            this.dgvKhachThue.TabIndex = 2;
            this.dgvKhachThue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachThue_CellClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTrangThai});
            this.statusStrip.Location = new System.Drawing.Point(0, 420);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(932, 22);
            this.statusStrip.TabIndex = 3;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(73, 17);
            this.lblTrangThai.Text = "Sẵn sàng...";
            // 
            // btnGayLoiThu
            // 
            this.btnGayLoiThu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGayLoiThu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGayLoiThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGayLoiThu.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGayLoiThu.ForeColor = System.Drawing.Color.DimGray;
            this.btnGayLoiThu.Location = new System.Drawing.Point(825, 417);
            this.btnGayLoiThu.Name = "btnGayLoiThu";
            this.btnGayLoiThu.Size = new System.Drawing.Size(95, 23);
            this.btnGayLoiThu.TabIndex = 4;
            this.btnGayLoiThu.Text = "Gây lỗi thử";
            this.btnGayLoiThu.UseVisualStyleBackColor = false;
            this.btnGayLoiThu.Click += new System.EventHandler(this.btnGayLoiThu_Click);
            // 
            // FormKhachThue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 442);
            this.Controls.Add(this.btnGayLoiThu);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.dgvKhachThue);
            this.Controls.Add(this.pnlTimKiem);
            this.Controls.Add(this.grpThongTin);
            this.MinimumSize = new System.Drawing.Size(948, 481);
            this.Name = "FormKhachThue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhà trọ - Khách thuê";
            this.Load += new System.EventHandler(this.FormKhachThue_Load);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.pnlGioiTinh.ResumeLayout(false);
            this.pnlGioiTinh.PerformLayout();
            this.pnlTimKiem.ResumeLayout(false);
            this.pnlTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachThue)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Panel pnlGioiTinh;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.RadioButton radNu;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label lblTinhThanh;
        private System.Windows.Forms.ComboBox cboTinhThanh;
        private System.Windows.Forms.Label lblPhuongXa;
        private System.Windows.Forms.ComboBox cboPhuongXa;
        private System.Windows.Forms.CheckBox chkTamTru;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Panel pnlTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblLocPhong;
        private System.Windows.Forms.ComboBox cboLocPhong;
        private System.Windows.Forms.Label lblLocTinh;
        private System.Windows.Forms.ComboBox cboLocTinh;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnBoLoc;
        private System.Windows.Forms.DataGridView dgvKhachThue;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblTrangThai;
        private System.Windows.Forms.Button btnGayLoiThu;
    }
}
