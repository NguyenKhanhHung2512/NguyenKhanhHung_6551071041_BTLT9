namespace Bai5
{
    partial class UcKhachHang
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
            grpThongTin = new GroupBox();
            lblMaKH = new Label();
            txtMaKH = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTim = new Label();
            txtTim = new TextBox();
            btnTim = new Button();
            btnHienTatCa = new Button();
            dgvKhachHang = new DataGridView();
            pnlTim = new Panel();
            grpThongTin.SuspendLayout();
            pnlTim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Dock = DockStyle.Top;
            grpThongTin.Controls.Add(lblMaKH);
            grpThongTin.Controls.Add(txtMaKH);
            grpThongTin.Controls.Add(lblHoTen);
            grpThongTin.Controls.Add(txtHoTen);
            grpThongTin.Controls.Add(lblSoDienThoai);
            grpThongTin.Controls.Add(txtSoDienThoai);
            grpThongTin.Controls.Add(lblEmail);
            grpThongTin.Controls.Add(txtEmail);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLamMoi);
            grpThongTin.Location = new Point(12, 10);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(1080, 170);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin khách hàng";
            // 
            // lblMaKH
            // 
            lblMaKH.AutoSize = true;
            lblMaKH.Location = new Point(15, 33);
            lblMaKH.Name = "lblMaKH";
            lblMaKH.Size = new Size(47, 15);
            lblMaKH.TabIndex = 0;
            lblMaKH.Text = "Mã KH:";
            // 
            // txtMaKH
            // 
            txtMaKH.BackColor = Color.Gainsboro;
            txtMaKH.Location = new Point(110, 30);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.ReadOnly = true;
            txtMaKH.Size = new Size(90, 23);
            txtMaKH.TabIndex = 1;
            txtMaKH.TabStop = false;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(225, 33);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(46, 15);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(310, 30);
            txtHoTen.MaxLength = 100;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(380, 23);
            txtHoTen.TabIndex = 3;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Location = new Point(15, 75);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(79, 15);
            lblSoDienThoai.TabIndex = 4;
            lblSoDienThoai.Text = "Số điện thoại:";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(110, 72);
            txtSoDienThoai.MaxLength = 15;
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(160, 23);
            txtSoDienThoai.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(285, 75);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(330, 72);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "(không bắt buộc)";
            txtEmail.Size = new Size(360, 23);
            txtEmail.TabIndex = 7;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(110, 118);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 32);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += BtnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(220, 118);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 32);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += BtnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(330, 118);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 32);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += BtnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(440, 118);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 32);
            btnLamMoi.TabIndex = 11;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += BtnLamMoi_Click;
            // 
            // lblTim
            // 
            lblTim.AutoSize = true;
            lblTim.Location = new Point(0, 12);
            lblTim.Name = "lblTim";
            lblTim.Size = new Size(110, 15);
            lblTim.TabIndex = 1;
            lblTim.Text = "Tìm theo tên / SĐT:";
            // 
            // txtTim
            // 
            txtTim.Location = new Point(123, 9);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(300, 23);
            txtTim.TabIndex = 2;
            txtTim.KeyDown += TxtTim_KeyDown;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(433, 7);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(80, 27);
            btnTim.TabIndex = 3;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += BtnTim_Click;
            // 
            // btnHienTatCa
            // 
            btnHienTatCa.Location = new Point(521, 7);
            btnHienTatCa.Name = "btnHienTatCa";
            btnHienTatCa.Size = new Size(95, 27);
            btnHienTatCa.TabIndex = 4;
            btnHienTatCa.Text = "Hiện tất cả";
            btnHienTatCa.UseVisualStyleBackColor = true;
            btnHienTatCa.Click += BtnHienTatCa_Click;
            // 
            // pnlTim
            // 
            pnlTim.Controls.Add(lblTim);
            pnlTim.Controls.Add(txtTim);
            pnlTim.Controls.Add(btnTim);
            pnlTim.Controls.Add(btnHienTatCa);
            pnlTim.Dock = DockStyle.Top;
            pnlTim.Name = "pnlTim";
            pnlTim.Size = new Size(1082, 44);
            pnlTim.TabIndex = 1;
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AllowUserToDeleteRows = false;
            dgvKhachHang.Dock = DockStyle.Fill;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.BackgroundColor = Color.White;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Location = new Point(12, 230);
            dgvKhachHang.MultiSelect = false;
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersVisible = false;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.Size = new Size(1080, 392);
            dgvKhachHang.TabIndex = 5;
            dgvKhachHang.SelectionChanged += DgvKhachHang_SelectionChanged;
            // 
            // UcKhachHang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvKhachHang);
            Controls.Add(pnlTim);
            Controls.Add(grpThongTin);
            Name = "UcKhachHang";
            Padding = new Padding(12, 10, 12, 10);
            Size = new Size(1106, 635);
            grpThongTin.ResumeLayout(false);
            pnlTim.ResumeLayout(false);
            pnlTim.PerformLayout();
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaKH;
        private TextBox txtMaKH;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTim;
        private TextBox txtTim;
        private Button btnTim;
        private Button btnHienTatCa;
        private DataGridView dgvKhachHang;
        private Panel pnlTim;
    }
}
