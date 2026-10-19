namespace Bai5
{
    partial class UcDatTour
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpDatTour = new GroupBox();
            lblKhachHang = new Label();
            cboKhachHang = new ComboBox();
            lblTour = new Label();
            cboTour = new ComboBox();
            lblSoNguoi = new Label();
            nudSoNguoi = new NumericUpDown();
            lblConLai = new Label();
            btnDatTour = new Button();
            btnTaiLaiTyGia = new Button();
            pnlGia = new Panel();
            lblGiaNgoaiTe = new Label();
            lblTyGia = new Label();
            lblGiaVnd = new Label();
            lblTongTien = new Label();
            lblNguonTyGia = new Label();
            prgTyGia = new ProgressBar();
            lblTim = new Label();
            txtTim = new TextBox();
            chkLocThang = new CheckBox();
            dtpThang = new DateTimePicker();
            btnTim = new Button();
            btnBoLoc = new Button();
            btnHuyDat = new Button();
            dgvDatTour = new DataGridView();
            pnlTim = new Panel();
            lblTongDoanhThu = new Label();
            grpDatTour.SuspendLayout();
            pnlTim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoNguoi).BeginInit();
            pnlGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatTour).BeginInit();
            SuspendLayout();
            // 
            // grpDatTour
            // 
            grpDatTour.Dock = DockStyle.Top;
            grpDatTour.Controls.Add(lblKhachHang);
            grpDatTour.Controls.Add(cboKhachHang);
            grpDatTour.Controls.Add(lblTour);
            grpDatTour.Controls.Add(cboTour);
            grpDatTour.Controls.Add(lblSoNguoi);
            grpDatTour.Controls.Add(nudSoNguoi);
            grpDatTour.Controls.Add(lblConLai);
            grpDatTour.Controls.Add(btnDatTour);
            grpDatTour.Controls.Add(btnTaiLaiTyGia);
            grpDatTour.Controls.Add(pnlGia);
            grpDatTour.Location = new Point(12, 10);
            grpDatTour.Name = "grpDatTour";
            grpDatTour.Size = new Size(1080, 210);
            grpDatTour.TabIndex = 0;
            grpDatTour.TabStop = false;
            grpDatTour.Text = "Đặt tour mới";
            // 
            // lblKhachHang
            // 
            lblKhachHang.AutoSize = true;
            lblKhachHang.Location = new Point(15, 33);
            lblKhachHang.Name = "lblKhachHang";
            lblKhachHang.Size = new Size(72, 15);
            lblKhachHang.TabIndex = 0;
            lblKhachHang.Text = "Khách hàng:";
            // 
            // cboKhachHang
            // 
            cboKhachHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhachHang.FormattingEnabled = true;
            cboKhachHang.Location = new Point(110, 30);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(360, 23);
            cboKhachHang.TabIndex = 1;
            cboKhachHang.SelectedIndexChanged += CboKhachHang_SelectedIndexChanged;
            // 
            // lblTour
            // 
            lblTour.AutoSize = true;
            lblTour.Location = new Point(15, 73);
            lblTour.Name = "lblTour";
            lblTour.Size = new Size(32, 15);
            lblTour.TabIndex = 2;
            lblTour.Text = "Tour:";
            // 
            // cboTour
            // 
            cboTour.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTour.FormattingEnabled = true;
            cboTour.Location = new Point(110, 70);
            cboTour.Name = "cboTour";
            cboTour.Size = new Size(360, 23);
            cboTour.TabIndex = 3;
            cboTour.SelectedIndexChanged += CboTour_SelectedIndexChanged;
            // 
            // lblSoNguoi
            // 
            lblSoNguoi.AutoSize = true;
            lblSoNguoi.Location = new Point(15, 113);
            lblSoNguoi.Name = "lblSoNguoi";
            lblSoNguoi.Size = new Size(58, 15);
            lblSoNguoi.TabIndex = 4;
            lblSoNguoi.Text = "Số người:";
            // 
            // nudSoNguoi
            // 
            nudSoNguoi.Location = new Point(110, 110);
            nudSoNguoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoNguoi.Name = "nudSoNguoi";
            nudSoNguoi.Size = new Size(80, 23);
            nudSoNguoi.TabIndex = 5;
            nudSoNguoi.TextAlign = HorizontalAlignment.Right;
            nudSoNguoi.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoNguoi.ValueChanged += NudSoNguoi_ValueChanged;
            // 
            // lblConLai
            // 
            lblConLai.AutoSize = true;
            lblConLai.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblConLai.Location = new Point(205, 113);
            lblConLai.Name = "lblConLai";
            lblConLai.Size = new Size(70, 15);
            lblConLai.TabIndex = 6;
            lblConLai.Text = "Còn lại: —";
            // 
            // btnDatTour
            // 
            btnDatTour.BackColor = Color.FromArgb(0, 120, 112);
            btnDatTour.Enabled = false;
            btnDatTour.FlatStyle = FlatStyle.Flat;
            btnDatTour.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDatTour.ForeColor = Color.White;
            btnDatTour.Location = new Point(110, 152);
            btnDatTour.Name = "btnDatTour";
            btnDatTour.Size = new Size(160, 38);
            btnDatTour.TabIndex = 7;
            btnDatTour.Text = "Đặt tour";
            btnDatTour.UseVisualStyleBackColor = false;
            btnDatTour.Click += BtnDatTour_Click;
            // 
            // btnTaiLaiTyGia
            // 
            btnTaiLaiTyGia.Location = new Point(280, 152);
            btnTaiLaiTyGia.Name = "btnTaiLaiTyGia";
            btnTaiLaiTyGia.Size = new Size(190, 38);
            btnTaiLaiTyGia.TabIndex = 8;
            btnTaiLaiTyGia.Text = "Tải lại tỷ giá";
            btnTaiLaiTyGia.UseVisualStyleBackColor = true;
            btnTaiLaiTyGia.Click += BtnTaiLaiTyGia_Click;
            // 
            // pnlGia
            // 
            pnlGia.BackColor = Color.FromArgb(240, 248, 247);
            pnlGia.BorderStyle = BorderStyle.FixedSingle;
            pnlGia.Controls.Add(lblGiaNgoaiTe);
            pnlGia.Controls.Add(lblTyGia);
            pnlGia.Controls.Add(lblGiaVnd);
            pnlGia.Controls.Add(lblTongTien);
            pnlGia.Controls.Add(lblNguonTyGia);
            pnlGia.Controls.Add(prgTyGia);
            pnlGia.Location = new Point(500, 25);
            pnlGia.Name = "pnlGia";
            pnlGia.Size = new Size(560, 168);
            pnlGia.TabIndex = 9;
            // 
            // lblGiaNgoaiTe
            // 
            lblGiaNgoaiTe.AutoSize = true;
            lblGiaNgoaiTe.Font = new Font("Segoe UI", 10F);
            lblGiaNgoaiTe.Location = new Point(14, 12);
            lblGiaNgoaiTe.Name = "lblGiaNgoaiTe";
            lblGiaNgoaiTe.Size = new Size(160, 19);
            lblGiaNgoaiTe.TabIndex = 0;
            lblGiaNgoaiTe.Text = "Giá/người (ngoại tệ): —";
            // 
            // lblTyGia
            // 
            lblTyGia.AutoSize = true;
            lblTyGia.Font = new Font("Segoe UI", 10F);
            lblTyGia.Location = new Point(14, 40);
            lblTyGia.Name = "lblTyGia";
            lblTyGia.Size = new Size(64, 19);
            lblTyGia.TabIndex = 1;
            lblTyGia.Text = "Tỷ giá: —";
            // 
            // lblGiaVnd
            // 
            lblGiaVnd.AutoSize = true;
            lblGiaVnd.Font = new Font("Segoe UI", 10F);
            lblGiaVnd.Location = new Point(14, 68);
            lblGiaVnd.Name = "lblGiaVnd";
            lblGiaVnd.Size = new Size(140, 19);
            lblGiaVnd.TabIndex = 2;
            lblGiaVnd.Text = "Giá/người (VND): —";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.FromArgb(180, 40, 30);
            lblTongTien.Location = new Point(12, 98);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(120, 25);
            lblTongTien.TabIndex = 3;
            lblTongTien.Text = "Tổng tiền: —";
            // 
            // lblNguonTyGia
            // 
            lblNguonTyGia.AutoSize = true;
            lblNguonTyGia.ForeColor = Color.DimGray;
            lblNguonTyGia.Location = new Point(14, 138);
            lblNguonTyGia.Name = "lblNguonTyGia";
            lblNguonTyGia.Size = new Size(0, 15);
            lblNguonTyGia.TabIndex = 4;
            // 
            // prgTyGia
            // 
            prgTyGia.Location = new Point(395, 14);
            prgTyGia.MarqueeAnimationSpeed = 25;
            prgTyGia.Name = "prgTyGia";
            prgTyGia.Size = new Size(150, 16);
            prgTyGia.Style = ProgressBarStyle.Marquee;
            prgTyGia.TabIndex = 5;
            prgTyGia.Visible = false;
            // 
            // lblTim
            // 
            lblTim.AutoSize = true;
            lblTim.Location = new Point(0, 12);
            lblTim.Name = "lblTim";
            lblTim.Size = new Size(152, 15);
            lblTim.TabIndex = 1;
            lblTim.Text = "Tìm (tên khách / tên tour):";
            // 
            // txtTim
            // 
            txtTim.Location = new Point(158, 9);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(250, 23);
            txtTim.TabIndex = 2;
            txtTim.KeyDown += TxtTim_KeyDown;
            // 
            // chkLocThang
            // 
            chkLocThang.AutoSize = true;
            chkLocThang.Location = new Point(428, 11);
            chkLocThang.Name = "chkLocThang";
            chkLocThang.Size = new Size(118, 19);
            chkLocThang.TabIndex = 3;
            chkLocThang.Text = "Tháng khởi hành:";
            chkLocThang.UseVisualStyleBackColor = true;
            chkLocThang.CheckedChanged += ChkLocThang_CheckedChanged;
            // 
            // dtpThang
            // 
            dtpThang.CustomFormat = "MM/yyyy";
            dtpThang.Enabled = false;
            dtpThang.Format = DateTimePickerFormat.Custom;
            dtpThang.Location = new Point(553, 9);
            dtpThang.Name = "dtpThang";
            dtpThang.ShowUpDown = true;
            dtpThang.Size = new Size(95, 23);
            dtpThang.TabIndex = 4;
            dtpThang.ValueChanged += DtpThang_ValueChanged;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(663, 7);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(80, 27);
            btnTim.TabIndex = 5;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += BtnTim_Click;
            // 
            // btnBoLoc
            // 
            btnBoLoc.Location = new Point(751, 7);
            btnBoLoc.Name = "btnBoLoc";
            btnBoLoc.Size = new Size(80, 27);
            btnBoLoc.TabIndex = 6;
            btnBoLoc.Text = "Bỏ lọc";
            btnBoLoc.UseVisualStyleBackColor = true;
            btnBoLoc.Click += BtnBoLoc_Click;
            // 
            // btnHuyDat
            // 
            btnHuyDat.ForeColor = Color.Firebrick;
            btnHuyDat.Location = new Point(851, 7);
            btnHuyDat.Name = "btnHuyDat";
            btnHuyDat.Size = new Size(120, 27);
            btnHuyDat.TabIndex = 7;
            btnHuyDat.Text = "Hủy đơn đã chọn";
            btnHuyDat.UseVisualStyleBackColor = true;
            btnHuyDat.Click += BtnHuyDat_Click;
            // 
            // pnlTim
            // 
            pnlTim.Controls.Add(lblTim);
            pnlTim.Controls.Add(txtTim);
            pnlTim.Controls.Add(chkLocThang);
            pnlTim.Controls.Add(dtpThang);
            pnlTim.Controls.Add(btnTim);
            pnlTim.Controls.Add(btnBoLoc);
            pnlTim.Controls.Add(btnHuyDat);
            pnlTim.Dock = DockStyle.Top;
            pnlTim.Name = "pnlTim";
            pnlTim.Size = new Size(1082, 44);
            pnlTim.TabIndex = 1;
            // 
            // dgvDatTour
            // 
            dgvDatTour.AllowUserToAddRows = false;
            dgvDatTour.AllowUserToDeleteRows = false;
            dgvDatTour.Dock = DockStyle.Fill;
            dgvDatTour.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDatTour.BackgroundColor = Color.White;
            dgvDatTour.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatTour.Location = new Point(12, 268);
            dgvDatTour.MultiSelect = false;
            dgvDatTour.Name = "dgvDatTour";
            dgvDatTour.ReadOnly = true;
            dgvDatTour.RowHeadersVisible = false;
            dgvDatTour.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatTour.Size = new Size(1080, 322);
            dgvDatTour.TabIndex = 8;
            // 
            // lblTongDoanhThu
            // 
            lblTongDoanhThu.Dock = DockStyle.Bottom;
            lblTongDoanhThu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTongDoanhThu.ForeColor = Color.FromArgb(0, 100, 90);
            lblTongDoanhThu.Location = new Point(12, 600);
            lblTongDoanhThu.Name = "lblTongDoanhThu";
            lblTongDoanhThu.Size = new Size(1082, 36);
            lblTongDoanhThu.TextAlign = ContentAlignment.MiddleLeft;
            lblTongDoanhThu.TabIndex = 9;
            lblTongDoanhThu.Text = "Tổng doanh thu: 0 đ";
            // 
            // UcDatTour
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvDatTour);
            Controls.Add(lblTongDoanhThu);
            Controls.Add(pnlTim);
            Controls.Add(grpDatTour);
            Name = "UcDatTour";
            Padding = new Padding(12, 10, 12, 10);
            Size = new Size(1106, 635);
            grpDatTour.ResumeLayout(false);
            pnlTim.ResumeLayout(false);
            pnlTim.PerformLayout();
            grpDatTour.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoNguoi).EndInit();
            pnlGia.ResumeLayout(false);
            pnlGia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatTour).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpDatTour;
        private Label lblKhachHang;
        private ComboBox cboKhachHang;
        private Label lblTour;
        private ComboBox cboTour;
        private Label lblSoNguoi;
        private NumericUpDown nudSoNguoi;
        private Label lblConLai;
        private Button btnDatTour;
        private Button btnTaiLaiTyGia;
        private Panel pnlGia;
        private Label lblGiaNgoaiTe;
        private Label lblTyGia;
        private Label lblGiaVnd;
        private Label lblTongTien;
        private Label lblNguonTyGia;
        private ProgressBar prgTyGia;
        private Label lblTim;
        private TextBox txtTim;
        private CheckBox chkLocThang;
        private DateTimePicker dtpThang;
        private Button btnTim;
        private Button btnBoLoc;
        private Button btnHuyDat;
        private DataGridView dgvDatTour;
        private Panel pnlTim;
        private Label lblTongDoanhThu;
    }
}
