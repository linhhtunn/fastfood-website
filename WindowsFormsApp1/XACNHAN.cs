using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class XACNHAN : Form
    {
        private List<DonHangMoi> _donHangMoi; // danh sách đơn
        private List<DonHangMoi> _donHangDaXacNhan; // danh sách đơn đã xác nhận

        public XACNHAN()
        {
            InitializeComponent();

            _donHangMoi = new List<DonHangMoi>();
            _donHangDaXacNhan = new List<DonHangMoi>();

            // Chuyển ListBox sang chế độ cho phép tick nhiều dòng
            lstThongBao.SelectionMode = SelectionMode.MultiExtended;

            lstThongBao.Items.Add($"[{DateTime.Now:HH:mm}] Hệ thống: Sẵn sàng nhận đơn hàng mới");
        }

        // 🟢 Nhận đơn mới từ form thanh toán
        // 🟢 Nhận đơn mới từ form thanh toán
        public void ThemDonHangMoi(string tenKhachHang, string soDienThoai, string diaChi, decimal tongTien, string phuongThucThanhToan)
        {
            var donHang = new DonHangMoi
            {
                MaDonHang = "DH" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                TenKhachHang = tenKhachHang,
                SoDienThoai = soDienThoai,
                DiaChi = diaChi,
                TongTien = tongTien,
                ThoiGian = DateTime.Now,
                PhuongThucThanhToan = phuongThucThanhToan,
                DaXacNhan = false
            };

            _donHangMoi.Add(donHang);

            string thongBao = $"[{donHang.ThoiGian:HH:mm}] ĐƠN MỚI: {donHang.TenKhachHang} - {donHang.TongTien:N0}đ - {donHang.DiaChi} ({donHang.PhuongThucThanhToan})";
            lstThongBao.Items.Add(thongBao);
            lstThongBao.TopIndex = lstThongBao.Items.Count - 1;

            CapNhatThongKe();
            FlashWindow();
        }


        // 🟢 Cập nhật số lượng đơn chờ xác nhận
        private void CapNhatThongKe()
        {
            int choXacNhan = _donHangMoi.Count(d => !d.DaXacNhan);
            lblThongKe.Text = $"Đang chờ xác nhận: {choXacNhan} đơn";
        }

        private void FlashWindow()
        {
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            this.Activate();
        }

        // 🟢 Nút "Xác nhận đơn"
        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            if (lstThongBao.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 đơn để xác nhận!");
                return;
            }

            List<int> indices = lstThongBao.SelectedIndices.Cast<int>().ToList();
            indices.Sort();
            indices.Reverse(); // xóa từ cuối danh sách cho an toàn

            foreach (int index in indices)
            {
                // bỏ qua dòng hệ thống
                string text = lstThongBao.Items[index].ToString();
                if (!text.Contains("ĐƠN MỚI")) continue;

                var donHang = _donHangMoi.ElementAtOrDefault(index - 1); // -1 vì dòng đầu tiên là hệ thống
                if (donHang == null) continue;

                donHang.DaXacNhan = true;
                _donHangDaXacNhan.Add(donHang);

                lstThongBao.Items[index] = $"[{DateTime.Now:HH:mm}] ✅ ĐÃ XÁC NHẬN: {donHang.TenKhachHang} - {donHang.TongTien:N0}đ";
            }

            CapNhatThongKe();
        }

        //  Nút "Xóa thông báo"
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (lstThongBao.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thông báo để xóa!");
                return;
            }

            List<int> indices = lstThongBao.SelectedIndices.Cast<int>().ToList();
            indices.Sort();
            indices.Reverse();

            foreach (int index in indices)
            {
                if (index == 0) continue;
                if (index - 1 < _donHangMoi.Count)
                    _donHangMoi.RemoveAt(index - 1);
                lstThongBao.Items.RemoveAt(index);
            }

            CapNhatThongKe();
        }

        //Nút "Làm mới" — chỉ hiển thị lại đơn chưa xác nhận
        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            // 1️⃣ Xóa hoàn toàn danh sách hiện trên giao diện
            lstThongBao.Items.Clear();
            lstThongBao.Items.Add($"[{DateTime.Now:HH:mm}] Hệ thống: Làm mới danh sách đơn");

            //Loại bỏ hoàn toàn các đơn đã xác nhận khỏi danh sách chính
            _donHangMoi = _donHangMoi.Where(d => !d.DaXacNhan).ToList();

            //Hiển thị lại các đơn chưa xác nhận
            foreach (var donHang in _donHangMoi)
            {
                string thongBao = $"[{donHang.ThoiGian:HH:mm}] ĐƠN MỚI: {donHang.TenKhachHang} - {donHang.TongTien:N0}đ - {donHang.DiaChi}";
                lstThongBao.Items.Add(thongBao);
            }

            // 4️⃣ Cập nhật thống kê
            CapNhatThongKe();
        }


        public class DonHangMoi
        {
            public string MaDonHang { get; set; }
            public string TenKhachHang { get; set; }
            public string SoDienThoai { get; set; }
            public string DiaChi { get; set; }
            public decimal TongTien { get; set; }
            public DateTime ThoiGian { get; set; }
            public string PhuongThucThanhToan { get; set; } 
            public bool DaXacNhan { get; set; } 
        }
    }
}
