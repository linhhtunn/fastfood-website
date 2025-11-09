using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MenuKhachHang
{
    public partial class FrmThanhToan : Form
    {
        // ===== Model một dòng hàng =====
        public class CheckoutItem
        {
            public string TenMon { get; set; }
            public int SoLuong { get; set; }
            public decimal DonGia { get; set; }
            public decimal ThanhTien => SoLuong * DonGia;
        }

        // ===== Dữ liệu nhận từ Form1 =====
        private readonly List<CheckoutItem> _items;
        private readonly decimal _tong;

        // ===== Constructor NHẬN DỮ LIỆU =====
        public FrmThanhToan(List<CheckoutItem> items, decimal tong)
        {
            InitializeComponent();
            _items = items ?? new List<CheckoutItem>();
            _tong = tong;

            // Thiết lập vài thuộc tính khởi tạo UI (nếu bạn chưa set trong Designer)
            this.StartPosition = FormStartPosition.CenterParent;
            this.AcceptButton = btnXong; // nhớ đặt tên nút là btnXong trong Designer
        }

        // ===== Sự kiện Load: bind dữ liệu lên lưới & control =====
        private void FrmThanhToan_Load(object sender, EventArgs e)
        {
            // -- DataGridView: nếu bạn đặt tên dgvOrder trong Designer
            dgvOrder.AutoGenerateColumns = false;
            dgvOrder.Columns.Clear();

            dgvOrder.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Món",
                DataPropertyName = nameof(CheckoutItem.TenMon),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvOrder.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "SL",
                DataPropertyName = nameof(CheckoutItem.SoLuong),
                Width = 50
            });
            dgvOrder.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Đơn giá",
                DataPropertyName = nameof(CheckoutItem.DonGia),
                DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight },
                Width = 100
            });
            dgvOrder.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thành tiền",
                DataPropertyName = nameof(CheckoutItem.ThanhTien),
                DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight },
                Width = 120
            });

            dgvOrder.DataSource = _items;

            // Tổng cộng
            lblTongTien.Text = _tong.ToString("N0") + " đ"; // label tổng của bạn đặt tên lblTongTien

            // Danh sách quận mẫu (nếu chưa đổ)
            if (cboQuan.Items.Count == 0)
            {
                cboQuan.Items.AddRange(new object[] {
                    "Ba Đình","Hoàn Kiếm","Đống Đa","Hai Bà Trưng","Cầu Giấy","Thanh Xuân","Hà Đông"
                });
                cboQuan.SelectedIndex = 0;
            }

            // Mặc định hiển thị QR khi chọn chuyển khoản
            rdoChuyenKhoan.Checked = true;
            picQR.Visible = true;
        }

        // ===== Nút Xong: validate đơn giản rồi trả về OK =====
        private void btnXong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên.");
                txtHoTen.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ.");
                txtDiaChi.Focus(); return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ===== Toggle QR theo phương thức =====
        private void rdoChuyenKhoan_CheckedChanged(object sender, EventArgs e)
            => picQR.Visible = rdoChuyenKhoan.Checked;

        private void rdoTienMat_CheckedChanged(object sender, EventArgs e)
            => picQR.Visible = rdoChuyenKhoan.Checked;

        private void FrmThanhToan_Load_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void grbOrder_Enter(object sender, EventArgs e)
        {

        }
    }
}
