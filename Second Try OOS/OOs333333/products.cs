﻿using System;
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
    public partial class products : UserControl
    {
        public products()
        {
            InitializeComponent();
            //panel2.AutoScroll = true;
        }

    public Label LBLID {
            get { return label3; }
            set { label3 = value; }
            }

      public products (string LblName) : this()
        {
         //  label2.Text = LblName;
        }
     //   public products(string ProductName , string Price , Form Product) : this()
     //   {
     //       label2.Text = ProductName;
     //       label1.Text = Price;
     //       Product.Controls.Add(this);
     //       
     //   }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Of = new OpenFileDialog();
            Of.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (Of.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(Of.FileName);
            }


            Of.Dispose();
        }
    }
}