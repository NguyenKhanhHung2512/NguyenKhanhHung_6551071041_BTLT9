namespace Bai3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTieuDe = new Label();
            pnlNgonNgu = new Panel();
            lblNgonNgu = new Label();
            cboNgonNgu = new ComboBox();
            pnlTren = new Panel();
            grpThongTin = new GroupBox();
            lblTenChuyen = new Label();
            txtTenChuyen = new TextBox();
            lblDiaDiem = new Label();
            txtDiaDiem = new TextBox();
            lblPhuongTien = new Label();
            cboPhuongTien = new ComboBox();
            chkDaHoanThanh = new CheckBox();
            lblNgayDi = new Label();
            dtpNgayDi = new DateTimePicker();
            lblSoNguoi = new Label();
            nudSoNguoi = new NumericUpDown();
            lblNganSach = new Label();
            nudNganSach = new NumericUpDown();
            lblGhiChu = new Label();
            txtGhiChu = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            pnlKhoangCach = new Panel();
            grpThoiTiet = new GroupBox();
            btnXemThoiTiet = new Button();
            prgThoiTiet = new ProgressBar();
            pnlKetQua = new Panel();
            lblTieuDeThoiTiet = new Label();
            lblIcon = new Label();
            lblChiTiet = new Label();
            lblLoiKhuyen = new Label();
            lblTrangThai = new Label();
            pnlLoc = new Panel();
            txtTim = new TextBox();
            chkChuaHoanThanh = new CheckBox();
            lblTu = new Label();
            dtpTu = new DateTimePicker();
            lblDen = new Label();
            dtpDen = new DateTimePicker();
            btnTim = new Button();
            btnBoLoc = new Button();
            dgvChuyenDi = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlNgonNgu.SuspendLayout();
            pnlTren.SuspendLayout();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoNguoi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNganSach).BeginInit();
            grpThoiTiet.SuspendLayout();
            pnlKetQua.SuspendLayout();
            pnlLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenDi).BeginInit();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Controls.Add(pnlNgonNgu);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(10, 10);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1320, 52);
            pnlHeader.TabIndex = 0;
            //
            // lblTieuDe
            //
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(29, 78, 74);
            lblTieuDe.Location = new Point(0, 0);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(1060, 52);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Kế hoạch dã ngoại";
            lblTieuDe.TextAlign = ContentAlignment.MiddleLeft;
            //
            // pnlNgonNgu
            //
            pnlNgonNgu.Controls.Add(lblNgonNgu);
            pnlNgonNgu.Controls.Add(cboNgonNgu);
            pnlNgonNgu.Dock = DockStyle.Right;
            pnlNgonNgu.Location = new Point(1060, 0);
            pnlNgonNgu.Name = "pnlNgonNgu";
            pnlNgonNgu.Size = new Size(260, 52);
            pnlNgonNgu.TabIndex = 1;
            //
            // lblNgonNgu
            //
            lblNgonNgu.AutoSize = true;
            lblNgonNgu.Location = new Point(10, 19);
            lblNgonNgu.Name = "lblNgonNgu";
            lblNgonNgu.Size = new Size(63, 15);
            lblNgonNgu.TabIndex = 0;
            lblNgonNgu.Text = "Ngôn ngữ:";
            //
            // cboNgonNgu
            //
            cboNgonNgu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNgonNgu.FormattingEnabled = true;
            cboNgonNgu.Items.AddRange(new object[] { "Tiếng Việt", "English" });
            cboNgonNgu.Location = new Point(95, 15);
            cboNgonNgu.Name = "cboNgonNgu";
            cboNgonNgu.Size = new Size(160, 23);
            cboNgonNgu.TabIndex = 1;
            cboNgonNgu.SelectedIndexChanged += CboNgonNgu_SelectedIndexChanged;
            //
            // pnlTren
            //
            pnlTren.Controls.Add(grpThongTin);
            pnlTren.Controls.Add(pnlKhoangCach);
            pnlTren.Controls.Add(grpThoiTiet);
            pnlTren.Dock = DockStyle.Top;
            pnlTren.Location = new Point(10, 62);
            pnlTren.Name = "pnlTren";
            pnlTren.Size = new Size(1320, 320);
            pnlTren.TabIndex = 1;
            //
            // grpThongTin
            //
            grpThongTin.Controls.Add(lblTenChuyen);
            grpThongTin.Controls.Add(txtTenChuyen);
            grpThongTin.Controls.Add(lblDiaDiem);
            grpThongTin.Controls.Add(txtDiaDiem);
            grpThongTin.Controls.Add(lblPhuongTien);
            grpThongTin.Controls.Add(cboPhuongTien);
            grpThongTin.Controls.Add(chkDaHoanThanh);
            grpThongTin.Controls.Add(lblNgayDi);
            grpThongTin.Controls.Add(dtpNgayDi);
            grpThongTin.Controls.Add(lblSoNguoi);
            grpThongTin.Controls.Add(nudSoNguoi);
            grpThongTin.Controls.Add(lblNganSach);
            grpThongTin.Controls.Add(nudNganSach);
            grpThongTin.Controls.Add(lblGhiChu);
            grpThongTin.Controls.Add(txtGhiChu);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLamMoi);
            grpThongTin.Dock = DockStyle.Fill;
            grpThongTin.Location = new Point(0, 0);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(840, 320);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin chuyến đi";
            //
            // lblTenChuyen
            //
            lblTenChuyen.AutoSize = true;
            lblTenChuyen.Location = new Point(15, 33);
            lblTenChuyen.Name = "lblTenChuyen";
            lblTenChuyen.Size = new Size(70, 15);
            lblTenChuyen.TabIndex = 0;
            lblTenChuyen.Text = "Tên chuyến:";
            //
            // txtTenChuyen
            //
            txtTenChuyen.Location = new Point(125, 30);
            txtTenChuyen.MaxLength = 100;
            txtTenChuyen.Name = "txtTenChuyen";
            txtTenChuyen.Size = new Size(330, 23);
            txtTenChuyen.TabIndex = 1;
            //
            // lblDiaDiem
            //
            lblDiaDiem.AutoSize = true;
            lblDiaDiem.Location = new Point(15, 71);
            lblDiaDiem.Name = "lblDiaDiem";
            lblDiaDiem.Size = new Size(56, 15);
            lblDiaDiem.TabIndex = 2;
            lblDiaDiem.Text = "Địa điểm:";
            //
            // txtDiaDiem
            //
            txtDiaDiem.Location = new Point(125, 68);
            txtDiaDiem.MaxLength = 100;
            txtDiaDiem.Name = "txtDiaDiem";
            txtDiaDiem.Size = new Size(330, 23);
            txtDiaDiem.TabIndex = 2;
            //
            // lblPhuongTien
            //
            lblPhuongTien.AutoSize = true;
            lblPhuongTien.Location = new Point(15, 109);
            lblPhuongTien.Name = "lblPhuongTien";
            lblPhuongTien.Size = new Size(72, 15);
            lblPhuongTien.TabIndex = 4;
            lblPhuongTien.Text = "Phương tiện:";
            //
            // cboPhuongTien
            //
            cboPhuongTien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhuongTien.FormattingEnabled = true;
            cboPhuongTien.Items.AddRange(new object[] { "Xe máy", "Ô tô", "Xe khách", "Tàu hỏa" });
            cboPhuongTien.Location = new Point(125, 106);
            cboPhuongTien.Name = "cboPhuongTien";
            cboPhuongTien.Size = new Size(200, 23);
            cboPhuongTien.TabIndex = 3;
            //
            // chkDaHoanThanh
            //
            chkDaHoanThanh.AutoSize = true;
            chkDaHoanThanh.Location = new Point(125, 145);
            chkDaHoanThanh.Name = "chkDaHoanThanh";
            chkDaHoanThanh.Size = new Size(104, 19);
            chkDaHoanThanh.TabIndex = 4;
            chkDaHoanThanh.Text = "Đã hoàn thành";
            chkDaHoanThanh.UseVisualStyleBackColor = true;
            //
            // lblNgayDi
            //
            lblNgayDi.AutoSize = true;
            lblNgayDi.Location = new Point(480, 33);
            lblNgayDi.Name = "lblNgayDi";
            lblNgayDi.Size = new Size(50, 15);
            lblNgayDi.TabIndex = 6;
            lblNgayDi.Text = "Ngày đi:";
            //
            // dtpNgayDi
            //
            dtpNgayDi.CustomFormat = "dd/MM/yyyy";
            dtpNgayDi.Format = DateTimePickerFormat.Custom;
            dtpNgayDi.Location = new Point(590, 30);
            dtpNgayDi.Name = "dtpNgayDi";
            dtpNgayDi.Size = new Size(150, 23);
            dtpNgayDi.TabIndex = 5;
            //
            // lblSoNguoi
            //
            lblSoNguoi.AutoSize = true;
            lblSoNguoi.Location = new Point(480, 71);
            lblSoNguoi.Name = "lblSoNguoi";
            lblSoNguoi.Size = new Size(58, 15);
            lblSoNguoi.TabIndex = 8;
            lblSoNguoi.Text = "Số người:";
            //
            // nudSoNguoi
            //
            nudSoNguoi.Location = new Point(590, 68);
            nudSoNguoi.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudSoNguoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoNguoi.Name = "nudSoNguoi";
            nudSoNguoi.Size = new Size(100, 23);
            nudSoNguoi.TabIndex = 6;
            nudSoNguoi.TextAlign = HorizontalAlignment.Right;
            nudSoNguoi.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // lblNganSach
            //
            lblNganSach.AutoSize = true;
            lblNganSach.Location = new Point(480, 109);
            lblNganSach.Name = "lblNganSach";
            lblNganSach.Size = new Size(86, 15);
            lblNganSach.TabIndex = 10;
            lblNganSach.Text = "Ngân sách (đ):";
            //
            // nudNganSach
            //
            nudNganSach.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            nudNganSach.Location = new Point(590, 106);
            nudNganSach.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudNganSach.Name = "nudNganSach";
            nudNganSach.Size = new Size(220, 23);
            nudNganSach.TabIndex = 7;
            nudNganSach.TextAlign = HorizontalAlignment.Right;
            nudNganSach.ThousandsSeparator = true;
            //
            // lblGhiChu
            //
            lblGhiChu.AutoSize = true;
            lblGhiChu.Location = new Point(15, 183);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(51, 15);
            lblGhiChu.TabIndex = 12;
            lblGhiChu.Text = "Ghi chú:";
            //
            // txtGhiChu
            //
            txtGhiChu.Location = new Point(125, 180);
            txtGhiChu.MaxLength = 200;
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.ScrollBars = ScrollBars.Vertical;
            txtGhiChu.Size = new Size(685, 70);
            txtGhiChu.TabIndex = 8;
            //
            // btnThem
            //
            btnThem.Location = new Point(125, 266);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 34);
            btnThem.TabIndex = 9;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += BtnThem_Click;
            //
            // btnSua
            //
            btnSua.Location = new Point(235, 266);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 34);
            btnSua.TabIndex = 10;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += BtnSua_Click;
            //
            // btnXoa
            //
            btnXoa.Location = new Point(345, 266);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 34);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += BtnXoa_Click;
            //
            // btnLamMoi
            //
            btnLamMoi.Location = new Point(455, 266);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 34);
            btnLamMoi.TabIndex = 12;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += BtnLamMoi_Click;
            //
            // pnlKhoangCach
            //
            pnlKhoangCach.Dock = DockStyle.Right;
            pnlKhoangCach.Location = new Point(840, 0);
            pnlKhoangCach.Name = "pnlKhoangCach";
            pnlKhoangCach.Size = new Size(10, 320);
            pnlKhoangCach.TabIndex = 1;
            //
            // grpThoiTiet
            //
            grpThoiTiet.Controls.Add(btnXemThoiTiet);
            grpThoiTiet.Controls.Add(prgThoiTiet);
            grpThoiTiet.Controls.Add(pnlKetQua);
            grpThoiTiet.Dock = DockStyle.Right;
            grpThoiTiet.Location = new Point(850, 0);
            grpThoiTiet.Name = "grpThoiTiet";
            grpThoiTiet.Size = new Size(470, 320);
            grpThoiTiet.TabIndex = 2;
            grpThoiTiet.TabStop = false;
            grpThoiTiet.Text = "Thời tiết ngày đi";
            //
            // btnXemThoiTiet
            //
            btnXemThoiTiet.Location = new Point(15, 25);
            btnXemThoiTiet.Name = "btnXemThoiTiet";
            btnXemThoiTiet.Size = new Size(150, 32);
            btnXemThoiTiet.TabIndex = 0;
            btnXemThoiTiet.Text = "Xem thời tiết";
            btnXemThoiTiet.UseVisualStyleBackColor = true;
            btnXemThoiTiet.Click += BtnXemThoiTiet_Click;
            //
            // prgThoiTiet
            //
            prgThoiTiet.Location = new Point(180, 33);
            prgThoiTiet.MarqueeAnimationSpeed = 25;
            prgThoiTiet.Name = "prgThoiTiet";
            prgThoiTiet.Size = new Size(150, 16);
            prgThoiTiet.Style = ProgressBarStyle.Marquee;
            prgThoiTiet.TabIndex = 1;
            prgThoiTiet.Visible = false;
            //
            // pnlKetQua
            //
            pnlKetQua.BackColor = Color.FromArgb(241, 248, 246);
            pnlKetQua.BorderStyle = BorderStyle.FixedSingle;
            pnlKetQua.Controls.Add(lblTieuDeThoiTiet);
            pnlKetQua.Controls.Add(lblIcon);
            pnlKetQua.Controls.Add(lblChiTiet);
            pnlKetQua.Controls.Add(lblLoiKhuyen);
            pnlKetQua.Controls.Add(lblTrangThai);
            pnlKetQua.Location = new Point(15, 68);
            pnlKetQua.Name = "pnlKetQua";
            pnlKetQua.Size = new Size(440, 238);
            pnlKetQua.TabIndex = 2;
            //
            // lblTieuDeThoiTiet
            //
            lblTieuDeThoiTiet.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTieuDeThoiTiet.Location = new Point(10, 8);
            lblTieuDeThoiTiet.Name = "lblTieuDeThoiTiet";
            lblTieuDeThoiTiet.Size = new Size(418, 40);
            lblTieuDeThoiTiet.TabIndex = 0;
            lblTieuDeThoiTiet.Text = "Dự báo thời tiết";
            lblTieuDeThoiTiet.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblIcon
            //
            lblIcon.Font = new Font("Segoe UI Emoji", 36F);
            lblIcon.Location = new Point(10, 50);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new Size(90, 80);
            lblIcon.TabIndex = 1;
            lblIcon.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblChiTiet
            //
            lblChiTiet.Font = new Font("Segoe UI", 10.5F);
            lblChiTiet.Location = new Point(110, 50);
            lblChiTiet.Name = "lblChiTiet";
            lblChiTiet.Size = new Size(318, 85);
            lblChiTiet.TabIndex = 2;
            lblChiTiet.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblLoiKhuyen
            //
            lblLoiKhuyen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLoiKhuyen.ForeColor = Color.FromArgb(153, 60, 0);
            lblLoiKhuyen.Location = new Point(10, 140);
            lblLoiKhuyen.Name = "lblLoiKhuyen";
            lblLoiKhuyen.Size = new Size(418, 42);
            lblLoiKhuyen.TabIndex = 3;
            lblLoiKhuyen.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblTrangThai
            //
            lblTrangThai.ForeColor = Color.DimGray;
            lblTrangThai.Location = new Point(10, 186);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(418, 44);
            lblTrangThai.TabIndex = 4;
            //
            // pnlLoc
            //
            pnlLoc.Controls.Add(txtTim);
            pnlLoc.Controls.Add(chkChuaHoanThanh);
            pnlLoc.Controls.Add(lblTu);
            pnlLoc.Controls.Add(dtpTu);
            pnlLoc.Controls.Add(lblDen);
            pnlLoc.Controls.Add(dtpDen);
            pnlLoc.Controls.Add(btnTim);
            pnlLoc.Controls.Add(btnBoLoc);
            pnlLoc.Dock = DockStyle.Top;
            pnlLoc.Location = new Point(10, 382);
            pnlLoc.Name = "pnlLoc";
            pnlLoc.Size = new Size(1320, 48);
            pnlLoc.TabIndex = 2;
            //
            // txtTim
            //
            txtTim.Location = new Point(0, 13);
            txtTim.Name = "txtTim";
            txtTim.PlaceholderText = "Tìm tên chuyến hoặc địa điểm";
            txtTim.Size = new Size(260, 23);
            txtTim.TabIndex = 0;
            txtTim.KeyDown += TxtTim_KeyDown;
            //
            // chkChuaHoanThanh
            //
            chkChuaHoanThanh.AutoSize = true;
            chkChuaHoanThanh.Location = new Point(275, 15);
            chkChuaHoanThanh.Name = "chkChuaHoanThanh";
            chkChuaHoanThanh.Size = new Size(213, 19);
            chkChuaHoanThanh.TabIndex = 1;
            chkChuaHoanThanh.Text = "Chỉ hiện chuyến chưa hoàn thành";
            chkChuaHoanThanh.UseVisualStyleBackColor = true;
            chkChuaHoanThanh.CheckedChanged += BoLocThayDoi;
            //
            // lblTu
            //
            lblTu.AutoSize = true;
            lblTu.Location = new Point(515, 17);
            lblTu.Name = "lblTu";
            lblTu.Size = new Size(48, 15);
            lblTu.TabIndex = 2;
            lblTu.Text = "Từ ngày:";
            //
            // dtpTu
            //
            dtpTu.Checked = false;
            dtpTu.CustomFormat = "dd/MM/yyyy";
            dtpTu.Format = DateTimePickerFormat.Custom;
            dtpTu.Location = new Point(575, 13);
            dtpTu.Name = "dtpTu";
            dtpTu.ShowCheckBox = true;
            dtpTu.Size = new Size(140, 23);
            dtpTu.TabIndex = 3;
            dtpTu.ValueChanged += BoLocThayDoi;
            //
            // lblDen
            //
            lblDen.AutoSize = true;
            lblDen.Location = new Point(730, 17);
            lblDen.Name = "lblDen";
            lblDen.Size = new Size(56, 15);
            lblDen.TabIndex = 4;
            lblDen.Text = "Đến ngày:";
            //
            // dtpDen
            //
            dtpDen.Checked = false;
            dtpDen.CustomFormat = "dd/MM/yyyy";
            dtpDen.Format = DateTimePickerFormat.Custom;
            dtpDen.Location = new Point(795, 13);
            dtpDen.Name = "dtpDen";
            dtpDen.ShowCheckBox = true;
            dtpDen.Size = new Size(140, 23);
            dtpDen.TabIndex = 5;
            dtpDen.ValueChanged += BoLocThayDoi;
            //
            // btnTim
            //
            btnTim.Location = new Point(950, 11);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(85, 28);
            btnTim.TabIndex = 6;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += BtnTim_Click;
            //
            // btnBoLoc
            //
            btnBoLoc.Location = new Point(1043, 11);
            btnBoLoc.Name = "btnBoLoc";
            btnBoLoc.Size = new Size(85, 28);
            btnBoLoc.TabIndex = 7;
            btnBoLoc.Text = "Bỏ lọc";
            btnBoLoc.UseVisualStyleBackColor = true;
            btnBoLoc.Click += BtnBoLoc_Click;
            //
            // dgvChuyenDi
            //
            dgvChuyenDi.AllowUserToAddRows = false;
            dgvChuyenDi.AllowUserToDeleteRows = false;
            dgvChuyenDi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChuyenDi.BackgroundColor = Color.White;
            dgvChuyenDi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChuyenDi.Dock = DockStyle.Fill;
            dgvChuyenDi.Location = new Point(10, 430);
            dgvChuyenDi.MultiSelect = false;
            dgvChuyenDi.Name = "dgvChuyenDi";
            dgvChuyenDi.ReadOnly = true;
            dgvChuyenDi.RowHeadersVisible = false;
            dgvChuyenDi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChuyenDi.Size = new Size(1320, 320);
            dgvChuyenDi.TabIndex = 3;
            dgvChuyenDi.CellDoubleClick += DgvChuyenDi_CellDoubleClick;
            dgvChuyenDi.SelectionChanged += DgvChuyenDi_SelectionChanged;
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1340, 760);
            Controls.Add(dgvChuyenDi);
            Controls.Add(pnlLoc);
            Controls.Add(pnlTren);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(1100, 700);
            Name = "Form1";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kế hoạch dã ngoại";
            WindowState = FormWindowState.Maximized;
            Shown += Form1_Shown;
            pnlHeader.ResumeLayout(false);
            pnlNgonNgu.ResumeLayout(false);
            pnlNgonNgu.PerformLayout();
            pnlTren.ResumeLayout(false);
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoNguoi).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNganSach).EndInit();
            grpThoiTiet.ResumeLayout(false);
            pnlKetQua.ResumeLayout(false);
            pnlLoc.ResumeLayout(false);
            pnlLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenDi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTieuDe;
        private Panel pnlNgonNgu;
        private Label lblNgonNgu;
        private ComboBox cboNgonNgu;
        private Panel pnlTren;
        private GroupBox grpThongTin;
        private Label lblTenChuyen;
        private TextBox txtTenChuyen;
        private Label lblDiaDiem;
        private TextBox txtDiaDiem;
        private Label lblPhuongTien;
        private ComboBox cboPhuongTien;
        private CheckBox chkDaHoanThanh;
        private Label lblNgayDi;
        private DateTimePicker dtpNgayDi;
        private Label lblSoNguoi;
        private NumericUpDown nudSoNguoi;
        private Label lblNganSach;
        private NumericUpDown nudNganSach;
        private Label lblGhiChu;
        private TextBox txtGhiChu;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Panel pnlKhoangCach;
        private GroupBox grpThoiTiet;
        private Button btnXemThoiTiet;
        private ProgressBar prgThoiTiet;
        private Panel pnlKetQua;
        private Label lblTieuDeThoiTiet;
        private Label lblIcon;
        private Label lblChiTiet;
        private Label lblLoiKhuyen;
        private Label lblTrangThai;
        private Panel pnlLoc;
        private TextBox txtTim;
        private CheckBox chkChuaHoanThanh;
        private Label lblTu;
        private DateTimePicker dtpTu;
        private Label lblDen;
        private DateTimePicker dtpDen;
        private Button btnTim;
        private Button btnBoLoc;
        private DataGridView dgvChuyenDi;
    }
}
