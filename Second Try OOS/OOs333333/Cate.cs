﻿using System;
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

        public Image Pic
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
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

        }
    

       

     }
}
