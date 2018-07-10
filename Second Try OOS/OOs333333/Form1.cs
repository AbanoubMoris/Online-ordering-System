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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel2.AutoScroll = true;
            Form2 CMS = new Form2();
            //   this.Hide();
            CMS.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.Red;

        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
