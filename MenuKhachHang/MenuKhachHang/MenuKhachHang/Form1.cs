using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MenuKhachHang
{
    public partial class Form1 : Form
    {
        int cartQty = 0;
        decimal cartTotal = 0m;
        const decimal PRICE_FALLBACK = 50000m;

        readonly Dictionary<string, int> itemQty = new Dictionary<string, int>();

        // >>> ADD: label tổng (tìm tự động)
        Label _lblTotalAmount;


        //chuoiketnoi
        string connectionString = "Data Source=DESKTOP-12ACNU2\\SQLEXPRESS;Initial Catalog=QuanLiNhaHang;Integrated Security=True;Trust Server Certificate=True";

        public Form1()
        {
            InitializeComponent();
            UpdateCartLabel();

           //panel menu do an 
            pnlCart.Visible = false;
            pnlCart.BringToFront();

            lblCart.Cursor = Cursors.Hand;
            lblCart.Click -= lblCart_Click;
            lblCart.Click += lblCart_Click;

            this.Resize += (_, __) => { if (pnlCart.Visible) PositionCartPanel(); };

            // >>> ADD: tìm label tổng theo nhiều tên
            _lblTotalAmount =
                this.Controls.Find("lblTotalAmount", true).FirstOrDefault() as Label ??
                this.Controls.Find("lblTong", true).FirstOrDefault() as Label ??
                this.Controls.Find("lblCartTotal", true).FirstOrDefault() as Label ??
                this.Controls.Find("lblTotalValue", true).FirstOrDefault() as Label;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // gỡ mọi control được thả sẵn trong flpCart (dòng mẫu)
            flpCart.Controls.Clear();
            ketNoiDb();
        }

        private void ketNoiDb()
        {
            flpMenu.Controls.Clear();
            string sql = "SELECT MaMon, TenMon, Gia, MaLoai, SoLuong FROM MON_AN";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string ma = reader["MaMon"].ToString();
                        string ten = reader["TenMon"].ToString();
                        decimal gia = Convert.ToDecimal(reader["Gia"]);
                        string loai = reader["MaLoai"].ToString().Trim();
                        int soLuong = Convert.ToInt32(reader["SoLuong"]);
                        Panel theMon = new Panel()
                        {
                            Width = 200,
                            Height = 250,
                            BackColor = Color.White,
                            BorderStyle = BorderStyle.FixedSingle,
                            Tag = loai
                        };

                        PictureBox pic = new PictureBox()
                        {
                            ImageLocation = $"Images/{ma}.jpg", //hien tai chua co anh
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Dock = DockStyle.Top,
                            Height = 130
                        };

                        Label lblTen = new Label()
                        {
                            Text = ten,
                            Dock = DockStyle.Top,
                            Height = 35,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Segoe UI", 10, FontStyle.Bold)
                        };

                        Label lblGia = new Label()
                        {
                            Text = $"Giá: {gia:N0} đ",
                            Dock = DockStyle.Top,
                            Height = 25,
                            TextAlign = ContentAlignment.MiddleCenter
                        };

                        Label lblSoLuong = new Label()
                        {
                            Text = $"Còn lại: {soLuong}",
                            Dock = DockStyle.Top,
                            Height = 25,
                            TextAlign = ContentAlignment.MiddleCenter,
                            ForeColor = soLuong > 0 ? Color.DarkGreen : Color.Red
                        };

                        Button btnAdd = new Button()
                        {
                            Text = "Thêm vào giỏ",
                            Dock = DockStyle.Bottom,
                            Tag = gia,
                            AccessibleDescription = ten,
                            Enabled = soLuong > 0
                        };

                        btnAdd.Click += btnAddToCart_Click;

                        theMon.Controls.Add(btnAdd);
                        theMon.Controls.Add(lblSoLuong);
                        theMon.Controls.Add(lblGia);
                        theMon.Controls.Add(lblTen);
                        theMon.Controls.Add(pic);

                        flpMenu.Controls.Add(theMon);
                    }
                }
            }
        }

        // CLICK CHUNG CHO TẤT CẢ NÚT GIỎ
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            // 1) GIÁ
            decimal price = PRICE_FALLBACK;
            if (btn.Tag != null && decimal.TryParse(btn.Tag.ToString(), out var p))
                price = p;

            // 2) TÊN
            string name = string.IsNullOrWhiteSpace(btn.AccessibleDescription)
                            ? btn.Name
                            : btn.AccessibleDescription;

            // 3) ẢNH từ PictureBox trong cùng card
            Image thumb = GetCardImageFrom(btn);

            // 4) Cộng tổng
            if (!itemQty.ContainsKey(name)) itemQty[name] = 0;
            itemQty[name]++;

            cartQty++;
            cartTotal += price;

            // >>> ADD: tạo 1 dòng trong giỏ
            AddCartRow(name, price, thumb);

            UpdateCartLabel();
        }

        // >>> SỬA lại UpdateCartLabel để cập nhật cả label tổng
        void UpdateCartLabel()
        {
            lblCart.Text = $"{cartQty} món - {FormatVnd(cartTotal)}";

            // cập nhật dòng tổng ở panel giỏ nếu có
            if (_lblTotalAmount != null)
                _lblTotalAmount.Text = FormatVnd(cartTotal);
        }

        static string FormatVnd(decimal money)
        {
            var vi = CultureInfo.GetCultureInfo("vi-VN");
            return $"VND {money.ToString("N0", vi)}";
        }

        // ======= FILTER =======
        private void ApplyFilter(string category)
        {
            foreach (Control card in flpMenu.Controls)
            {
                if (card is Panel)
                {
                    var tag = (card.Tag ?? "").ToString().Trim();
                    bool match = string.IsNullOrEmpty(category)
                                 || tag.Equals(category, StringComparison.OrdinalIgnoreCase);
                    card.Visible = match;
                }
            }
            SetActiveButtonStyle(category);
        }

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

        private void btnAll_Click(object sender, EventArgs e) => ApplyFilter(null);
        private void btnMonMy_Click(object sender, EventArgs e) => ApplyFilter("LM01");
        private void btnMonBanh_Click(object sender, EventArgs e) => ApplyFilter("LM02");
        private void btnDoCuon_Click(object sender, EventArgs e) => ApplyFilter("LM03");

        // ======= STUBS CŨ (để khỏi lỗi) =======
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void flowLayoutPanel5_Paint(object sender, PaintEventArgs e) { }
        private void panel1_MouseEnter(object sender, EventArgs e) { }
        private void panel1_MouseLeave(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void panel1_Paint_1(object sender, PaintEventArgs e) { }
        private void cartItemControl1_Load(object sender, EventArgs e) { }

        // ========== HIỆN/ẨN PANEL GIỎ ==========
        private void PositionCartPanel()
        {
            var bottomRightScreen = lblCart.PointToScreen(new Point(lblCart.Width, lblCart.Height));
            var host = pnlCart.Parent ?? this;
            var p = host.PointToClient(bottomRightScreen);

            int x = p.X - pnlCart.Width;
            int y = p.Y + 6;

            x = Math.Max(0, Math.Min(x, host.ClientSize.Width - pnlCart.Width - 4));
            y = Math.Max(0, Math.Min(y, host.ClientSize.Height - pnlCart.Height - 4));

            pnlCart.Location = new Point(x, y);
            pnlCart.BringToFront();
        }

        private void lblCart_Click(object sender, EventArgs e)
        {
            UpdateCartLabel(); // ép cập nhật tổng mới nhất

            if (!pnlCart.Visible)
            {
                foreach (Control c in flpCart.Controls)
                    c.Width = flpCart.ClientSize.Width - 8;

                PositionCartPanel();
                pnlCart.Visible = true;
            }
            else pnlCart.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            flpCart.Controls.Clear();
            cartQty = 0;
            cartTotal = 0;
            itemQty.Clear();
            UpdateCartLabel();
            pnlCart.Visible = false;
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cartQty == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show($"Tổng cộng: {FormatVnd(cartTotal)} cho {cartQty} món.",
                "Thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnClear_Click(sender, e);
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            pnlCart.Visible = false;
        }

        // ========== LẤY ẢNH TỪ CARD ==========
        private Image GetCardImageFrom(Button btn)
        {
            Control card = btn;
            while (card != null && !(card is Panel)) card = card.Parent;
            if (card == null) card = btn.Parent;

            var pic = card.Controls.CastControlTree()
                                   .OfType<PictureBox>()
                                   .FirstOrDefault();
            return pic?.Image;
        }

        // ========== TẠO 1 DÒNG TRONG GIỎ ==========
        private void AddCartRow(string name, decimal price, Image thumb)
        {
            var row = new CartItemControl
            {
                ItemName = name,
                Price = price
            };
            if (thumb != null) row.Thumbnail = thumb;
            row.Width = flpCart.ClientSize.Width - 8;

            row.RemoveRequested += (s, e) =>
            {
                flpCart.Controls.Remove(row);
                cartQty = Math.Max(0, cartQty - 1);
                cartTotal = Math.Max(0, cartTotal - price);

                if (itemQty.ContainsKey(name))
                {
                    itemQty[name] = Math.Max(0, itemQty[name] - 1);
                    if (itemQty[name] == 0) itemQty.Remove(name);
                }

                UpdateCartLabel();
                if (cartQty == 0) pnlCart.Visible = false;
            };

            flpCart.Controls.Add(row);
            flpCart.ScrollControlIntoView(row);
        }
    }

    // ======= helper duyệt cây control =======
    static class ControlExtensions
    {
        public static IEnumerable<Control> CastControlTree(this Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                foreach (var child in c.Controls.CastControlTree())
                    yield return child;
                yield return c;
            }
        }
    }
}
