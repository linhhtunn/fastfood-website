using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace MenuKhachHang
{
    public partial class CartItemControl : UserControl
    {
        // Event để Form1 bắt và trừ lại tổng khi xoá từng dòng
        public event EventHandler RemoveRequested;

        public CartItemControl()
        {
            InitializeComponent();
            this.Height = 48; // chiều cao dòng
        }

        // *** BẮT BUỘC có vì Designer đang gán this.Load += CartItemControl_Load
        private void CartItemControl_Load(object sender, EventArgs e)
        {
            // no-op
        }

        // ==== API công khai để Form1 set vào ====
        private string _itemName = "Tên món";
        public string ItemName
        {
            get => _itemName;
            set { _itemName = value; if (lblName != null) lblName.Text = value; }
        }

        private decimal _price = 0m;
        public decimal Price
        {
            get => _price;
            set { _price = value; if (lblPrice != null) lblPrice.Text = FormatVnd(value); }
        }

        public Image Thumbnail
        {
            get => pic?.Image;
            set { if (pic != null) pic.Image = value; }
        }

        // Nút thùng rác trong UserControl
        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveRequested?.Invoke(this, EventArgs.Empty);
        }

        // Helper format VND
        private static string FormatVnd(decimal money)
        {
            var vi = CultureInfo.GetCultureInfo("vi-VN");
            return $"VND {money.ToString("N0", vi)}";
        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }
    }
}
