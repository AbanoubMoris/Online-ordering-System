using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOs333333
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() == "Admin" && textBox2.Text.ToString() == "Admin")
            {
                Form1 adminForm = new Form1();
                this.Hide();
                adminForm.Show();
            }
            else
            {
                MessageBox.Show("Error,Incorrect Password!");
            }
        }
        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text == "UserName") textBox1.Text = "";
        }
        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text == "") textBox1.Text = "UserName";
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password") textBox2.Text = "";
            else textBox2.PasswordChar = '*';
        }
        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            if (textBox2.Text == "") textBox2.Text = "Password";
        }



    }
}
