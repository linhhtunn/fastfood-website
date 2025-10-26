using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGINFORM
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            mk.UseSystemPasswordChar = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void username_Enter(object sender, EventArgs e)
        {
            if(username.Text == "Tên Đăng Ký")
            {
                username.Text = "";
                username.ForeColor = Color.Black;
            }
        }

        private void email_Enter(object sender, EventArgs e)
        {
            if(email.Text == "Email")
            {
                email.Text = "";
                email.ForeColor = Color.Black;
            }
        }

        private void mk_TextChanged(object sender, EventArgs e)
        {

        }

        private void mk_Enter(object sender, EventArgs e)
        {
            if(mk.Text == "Mật Khẩu")
            {
                mk.Text = "";
                mk.ForeColor = Color.Black;
                mk.UseSystemPasswordChar = true;
            }
        }

        private void sdt_Enter(object sender, EventArgs e)
        {
            if(sdt.Text == "Số Điện Thoại")
            {
                sdt.Text = "";
                sdt.ForeColor = Color.Black;
            }
        }

        private void username_Leave(object sender, EventArgs e)
        {
            if(username.Text == "")
            {
                username.Text = "Tên Đăng Ký";
                username.ForeColor = Color.Gray;
            }
        }

        private void email_Leave(object sender, EventArgs e)
        {
            if(email.Text == "")
            {
                email.Text = "Email";
                email.ForeColor = Color.Gray;
            }
        }

        private void mk_Leave(object sender, EventArgs e)
        {
            if(mk.Text == "")
            {
                mk.Text = "Mật Khẩu";
                mk.ForeColor = Color.Gray;
                mk.UseSystemPasswordChar = false;
            }
        }

        private void sdt_Leave(object sender, EventArgs e)
        {
            if(sdt.Text == "")
            {
                sdt.Text = "Số Điện Thoại";
                sdt.ForeColor = Color.Gray;
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {
            }

        private void button3_Click(object sender, EventArgs e)
        {
            string tenDangKy = username.Text.Trim();
            string userEmail = email.Text.Trim();
            string matkhau = mk.Text.Trim();
            string soDienThoai = sdt.Text.Trim();
            if (tenDangKy == "" || tenDangKy == "Tên Đăng Ký" ||
                userEmail == "" || userEmail == "Email" ||
                matkhau == "" || matkhau == "Mật Khẩu" ||
                soDienThoai == "" || soDienThoai == "Số Điện Thoại")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin còn thiếu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(userEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Vui lòng nhập đúng lại email", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(soDienThoai.Length < 10 || soDienThoai.Length > 11)
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!Regex.IsMatch(soDienThoai, @"^[0-9]+$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (matkhau.Length < 6)
            {
                MessageBox.Show("Mật khẩu cần ít nhất 6 ký tự", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Đăng ký Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Login Login=new Login();
            Login.Show();
        }
    }
}
