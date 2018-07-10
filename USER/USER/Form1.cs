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

namespace USER
{
    public partial class Form1 : Form
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


        public Form1()
        {
            InitializeComponent();
            readDataFromFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 login = new Form2(userName,userPassword,userEmail);
            if(textBox3.Text.Count()>=6)
            {
            isPasswordValid = true;
            }
            else
            {
            MessageBox.Show("Password is too weak!");
            isPasswordValid = false;
            }
            for(int i=0; i<userName.Count(); i++)
            {
                if(textBox1.Text == userName[i])
                {
                    isUsernameValid = false;
                    break;
                }
                if(i == (userName.Count())-1)
                {
                    isUsernameValid = true;
                }
            }
            if(!isUsernameValid)
            {
                MessageBox.Show("Username is already taken!");
            }

            if(isPasswordValid && isUsernameValid)
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
            userAddress.Add(textBox2.Text);
            userPassword.Add(textBox3.Text);
            userEmail.Add(textBox4.Text);
            for (int i = 0; i < userName.Count; i++)
            {
                sw.WriteLine(userName[i]);
                sw.WriteLine(userAddress[i]);
                sw.WriteLine(userPassword[i]);
                sw.WriteLine(userEmail[i]);
            }
            checkUserName = userName;
            sw.Close();
        }
        
        

        public void readDataFromFile()
        {
            while (!sr.EndOfStream)
            {
                userName.Add(sr.ReadLine());
                userAddress.Add(sr.ReadLine());
                userPassword.Add(sr.ReadLine());
                userEmail.Add(sr.ReadLine());
            }
            sr.Close();
        }

        
    }
}
