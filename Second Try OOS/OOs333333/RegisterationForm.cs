using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                int c = 0;
        Boolean isUsernameValid = true;
        Boolean isPasswordValid = false;
        UserLogin login;

        public RegisterationForm()
        {
            InitializeComponent();
            login = new UserLogin(userName, userPassword,userAddress ,userEmail);
            readDataFromFile();
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
            StreamReader sr = new StreamReader("UserData.txt");

            while (!sr.EndOfStream)
            {
                userName.Add(sr.ReadLine());
                userEmail.Add(sr.ReadLine());
                userAddress.Add(sr.ReadLine());
                userPassword.Add(sr.ReadLine());
               
            }
            sr.Close();
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text=="Name")textBox1.Text = "";
        }
        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Email") textBox2.Text = "";
        }
        private void textBox3_MouseEnter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Address") textBox3.Text = "";
        }
        private void textBox4_MouseEnter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Password") textBox4.Text = "";
            else textBox4.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text == "") textBox1.Text = "Name";
        }
        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            if (textBox2.Text == "") textBox2.Text = "Email";
        }
        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
            if (textBox3.Text == "") textBox3.Text = "Address";
        }
        private void textBox4_MouseLeave(object sender, EventArgs e)
        {
            if (textBox4.Text == "") textBox4.Text = "Password";
        }
    }
}

