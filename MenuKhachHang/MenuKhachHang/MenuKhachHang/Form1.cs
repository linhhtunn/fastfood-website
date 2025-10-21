using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace MenuKhachHang
{
    public partial class Form1 : Form
    {
        int cartQty = 0;                // tổng số món
        decimal cartTotal = 0m;         // tổng tiền
        const decimal PRICE_FALLBACK = 50000m; // phòng khi Tag trống

        // (tuỳ chọn) đếm số lượng theo từng món
        readonly Dictionary<string, int> itemQty = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();
            UpdateCartLabel(); // "0 món - VND 0"
        }

 
        private void Form1_Load(object sender, EventArgs e)
        {
            ApplyFilter(null); // hiển thị tất cả lúc đầu
        }

        // CLICK CHUNG CHO TẤT CẢ NÚT GIỎ
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            // 1) GIÁ từ Tag (vd: "50000")
            decimal price = PRICE_FALLBACK;
            if (btn.Tag != null && decimal.TryParse(btn.Tag.ToString(), out var p))
                price = p;

            // 2) TÊN món: ưu tiên AccessibleDescription, rỗng thì lấy Name
            string name = string.IsNullOrWhiteSpace(btn.AccessibleDescription)
                            ? btn.Name
                            : btn.AccessibleDescription;

            // 3) Cộng theo món (tuỳ chọn)
            if (!itemQty.ContainsKey(name)) itemQty[name] = 0;
            itemQty[name]++;

            // 4) Cộng tổng
            cartQty++;
            cartTotal += price;

            UpdateCartLabel();
        }

        void UpdateCartLabel()
        {
            lblCart.Text = $"{cartQty} món - {FormatVnd(cartTotal)}";
        }

        static string FormatVnd(decimal money)
        {
            var vi = CultureInfo.GetCultureInfo("vi-VN");
            return $"VND {money.ToString("N0", vi)}";
        }

        // (tuỳ chọn) đệ quy lấy toàn bộ control con
        static IEnumerable<Control> GetAllControls(Control root)
        {
            foreach (Control c in root.Controls)
            {
                foreach (var child in GetAllControls(c))
                    yield return child;
                yield return c;
            }
        }
        // ===================== BỘ LỌC MÓN ĂN =====================

        // Hàm lọc theo loại
        private void ApplyFilter(string category)
        {
            foreach (Control card in flpMenu.Controls)
            {
                if (card is Panel)
                {
                    var tag = (card.Tag ?? "").ToString();
                    bool match = string.IsNullOrEmpty(category)
                                 || tag.Equals(category, StringComparison.OrdinalIgnoreCase);
                    card.Visible = match;
                }
            }

            SetActiveButtonStyle(category);
        }

        // Đổi màu nút đang chọn
        private void SetActiveButtonStyle(string category)
        {
            var buttons = new[] { btnAll, btnMonMy, btnMonBanh, btnDoCuon };

            foreach (var b in buttons)
            {
                b.BackColor = SystemColors.Control;
                b.ForeColor = Color.Black;
            }

            Button active = btnAll;
            if (string.Equals(category, "MonMy", StringComparison.OrdinalIgnoreCase)) active = btnMonMy;
            else if (string.Equals(category, "MonBanh", StringComparison.OrdinalIgnoreCase)) active = btnMonBanh;
            else if (string.Equals(category, "DoCuon", StringComparison.OrdinalIgnoreCase)) active = btnDoCuon;

            active.BackColor = Color.MediumSlateBlue;
            active.ForeColor = Color.White;
        }

        // Các handler Click cho 4 nút lọc
        private void btnAll_Click(object sender, EventArgs e) => ApplyFilter(null);
        private void btnMonMy_Click(object sender, EventArgs e) => ApplyFilter("MonMy");
        private void btnMonBanh_Click(object sender, EventArgs e) => ApplyFilter("MonBanh");
        private void btnDoCuon_Click(object sender, EventArgs e) => ApplyFilter("DoCuon");

        // ==== STUBS cho các event Designer đang gán ====
        // Paint
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void flowLayoutPanel5_Paint(object sender, PaintEventArgs e) { }

        // Mouse Enter/Leave (panel1 và panel2, pictureBox1, lblName đang dùng chung panel1_* )
        private void panel1_MouseEnter(object sender, EventArgs e) { }
        private void panel1_MouseLeave(object sender, EventArgs e) { }

        // Click các label
        private void label1_Click(object sender, EventArgs e) { }      // lblName.Click
        private void label1_Click_1(object sender, EventArgs e) { }    // label1.Click
        private void label2_Click(object sender, EventArgs e) { }      // lblCart.Click
        private void label5_Click(object sender, EventArgs e) { }      // label5.Click
        private void label7_Click(object sender, EventArgs e) { }      // label7.Click

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        // Giữ nguyên các handler hover/paint bạn đã có…
        // panel1_MouseEnter/MouseLeave, panel1_Paint, labelX_Click...
    }
}
