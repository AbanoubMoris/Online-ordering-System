﻿using System;
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
    public partial class UserLogin : Form
    {

        
        public List<String> userNAME, userPASS, userEmail,userAddress;

        public UserLogin(List<String> userName, List<String> userPass, List<String> userAdd, List<String> userE_Mail)
        {
            InitializeComponent();
            this.userNAME = userName;
            this.userPASS = userPass;
            this.userAddress = userAdd;
            this.userEmail = userE_Mail;

        }

        private void UserLogin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            checkDataIfValid();
        }
        

        Boolean Valid = false;


        public void checkDataIfValid()
        {
            int i = 0;
            for (i = 0; i < userNAME.Count; i++)
            {
                if (userNAME[i] == textBox4.Text && userPASS[i] == textBox3.Text)
                {
                    MessageBox.Show("Welcome " + userNAME[i] + "!");
                    Valid = true;
                    break;
                }
                else
                {
                    Valid = false;
                }
                i++;
            }
            if (!Valid)
            {
                MessageBox.Show("Wrong username or password! , Please try again.");
            }else
            {
                user User = new user(i);
                User.Text = userNAME[i];
                User.Show();
                this.Hide();
            }

        }
        private void textBox1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {

        }
        private void textBox2_MouseLeave(object sender, EventArgs e)
        {

        }

    }
}
