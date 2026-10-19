namespace Bai5
{
    partial class UcTour
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
            lblMaTour = new Label();
            txtMaTour = new TextBox();
            lblTenTour = new Label();
            txtTenTour = new TextBox();
            lblDiemDen = new Label();
            txtDiemDen = new TextBox();
            lblNgoaiTe = new Label();
            cboNgoaiTe = new ComboBox();
            lblGia = new Label();
            nudGia = new NumericUpDown();
            lblKhoiHanh = new Label();
            dtpKhoiHanh = new DateTimePicker();
            lblSoCho = new Label();
            nudSoCho = new NumericUpDown();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTim = new Label();
            txtTim = new TextBox();
            btnTim = new Button();
            btnHienTatCa = new Button();
            dgvTour = new DataGridView();
            pnlTim = new Panel();
            grpThongTin.SuspendLayout();
            pnlTim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSoCho).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTour).BeginInit();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Dock = DockStyle.Top;
            grpThongTin.Controls.Add(lblMaTour);
            grpThongTin.Controls.Add(txtMaTour);
            grpThongTin.Controls.Add(lblTenTour);
            grpThongTin.Controls.Add(txtTenTour);
            grpThongTin.Controls.Add(lblDiemDen);
            grpThongTin.Controls.Add(txtDiemDen);
            grpThongTin.Controls.Add(lblNgoaiTe);
            grpThongTin.Controls.Add(cboNgoaiTe);
            grpThongTin.Controls.Add(lblGia);
            grpThongTin.Controls.Add(nudGia);
            grpThongTin.Controls.Add(lblKhoiHanh);
            grpThongTin.Controls.Add(dtpKhoiHanh);
            grpThongTin.Controls.Add(lblSoCho);
            grpThongTin.Controls.Add(nudSoCho);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLamMoi);
            grpThongTin.Location = new Point(12, 10);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(1080, 170);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin tour";
            // 
            // lblMaTour
            // 
            lblMaTour.AutoSize = true;
            lblMaTour.Location = new Point(15, 33);
            lblMaTour.Name = "lblMaTour";
            lblMaTour.Size = new Size(52, 15);
            lblMaTour.TabIndex = 0;
            lblMaTour.Text = "Mã tour:";
            // 
            // txtMaTour
            // 
            txtMaTour.BackColor = Color.Gainsboro;
            txtMaTour.Location = new Point(110, 30);
            txtMaTour.Name = "txtMaTour";
            txtMaTour.ReadOnly = true;
            txtMaTour.Size = new Size(90, 23);
            txtMaTour.TabIndex = 1;
            txtMaTour.TabStop = false;
            // 
            // lblTenTour
            // 
            lblTenTour.AutoSize = true;
            lblTenTour.Location = new Point(225, 33);
            lblTenTour.Name = "lblTenTour";
            lblTenTour.Size = new Size(56, 15);
            lblTenTour.TabIndex = 2;
            lblTenTour.Text = "Tên tour:";
            // 
            // txtTenTour
            // 
            txtTenTour.Location = new Point(310, 30);
            txtTenTour.MaxLength = 100;
            txtTenTour.Name = "txtTenTour";
            txtTenTour.Size = new Size(380, 23);
            txtTenTour.TabIndex = 3;
            // 
            // lblDiemDen
            // 
            lblDiemDen.AutoSize = true;
            lblDiemDen.Location = new Point(715, 33);
            lblDiemDen.Name = "lblDiemDen";
            lblDiemDen.Size = new Size(61, 15);
            lblDiemDen.TabIndex = 4;
            lblDiemDen.Text = "Điểm đến:";
            // 
            // txtDiemDen
            // 
            txtDiemDen.Location = new Point(800, 30);
            txtDiemDen.MaxLength = 50;
            txtDiemDen.Name = "txtDiemDen";
            txtDiemDen.Size = new Size(260, 23);
            txtDiemDen.TabIndex = 5;
            // 
            // lblNgoaiTe
            // 
            lblNgoaiTe.AutoSize = true;
            lblNgoaiTe.Location = new Point(15, 75);
            lblNgoaiTe.Name = "lblNgoaiTe";
            lblNgoaiTe.Size = new Size(56, 15);
            lblNgoaiTe.TabIndex = 6;
            lblNgoaiTe.Text = "Ngoại tệ:";
            // 
            // cboNgoaiTe
            // 
            cboNgoaiTe.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNgoaiTe.FormattingEnabled = true;
            cboNgoaiTe.Items.AddRange(new object[] { "THB", "KRW", "JPY", "USD" });
            cboNgoaiTe.Location = new Point(110, 72);
            cboNgoaiTe.Name = "cboNgoaiTe";
            cboNgoaiTe.Size = new Size(90, 23);
            cboNgoaiTe.TabIndex = 7;
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.Location = new Point(225, 75);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(63, 15);
            lblGia.TabIndex = 8;
            lblGia.Text = "Giá/người:";
            // 
            // nudGia
            // 
            nudGia.DecimalPlaces = 2;
            nudGia.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            nudGia.Location = new Point(310, 72);
            nudGia.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudGia.Name = "nudGia";
            nudGia.Size = new Size(160, 23);
            nudGia.TabIndex = 9;
            nudGia.TextAlign = HorizontalAlignment.Right;
            nudGia.ThousandsSeparator = true;
            // 
            // lblKhoiHanh
            // 
            lblKhoiHanh.AutoSize = true;
            lblKhoiHanh.Location = new Point(495, 75);
            lblKhoiHanh.Name = "lblKhoiHanh";
            lblKhoiHanh.Size = new Size(65, 15);
            lblKhoiHanh.TabIndex = 10;
            lblKhoiHanh.Text = "Khởi hành:";
            // 
            // dtpKhoiHanh
            // 
            dtpKhoiHanh.CustomFormat = "dd/MM/yyyy";
            dtpKhoiHanh.Format = DateTimePickerFormat.Custom;
            dtpKhoiHanh.Location = new Point(570, 72);
            dtpKhoiHanh.Name = "dtpKhoiHanh";
            dtpKhoiHanh.Size = new Size(120, 23);
            dtpKhoiHanh.TabIndex = 11;
            // 
            // lblSoCho
            // 
            lblSoCho.AutoSize = true;
            lblSoCho.Location = new Point(715, 75);
            lblSoCho.Name = "lblSoCho";
            lblSoCho.Size = new Size(80, 15);
            lblSoCho.TabIndex = 12;
            lblSoCho.Text = "Số chỗ tối đa:";
            // 
            // nudSoCho
            // 
            nudSoCho.Location = new Point(800, 72);
            nudSoCho.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudSoCho.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoCho.Name = "nudSoCho";
            nudSoCho.Size = new Size(90, 23);
            nudSoCho.TabIndex = 13;
            nudSoCho.TextAlign = HorizontalAlignment.Right;
            nudSoCho.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // btnThem
            // 
            btnThem.Location = new Point(110, 118);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 32);
            btnThem.TabIndex = 14;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += BtnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(220, 118);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 32);
            btnSua.TabIndex = 15;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += BtnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(330, 118);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 32);
            btnXoa.TabIndex = 16;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += BtnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(440, 118);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 32);
            btnLamMoi.TabIndex = 17;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += BtnLamMoi_Click;
            // 
            // lblTim
            // 
            lblTim.AutoSize = true;
            lblTim.Location = new Point(0, 12);
            lblTim.Name = "lblTim";
            lblTim.Size = new Size(141, 15);
            lblTim.TabIndex = 1;
            lblTim.Text = "Tìm theo tên / điểm đến:";
            // 
            // txtTim
            // 
            txtTim.Location = new Point(153, 9);
            txtTim.Name = "txtTim";
            txtTim.PlaceholderText = "Ví dụ: Bangkok, Nhật Bản…";
            txtTim.Size = new Size(300, 23);
            txtTim.TabIndex = 2;
            txtTim.KeyDown += TxtTim_KeyDown;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(463, 7);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(80, 27);
            btnTim.TabIndex = 3;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += BtnTim_Click;
            // 
            // btnHienTatCa
            // 
            btnHienTatCa.Location = new Point(551, 7);
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
            // dgvTour
            // 
            dgvTour.AllowUserToAddRows = false;
            dgvTour.AllowUserToDeleteRows = false;
            dgvTour.Dock = DockStyle.Fill;
            dgvTour.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTour.BackgroundColor = Color.White;
            dgvTour.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTour.Location = new Point(12, 230);
            dgvTour.MultiSelect = false;
            dgvTour.Name = "dgvTour";
            dgvTour.ReadOnly = true;
            dgvTour.RowHeadersVisible = false;
            dgvTour.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTour.Size = new Size(1080, 392);
            dgvTour.TabIndex = 5;
            dgvTour.SelectionChanged += DgvTour_SelectionChanged;
            // 
            // UcTour
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvTour);
            Controls.Add(pnlTim);
            Controls.Add(grpThongTin);
            Name = "UcTour";
            Padding = new Padding(12, 10, 12, 10);
            Size = new Size(1106, 635);
            grpThongTin.ResumeLayout(false);
            pnlTim.ResumeLayout(false);
            pnlTim.PerformLayout();
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSoCho).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTour).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaTour;
        private TextBox txtMaTour;
        private Label lblTenTour;
        private TextBox txtTenTour;
        private Label lblDiemDen;
        private TextBox txtDiemDen;
        private Label lblNgoaiTe;
        private ComboBox cboNgoaiTe;
        private Label lblGia;
        private NumericUpDown nudGia;
        private Label lblKhoiHanh;
        private DateTimePicker dtpKhoiHanh;
        private Label lblSoCho;
        private NumericUpDown nudSoCho;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTim;
        private TextBox txtTim;
        private Button btnTim;
        private Button btnHienTatCa;
        private DataGridView dgvTour;
        private Panel pnlTim;
    }
}
