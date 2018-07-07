using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOs333333
{
    public partial class NameAndPrice : UserControl
    {
        public NameAndPrice()
        {
            InitializeComponent();
        }


        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }

        public NameAndPrice(ref string name ,ref string price) : this()
        {
            if (textBox1.Text == "" && textBox1.Text == "Name")
            {
                MessageBox.Show("Please Enter Product Name", "Alert");
            }

            if (textBox2.Text == "" && textBox2.Text == "Price")
            {
                MessageBox.Show("Please Enter Price of Product", "Alert");
            }
            else
            {
                name = textBox1.Text;
                price = textBox2.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox1.Text == "Name")
            {
                MessageBox.Show("Please Enter Product Name", "Alert");
            }

            if (textBox2.Text == "" && textBox2.Text == "Price")
            {
                MessageBox.Show("Please Enter Price of Product", "Alert");
            }
            else
            {
                MessageBox.Show("Test");
            }
        }
    }
}
