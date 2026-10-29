using System;
using System.Data;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class MainForm : Form
    {
        private PhongBUS phongBUS = new PhongBUS();
        private KhachHangBUS khachHangBUS = new KhachHangBUS();
        private PhieuDatPhongBUS pdpBUS = new PhieuDatPhongBUS();
        private DichVuBUS dichVuBUS = new DichVuBUS();

        private DataTable dtPhong;

        public MainForm()
        {
            InitializeComponent();
            LoadDanhSachPhong();
            KhoiTaoBoLoc();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadDanhSachPhong()
        {
            try
            {
                dtPhong = phongBUS.GetDanhSachPhong();
                dgvPhong.DataSource = dtPhong;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void KhoiTaoBoLoc()
        {
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Tất cả");
            cbTrangThai.Items.Add("Trống");
            cbTrangThai.Items.Add("Đang ở");
            cbTrangThai.Items.Add("Đang dọn dẹp");
            cbTrangThai.SelectedIndex = 0;

            cbLoaiPhong.Items.Clear();
            cbLoaiPhong.Items.Add("Tất cả");
            cbLoaiPhong.Items.Add("Đơn");
            cbLoaiPhong.Items.Add("Đôi");
            cbLoaiPhong.Items.Add("VIP");
            cbLoaiPhong.SelectedIndex = 0;
        }

        private void ThucHienLoc()
        {
            if (dtPhong == null) return;

            string filterExpression = "";

            if (cbTrangThai.SelectedItem != null && cbTrangThai.SelectedItem.ToString() != "Tất cả")
            {
                filterExpression += $"TrangThai = '{cbTrangThai.SelectedItem.ToString()}'";
            }

            if (cbLoaiPhong.SelectedItem != null && cbLoaiPhong.SelectedItem.ToString() != "Tất cả")
            {
                if (filterExpression != "") filterExpression += " AND ";
                filterExpression += $"LoaiPhong = '{cbLoaiPhong.SelectedItem.ToString()}'";
            }

            if (!string.IsNullOrEmpty(txtTimLoaiPhong.Text) && txtTimLoaiPhong.Text != "Nhập tên phòng cần tìm")
            {
                if (filterExpression != "") filterExpression += " AND ";
                filterExpression += $"SoPhong LIKE '%{txtTimLoaiPhong.Text}%'";
            }

            DataView dv = new DataView(dtPhong);
            dv.RowFilter = filterExpression;
            dgvPhong.DataSource = dv;
        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThucHienLoc();
        }

        private void txtTimLoaiPhong_TextChanged(object sender, EventArgs e)
        {
            ThucHienLoc();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null || dgvPhong.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn một phòng trên danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string soPhong = dgvPhong.CurrentRow.Cells["SoPhong"].Value?.ToString();
            string trangThai = dgvPhong.CurrentRow.Cells["TrangThai"].Value?.ToString()?.Trim();

            if (string.IsNullOrEmpty(trangThai) || !trangThai.Equals("Trống", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Vui lòng chọn một phòng có trạng thái 'Trống' để nhận phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            MessageBox.Show($"Đã chọn thành công phòng {soPhong} để làm thủ tục nhận phòng!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGoiDichVu_Click(object sender, EventArgs e)
        {
            if (dgvPhong.SelectedRows.Count == 0) return;
            string soPhong = dgvPhong.SelectedRows[0].Cells["SoPhong"].Value.ToString();
            string trangThai = dgvPhong.SelectedRows[0].Cells["TrangThai"].Value.ToString();

            if (trangThai != "Đang ở")
            {
                MessageBox.Show("Chỉ có thể gọi dịch vụ cho phòng đang có khách ở!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhieu = pdpBUS.LayMaPhieuDangHoatDong(soPhong);
            if (maPhieu == -1)
            {
                MessageBox.Show("Không tìm thấy phiếu thuê phòng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maDVStr = Microsoft.VisualBasic.Interaction.InputBox("Nhập Mã dịch vụ muốn gọi (Ví dụ: 1, 2...):", "Gọi Dịch Vụ", "1");
            string soLuongStr = Microsoft.VisualBasic.Interaction.InputBox("Nhập Số lượng:", "Gọi Dịch Vụ", "1");

            if (int.TryParse(maDVStr, out int maDV) && int.TryParse(soLuongStr, out int soLuong))
            {
                bool kq = pdpBUS.ThemSuDungDichVu(maPhieu, maDV, soLuong);
                if (kq)
                    MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (dgvPhong.SelectedRows.Count == 0) return;
            string soPhong = dgvPhong.SelectedRows[0].Cells["SoPhong"].Value.ToString();
            string trangThai = dgvPhong.SelectedRows[0].Cells["TrangThai"].Value.ToString();

            if (trangThai != "Đang ở")
            {
                MessageBox.Show("Phòng này không có khách đang ở để Check-out!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhieu = pdpBUS.LayMaPhieuDangHoatDong(soPhong);
            if (maPhieu == -1) return;

            decimal giaTheoGio = Convert.ToDecimal(dgvPhong.SelectedRows[0].Cells["GiaTheoGio"].Value);

            string tongTienStr = Microsoft.VisualBasic.Interaction.InputBox("Nhập tổng số tiền thanh toán (Tiền phòng + Tiền dịch vụ):", "Thanh Toán Check-Out", "500000");

            if (decimal.TryParse(tongTienStr, out decimal tongTien))
            {
                bool kq = pdpBUS.CheckOut(maPhieu, soPhong, tongTien);
                if (kq)
                {
                    MessageBox.Show($"Check-out thành công!\nTổng tiền thanh toán: {tongTien:N0} VNĐ\nTrạng thái phòng đã chuyển sang: Đang dọn dẹp.", "Hóa Đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachPhong();
                }
                else
                {
                    MessageBox.Show("Thanh toán Check-out thất bại do lỗi Transaction!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }

        private void cbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThucHienLoc();
        }

        private void cbTrangThai_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ThucHienLoc();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDanhSachPhong();
        }
    }
}