using Bai2.Helpers;
using Bai2.Models;
using Bai2.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai2
{
    public partial class FormKhachThue : Form
    {
        private int _selectedMaKhach = -1;
        private bool _isInitializing = true;
        private List<ProvinceItem> _provinces = new();
        private readonly CultureInfo _vnCulture = new CultureInfo("vi-VN");

        public FormKhachThue()
        {
            CultureInfo.DefaultThreadCurrentCulture = _vnCulture;
            CultureInfo.DefaultThreadCurrentUICulture = _vnCulture;
            InitializeComponent();
        }

        private async void FormKhachThue_Load(object sender, EventArgs e)
        {
            _isInitializing = true;
            SetupDataGridView();
            LoadPhongToCombobox();
            await LoadProvincesAsync();
            _isInitializing = false;

            await LoadDataAsync();
        }

        private void SetupDataGridView()
        {
            dgvKhachThue.AutoGenerateColumns = false;
            dgvKhachThue.Columns.Clear();

            dgvKhachThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HoTen",
                HeaderText = "Họ tên",
                Width = 135
            });

            dgvKhachThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoDienThoai",
                HeaderText = "SĐT",
                Width = 100
            });

            dgvKhachThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenPhong",
                HeaderText = "Phòng",
                Width = 65,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvKhachThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GiaThueFormatted",
                HeaderText = "Giá thuê",
                Width = 105,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvKhachThue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "QueQuan",
                HeaderText = "Quê quán",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvKhachThue.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "DaDangKyTamTru",
                HeaderText = "Tạm trú",
                Width = 75
            });
        }

        private void LoadPhongToCombobox()
        {
            try
            {
                using var db = DbContextHelper.GetContext();
                var listPhong = db.PhongTros
                    .OrderBy(p => p.TenPhong)
                    .Select(p => new PhongTroDisplayItem
                    {
                        MaPhong = p.MaPhong,
                        TenPhong = p.TenPhong,
                        GiaThue = p.GiaThue,
                        TinhTrang = p.TinhTrang
                    })
                    .ToList();

                cboPhong.DataSource = listPhong;
                cboPhong.DisplayMember = "DisplayText";
                cboPhong.ValueMember = "MaPhong";
                cboPhong.SelectedIndex = -1;

                // Combobox lọc theo phòng
                var listLocPhong = new List<PhongTroDisplayItem>
                {
                    new PhongTroDisplayItem { MaPhong = 0, TenPhong = "Tất cả" }
                };
                listLocPhong.AddRange(listPhong);

                cboLocPhong.DataSource = listLocPhong;
                cboLocPhong.DisplayMember = "TenPhong";
                cboLocPhong.ValueMember = "MaPhong";
                cboLocPhong.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi tải danh sách phòng trọ.");
                MessageBox.Show("Có lỗi xảy ra khi nạp danh sách phòng trọ!", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================= GỌI API ĐỊA CHÍNH (TASK 3 & 8) =======================
        private async Task LoadProvincesAsync()
        {
            lblTrangThai.Text = "Đang tải danh sách tỉnh/thành từ open-api.vn...";
            cboTinhThanh.Enabled = false;
            cboTinhThanh.Text = "Đang tải…";

            try
            {
                _provinces = await DiaChinhService.GetProvincesAsync(AppConfig.Settings.ProvincesApiUrl);

                cboTinhThanh.DataSource = _provinces;
                cboTinhThanh.DisplayMember = "name";
                cboTinhThanh.ValueMember = "code";
                cboTinhThanh.SelectedIndex = -1;

                // Nạp combobox lọc tỉnh
                var locTinhList = new List<ProvinceItem>
                {
                    new ProvinceItem { code = 0, name = "Tất cả" }
                };
                locTinhList.AddRange(_provinces);

                cboLocTinh.DataSource = locTinhList;
                cboLocTinh.DisplayMember = "name";
                cboLocTinh.ValueMember = "code";
                cboLocTinh.SelectedIndex = 0;

                lblTrangThai.Text = $"Đã tải {_provinces.Count} tỉnh/thành từ provinces.open-api.vn";
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException || ex is OperationCanceledException)
            {
                Log.Warning(ex, "Không thể kết nối đến API tỉnh/thành phố (mất mạng hoặc hết thời gian chờ).");
                MessageBox.Show("Không tải được danh sách địa chỉ, vui lòng kiểm tra mạng", "Thông báo mạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Cho phép gõ tay
                cboTinhThanh.DropDownStyle = ComboBoxStyle.DropDown;
                cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown;
                cboTinhThanh.Text = string.Empty;
                cboPhuongXa.Text = string.Empty;
                lblTrangThai.Text = "Mất kết nối mạng - Cho phép nhập tay Tỉnh/Thành và Phường/Xã";
            }
            finally
            {
                cboTinhThanh.Enabled = true;
            }
        }

        private async void cboTinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing) return;
            if (cboTinhThanh.SelectedValue is int code && code > 0)
            {
                await LoadWardsAsync(code);
            }
            else
            {
                cboPhuongXa.DataSource = null;
                cboPhuongXa.Items.Clear();
            }
        }

        private async Task LoadWardsAsync(int provinceCode, int? selectWardCode = null, string? manualWardName = null)
        {
            cboPhuongXa.Enabled = false;
            cboPhuongXa.Text = "Đang tải…";

            try
            {
                var wards = await DiaChinhService.GetWardsAsync(provinceCode, AppConfig.Settings.ProvincesApiUrl);
                cboPhuongXa.DataSource = wards;
                cboPhuongXa.DisplayMember = "name";
                cboPhuongXa.ValueMember = "code";

                if (selectWardCode.HasValue && selectWardCode.Value > 0)
                {
                    cboPhuongXa.SelectedValue = selectWardCode.Value;
                }
                else if (!string.IsNullOrWhiteSpace(manualWardName))
                {
                    cboPhuongXa.Text = manualWardName;
                }
                else
                {
                    cboPhuongXa.SelectedIndex = -1;
                }
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException || ex is OperationCanceledException)
            {
                Log.Warning(ex, "Không thể nạp danh sách phường/xã cho tỉnh mã {ProvinceCode}.", provinceCode);
                MessageBox.Show("Không tải được danh sách địa chỉ, vui lòng kiểm tra mạng", "Thông báo mạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown;
                cboPhuongXa.Text = manualWardName ?? string.Empty;
            }
            finally
            {
                cboPhuongXa.Enabled = true;
            }
        }

        // ======================= HIỂN THỊ DỮ LIỆU & TÌM KIẾM (TASK 5 & 6) =======================
        public async Task LoadDataAsync()
        {
            try
            {
                using var db = DbContextHelper.GetContext();

                string keyword = txtTimKiem.Text.Trim().ToLower();
                int filterPhongId = 0;
                if (cboLocPhong.SelectedValue is int pId) filterPhongId = pId;

                int filterTinhCode = 0;
                if (cboLocTinh.SelectedValue is int tCode) filterTinhCode = tCode;

                var query = from k in db.KhachThues
                            join p in db.PhongTros on k.MaPhong equals p.MaPhong
                            select new KhachThueViewModel
                            {
                                MaKhach = k.MaKhach,
                                HoTen = k.HoTen,
                                GioiTinh = k.GioiTinh,
                                NgaySinh = k.NgaySinh,
                                SoDienThoai = k.SoDienThoai,
                                MaPhong = k.MaPhong,
                                TenPhong = p.TenPhong,
                                GiaThue = p.GiaThue,
                                MaTinh = k.MaTinh,
                                TenTinh = k.TenTinh,
                                MaPhuongXa = k.MaPhuongXa,
                                TenPhuongXa = k.TenPhuongXa,
                                DaDangKyTamTru = k.DaDangKyTamTru
                            };

                // Lọc theo từ khóa họ tên hoặc SĐT
                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(x => x.HoTen.ToLower().Contains(keyword) || x.SoDienThoai.Contains(keyword));
                }

                // Lọc theo phòng
                if (filterPhongId > 0)
                {
                    query = query.Where(x => x.MaPhong == filterPhongId);
                }

                // Lọc theo tỉnh
                if (filterTinhCode > 0)
                {
                    query = query.Where(x => x.MaTinh == filterTinhCode);
                }

                var list = await query.OrderBy(x => x.TenPhong).ThenBy(x => x.HoTen).ToListAsync();
                dgvKhachThue.DataSource = list;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi truy vấn danh sách khách thuê.");
                MessageBox.Show("Có lỗi xảy ra khi nạp danh sách khách thuê từ CSDL!", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgvKhachThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvKhachThue.Rows.Count) return;

            if (dgvKhachThue.Rows[e.RowIndex].DataBoundItem is KhachThueViewModel item)
            {
                _selectedMaKhach = item.MaKhach;
                txtHoTen.Text = item.HoTen;

                if (string.Equals(item.GioiTinh, "Nữ", StringComparison.OrdinalIgnoreCase))
                    radNu.Checked = true;
                else
                    radNam.Checked = true;

                dtpNgaySinh.Value = item.NgaySinh.ToDateTime(TimeOnly.MinValue);
                txtSoDienThoai.Text = item.SoDienThoai;
                cboPhong.SelectedValue = item.MaPhong;
                chkTamTru.Checked = item.DaDangKyTamTru;

                // Xử lý tỉnh/thành & phường/xã
                if (item.MaTinh > 0 && _provinces.Any(p => p.code == item.MaTinh))
                {
                    _isInitializing = true;
                    cboTinhThanh.SelectedValue = item.MaTinh;
                    _isInitializing = false;
                    await LoadWardsAsync(item.MaTinh, item.MaPhuongXa, item.TenPhuongXa);
                }
                else
                {
                    cboTinhThanh.Text = item.TenTinh;
                    cboPhuongXa.Text = item.TenPhuongXa;
                }
            }
        }

        // ======================= THAO TÁC CRUD TRÊN NHIỀU BẢNG (TASK 4) =======================
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên khách thuê không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return false;
            }

            if (cboPhong.SelectedValue == null || (int)cboPhong.SelectedValue <= 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cho khách thuê!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhong.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboTinhThanh.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Tỉnh/Thành quê quán!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTinhThanh.Focus();
                return false;
            }

            return true;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using var db = DbContextHelper.GetContext();

                int maPhong = cboPhong.SelectedValue is int mp ? mp : 0;

                // Lấy thông tin Tỉnh/Thành
                int maTinh = 0;
                string tenTinh = cboTinhThanh.Text.Trim();
                if (cboTinhThanh.SelectedItem is ProvinceItem p)
                {
                    maTinh = p.code;
                    tenTinh = p.name;
                }

                // Lấy thông tin Phường/Xã
                int maPhuongXa = 0;
                string tenPhuongXa = cboPhuongXa.Text.Trim();
                if (cboPhuongXa.SelectedItem is WardItem w)
                {
                    maPhuongXa = w.code;
                    tenPhuongXa = w.name;
                }

                var khach = new KhachThue
                {
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = radNu.Checked ? "Nữ" : "Nam",
                    NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value.Date),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    MaPhong = maPhong,
                    MaTinh = maTinh,
                    TenTinh = tenTinh,
                    MaPhuongXa = maPhuongXa,
                    TenPhuongXa = tenPhuongXa,
                    DaDangKyTamTru = chkTamTru.Checked
                };

                db.KhachThues.Add(khach);

                // Khi thêm khách vào phòng thì phòng chuyển "Đang thuê"
                var phong = await db.PhongTros.FindAsync(maPhong);
                if (phong != null)
                {
                    phong.TinhTrang = "Đang thuê";
                }

                await db.SaveChangesAsync();

                Log.Information("Thêm khách thuê thành công: MaKhach = {MaKhach}, HoTen = {HoTen}, MaPhong = {MaPhong}",
                    khach.MaKhach, khach.HoTen, khach.MaPhong);
                MessageBox.Show("Thêm khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnLamMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi xảy ra khi thêm khách thuê mới.");
                MessageBox.Show("Có lỗi xảy ra khi thêm khách thuê vào CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaKhach <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách thuê cần sửa trên bảng danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                using var db = DbContextHelper.GetContext();
                var khach = await db.KhachThues.FindAsync(_selectedMaKhach);
                if (khach == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin khách thuê này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    await LoadDataAsync();
                    return;
                }

                int oldMaPhong = khach.MaPhong;
                int newMaPhong = cboPhong.SelectedValue is int nmp ? nmp : 0;

                // Cập nhật thông tin
                khach.HoTen = txtHoTen.Text.Trim();
                khach.GioiTinh = radNu.Checked ? "Nữ" : "Nam";
                khach.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value.Date);
                khach.SoDienThoai = txtSoDienThoai.Text.Trim();
                khach.MaPhong = newMaPhong;
                khach.DaDangKyTamTru = chkTamTru.Checked;

                if (cboTinhThanh.SelectedItem is ProvinceItem p)
                {
                    khach.MaTinh = p.code;
                    khach.TenTinh = p.name;
                }
                else
                {
                    khach.TenTinh = cboTinhThanh.Text.Trim();
                }

                if (cboPhuongXa.SelectedItem is WardItem w)
                {
                    khach.MaPhuongXa = w.code;
                    khach.TenPhuongXa = w.name;
                }
                else
                {
                    khach.TenPhuongXa = cboPhuongXa.Text.Trim();
                }

                // Nếu đổi phòng
                if (oldMaPhong != newMaPhong)
                {
                    // Phòng mới chuyển Đang thuê
                    var newPhong = await db.PhongTros.FindAsync(newMaPhong);
                    if (newPhong != null) newPhong.TinhTrang = "Đang thuê";

                    // Kiểm tra phòng cũ còn ai không
                    bool oldPhongHasOtherGuests = await db.KhachThues.AnyAsync(k => k.MaPhong == oldMaPhong && k.MaKhach != _selectedMaKhach);
                    if (!oldPhongHasOtherGuests)
                    {
                        var oldPhong = await db.PhongTros.FindAsync(oldMaPhong);
                        if (oldPhong != null) oldPhong.TinhTrang = "Trống";
                    }
                }

                await db.SaveChangesAsync();

                Log.Information("Cập nhật khách thuê thành công: MaKhach = {MaKhach}, HoTen = {HoTen}", _selectedMaKhach, khach.HoTen);
                MessageBox.Show("Cập nhật thông tin khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadPhongToCombobox();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi cập nhật khách thuê MaKhach = {MaKhach}", _selectedMaKhach);
                MessageBox.Show("Có lỗi xảy ra khi cập nhật dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaKhach <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách thuê cần xóa trên danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách thuê [{txtHoTen.Text}] không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog != DialogResult.Yes) return;

            try
            {
                using var db = DbContextHelper.GetContext();
                var khach = await db.KhachThues.FindAsync(_selectedMaKhach);
                if (khach != null)
                {
                    int maPhong = khach.MaPhong;
                    db.KhachThues.Remove(khach);
                    await db.SaveChangesAsync();

                    // Kiểm tra xem phòng còn người nào không
                    bool hasRemaining = await db.KhachThues.AnyAsync(k => k.MaPhong == maPhong);
                    if (!hasRemaining)
                    {
                        var phong = await db.PhongTros.FindAsync(maPhong);
                        if (phong != null)
                        {
                            phong.TinhTrang = "Trống";
                            await db.SaveChangesAsync();
                        }
                    }

                    Log.Information("Xóa khách thuê thành công: MaKhach = {MaKhach}", _selectedMaKhach);
                    MessageBox.Show("Đã xóa khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnLamMoi_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi xảy ra khi xóa khách thuê: MaKhach = {MaKhach}", _selectedMaKhach);
                MessageBox.Show("Không thể xóa khách thuê này khỏi CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            _selectedMaKhach = -1;
            txtHoTen.Clear();
            radNam.Checked = true;
            dtpNgaySinh.Value = new DateTime(2000, 1, 1);
            txtSoDienThoai.Clear();
            cboPhong.SelectedIndex = -1;
            cboTinhThanh.SelectedIndex = -1;
            cboPhuongXa.DataSource = null;
            cboPhuongXa.Items.Clear();
            chkTamTru.Checked = false;

            dgvKhachThue.ClearSelection();
            LoadPhongToCombobox();
            await LoadDataAsync();
        }

        // ======================= TÌM KIẾM & BỎ LỌC =======================
        private async void btnTim_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void btnBoLoc_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            if (cboLocPhong.Items.Count > 0) cboLocPhong.SelectedIndex = 0;
            if (cboLocTinh.Items.Count > 0) cboLocTinh.SelectedIndex = 0;
            await LoadDataAsync();
        }

        private async void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await LoadDataAsync();
            }
        }

        private async void cboLocPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isInitializing) await LoadDataAsync();
        }

        private async void cboLocTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isInitializing) await LoadDataAsync();
        }

        // ======================= KIỂM TRA LỖI TOÀN CỤC (TASK 7) =======================
        private void btnGayLoiThu_Click(object sender, EventArgs e)
        {
            // Ném lỗi cố ý để kích hoạt Application.ThreadException toàn cục
            throw new InvalidOperationException("Thử nghiệm lỗi chưa bắt (Global Unhandled Exception Test) cho Bài 2!");
        }
    }
}
