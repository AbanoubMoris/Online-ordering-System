﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace OOs333333
{
    public partial class RegisterationForm : Form
    {


        List<String> userName = new List<string>();
        List<String> userAddress = new List<string>();
        List<String> userEmail = new List<string>();
        List<String> userPassword = new List<string>();
        List<String> checkUserName = new List<string>();
        StreamReader sr = new StreamReader("UserData.txt");
        int c = 0;
        Boolean isUsernameValid = true;
        Boolean isPasswordValid = false;
        UserLogin login;

        public RegisterationForm()
        {
            InitializeComponent();
            readDataFromFile();
            login = new UserLogin(userName, userPassword,userAddress ,userEmail);
        }

        private void RegisterationForm_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            
            if (textBox4.Text.Count() >= 6)
            {
                isPasswordValid = true;
            }
            else
            {
                MessageBox.Show("Password is too weak!");
                isPasswordValid = false;
            }
            for (int i = 0; i < userName.Count(); i++)
            {
                if (textBox1.Text == userName[i])
                {
                    isUsernameValid = false;
                    break;
                }
                if (i == (userName.Count()) - 1)
                {
                    isUsernameValid = true;
                }
            }
            if (!isUsernameValid)
            {
                MessageBox.Show("Username is already taken!");
            }

            if (isPasswordValid && isUsernameValid)
            {
                saveDataToFile();
                login.Show();
                this.Hide();
            }


        }

        public void saveDataToFile()
        {
            StreamWriter sw = new StreamWriter("UserData.txt");
            userName.Add(textBox1.Text);
            userEmail.Add(textBox2.Text);
            userAddress.Add(textBox3.Text);
            userPassword.Add(textBox4.Text);
            
            for (int i = 0; i < userName.Count; i++)
            {
                sw.WriteLine(userName[i]);
                sw.WriteLine(userEmail[i]);
                sw.WriteLine(userAddress[i]);
                sw.WriteLine(userPassword[i]);
            }
            checkUserName = userName;
            sw.Close();
        }



        public void readDataFromFile()
        {
            while (!sr.EndOfStream)
            {
                userName.Add(sr.ReadLine());
                userEmail.Add(sr.ReadLine());
                userAddress.Add(sr.ReadLine());
                userPassword.Add(sr.ReadLine());
               
            }
            sr.Close();
        }

        
    }
}

