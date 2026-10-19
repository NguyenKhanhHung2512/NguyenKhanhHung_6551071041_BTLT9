using Bai1.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Bai1
{
    public partial class FormChiTieu : Form
    {
        private int _selectedMaCT = -1;
        private bool _isInitializing = true;
        private readonly CultureInfo _vnCulture = new CultureInfo("vi-VN");

        public FormChiTieu()
        {
            // Thiết lập văn hóa tiếng Việt cho định dạng ngày và số
            CultureInfo.DefaultThreadCurrentCulture = _vnCulture;
            CultureInfo.DefaultThreadCurrentUICulture = _vnCulture;
            InitializeComponent();
        }

        private void FormChiTieu_Load(object sender, EventArgs e)
        {
            _isInitializing = true;
            InitControls();
            _isInitializing = false;
            LoadData();

            // Lắng nghe thay đổi bộ lọc để tự động lọc nhanh
            cboLocLoaiChi.SelectedIndexChanged += (s, ev) => { if (!_isInitializing) LoadData(); };
            dtpTuNgay.ValueChanged += (s, ev) => { if (!_isInitializing) LoadData(); };
            dtpDenNgay.ValueChanged += (s, ev) => { if (!_isInitializing) LoadData(); };
        }

        private void InitControls()
        {
            // Nạp danh mục loại chi cho combobox nhập liệu
            cboLoaiChi.Items.Clear();
            cboLoaiChi.Items.AddRange(new object[] { "Ăn uống", "Đi lại", "Học tập", "Giải trí", "Khác" });
            cboLoaiChi.SelectedIndex = 0;

            // Nạp combobox lọc loại chi
            cboLocLoaiChi.Items.Clear();
            cboLocLoaiChi.Items.Add("Tất cả");
            cboLocLoaiChi.Items.AddRange(new object[] { "Ăn uống", "Đi lại", "Học tập", "Giải trí", "Khác" });
            cboLocLoaiChi.SelectedIndex = 0;

            // Khoảng ngày mặc định: Đầu tháng hiện tại -> Hôm nay
            var today = DateTime.Today;
            dtpTuNgay.Value = new DateTime(today.Year, today.Month, 1);
            dtpDenNgay.Value = today;
            dtpNgayChi.Value = today;

            // Thiết lập cấu hình DataGridView
            dgvChiTieu.AutoGenerateColumns = false;
            dgvChiTieu.Columns.Clear();

            // Cột Mã
            dgvChiTieu.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaCt",
                HeaderText = "Mã",
                Width = 65,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "D3",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            // Cột Ngày chi
            dgvChiTieu.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayChi",
                HeaderText = "Ngày chi",
                Width = 95,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            // Cột Nội dung
            dgvChiTieu.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NoiDung",
                HeaderText = "Nội dung",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Cột Loại chi
            dgvChiTieu.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LoaiChi",
                HeaderText = "Loại chi",
                Width = 110
            });

            // Cột Số tiền
            dgvChiTieu.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoTien",
                HeaderText = "Số tiền",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            // Cột Ghi chú
            dgvChiTieu.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GhiChu",
                HeaderText = "Ghi chú",
                Width = 160
            });
        }

        // ======================= TRUY VẤN VÀ TÍNH TOÁN =======================
        public void LoadData()
        {
            try
            {
                using var db = new QL_ChiTieuContext();

                string keyword = txtTimNoiDung.Text.Trim().ToLower();
                string loaiChi = cboLocLoaiChi.SelectedItem?.ToString() ?? "Tất cả";
                var tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value.Date);
                var denNgay = DateOnly.FromDateTime(dtpDenNgay.Value.Date);

                IQueryable<ChiTieu> query = db.ChiTieus.AsNoTracking();

                // Lọc theo khoảng ngày (Từ ngày - Đến ngày)
                query = query.Where(x => x.NgayChi >= tuNgay && x.NgayChi <= denNgay);

                // Lọc theo loại chi
                if (loaiChi != "Tất cả")
                {
                    query = query.Where(x => x.LoaiChi == loaiChi);
                }

                // Lọc theo từ khóa nội dung
                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(x => x.NoiDung.ToLower().Contains(keyword));
                }

                var list = query.OrderBy(x => x.NgayChi).ThenBy(x => x.MaCt).ToList();
                dgvChiTieu.DataSource = list;

                // Cập nhật nhãn Tổng chi
                decimal tongChi = list.Sum(x => x.SoTien);
                lblTongChi.Text = $"Tổng chi: {tongChi.ToString("N0", _vnCulture)} đ";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi xảy ra khi truy vấn dữ liệu chi tiêu từ CSDL.");
                MessageBox.Show("Có lỗi xảy ra khi nạp dữ liệu chi tiêu. Vui lòng kiểm tra kết nối CSDL!",
                    "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================= KIỂM TRA HỢP LỆ =======================
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                MessageBox.Show("Nội dung khoản chi không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDung.Focus();
                return false;
            }

            if (numSoTien.Value <= 0)
            {
                MessageBox.Show("Số tiền chi tiêu phải lớn hơn 0!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSoTien.Focus();
                return false;
            }

            if (dtpNgayChi.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Ngày chi không được lớn hơn hôm nay!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayChi.Focus();
                return false;
            }

            return true;
        }

        // ======================= THAO TÁC CRUD =======================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using var db = new QL_ChiTieuContext();
                var item = new ChiTieu
                {
                    NgayChi = DateOnly.FromDateTime(dtpNgayChi.Value.Date),
                    NoiDung = txtNoiDung.Text.Trim(),
                    LoaiChi = cboLoaiChi.SelectedItem?.ToString() ?? "Khác",
                    SoTien = numSoTien.Value,
                    GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim()
                };

                db.ChiTieus.Add(item);
                db.SaveChanges();

                Log.Information("Thêm khoản chi thành công: MaCT = {MaCT}, Số tiền = {SoTien}, Loại chi = {LoaiChi}",
                    item.MaCt, item.SoTien, item.LoaiChi);
                MessageBox.Show("Thêm khoản chi mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnLamMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi xảy ra khi thêm mới khoản chi vào CSDL.");
                MessageBox.Show("Không thể thêm dữ liệu. Vui lòng kiểm tra lại kết nối CSDL!",
                    "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaCT <= 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng khoản chi cần sửa trên bảng danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                using var db = new QL_ChiTieuContext();
                var item = db.ChiTieus.FirstOrDefault(x => x.MaCt == _selectedMaCT);

                if (item == null)
                {
                    MessageBox.Show("Khoản chi này không còn tồn tại trên hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadData();
                    return;
                }

                item.NgayChi = DateOnly.FromDateTime(dtpNgayChi.Value.Date);
                item.NoiDung = txtNoiDung.Text.Trim();
                item.LoaiChi = cboLoaiChi.SelectedItem?.ToString() ?? "Khác";
                item.SoTien = numSoTien.Value;
                item.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();

                db.SaveChanges();

                Log.Information("Cập nhật khoản chi thành công: MaCT = {MaCT}, Số tiền = {SoTien}", _selectedMaCT, item.SoTien);
                MessageBox.Show("Cập nhật khoản chi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi xảy ra khi cập nhật khoản chi: MaCT = {MaCT}", _selectedMaCT);
                MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra kết nối CSDL!",
                    "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaCT <= 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng khoản chi cần xóa trên bảng danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = MessageBox.Show($"Bạn có chắc chắn muốn xóa khoản chi [Mã: {_selectedMaCT}] không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog != DialogResult.Yes) return;

            try
            {
                using var db = new QL_ChiTieuContext();
                var item = db.ChiTieus.FirstOrDefault(x => x.MaCt == _selectedMaCT);

                if (item != null)
                {
                    db.ChiTieus.Remove(item);
                    db.SaveChanges();

                    Log.Information("Xóa khoản chi thành công: MaCT = {MaCT}", _selectedMaCT);
                    MessageBox.Show("Đã xóa khoản chi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi xảy ra khi xóa khoản chi: MaCT = {MaCT}", _selectedMaCT);
                MessageBox.Show("Không thể xóa khoản chi này. Vui lòng kiểm tra kết nối CSDL!",
                    "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _selectedMaCT = -1;
            txtNoiDung.Clear();
            txtGhiChu.Clear();
            numSoTien.Value = 0;
            dtpNgayChi.Value = DateTime.Today;
            if (cboLoaiChi.Items.Count > 0) cboLoaiChi.SelectedIndex = 0;

            _isInitializing = true;
            txtTimNoiDung.Clear();
            if (cboLocLoaiChi.Items.Count > 0) cboLocLoaiChi.SelectedIndex = 0;
            var today = DateTime.Today;
            dtpTuNgay.Value = new DateTime(today.Year, today.Month, 1);
            dtpDenNgay.Value = today;
            _isInitializing = false;

            dgvChiTieu.ClearSelection();
            LoadData();
        }

        // Bấm vào 1 dòng trong DataGridView để hiển thị dữ liệu lên form
        private void dgvChiTieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvChiTieu.Rows.Count) return;

            if (dgvChiTieu.Rows[e.RowIndex].DataBoundItem is ChiTieu item)
            {
                _selectedMaCT = item.MaCt;
                txtNoiDung.Text = item.NoiDung;

                if (!cboLoaiChi.Items.Contains(item.LoaiChi))
                {
                    cboLoaiChi.Items.Add(item.LoaiChi);
                }
                cboLoaiChi.SelectedItem = item.LoaiChi;

                numSoTien.Value = item.SoTien;
                dtpNgayChi.Value = item.NgayChi.ToDateTime(TimeOnly.MinValue);
                txtGhiChu.Text = item.GhiChu ?? string.Empty;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtTimNoiDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadData();
            }
        }
    }
}