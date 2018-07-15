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
        
    }
}
