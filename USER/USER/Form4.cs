﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USER
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() == "Admin" && textBox2.Text.ToString() == "Admin")
            {

            }
            else
            {
                MessageBox.Show("Error,Incorrect Password!");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
