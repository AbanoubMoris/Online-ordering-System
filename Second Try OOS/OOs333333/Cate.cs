using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OOs333333
{
    public partial class Cate : UserControl
    {

        public Cate()
        {
            InitializeComponent();
        }


        public Cate (string Category) : this()
        {
            label1.Text = Category;
        }
       
        private void Cate_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            OpenFileDialog Of = new OpenFileDialog();
            Of.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (Of.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(Of.FileName);
            }


            Of.Dispose();

        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Orange;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Gray;
        }

     }
}
