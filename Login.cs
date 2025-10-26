using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using MenuKhachHang;

namespace LOGINFORM
{
    


    public partial class Login : Form
    {

        string strCon = @"Data Source=DESKTOP-4H6V6E9\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True";
        SqlConnection sqlCon = null;
        public Login()      
        {
            InitializeComponent();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            AddButtonEffect();
            textBox4.UseSystemPasswordChar = false;
        }
        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Tên Đăng Nhập")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Tên Đăng Nhập";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Mật Khẩu")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
                textBox4.UseSystemPasswordChar = true;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Mật Khẩu";
                textBox4.ForeColor = Color.Gray;
                textBox4.UseSystemPasswordChar = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

                string username = textBox3.Text;
            string password = textBox4.Text;
            if (username == "" || username == "Tên Đăng Nhập" || password == "" || password == "Mật Khẩu")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.",
                            "Lỗi đăng nhập",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                return;
            }
            string user = "admin";
            string pass = "admin1";
            if (username == user && password == pass)
            {
                MessageBox.Show("Đăng nhập thành công!",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.",
                            "Lỗi đăng nhập",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            if(password.Length < 6)
            {
                MessageBox.Show("Mật khẩu cần ít nhất 6 ký tự",
                            "Lỗi đăng nhập",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                return;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.Show();
        }

       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.UseSystemPasswordChar = true;
            }
            else
            {
                textBox4.UseSystemPasswordChar =true;
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
        private void AddButtonEffect()
        {
            button2.BackColor = Color.Navy;
            button2.ForeColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            button2.MouseEnter += (s, e) =>
            {
                button2.BackColor = Color.RoyalBlue;
            };

            button2.MouseLeave += (s, e) =>
            {
                button2.BackColor = Color.Navy;
            };

            button2.MouseDown += (s, e) =>
            {
                button2.BackColor = Color.DodgerBlue;
            };

            button2.MouseUp += (s, e) =>
            {
                button2.BackColor = Color.RoyalBlue;
            };

            button3.BackColor = Color.Navy;
            button3.ForeColor = Color.White;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;


            button3.MouseEnter += (s, e) =>
            {
                button3.BackColor = Color.RoyalBlue;
            };

            button3.MouseLeave += (s, e) =>
            {
                button3.BackColor = Color.Navy;
            };

            button3.MouseDown += (s, e) =>
            {
                button3.BackColor = Color.DodgerBlue;
            };

            button3.MouseUp += (s, e) =>
            {
                button3.BackColor = Color.RoyalBlue;
            };
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ quản trị viên hoặc nhập email để khôi phục mật khẩu.",
                            "Quên mật khẩu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void label4_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Leave(object sender, EventArgs e)
        {

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

